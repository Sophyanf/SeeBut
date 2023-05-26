using SeeBut.Views;
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
        Field field;
        MainWindow mainWindow;
        public Ship (int sizeShip, Field fieldGame, MainWindow mainWind)
        {
            mainWindow = mainWind;
            field = fieldGame;
            SizeShip = sizeShip;
            creatShip();
        }

        private void randGenarationShip ()
        {
            //StartPozV_G = new Random().Next(0, 2);
            StartPozV_G = 0;
            Thread.Sleep(10);
            switch (StartPozV_G)
            {
                case 0: //вертикальный
                    StartY = new Random().Next(0, 10 - SizeShip);
                    Thread.Sleep(10);
                    StartX = new Random().Next(0, 10);
                    Thread.Sleep(10);
                    break;

                case 1: //горизогтальный
                    StartY = new Random().Next(0, 10);
                    Thread.Sleep(10);
                    StartX = new Random().Next(0, 10 - SizeShip);
                    Thread.Sleep(10);
                    break;
            }
        }

        private bool checkShip()
        {
            ControlPozitionShip controlPozitionShip = new ControlPozitionShip(this, field);
           bool rez = false;
            switch (StartPozV_G)
            {
                case 0: //вертикальный
                    rez = controlPozitionShip.VertControlPozitionShip();
                //    MessageBox.Show("VertShip");
                    break;

                case 1: //горизонтальный
                    rez = controlPozitionShip.GorizontControlPozitionShip();
                   // MessageBox.Show("GorShip");
                    break ;
            }
            return rez;
        }

        private void creatShip ()
        {
            Thread.Sleep(10);
            randGenarationShip();
            if ( !checkShip())
            {
               
                mainWindow.fillButtonShow();
                MessageBox.Show("Невозможно установит корабль с координатами (" + StartY + ", " + StartX + ")");
                Thread.Sleep(3000);
                moveShip();
            } else { MessageBox.Show(SizeShip.ToString()); }
        }

        private void moveShip ()
        {
            int xMax = 10;
            int yMax = 10;

            int StartYStart = StartY;
            int StartXStart = StartX;
            StartX++;

           if (StartPozV_G == 0) { yMax -= SizeShip;}
           else { xMax -= SizeShip; }

            while (StartX < xMax)
            {
                //MessageBox.Show("сдвиг вправо X= " + StartX);
                //mainWindow.fillButtonShow();
                //Thread.Sleep(1000);
                if (checkShip())
                {
                    return;
                }
                StartX++;
            }
            StartX = StartXStart;
            while (StartX >= 0)
            {
                //MessageBox.Show("сдвиг влево X= " + StartX);
               /* mainWindow.fillButtonShow();
                Thread.Sleep(1000);*/
                if (checkShip())
                {
                  
                    return;
                }
                 StartX--;
            }
            StartX = StartXStart;

            StartY++;
            while (StartY < yMax)
            {
                if (checkShip())
                {
                    return;
                }
                StartY++;
            }
            StartY = StartYStart;
            while (StartY >= 0)
            {if (StartX>0)
                {
                    return;
                }
                mainWindow.fillButtonShow();
                StartY--;
            }
            
            MessageBox.Show("ERROR!! Невозможно установит корабль с координатами (" + StartYStart + ", " + StartXStart + ")");
            creatShip();
        }
    }
}
