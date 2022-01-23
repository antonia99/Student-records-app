using Evidenta_Studenti.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Evidenta_Studenti
{
    /// <summary>
    /// Interaction logic for Modifica_note.xaml
    /// </summary>
    public partial class Modifica_note : Window
    {
        Evidenta_StudentiEntities model = new Evidenta_StudentiEntities();
        ObservableCollection<ModelNote> collectionNote;
        public Modifica_note()
        {
            InitializeComponent();
            collectionNote = new ObservableCollection<ModelNote>();
           
        }
        Note rezultat;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnmodifica_Click(object sender, RoutedEventArgs e)
        {

            try
            {     
                int id = Convert.ToInt32(tbidstudent.Text);
                rezultat = model.Notes.Single(x => x.idStudent == id);
                
                tbcredite.Text =Convert.ToString(rezultat.credite);
                tbnumedisc.Text = rezultat.numeDisc;
                tbnota.Text = Convert.ToString(rezultat.nota);
              
            }
            catch (System.InvalidOperationException exception)
            {
                MessageBox.Show("Id-ul introdus nu exista in baza de date");
            }
        }

        private void btnadauga_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               

                rezultat.credite =Convert.ToInt32( tbcredite.Text);
                rezultat.numeDisc = tbnumedisc.Text;
                rezultat.nota = Convert.ToInt32(tbnota.Text);
                model.Notes.Add(rezultat);
                model.Entry(rezultat).State = System.Data.Entity.EntityState.Modified;
                model.SaveChanges();
               // int id = Convert.ToInt32(tbidstudent.Text);
               // var stud = model.Notes.Where(x => x.idStudent == id).ToList();
               // ((MainWindow)System.Windows.Application.Current.MainWindow).gridafisat.ItemsSource = stud;
                {
                    Note NotestuSelectat = new Note();
                    foreach (var item in model.Notes)
                    {
                        collectionNote.Add(new ModelNote() { idStudent = item.idStudent, codDisc = item.codDisc, credite = item.credite, nota = item.nota,numeDisc = item.numeDisc });
                    }

                    ((MainWindow)System.Windows.Application.Current.MainWindow).gridafisat.ItemsSource = collectionNote;
                }
            }
            catch (System.NullReferenceException exception)
            {
                MessageBox.Show("Nu ati modificat nimic");
            }
            this.Close();
        }
    }
}
