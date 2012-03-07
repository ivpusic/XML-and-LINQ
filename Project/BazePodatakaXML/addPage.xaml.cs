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
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace BazePodatakaXML
{
    /// <summary>
    /// Interaction logic for addPage.xaml
    /// </summary>
    public partial class addPage : Window
    {
        XmlDocument xml;
        public addPage()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //putanja do xml file-a
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Students.xml");
            //ucitavanje xml file-a
            xml = new XmlDocument();
            xml.Load(path);
            //dodavanje novog elementa
            XmlElement root = xml.DocumentElement;
            XmlElement elem = xml.CreateElement("Student");
            root.AppendChild(elem);

            elem = xml.CreateElement("JMBAG");
            XmlText text4 = xml.CreateTextNode(jmbagTextBox.Text);
            root.LastChild.AppendChild(elem);
            root.LastChild.LastChild.AppendChild(text4);

            elem = xml.CreateElement("Ime");
            XmlText text = xml.CreateTextNode(nameTextBox.Text);
            root.LastChild.AppendChild(elem);
            root.LastChild.LastChild.AppendChild(text);

            elem = xml.CreateElement("Prezime");
            XmlText text1 = xml.CreateTextNode(lastnameTextBox.Text);
            root.LastChild.AppendChild(elem);
            root.LastChild.LastChild.AppendChild(text1);

            elem = xml.CreateElement("Godina");
            XmlText text2 = xml.CreateTextNode(yearTextBox.Text);
            root.LastChild.AppendChild(elem);
            root.LastChild.LastChild.AppendChild(text2);

            elem = xml.CreateElement("Smjer");
            XmlText text3 = xml.CreateTextNode(smjerTextBox.Text);
            root.LastChild.AppendChild(elem);
            root.LastChild.LastChild.AppendChild(text3);

            xml.Save(path);

            //dio koda koji se odnosi na messagebox koji se pojavi nakon klika na button "Spremi"
            string caption = "Spremljeno";
            string question = "Zelite li dodati jos zapisa?";
            if (MessageBox.Show(question, caption, MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                this.Close();
            }

            else
            {
                nameTextBox.Clear();
                lastnameTextBox.Clear();
                yearTextBox.Clear();
                smjerTextBox.Clear();
                jmbagTextBox.Clear();
            }
            
            

        }
    }
}
