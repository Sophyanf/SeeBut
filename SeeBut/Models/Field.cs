using SeeBut.Services;
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
        public List<Ship> ShipsList { get; set; } = new List<Ship> ();

        int startSize = 4;
        int startCountShips = 1;
        

        public Field()
        {
            FillField();
        }
        public void FillField()
        {
            int count = 0;
            for (int i = 0; i < startCountShips; i++)
            {
                count++;
                CreatShipService creatShipService = new CreatShipService(startSize, this);
                for (int j = 0; j < startSize; j++)
                {
                    switch (creatShipService.StartPozV_G)
                    {
                        case 0:
                            FieldGame[creatShipService.StartY + j, creatShipService.StartX] = count;
                            break;

                        case 1:
                            FieldGame[creatShipService.StartY, creatShipService.StartX + j] = count;
                            break;
                    }
                }
            }
             startCountShips++;
                startSize--;
            if (startSize>0) FillField();
        }
    }
}
