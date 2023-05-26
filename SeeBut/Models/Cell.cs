using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeBut.Models
{
    internal class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Cell (int y, int x)
        {
            X = x;
            Y = y;
        }
    }
}
