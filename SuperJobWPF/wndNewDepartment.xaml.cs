using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace SuperJobWPF
{   
    public partial class wndNewDepartment : Window
    {
        ObservableCollection<string> Departments = new ObservableCollection<string>();

        public wndNewDepartment()
        {
            InitializeComponent();
            LoadFromXMLDep("Departments.xml");
            cbDep.ItemsSource = Departments;
        }

        private void LoadFromXMLDep(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<string>));
            using (FileStream fStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                Departments = (ObservableCollection<string>)xmlFormat.Deserialize(fStream);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {            
            this.Close();
        }

        private void btnOkDep_Click(object sender, RoutedEventArgs e)
        {
            if (cbDep.Text == "")
            {
                MessageBox.Show("Введите название отдела", "Ошибка ввода", MessageBoxButton.OK);
            }
            else
            {                
                Departments.Add(cbDep.Text);
                SaveToXML();                
                cbDep.Text = "";
            }
        }

        public void SaveToXML()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<string>));
            using (FileStream fStream = new FileStream("Departments.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                xmlFormat.Serialize(fStream, Departments);
            }
        }
    }
}
