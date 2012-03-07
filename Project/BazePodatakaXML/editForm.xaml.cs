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
using System.Xml.Linq;
using System.Collections;

namespace BazePodatakaXML
{
    /// <summary>
    /// Interaction logic for editForm.xaml
    /// </summary>
    public partial class editForm : Window
    {
        string file = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\students.xml");
        string jmbag;

        public editForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            XDocument xmlDoc = XDocument.Load(file);
            //selektiranje elementa
            IEnumerable node = (from b in xmlDoc.Descendants("Student")
                                where (b.Element("JMBAG").Value == jmbag)
                                select b);
            //zamjena stare vrijednosti novom
            foreach (XElement elem in node)
            {
                elem.SetElementValue("JMBAG", jmbagTextBox.Text);
                elem.SetElementValue("Ime", nameTextBox.Text);
                elem.SetElementValue("Prezime", lastnameTextBox.Text);
                elem.SetElementValue("Godina", yearTextBox.Text);
                elem.SetElementValue("Smjer", smjerTextBox.Text);
            }
            //spremanje, i zatvaranje forme(prozora)
            xmlDoc.Save(file);
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            jmbag = jmbagTextBox.Text;
        }
    }
}
