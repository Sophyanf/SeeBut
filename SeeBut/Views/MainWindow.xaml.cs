using SeeBut.Models;
using SeeBut.ViewModels;
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
        MainWindowViewModel mainWindowViewModel;
        //public int butContent { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            mainWindowViewModel = new MainWindowViewModel();
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindowViewModel.CreatGameField();
            fillButton(uniformGrid1);
            fillButton(uniformGrid2);
            infoBlocK.Text = mainWindowViewModel.ShowFieldText();
            fillButtonField();
        }

        private void ButtonField_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            button.Content = mainWindowViewModel.GetFieldCell((int)button.Tag);
        }
        public void fillButton(UniformGrid uniformGrid)
        {
           
            if (uniformGrid.Children.Count != 0)
            {
                uniformGrid.Children.Clear();
            }

            for (int i = 0; i < 100; i++) { 
                Button button = new Button();
                uniformGrid.Children.Add(button);
                button.Tag = i;

                button.Command = mainWindowViewModel.gunBut;    
                /* не могу сообразить, как поменять  button.Content через mainWindowViewModel.gunBut. 
                 Если только кнопку передовать, но какие тогда вообще паттерны*/
                
                button.Click += ButtonField_Click ;
                }
        }

        public void fillButtonField()
        {
            int count = 0;
            foreach (Button button in uniformGrid1.Children)
            {
                button.Content = mainWindowViewModel.GetFieldCell(count);
                count++;
            }
        }
    }
}
