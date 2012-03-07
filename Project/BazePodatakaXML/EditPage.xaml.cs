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

namespace BazePodatakaXML
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    /// 

    

    public partial class EditPage : Window
    {
        string file = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\students.xml");
        XDocument xmlDoc;

        //u konstruktoru se nalazi kod za ucitavanje podataka iz xml file-a
        public EditPage()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            //konstruktor koji sluzi za ucitavanje podataka iz xml dokumenta, i dodavanje tih podataka u listView
            xmlDoc = XDocument.Load(file);
            var studenti = from students in xmlDoc.Descendants("Student")
                           select new Student
                           {
                               JMBAG = students.Element("JMBAG").Value,
                               Ime = students.Element("Ime").Value,
                               Prezime = students.Element("Prezime").Value,
                               Smjer = students.Element("Smjer").Value,
                               Godina = students.Element("Godina").Value,
                           };
            listStudents.ItemsSource = studenti;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            //element koji smo selektirali u listview-u
            var student = listStudents.SelectedItems;
            //brisanje elementa
            foreach (Student s in student)
            {
                var xElement = (
                from x in xmlDoc.Root.Elements("Student")
                where x.Element("JMBAG").Value == s.JMBAG
                select x
                ).FirstOrDefault();
                xElement.Remove();
            }
            xmlDoc.Save(file);
            loadData();
        }

        public class Student
        {
            public string JMBAG { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Smjer { get; set; }
            public string Godina { get; set; }

        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            editForm edit = new editForm();
            var student = listStudents.SelectedItems;
            //slanje podataka drugom prozoru (formi)
            foreach (Student s in student)
            {
                edit.jmbagTextBox.Text = s.JMBAG;
                edit.nameTextBox.Text = s.Ime;
                edit.lastnameTextBox.Text = s.Prezime;
                edit.yearTextBox.Text = s.Godina;
                edit.smjerTextBox.Text = s.Smjer;
            }
            edit.ShowDialog();
            loadData();
        }


        
    }
}
