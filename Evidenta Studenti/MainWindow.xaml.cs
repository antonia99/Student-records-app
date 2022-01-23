using Evidenta_Studenti.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Evidenta_Studenti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   
    public partial class MainWindow : Window
    {Evidenta_StudentiEntities model = new Evidenta_StudentiEntities();
        ObservableCollection<ModelStudenti> collectionStudenti;
        
        public MainWindow()
        {
            InitializeComponent();
            collectionStudenti = new ObservableCollection<ModelStudenti>();
            this.DataContext = this;
            

    }
        
            private void gridafisat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
           // var tabelStudenti = from x in model.Studentis select x;
            //gridafisat.ItemsSource = tabelStudenti.ToList();
            
        }




            private void Button_Click(object sender, RoutedEventArgs e)
        {
            Adauga pagadauga = new Adauga();
            pagadauga.ShowDialog();
            /*if (pagadauga.DialogResult == false)
            {Studenti StudentSelectat = new Studenti();
             foreach (var item in model.Studentis)
            {
                collectionStudenti.Add(new ModelStudenti() { id = item.id, Nume = item.Nume, DataNasterii = item.DataNasterii, Adresa = item.Adresa, Gen = item.Gen, An = item.An, Nivel = item.Nivel, Specializarea = item.Specializarea });
            }
            gridafisat.ItemsSource = collectionStudenti;

            }*/

        }
     

        private void btnsterge_Click(object sender, RoutedEventArgs e)
        {
            Sterge pagsterge = new Sterge();
            pagsterge.ShowDialog();
            

        }

        

        private void btniesire_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void chbafstudentii_Checked(object sender, RoutedEventArgs e)
        {
            var tabelStudenti =( from x in model.Studentis  select new{
                               id = x.id,
                             nume = x.Nume,
                             dataNasterii = x.DataNasterii,
                             gen = x.Gen,
                             an = x.An,
                             nivel = x.Nivel,
                             specializare = x.Specializarea,
                             adresa = x.Adresa}).ToList();

            gridafisat.ItemsSource = tabelStudenti.ToList();
        }

        private void chbafstudentii_Unchecked(object sender, RoutedEventArgs e)
        {
            gridafisat.ItemsSource = null;
        }

        private void chbafnotele_Checked(object sender, RoutedEventArgs e)
        {
            var tabelNote = (from x in model.Notes select new{
                codDisciplina = x.codDisc,
                numedisc = x.numeDisc,
                credite = x.credite,
                nota = x.nota ,
                idStudent=x.idStudent}).ToList();
                  
            gridafisat.ItemsSource = tabelNote.ToList();
        }

        private void chbafnotele_Unchecked(object sender, RoutedEventArgs e)
        {
            gridafisat.ItemsSource = null;

        }

        private void btnmodifica_Click(object sender, RoutedEventArgs e)
        {
            Modifica pagmodifica = new Modifica();
            pagmodifica.ShowDialog();
        }

        private void cbculoare_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Color culoareAleasa = (Color)(cbculoare.SelectedItem as PropertyInfo).GetValue(1, null);
            this.Background = new SolidColorBrush(culoareAleasa);
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            cbculoare.ItemsSource = typeof(Colors).GetProperties();
        }

        private void chbtoatedatele_Checked(object sender, RoutedEventArgs e)
        {
            var query = (from s in model.Studentis
                         join cs in model.Notes on s.id equals cs.idStudent
                         select new
                         {
                             id = s.id,
                             nume = s.Nume,
                             dataNasterii = s.DataNasterii,
                             gen = s.Gen,
                             an = s.An,
                             nivel = s.Nivel,
                             specializare = s.Specializarea,
                             adresa = s.Adresa,
                             codDisciplina = cs.codDisc,
                             numedisc = cs.numeDisc,
                             credite = cs.credite,
                             nota = cs.nota
                         }).ToList();

            gridafisat.ItemsSource = query.ToList();
        }
        private void chbtoatedatele_Unchecked(object sender, RoutedEventArgs e)
        {
            gridafisat.ItemsSource = null;

        }

       
    }
}
