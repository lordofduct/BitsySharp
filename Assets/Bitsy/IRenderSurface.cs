using System;
using System.Collections.Generic;

namespace SPBitsy
{

    /// <summary>
    /// Represents a drawable surface.
    /// 
    /// We draw from (0,0) being the top left corner.
    /// </summary>
    public interface IRenderSurface
    {
        
        void SetPixel(BitsyGame.Color color, int x, int y);
        void FillSurface(BitsyGame.Color color);
        
    }

}
