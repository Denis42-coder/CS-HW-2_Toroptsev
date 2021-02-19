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

namespace Udvoitel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Class_Udvoitel.Udvoitel udvoitel;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void wndMain_Loaded(object sender, RoutedEventArgs e)
        {
            udvoitel = new Class_Udvoitel.Udvoitel(10,100);
            tbFinish.Text = udvoitel.Finish.ToString();
            tbCurrent.Text = udvoitel.Current.ToString();

        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            udvoitel.Plus();
            tbCurrent.Text = udvoitel.ToString();
        }

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            udvoitel.Multi();
            tbCurrent.Text = udvoitel.ToString();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            udvoitel.Back();
            tbCurrent.Text = udvoitel.ToString();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            udvoitel.Reset();
            tbCurrent.Text = udvoitel.ToString();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
