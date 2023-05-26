using SeeBut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SeeBut.Views

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Field field;
        public MainWindow()
        {
            InitializeComponent();
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("Кнопка нажата");
            fillButton();
        }

        public void fillButton()
        {
            field = new Field(this);
            field.FillField();
            fillButtonShow();
            
        }

        public void fillButtonShow()
        {
            if (uniformGrid1.Children.Count != 0)
            {
                uniformGrid1.Children.Clear();
            }
            for (int i = 0; i < field.YLight; i++)
                for (int j = 0; j < field.XLight; j++)
                {
                    Button button = new Button();
                    button.Content = field.FieldGame[i, j].ToString();
                    if (field.FieldGame[i, j] == 0) button.Content = null;
                    uniformGrid1.Children.Add(button);
                }

            infoBlocK.Text = field.ShowFieldText();
        }


    }
}
