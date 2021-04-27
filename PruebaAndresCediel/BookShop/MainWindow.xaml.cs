using BookShop.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace BookShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }
        
        private void Writer_Click(object sender, RoutedEventArgs e)
        {
            Writers w = new Writers();
            //FrameBookShop.Source = w;
        }

        private void Btn_Click_Power(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_Writer(object sender, RoutedEventArgs e)
        {
            this.LoadFrame.Content = new Writers();
        }

        private void Button_Click_Books(object sender, RoutedEventArgs e)
        {
            this.LoadFrame.Content = new Book();
        }
    }
}
