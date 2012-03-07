using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace BazePodatakaXML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string file = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\students.xml");
       // string file = "students.xml";
        XmlDocument xml = new XmlDocument();
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(file))
            {
                xml.Load(file);
               // MessageBox.Show("tu3");
               // XmlElement elmRoot = xml.DocumentElement;
                XmlElement elem = xml.CreateElement("Studenti");
                //xml.AppendChild(elem);
                elem = xml.DocumentElement;
                //XmlElement e = xml.CreateElement("Student");
                //elem.AppendChild(e);
                xml.Save(file);
            }

        }

        private void unosButton_Click(object sender, RoutedEventArgs e)
        {
            addPage pageAdd = new addPage();
            pageAdd.ShowDialog();
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pretrazivanjeButton_Click(object sender, RoutedEventArgs e)
        {
            Search search = new Search();
            search.ShowDialog();
        }

        private void uređivanjeButton_Click(object sender, RoutedEventArgs e)
        {
            EditPage page = new EditPage();
            page.ShowDialog();
        }

        private void pregledButton_Click(object sender, RoutedEventArgs e)
        {
            XElement xmlDoc = XElement.Load(file);
            MessageBox.Show(xmlDoc.ToString());
        }
    }
}
