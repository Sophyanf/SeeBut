using SeeBut.Models;
using SeeBut.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SeeBut.Services
{
    internal class CreatShipService
    {
        public int StartY { get; set; }
        public int StartX { get; set; }
        public int StartPozV_G { get; set; }
        public int SizeShip { get; set; }
        Field field;

        public CreatShipService(int sizeShip, Field fieldGame)
        {
            field = fieldGame;
            SizeShip = sizeShip;
            creatShip();
        }

        private void randGenarationShip()
        {
            StartPozV_G = new Random().Next(0, 2);
            Thread.Sleep(10);
            switch (StartPozV_G)
            {
                case 0: //вертикальный
                    StartY = new Random().Next(0, 10 - SizeShip+1);
                    Thread.Sleep(10);
                    StartX = new Random().Next(0, 10);
                    Thread.Sleep(10);
                    break;

                case 1: //горизотальный
                    StartY = new Random().Next(0, 10);
                    Thread.Sleep(10);
                    StartX = new Random().Next(0, 10 - SizeShip+1);
                    Thread.Sleep(10);
                    break;
            }
        }

        private bool checkShip()
        {
            CheckCellsService checkCellsService = new CheckCellsService(this, field);
            return checkCellsService.ControlShip();
        }

        private void creatShip()
        {
            Thread.Sleep(10);
            randGenarationShip();
            if (!checkShip())
            {
                moveShip();
            }
            Ship ship = new Ship(StartY, StartX, StartPozV_G, SizeShip);   
            field.ShipsList.Add(ship);
        }

        private void moveShip()
        {
            int xMax = 10;
            int yMax = 10;

            int StartYStart = StartY;
            int StartXStart = StartX;

            StartX++;
            if (StartPozV_G == 0) { yMax -= SizeShip; }
            else { xMax -= SizeShip; }

            while (StartX < xMax)
            {
                if (checkShip()) return;
                StartX++;
            }
            StartX = StartXStart;
            while (StartX >= 0)
            {
                if (checkShip()) return;
                StartX--;
            }
            StartX = StartXStart;

            StartY++;
            while (StartY < yMax)
            {
                if (checkShip()) return;
                StartY++;
            }
            StartY = StartYStart;
            while (StartY >= 0)
            {
                if (checkShip()) return;
                StartY--;
            }
            StartY = StartYStart;

            MessageBox.Show("ERROR!! Невозможно установит корабль с координатами (" + StartYStart + ", " + StartXStart + ")");
            creatShip();
        }

        public override string ToString()
        {
            return "Размер: " + SizeShip + "Координаты: (" + StartY + ";" +StartX + ")";
        }
    }
}
