using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace SuperJobWPF
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();
        ObservableCollection<string> Departments = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();

            dgDBase.IsReadOnly = true;
            LoadFromXML("Employees.xml");
            LoadFromXMLDep("Departments.xml");
            dgDBase.ItemsSource = Employees;
            dgComboBox.ItemsSource = Departments;
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            dgDBase.IsReadOnly = false;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            dgDBase.IsReadOnly = true;
        }        

        public void SaveToXML(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<Employee>));
            using (FileStream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlFormat.Serialize(fStream, Employees);
            }           
        }

        public void LoadFromXML(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<Employee>));
            using (FileStream fStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                Employees = (ObservableCollection<Employee>)xmlFormat.Deserialize(fStream);
            }            
        }

        public void LoadFromXMLDep(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<string>));
            using (FileStream fStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                Departments = (ObservableCollection<string>)xmlFormat.Deserialize(fStream);
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML файл|*.XML|Все файлы|*.*";
            if (dialog.ShowDialog() == true)
            {
                LoadFromXML(dialog.FileName);
                dgDBase.ItemsSource = Employees;
            }
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "XML файл|*.XML|Все файлы|*.*";
            if (dialog.ShowDialog() == true)
            {
                SaveToXML(dialog.FileName);
            }
        }

        private void SaveAll()
        {
           SaveToXML("Employees.xml");            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {            
            if (MessageBox.Show("В базе произошли изменения, сохранить их?", "Закрыть", MessageBoxButton.YesNo) == MessageBoxResult.Yes) SaveAll();
            Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            wndNewDepartment newDeparment = new wndNewDepartment();
            newDeparment.ShowDialog();            
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
           // dgDBase.IsReadOnly = false;
            cbEditBase.IsChecked = true;
        }
    }
}
