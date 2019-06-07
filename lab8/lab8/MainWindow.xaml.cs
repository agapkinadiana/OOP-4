using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DbDataContext();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Roll_Up_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void openConnection_Click(object sender, RoutedEventArgs e)
        {
            SqlController.OpenConnection();
        }

        private void closeConnection_Click(object sender, RoutedEventArgs e)
        {
            SqlController.CloseConnection();
        }

        private void getInfo_Click(object sender, RoutedEventArgs e)
        {
            SqlController.Read();
        }

        private void setInfo_Click(object sender, RoutedEventArgs e)
        {
            SqlController.Write(disList, lectList);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                ContextMenu cm = mi.CommandParameter as ContextMenu;
                if (cm != null)
                {
                    DataGrid dg = cm.PlacementTarget as DataGrid;
                    if (dg != null)
                    {
                        SqlController.DeleteByID(dg);
                    }
                }
            }
        }

        private void sort_Click(object sender, RoutedEventArgs e)
        {
            SqlController.Sort();
        }
    }
}
