using System;
using System.Collections;
using System.Collections.Generic;

namespace SPBitsy
{

    public class GfxTileSheet
    {
        public readonly int width;
        public readonly int height;
        public readonly int frameCount;
        private BitArray _pixels;

        #region CONSTRUCTOR

        public GfxTileSheet(int w, int h, int frameCount)
        {
            this.width = w;
            this.height = h;
            this.frameCount = frameCount;
            _pixels = new BitArray(w * h * frameCount);
        }

        public GfxTileSheet(int w, int h, int frameCount, params byte[] pixels)
        {
            this.width = w;
            this.height = h;
            this.frameCount = frameCount;
            _pixels = new BitArray(w * h * frameCount);
            this.SetPixels(pixels);
        }

        #endregion

        #region Properties

        public bool this[int x, int y]
        {
            get
            {
                int i = x + y * this.width;
                if (i < 0 || i >= _pixels.Length) return false;
                return _pixels[i];
            }
            set
            {
                int i = x + y * this.width;
                if (i < 0 || i >= _pixels.Length) return;
                _pixels[i] = value;
            }
        }

        #endregion

        #region Methods

        public void SetPixels(IEnumerable<bool> pixels)
        {
            int i = 0;
            foreach (var p in pixels)
            {
                if (i < _pixels.Length)
                    _pixels[i] = p;
                else
                    break;
                i++;
            }
        }

        public void SetPixels(params byte[] pixels)
        {
            int i = 0;
            foreach (var p in pixels)
            {
                if (i < _pixels.Length)
                    _pixels[i] = (p != 0);
                else
                    break;
                i++;
            }
        }
        
        public void Draw(int frame, int x, int y, BitsyGame.Color c, IRenderSurface context, int pixelScale = 1)
        {
            if (context == null) return;
            if (frame < 0 || frame >= frameCount) return;

            int offset = frame * width * height;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (_pixels[offset + j * width + i])
                    {
                        int px = x + i * pixelScale;
                        int py = y + j * pixelScale;
                        if (pixelScale == 1)
                        {
                            context.SetPixel(c, px, py);
                        }
                        else
                        {
                            for (int sx = 0; sx < pixelScale; sx++)
                            {
                                for (int sy = 0; sy < pixelScale; sy++)
                                {
                                    context.SetPixel(c, px + sx, py + sy);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static GfxTileSheet CreateStatic(int w, int h, params byte[] pixels)
        {
            var tile = new GfxTileSheet(w, h, 1);
            tile.SetPixels(pixels);
            return tile;
        }

        #endregion

    }

    public class SceneRenderer
    {

        #region Fields

        private Environment _env;
        
        #endregion

        #region CONSTRUCTOR

        public SceneRenderer(Environment environment)
        {
            if (environment == null) throw new System.ArgumentNullException("environment");
            _env = environment;
        }

        #endregion

        #region Methods

        public void DrawRoom(BitsyGame.Room room, IRenderSurface context)
        {
            var pal = _env.GetRoomPalette(room.Id);
            context.FillSurface(_env.GetCurrentPalette().Colors[0]);

            for(int i = 0; i < room.Tilemap.GetLength(0); i++)
            {
                for(int j = 0; j < room.Tilemap.GetLength(1); j++)
                {
                    string id = room.Tilemap[i, j];
                    if(id != BitsyGame.ID_DEFAULT)
                    {
                        BitsyGame.Tile tile;
                        if(_env.Tiles.TryGetValue(id, out tile))
                        {
                            this.DrawTile(tile.DrawId, tile.Anim.FrameIndex, i, j, pal.Colors[tile.Color], context);
                        }
                        else
                        {
                            id = BitsyGame.ID_DEFAULT;
                            room.Tilemap[i, j] = id;
                        }
                    }
                }
            }

            for(int i = 0; i < room.Items.Count; i++)
            {
                BitsyGame.Item item;
                if(_env.Items.TryGetValue(room.Items[i].Id, out item))
                {
                    this.DrawTile(item.DrawId, item.Anim.FrameIndex, room.Items[i].x, room.Items[i].y, pal.Colors[item.Color], context);
                }
            }

            foreach(var spr in _env.Sprites.Values)
            {
                if(spr.RoomId == room.Id)
                {
                    this.DrawTile(spr.DrawId, spr.Anim.FrameIndex, spr.x, spr.y, pal.Colors[spr.Color], context);
                }
            }
        }

        private void DrawTile(string drawId, int frame, int x, int y, BitsyGame.Color c, IRenderSurface context)
        {
            GfxTileSheet gfx;
            if (_env.ImageStore.TryGetValue(drawId, out gfx))
            {
                gfx.Draw(frame, x * BitsyGame.TILESIZE * BitsyGame.PIXEL_SCALE, y * BitsyGame.TILESIZE * BitsyGame.PIXEL_SCALE, c, context, BitsyGame.PIXEL_SCALE);
            }
        }
        
        public void FillTile(BitsyGame.Color color, int x, int y, IRenderSurface context)
        {
            if (context == null) return;

            for(int i = 0; i < BitsyGame.TILESIZE * BitsyGame.PIXEL_SCALE; i++)
            {
                for (int j = 0; j < BitsyGame.TILESIZE * BitsyGame.PIXEL_SCALE; j++)
                {
                    context.SetPixel(color, x + i, y + j);
                }
            }
        }

        #endregion

    }

    public class DialogRenderer
    {

        public event System.Action OnPageFinish;

        public const int TXTBOX_WIDTH = 104;
        public const int TXTBOX_HEIGHT = 8 + 4 + 2 + 5; //8 for text, 4 for top-bottom padding, 2 for line padding, 5 for arrow
        public const int TXTBOX_TOP_POS = 12;
        public const int TXTBOX_LEFT_POS = 12;
        public const int TXTBOX_BOTTOM_POS = BitsyGame.RENDERSIZE - TXTBOX_HEIGHT - 12;
        public const int CHARS_PER_ROW = 32;
        public const int ROWS_PER_PAGE = 2;

        #region Fields

        private Environment _env;
        private IRenderSurface _context;

        private bool _isCentered = false;
        private int _effectTimer;
        
        private GfxTileSheet _arrowData = GfxTileSheet.CreateStatic(5, 3, new byte[] {
            1,1,1,1,1,
            0,1,1,1,0,
            0,0,1,0,0
        });

        #endregion

        #region CONSTRUCTOR

        public DialogRenderer(Environment environment)
        {
            if (environment == null) throw new System.ArgumentNullException("environment");
            _env = environment;
        }

        #endregion

        #region Properties

        public bool IsCentered
        {
            get { return _isCentered; }
            set
            {
                _isCentered = value;
            }
        }

        #endregion

        #region Methods

        public void Draw(DialogBuffer buffer, int deltaTime, IRenderSurface context)
        {
            _effectTimer += deltaTime;
            _context = context;
            
            this.DrawTextboxBackground(buffer);
            
            buffer.ForeachActiveChar(this.DrawChar);

            if (buffer.CanContinue)
                this.DrawNextArrow();

            if (buffer.DidPageFinishThisFrame && this.OnPageFinish != null)
                this.OnPageFinish();

            _context = null;
        }
        
        public void Reset()
        {
            _effectTimer = 0;
        }


        

        private int GetYOrigin()
        {
            if (_isCentered)
            {
                //center
                return (BitsyGame.RENDERSIZE - TXTBOX_HEIGHT) / 2;
            }
            else if (_env.GetPlayer() != null && _env.GetPlayer().y < BitsyGame.MAPSIZE / 2)
            {
                //bottom
                return TXTBOX_BOTTOM_POS;
            }
            else
            {
                //top
                return TXTBOX_TOP_POS;
            }
        }

        private void DrawTextboxBackground(DialogBuffer buffer)
        {
            _context.FillArea(buffer.BackgroundColor, TXTBOX_LEFT_POS * BitsyGame.PIXEL_SCALE, this.GetYOrigin() * BitsyGame.PIXEL_SCALE,
                                                      TXTBOX_WIDTH * BitsyGame.PIXEL_SCALE, TXTBOX_HEIGHT * BitsyGame.PIXEL_SCALE);
        }

        private void DrawChar(DialogBuffer.Line ln, int row, int col)
        {
            var c = ln.chars[col];
            c.offsetX = 0f;
            c.offsetY = 0f;

            if (c.effect != null) c.effect(_env, ref c, _effectTimer, row, col);

            GfxTileSheet gfx;
            if(c.character > 0)
            {
                gfx = _env.Font.GetCharGfx(c.character);
                if (gfx != null)
                {
                    int top = 4 + (row * 2) + (row * 8 / 2) + (int)c.offsetY;
                    int left = 4 + (col * 6 / 2) + (int)c.offsetX;
                    //adjust into textbox
                    top = (this.GetYOrigin() + top) * BitsyGame.PIXEL_SCALE;
                    left = (TXTBOX_LEFT_POS + left) * BitsyGame.PIXEL_SCALE;

                    gfx.Draw(0, left, top, c.color, _context, BitsyGame.TEXT_SCALE);
                }
            }
            else if(c.drawId != null && _env.ImageStore.TryGetValue(c.drawId, out gfx) && gfx != null)
            {
                int top = 4 + (row * 2) + (row * 8 / 2) + (int)c.offsetY;
                int left = 4 + (col * 6 / 2) + (int)c.offsetX;
                //adjust into textbox
                top = (this.GetYOrigin() + top) * BitsyGame.PIXEL_SCALE;
                left = (TXTBOX_LEFT_POS + left) * BitsyGame.PIXEL_SCALE;

                gfx.Draw(0, left, top, c.color, _context, 1);
            }
        }

        private void DrawNextArrow()
        {
            const int TOP = TXTBOX_HEIGHT - 5;
            const int LEFT = TXTBOX_WIDTH - (5 + 4);

            _arrowData.Draw(0, (TXTBOX_LEFT_POS + LEFT) * BitsyGame.PIXEL_SCALE, (this.GetYOrigin() + TOP) * BitsyGame.PIXEL_SCALE, BitsyGame.Color.White, _context, BitsyGame.PIXEL_SCALE);
        }
        
        #endregion

    }

    public class DialogBuffer
    {

        public const int NEXT_CHAR_MAX_TIME = 50;

        #region Fields

        public BitsyGame.Color BackgroundColor = BitsyGame.Color.Black;
        public BitsyGame.Color DefaultTextColor = BitsyGame.Color.White;
        
        private List<Line> _lines = new List<Line>();
        private Dictionary<string, TextEffects.ApplyEffectCallback> _activeEffects = new Dictionary<string, TextEffects.ApplyEffectCallback>();
        private TextEffects.ApplyEffectCallback _activeEffectsFullDelegate;

        private int _nextCharTimer = 0;
        private int _charIndex = 0;
        private int _rowIndex = 0;
        private bool _isDialogReadyToContinue;

        #endregion

        #region Properties

        public bool IsActive
        {
            get { return _lines.Count > 0 && _rowIndex < _lines.Count; }
        }

        public bool CanContinue
        {
            get { return _isDialogReadyToContinue; }
        }

        public bool DidPageFinishThisFrame
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public void Update(int deltaTime)
        {
            this.DidPageFinishThisFrame = false;

            if (_isDialogReadyToContinue)
                return;

            _nextCharTimer += deltaTime;
            if(_nextCharTimer > NEXT_CHAR_MAX_TIME)
            {
                this.DoNextChar();
            }
        }

        public void Reset()
        {
            foreach (var ln in _lines)
            {
                this.ReleaseLine(ln);
            }
            _lines.Clear();
            _activeEffects.Clear();
            _activeEffectsFullDelegate = null;
            _nextCharTimer = 0;
            _charIndex = 0;
            _rowIndex = 0;
            _isDialogReadyToContinue = false;
        }

        public void AddDrawing(string drawingId, System.Action onFinish)
        {
            if (_lines.Count == 0) this.QueueLine();

            //get line
            Line ln = _lines[_lines.Count - 1];
            if (ln.length >= DialogRenderer.CHARS_PER_ROW)
            {
                ln = this.QueueLine();
            }
            
            ln.chars[ln.length] = new DialogChar()
            {
                drawId = drawingId,
                color = this.DefaultTextColor,
                effect = _activeEffectsFullDelegate,
                onPrint = onFinish
            };
            ln.length++;
        }

        public void AddText(string text, System.Action onFinish)
        {
            if (string.IsNullOrEmpty(text))
            {
                //empty text isn't really allowed... so make it a single space
                text = " ";
            }

            if (_lines.Count == 0) this.QueueLine();

            Line ln = null;
            int i = 0;
            while(i < text.Length)
            {
                ln = _lines[_lines.Count - 1];
                //if (ln.length > 0) ln.length++; //add a space if we're appending to an existing line.
                int offset = ln.length;

                int start = i;
                int avail = DialogRenderer.CHARS_PER_ROW - offset;
                int end = i + avail;
                if (end >= text.Length)
                {
                    //reach the end of the text, just fill it out
                    end = text.Length;
                    i = end;
                }
                else
                {
                    this.QueueLine(); //queue up a line to be used next loop

                    end = text.LastIndexOf(' ', end, avail);
                    if (end < 0)
                    {
                        if (avail < DialogRenderer.CHARS_PER_ROW)
                        {
                            //can't fit, so go to next line
                            continue;
                        }
                        else
                        {
                            //some mad man stuck a 32+ character string in, just print that shit
                            end = i + avail;
                        }
                    }
                    i = end + 1;
                }

                int len = end - start;
                ln.length += len;
                if (len > 0)
                {
                    for (int j = 0; j < len; j++)
                    {
                        ln.chars[j + offset].character = text[start + j];
                        ln.chars[j + offset].color = this.DefaultTextColor;
                        ln.chars[j + offset].effect = _activeEffectsFullDelegate;
                    }
                }
            }

            if (ln != null && ln.length > 0)
                ln.chars[ln.length - 1].onPrint = onFinish;

        }

        public void AddLinebreak()
        {
            this.QueueLine();
        }

        public bool Continue()
        {
            int pageIndex = (_rowIndex / DialogRenderer.ROWS_PER_PAGE);
            int pageCount = (_lines.Count + DialogRenderer.ROWS_PER_PAGE - 1) / DialogRenderer.ROWS_PER_PAGE; //this performs an int division of count / rowsPerPage, where the result rounds up instead of down
            if(pageIndex + 1 < pageCount)
            {
                pageIndex++;
                _rowIndex = pageIndex * DialogRenderer.ROWS_PER_PAGE;
                _charIndex = 0;
                _isDialogReadyToContinue = false;
                return true;
            }
            else
            {
                _rowIndex = _lines.Count; //at a row outside of bounds = inActive
                return false;
            }
        }

        public void Skip()
        {
            this.DidPageFinishThisFrame = false;
            if (_lines.Count == 0) return;

            int pageIndex = (_rowIndex / DialogRenderer.ROWS_PER_PAGE);
            int nextPageRowIndex = (pageIndex + 1) * DialogRenderer.ROWS_PER_PAGE;
            // add new characters until you get to the end of the current line of dialog
            while (_rowIndex < nextPageRowIndex)
            {
                this.DoNextChar();

                if (_isDialogReadyToContinue)
                {
                    //make sure to push the rowIndex past the end to break out of the loop
                    _rowIndex++;
                    _charIndex = 0;
                }
            }

            //set to end of page
            _rowIndex = Math.Min(nextPageRowIndex - 1, _lines.Count - 1);
            _charIndex = _lines[_rowIndex].length - 1;
            _isDialogReadyToContinue = true;
        }

        public void ForeachActiveChar(ForeachCharCallback handler)
        {
            int rowCnt = (_rowIndex % DialogRenderer.ROWS_PER_PAGE) + 1;
            int low = _rowIndex - (_rowIndex % DialogRenderer.ROWS_PER_PAGE);
            for(int i = 0; i < rowCnt; i++)
            {
                var ln = _lines[low + i];
                int cnt = ln.length;
                if ((low + i) == _rowIndex && cnt > _charIndex) cnt = _charIndex + 1;

                for(int j = 0; j < cnt; j++)
                {
                    handler(ln, i, j);
                }
            }
        }

        private void DoNextChar()
        {
            _nextCharTimer = 0;
            if (_rowIndex < 0) _rowIndex = 0;
            if (_rowIndex >= _lines.Count) return;

            int nr = _rowIndex + 1;
            int nc = _charIndex + 1;

            if(nc < _lines[_rowIndex].length)
            {
                _charIndex++;
            }
            else if(nr < _lines.Count && (nr % DialogRenderer.ROWS_PER_PAGE) != 0)
            {
                _rowIndex++;
                _charIndex = 0;
            }
            else
            {
                _isDialogReadyToContinue = true;
                this.DidPageFinishThisFrame = true;
            }
            
            if (_charIndex < _lines[_rowIndex].length && _lines[_rowIndex].chars[_charIndex].onPrint != null)
                _lines[_rowIndex].chars[_charIndex].onPrint();
        }

        #endregion

        #region Text Effect

        public bool HasTextEffect(string name)
        {
            if (name == null) return false;
            return _activeEffects.ContainsKey(name);
        }

        public void AddTextEffect(string name, TextEffects.ApplyEffectCallback fx)
        {
            if (name == null) return;

            TextEffects.ApplyEffectCallback d;
            if(_activeEffects.TryGetValue(name, out d))
            {
                _activeEffectsFullDelegate -= d;
            }
            _activeEffects[name] = fx;
            _activeEffectsFullDelegate += fx;
        }

        public void RemoveTextEffect(string name)
        {
            if (name == null) return;

            TextEffects.ApplyEffectCallback d;
            if (_activeEffects.TryGetValue(name, out d))
            {
                _activeEffectsFullDelegate -= d;
                _activeEffects.Remove(name);
            }
        }
        
        #endregion

        #region Line Cache

        private const int LINE_CACHE_SIZE = 10;
        private Stack<Line> _lineCache = new Stack<Line>();
        private Line QueueLine()
        {
            Line ln;
            if (_lineCache.Count > 0)
                ln = _lineCache.Pop();
            else
                ln = new Line();
            
            _lines.Add(ln);
            return ln;
        }

        private void ReleaseLine(Line ln)
        {
            if (_lineCache.Count >= LINE_CACHE_SIZE || ln == null) return;

            ln.length = 0;
            for(int i = 0; i < DialogRenderer.CHARS_PER_ROW; i++)
            {
                ln.chars[i].color = this.DefaultTextColor;
                ln.chars[i].offsetX = 0;
                ln.chars[i].offsetY = 0;
                ln.chars[i].character = default(char);
                ln.chars[i].drawId = null;
                ln.chars[i].effect = null;
                ln.chars[i].onPrint = null;
            }
            _lineCache.Push(ln);
        }

        #endregion

        #region Special Types

        public delegate void ForeachCharCallback(Line ln, int row, int col);

        public class Line
        {
            public readonly DialogChar[] chars = new DialogChar[DialogRenderer.CHARS_PER_ROW];
            public int length;
        }
        
        #endregion

    }

    public struct DialogChar
    {

        public BitsyGame.Color color;
        public float offsetX;
        public float offsetY;
        public TextEffects.ApplyEffectCallback effect;
        public System.Action onPrint;

        public char character;
        public string drawId;
    }

    public static class TextEffects
    {

        public static ApplyEffectCallback CreateEffectCallback(string id)
        {
            switch (id)
            {
                case ScriptInterpreter.FUNC_RBW:
                    return ApplyRbw;
                case ScriptInterpreter.FUNC_CLR1:
                    return ApplyClr1;
                case ScriptInterpreter.FUNC_CLR2:
                    return ApplyClr2;
                case ScriptInterpreter.FUNC_CLR3:
                    return ApplyClr3;
                case ScriptInterpreter.FUNC_WVY:
                    return ApplyWvy;
                case ScriptInterpreter.FUNC_SHK:
                    return ApplyShk;
                default:
                    return null;
            }
        }



        public static void ApplyEffect(string id, Environment env, ref DialogChar c, int time, int row, int col)
        {
            switch(id)
            {
                case ScriptInterpreter.FUNC_RBW:
                    ApplyRbw(env, ref c, time, row, col);
                    break;
                case ScriptInterpreter.FUNC_CLR1:
                    ApplyClr(env, ref c, time, row, col, 0);
                    break;
                case ScriptInterpreter.FUNC_CLR2:
                    ApplyClr(env, ref c, time, row, col, 1);
                    break;
                case ScriptInterpreter.FUNC_CLR3:
                    ApplyClr(env, ref c, time, row, col, 2);
                    break;
                case ScriptInterpreter.FUNC_WVY:
                    ApplyWvy(env, ref c, time, row, col);
                    break;
                case ScriptInterpreter.FUNC_SHK:
                    ApplyShk(env, ref c, time, row, col);
                    break;
            }
        }

        public static void ApplyRbw(Environment env, ref DialogChar c, int time, int row, int col)
        {
            var h = (float)Math.Abs(Math.Sin((time / 600d) - (col / 8d)));
            c.color = ColorUtil.HslToRGB(h, 1.0f, 0.5f);
        }

        public static void ApplyWvy(Environment env, ref DialogChar c, int time, int row, int col)
        {
            c.offsetY += (float)(Math.Sin((time / 250d) - (col / 2d)) * 4);
        }

        public static void ApplyShk(Environment env, ref DialogChar c, int time, int row, int col)
        {
            c.offsetY += (float)(
                         3d
                         * Math.Sin((time * 0.1d) - (col * 0.5d))
                         * Math.Cos((time * 0.3d) - (col * 0.2d))
                         * Math.Sin((time * 2.0d) - (col * 1.0d))
                         );
            c.offsetX += (float)(
                         3d
                         * Math.Cos((time * 0.1d) - (col * 1.0d))
                         * Math.Sin((time * 3.0d) - (col * 0.7d))
                         * Math.Cos((time * 0.2d) - (col * 0.3d))
                         );
        }

        public static void ApplyClr(Environment env, ref DialogChar c, int time, int row, int col, int paletteIndex)
        {
            if (paletteIndex < 0) return;
            var pal = env.GetCurrentPalette();
            if (pal != null && pal.Colors != null && paletteIndex < pal.Colors.Length)
            {
                c.color = pal.Colors[paletteIndex];
            }
        }

        public static void ApplyClr1(Environment env, ref DialogChar c, int time, int row, int col)
        {
            ApplyClr(env, ref c, time, row, col, 0);
        }

        public static void ApplyClr2(Environment env, ref DialogChar c, int time, int row, int col)
        {
            ApplyClr(env, ref c, time, row, col, 1);
        }

        public static void ApplyClr3(Environment env, ref DialogChar c, int time, int row, int col)
        {
            ApplyClr(env, ref c, time, row, col, 2);
        }


        public delegate void ApplyEffectCallback(Environment env, ref DialogChar c, int time, int row, int col);

    }

}
