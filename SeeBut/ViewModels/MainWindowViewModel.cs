using SeeBut.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;

namespace SeeBut.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {

        public ActionCommand gunBut { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged; // с этим не разобралась, нужно ли мне это здесь. У нас в примере к этому свойству обращвлись из xaml

        public int getFieldValue { get; set; }

        private Field field;


        public MainWindowViewModel()
        {
            field = null;
            gunBut = new ActionCommand(x => GunCommand());
        }

        public void CreatGameField()
        {
            field = new Field();
        }
        public void GunCommand()
        {
            MessageBox.Show("Command");
        }

        public string GetFieldCell(int butNum)
        {
            int i = butNum/10;
            int j = butNum % 10;
            if (field.FieldGame[i, j] == 0) return "";
            else return field.FieldGame[i, j].ToString();
        }

        public string ShowFieldText()
        {
            string str = "";
            for (int i = 0; i < field.ShipsList.Count; i++)
            {
                str += i + 1 + " - (" + field.ShipsList[i].StartY + ", " + field.ShipsList[i].StartX + Environment.NewLine;
            }

            return str;
        }

        public void OnPropertyChanged(string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}

