using System;
using System.Collections.Generic;
using System.Text;

namespace ToMarsOrExplode.Core
{
    public class Position
    {
        public int XPoint { get; set; }
        public int YPoint { get; set; }
        public string CardinalPoint { get; set; }

        public Position(int x, int y, string cardinalPoint)
        {
            XPoint = x;
            YPoint = y;
            CardinalPoint = cardinalPoint;
        }
    }
}
