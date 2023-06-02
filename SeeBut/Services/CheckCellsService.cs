using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using SeeBut.Models;

namespace SeeBut.Services
{
    internal class CheckCellsService
    {
        int startControlX;
        int startControlY;
        int SizeShip;
        CreatShipService ship;
        int step;
        int stepDown;
        Field field;

        public CheckCellsService(CreatShipService ship, Field fieldGame)
        {
            this.ship = ship;
            startControlY = ship.StartY;
            startControlX = ship.StartX;
            SizeShip = ship.SizeShip;
            field = fieldGame;
        }

        public bool ControlShip()
        {
            bool control = true;
            if (startControlY > 0) { startControlY -= 1; }
            if (startControlX > 0) { startControlX -= 1; }

            StepsCount();

            for (int i = 0; i < stepDown; i++)
            {
                for (int j = 0; j < step; j++)
                {
                    if (field.FieldGame[startControlY + i, startControlX + j] != 0)
                    {
                        control = false; break;
                    }
                }
            }
            return control;
        }

        private void StepsCount()
        {
            switch (ship.StartPozV_G)
            {
                case 0: //вертикальный
                    if (ship.StartX == 0 || ship.StartX == field.XLight - 1) { step = 2; } else { step = 3; }
                    if (ship.StartY == 0 || ship.StartY == field.YLight - SizeShip ) { stepDown = SizeShip + 1; } else { stepDown = SizeShip + 2; }
                    break;

                case 1: //горизогтальный
                    if (ship.StartY == 0 || ship.StartY == field.YLight - 1) { stepDown = 2; } else { stepDown = 3; }
                    if (ship.StartX == 0 || ship.StartX == field.XLight - SizeShip) { step = SizeShip + 1; } else { step = SizeShip + 2; }
                    break;
            }
        }

    }
}
