using SeeBut.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SeeBut.Models
{
    internal class Field
    {
        public int XLight { get; set; } = 10;
        public int YLight { get; set; } = 10;
        public int[,] FieldGame { get; set; } = new int[10, 10];
        int startSize = 4;
        int startCountShips = 1;
        int count = 0;
        public List<Ship> CellsShips { get; set; } = new List<Ship> ();

        public MainWindow mainWindow { get; set; }

        public Field (MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }
        public void FillField()
        {
            
           
            for (int i = 0; i < startCountShips; i++)
            {
                count++;
                Ship ship = new Ship(startSize, this, mainWindow);
                for (int j = 0; j < startSize; j++)
                {
                    switch (ship.StartPozV_G)
                    {
                        case 0:
                            FieldGame[ship.StartY + j, ship.StartX] = count;
                            break;

                        case 1:
                            FieldGame[ship.StartY, ship.StartX + j] = count;
                            break;
                    }
                }
                AddShipsCell(ship);
            }
             startCountShips++;
                startSize--;
            if (startSize>0) FillField();
        }

      /*  public void fillF ()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    FieldGame[i, j] = '.';
                }
            }
        }*/
        private void AddShipsCell (Ship ship)
        {
            CellsShips.Add(ship);
          
        }

        public string ShowFieldText ()
        {
            string str = "";
            for (int i = 0; i < CellsShips.Count; i++)
            {
               str  += i + 1 + " - (" + CellsShips[i].StartY + ", " + CellsShips[i].StartX + Environment.NewLine;
            }

            return str;
        }
    }
}
