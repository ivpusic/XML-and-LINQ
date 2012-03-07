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
    /// Interaction logic for Search.xaml
    /// </summary>
    /// 

    public partial class Search : Window
    {
        string file = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\students.xml");
        XDocument xmlDoc;

        public Search()
        {
            InitializeComponent();
            xmlDoc = XDocument.Load(file);
           
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            //pretrazivanje studenata s obzirom na odabran uvjet
            if (JMBAGsearch.IsChecked == true) 
            {
                var studenti = from students in xmlDoc.Descendants("Student")
                               where students.Element("JMBAG").Value == keyBox.Text.ToString()
                               select new
                               {
                                   JMBAG = students.Element("JMBAG").Value,
                                   Ime = students.Element("Ime").Value,
                                   Prezime = students.Element("Prezime").Value,
                                   Smjer = students.Element("Smjer").Value,
                                   Godina = students.Element("Godina").Value,
                               };
                listStudents.ItemsSource = studenti;
            }
            else if (imeSearch.IsChecked == true) 
            {
                var studenti = from students in xmlDoc.Descendants("Student")
                               where students.Element("Ime").Value == keyBox.Text.ToString()
                               select new
                               {
                                   JMBAG = students.Element("JMBAG").Value,
                                   Ime = students.Element("Ime").Value,
                                   Prezime = students.Element("Prezime").Value,
                                   Smjer = students.Element("Smjer").Value,
                                   Godina = students.Element("Godina").Value,
                               };
                listStudents.ItemsSource = studenti;
            }
            else if (prezimeSearch.IsChecked == true) 
            {
                var studenti = from students in xmlDoc.Descendants("Student")
                               where students.Element("Prezime").Value == keyBox.Text.ToString()
                               select new
                               {
                                   JMBAG = students.Element("JMBAG").Value,
                                   Ime = students.Element("Ime").Value,
                                   Prezime = students.Element("Prezime").Value,
                                   Smjer = students.Element("Smjer").Value,
                                   Godina = students.Element("Godina").Value,
                               };
                listStudents.ItemsSource = studenti;
            }
            else if (godinaSerarch.IsChecked == true)
            {
                var studenti = from students in xmlDoc.Descendants("Student")
                               where students.Element("Godina").Value == keyBox.Text.ToString()
                               select new
                               {
                                   JMBAG = students.Element("JMBAG").Value,
                                   Ime = students.Element("Ime").Value,
                                   Prezime = students.Element("Prezime").Value,
                                   Smjer = students.Element("Smjer").Value,
                                   Godina = students.Element("Godina").Value,
                               };
                listStudents.ItemsSource = studenti;
            }
            else if (smjerSearch.IsChecked == true)
            {
                var studenti = from students in xmlDoc.Descendants("Student")
                               where students.Element("Smjer").Value == keyBox.Text.ToString()
                               select new
                               {
                                   JMBAG = students.Element("JMBAG").Value,
                                   Ime = students.Element("Ime").Value,
                                   Prezime = students.Element("Prezime").Value,
                                   Smjer = students.Element("Smjer").Value,
                                   Godina = students.Element("Godina").Value,
                               };
                listStudents.ItemsSource = studenti;
            }
            //ukoliko nismo odabrali nijedan uvjet, onda cemo dobiti sve zapise iz xml-a
            else
            {
                var studenti = from students in xmlDoc.Descendants("Student")
                                select new
                                {
                                    JMBAG = students.Element("JMBAG").Value,
                                    Ime = students.Element("Ime").Value,
                                    Prezime = students.Element("Prezime").Value,
                                    Smjer = students.Element("Smjer").Value,
                                    Godina = students.Element("Godina").Value,
                                };
                listStudents.ItemsSource = studenti;
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
