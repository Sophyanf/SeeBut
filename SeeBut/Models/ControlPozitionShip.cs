using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SeeBut.Models
{
    internal class ControlPozitionShip
    {
        public int startControlX { get; set; }
        public int startControlY { get; set; }
        public int SizeShip { get; set; }

        Ship ship;
        int step;
        int stepDown;
        Field field;



        public ControlPozitionShip (Ship ship, Field fieldGame) {
            this.ship = ship;
            startControlY = ship.StartY;
            startControlX = ship.StartX;
            SizeShip = ship.SizeShip; 
            field = fieldGame;
        }

        public bool VertControlPozitionShip ()
        {
            bool control = true;
            if (startControlY > 0) { startControlY -= 1; }
            if (startControlX > 0) { startControlX -= 1; }

            if (ship.StartX == 0 || ship.StartX == field.XLight-1) { step = 2; } else { step = 3; }
            if (ship.StartY == 0 || ship.StartY == field.YLight - SizeShip-1) { stepDown = SizeShip + 1; } else { stepDown = SizeShip + 2;  }

           
            for (int i = 0; i < stepDown; i++)
            {
                for (int j = 0; j < step; j++)
                {
                    if (field.FieldGame[startControlY + i, startControlX + j] != 0) { 
                        control = false;  break; }
                }
            }
            return control;
        }

        public bool GorizontControlPozitionShip()
        {
            if (startControlY > 0) { startControlY -= 1; }
            if (startControlX > 0) { startControlX -= 1; }

            bool control = true;
            if (startControlY == 0 || startControlY == field.YLight - 1) { stepDown = 2; } else { stepDown = 3; }
            if (startControlX == 0 || startControlX == field.XLight - SizeShip) { step = SizeShip + 1; } else { step = SizeShip + 2; }
            for (int i = 0; i < stepDown; i++)
            {
                for (int j = 0; j < step; j++)
                {
                    if (field.FieldGame[startControlY  + i, startControlX + j] == 'X') { 
                        control = false; break; }
                }
            }
            return control;
        }
    }
}
