using System;
using System.Collections.Generic;

namespace SPBitsy
{

    public interface IRenderSurface
    {
        
        void SetPixel(BitsyGame.Color color, int x, int y);
        void FillSurface(BitsyGame.Color color);
        void FillTile(BitsyGame.Color color, int x, int y);

    }

}
