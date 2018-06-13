using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace SPBitsy
{

    public class BitsyGameParser
    {

        public enum RoomFormats
        {
            Space,
            Comma
        }

        #region Fields

        private Environment _environment;
        private Dictionary<string, string> _variables;
        private Dictionary<string, BitsyGame.Loc> _spriteStartLocations;


        public const string FLAG_ROOMFORMAT = "ROOM_FORMAT";
        private Dictionary<string, int> _flags = new Dictionary<string, int>();

        #endregion


        public BitsyGameParser()
        {
            this.ResetFlags();
        }

        public Environment Parse(TextReader reader)
        {
            _environment = new Environment();
            _variables = new Dictionary<string, string>();
            _spriteStartLocations = new Dictionary<string, BitsyGame.Loc>();

            try
            {
                _environment.Title = reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line) || line[0] == '#') continue;

                    switch (GetLineArg(line, 0))
                    {
                        case "PAL":
                            this.ParsePalette(reader, line);
                            break;
                        case "ROOM":
                        case "SET":
                            this.ParseRoom(reader, line);
                            break;
                        case "TIL":
                            this.ParseTile(reader, line);
                            break;
                        case "SPR":
                            this.ParseSprite(reader, line);
                            break;
                        case "ITM":
                            this.ParseItem(reader, line);
                            break;
                        case "DRW":
                            this.ParseDrawing(reader, line);
                            break;
                        case "DLG":
                            this.ParseDialog(reader, line);
                            break;
                        case "END":
                            this.ParseEnding(reader, line);
                            break;
                        case "VAR":
                            this.ParseVariable(reader, line);
                            break;
                        case "!":
                            this.ParseFlag(reader, line);
                            break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new System.FormatException("Failed to parse world data, malformed.", ex);
            }

            this.InitializeSprites();

            this.InitializeVariables();

            var result = _environment;
            this.Cleanup();
            return result;
        }

        #region Parse Entries

        private void ParsePalette(TextReader reader, string header)
        {
            string id = GetLineArg(header, 1);

            string name = null;
            List<BitsyGame.Color> colors = new List<BitsyGame.Color>();

            string line;
            while (!string.IsNullOrEmpty(line = reader.ReadLine()))
            {
                if (line.StartsWith("NAME"))
                {
                    name = line.Substring(5);
                }
                else
                {
                    var arr = line.Split(',');
                    colors.Add(new BitsyGame.Color(byte.Parse(arr[0]), byte.Parse(arr[1]), byte.Parse(arr[2])));
                }
            }

            if (string.IsNullOrEmpty(id)) return;
            _environment.Palettes[id] = new BitsyGame.Palette()
            {
                Id = id,
                Name = name,
                Colors = colors.ToArray()
            };
        }

        private void ParseRoom(TextReader reader, string header)
        {
            var room = new BitsyGame.Room()
            {
                Id = GetLineArg(header, 1),
                Walls = Utils.Empty<string>()
            };
            List<BitsyGame.Loc> items = new List<BitsyGame.Loc>();
            List<BitsyGame.Loc> endings = new List<BitsyGame.Loc>();
            List<BitsyGame.Exit> exits = new List<BitsyGame.Exit>();

            string line;
            switch ((RoomFormats)_flags[FLAG_ROOMFORMAT])
            {
                case RoomFormats.Space:
                    {
                        room.Tilemap = new string[BitsyGame.MAPSIZE, BitsyGame.MAPSIZE];
                        for (int i = 0; i < BitsyGame.MAPSIZE; i++)
                        {
                            line = reader.ReadLine();
                            for (int j = 0; j < BitsyGame.MAPSIZE; j++)
                            {
                                room.Tilemap[i, j] = line[j].ToString();
                            }
                        }
                    }
                    break;
                case RoomFormats.Comma:
                    {
                        room.Tilemap = new string[BitsyGame.MAPSIZE, BitsyGame.MAPSIZE];
                        for (int j = 0; j < BitsyGame.MAPSIZE; j++)
                        {
                            var lines = reader.ReadLine().Split(',');
                            for (int i = 0; i < BitsyGame.MAPSIZE; i++)
                            {
                                room.Tilemap[i, j] = lines[i];
                            }
                        }
                    }
                    break;
            }

            while (!string.IsNullOrEmpty(line = reader.ReadLine()))
            {
                switch (GetLineArg(line, 0))
                {
                    case "NAME":
                        room.Name = line.Substring(5);
                        break;
                    case "SPR":
                        {
                            string sid = GetLineArg(line, 1);
                            string[] args;
                            if (sid.IndexOf(',') < 0 && (args = line.Split(' ')).Length >= 3)
                            {
                                var coords = args[2].Split(',');
                                this._spriteStartLocations[sid] = new BitsyGame.Loc()
                                {
                                    Id = room.Id,
                                    x = int.Parse(coords[0]),
                                    y = int.Parse(coords[1])
                                };
                            }
                            else if ((RoomFormats)_flags[FLAG_ROOMFORMAT] == RoomFormats.Space)
                            {
                                var arr = sid.Split(',');
                                for (int i = 0; i < BitsyGame.MAPSIZE; i++)
                                {
                                    foreach (var s in arr)
                                    {
                                        int j = Utils.IndexOfInRow(room.Tilemap, i, s);
                                        if (j >= 0)
                                        {
                                            room.Tilemap[i, j] = "0";
                                            this._spriteStartLocations[s] = new BitsyGame.Loc()
                                            {
                                                Id = room.Id,
                                                x = j,
                                                y = i
                                            };
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "ITM":
                        {
                            var coords = GetLineArg(line, 2).Split(',');
                            items.Add(new BitsyGame.Loc()
                            {
                                Id = GetLineArg(line, 1),
                                x = int.Parse(coords[0]),
                                y = int.Parse(coords[1])
                            });
                        }
                        break;
                    case "WAL":
                        room.Walls = GetLineArg(line, 1).Split(',');
                        break;
                    case "EXT":
                        {
                            var args = line.Split(' ');
                            var exitCoords = args[1].Split(',');
                            var destCoords = args[3].Split(',');
                            exits.Add(new BitsyGame.Exit()
                            {
                                x = int.Parse(exitCoords[0]),
                                y = int.Parse(exitCoords[1]),
                                Destination = new BitsyGame.Loc()
                                {
                                    Id = args[2],
                                    x = int.Parse(destCoords[0]),
                                    y = int.Parse(destCoords[1])
                                }
                            });
                        }
                        break;
                    case "END":
                        {
                            var coords = GetLineArg(line, 2).Split(',');
                            endings.Add(new BitsyGame.Loc()
                            {
                                Id = GetLineArg(line, 1),
                                x = int.Parse(coords[0]),
                                y = int.Parse(coords[1])
                            });
                        }
                        break;
                    case "PAL":
                        room.Palette = GetLineArg(line, 1);
                        break;
                }
            }

            if (string.IsNullOrEmpty(room.Id)) return;
            room.Items = items;
            room.Endings = endings.ToArray();
            room.Exits = exits.ToArray();
            _environment.Rooms[room.Id] = room;
            if (!string.IsNullOrEmpty(room.Name)) _environment.Names.rooms[room.Name] = room.Id;
        }

        private void ParseTile(TextReader reader, string header)
        {
            var tile = new BitsyGame.Tile()
            {
                Id = GetLineArg(header, 1),
                Color = 1 //default palette color index is 1
            };

            string line;
            if (reader.Peek() >= 0 && ((char)reader.Peek()) == 'D')
            {
                tile.DrawId = GetLineArg(reader.ReadLine(), 1);
            }
            else
            {
                tile.DrawId = "TIL_" + tile.Id;
                this.ParseDrawingCore(reader, tile.DrawId);
            }
            tile.Anim.FrameCount = _environment.ImageStore[tile.DrawId].frameCount;
            tile.Anim.FrameIndex = 0;
            tile.Anim.IsAnimated = tile.Anim.FrameCount > 1;


            while (!string.IsNullOrEmpty(line = reader.ReadLine()))
            {
                switch (GetLineArg(line, 0))
                {
                    case "NAME":
                        tile.Name = line.Substring(5);
                        break;
                    case "COL":
                        tile.Color = int.Parse(GetLineArg(line, 1));
                        break;
                    case "WAL":
                        {
                            var isWall = GetLineArg(line, 1);
                            if (isWall == "true")
                                tile.IsWall = true;
                            else if (isWall == "false")
                                tile.IsWall = false;
                        }
                        break;
                }
            }

            if (string.IsNullOrEmpty(tile.Id)) return;
            _environment.Tiles[tile.Id] = tile;
            if (!string.IsNullOrEmpty(tile.Name)) _environment.Names.tiles[tile.Name] = tile.Id;
        }

        private void ParseSprite(TextReader reader, string header)
        {
            var sprite = new BitsyGame.Sprite()
            {
                Id = GetLineArg(header, 1),
                Color = 2 //default palette color index is 2
            };

            string line;
            if (reader.Peek() >= 0 && ((char)reader.Peek()) == 'D')
            {
                sprite.DrawId = GetLineArg(reader.ReadLine(), 1);
            }
            else
            {
                sprite.DrawId = "SPR_" + sprite.Id;
                this.ParseDrawingCore(reader, sprite.DrawId);
            }
            sprite.Anim.FrameCount = _environment.ImageStore[sprite.DrawId].frameCount;
            sprite.Anim.FrameIndex = 0;
            sprite.Anim.IsAnimated = sprite.Anim.FrameCount > 1;

            while (!string.IsNullOrEmpty(line = reader.ReadLine()))
            {
                switch (GetLineArg(line, 0))
                {
                    case "NAME":
                        sprite.Name = line.Substring(5);
                        break;
                    case "COL":
                        sprite.Color = int.Parse(GetLineArg(line, 1));
                        break;
                    case "POS":
                        {
                            var args = line.Split(' ');
                            var coords = args[2].Split(',');
                            this._spriteStartLocations[sprite.Id] = new BitsyGame.Loc()
                            {
                                Id = args[1], //roomid
                                x = int.Parse(coords[0]),
                                y = int.Parse(coords[1])
                            };
                        }
                        break;
                    case "DLG":
                        sprite.DialogId = GetLineArg(line, 1);
                        break;
                    case "ITM":
                        {
                            string item = GetLineArg(line, 1);
                            float cnt = float.Parse(GetLineArg(line, 2));
                            sprite.Inventory[item] = cnt;
                        }
                        break;
                }
            }

            if (string.IsNullOrEmpty(sprite.Id)) return;
            _environment.Sprites[sprite.Id] = sprite;
            if (!string.IsNullOrEmpty(sprite.Name)) _environment.Names.sprites[sprite.Name] = sprite.Id;
        }

        private void ParseItem(TextReader reader, string header)
        {
            var item = new BitsyGame.Item()
            {
                Id = GetLineArg(header, 1),
                Color = 2 //default palette color index is 2
            };

            string line;
            if (reader.Peek() >= 0 && ((char)reader.Peek()) == 'D')
            {
                item.DrawId = GetLineArg(reader.ReadLine(), 1);
            }
            else
            {
                item.DrawId = "ITM_" + item.Id;
                this.ParseDrawingCore(reader, item.DrawId);
            }
            item.Anim.FrameCount = _environment.ImageStore[item.DrawId].frameCount;
            item.Anim.FrameIndex = 0;
            item.Anim.IsAnimated = item.Anim.FrameCount > 1;

            while (!string.IsNullOrEmpty(line = reader.ReadLine()))
            {
                switch (GetLineArg(line, 0))
                {
                    case "NAME":
                        item.Name = line.Substring(5);
                        break;
                    case "COL":
                        item.Color = int.Parse(GetLineArg(line, 1));
                        break;
                    case "DLG":
                        item.DialogId = GetLineArg(line, 1);
                        break;
                }
            }

            if (string.IsNullOrEmpty(item.Id)) return;
            _environment.Items[item.Id] = item;
            if (!string.IsNullOrEmpty(item.Name)) _environment.Names.items[item.Name] = item.Id;
        }

        private void ParseDrawing(TextReader reader, string header)
        {
            this.ParseDrawingCore(reader, GetLineArg(header, 1));
        }

        private void ParseDrawingCore(TextReader reader, string drawId)
        {
            var lst = new List<bool>();
            string line;
            int frameCount = 1;

            loop:
            for (int i = 0; i < BitsyGame.TILESIZE; i++)
            {
                line = reader.ReadLine();
                for (int j = 0; j < 8; j++)
                {
                    lst.Add(line[j] != '0');
                }
            }
            if (reader.Peek() >= 0 && ((char)reader.Peek() == '>'))
            {
                reader.ReadLine();
                frameCount++;
                goto loop;
            }

            var gfx = new BitsyGame.GfxTileSheet(BitsyGame.TILESIZE, BitsyGame.TILESIZE, frameCount);
            gfx.SetPixels(lst);
            _environment.ImageStore[drawId] = gfx;
        }

        private void ParseDialog(TextReader reader, string header)
        {
            string id = GetLineArg(header, 1);

            string line = reader.ReadLine();
            if (line == Sym.DialogOpen)
            {
                var builder = Utils.GetTempStringBuilder();
                builder.AppendLine(line);
                while (true)
                {
                    line = reader.ReadLine();
                    if (line == null) throw new System.InvalidOperationException("End of file.");

                    builder.AppendLine(line);
                    if (line == Sym.DialogClose) break;
                }
                _environment.Dialog[id] = Utils.Release(builder);
            }
            else
            {
                _environment.Dialog[id] = line;
            }
        }

        private void ParseEnding(TextReader reader, string header)
        {
            string id = GetLineArg(header, 1);
            string val = reader.ReadLine();
            _environment.Endings[id] = val;
        }

        private void ParseVariable(TextReader reader, string header)
        {
            string id = GetLineArg(header, 1);
            string val = reader.ReadLine();
            this._variables[id] = val;
        }

        private void ParseFlag(TextReader reader, string header)
        {
            string id = GetLineArg(header, 1);
            string val = GetLineArg(header, 2);
            _flags[id] = int.Parse(val);
        }

        private void ResetFlags()
        {
            _flags.Clear();
            _flags[FLAG_ROOMFORMAT] = (int)RoomFormats.Space;
        }

        private static string GetLineArg(string line, int index)
        {
            int start = 0;
            int j = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ' ')
                {
                    if (index == j)
                    {
                        return line.Substring(start, i - start);
                    }
                    else
                    {
                        start = i + 1;
                        j++;
                    }
                }
            }

            if (index == j && start < line.Length)
            {
                return line.Substring(start);
            }
            return null;
        }

        #endregion

        #region Post Setup

        private void InitializeSprites()
        {
            foreach (var pair in _spriteStartLocations)
            {
                BitsyGame.Sprite spr;
                if (_environment.Sprites.TryGetValue(pair.Key, out spr))
                {
                    spr.RoomId = pair.Value.Id;
                    spr.x = pair.Value.x;
                    spr.y = pair.Value.y;
                }
            }

        }

        private void InitializeVariables()
        {
            foreach (var pair in _variables)
            {
                if (pair.Value == "true")
                    _environment.SetVariable(pair.Key, true);
                else if (pair.Value == "false")
                    _environment.SetVariable(pair.Key, false);
                else
                {
                    float v;
                    if (float.TryParse(pair.Value, out v))
                        _environment.SetVariable(pair.Key, v);
                    else
                        _environment.SetVariable(pair.Key, pair.Value);
                }
            }
        }

        #endregion

        #region Cleanup

        private void Cleanup()
        {
            _environment = null;
            _variables = null;
            _spriteStartLocations = null;
        }

        #endregion

    }

}
