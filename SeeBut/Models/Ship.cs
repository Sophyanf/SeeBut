using SeeBut.Views;
using SeeBut.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SeeBut.Models
{
    internal class Ship
    {
        public int StartY { get; set; }
        public int StartX { get; set; }
        public int StartPozV_G { get; set; }
        public int SizeShip { get; set; }

        public Ship(int startY, int startX, int startPozV_G, int sizeShip)
        {
            StartY = startY;
            StartX = startX;
            StartPozV_G = startPozV_G;
            SizeShip = sizeShip;
        }
    }
}
