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
    /// Interaction logic for Modifica.xaml
    /// </summary>
    public partial class Modifica : Window
    {Evidenta_StudentiEntities model = new Evidenta_StudentiEntities();
        ObservableCollection<ModelStudenti> collectionStudenti;
       
        public Modifica()
        {
            InitializeComponent();
            collectionStudenti = new ObservableCollection<ModelStudenti>();
        }

        private void btniesire_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

Studenti rezultat;
       
        
        private void btnmodifica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(tbID.Text);
                rezultat = model.Studentis.Single(x => x.id == id);
                tbnume.Text = rezultat.Nume;
                alegedata.SelectedDate = rezultat.DataNasterii;
                if (rezultat.Gen == "Masculin")
                {
                    rbm.IsChecked = true;

                }
                else rbf.IsChecked = true;

                comboan.Text = Convert.ToString(rezultat.An);
                tbspecializare.Text = rezultat.Specializarea;
                tbadrm.Text = rezultat.Adresa;

                if (rezultat.Nivel == "Licenta")
                {
                    chblicenta.IsChecked = true;

                }
                else chbmaster.IsChecked = true;
            }catch(System.InvalidOperationException exception)
            {
                MessageBox.Show("Id-ul introdus nu exista in baza de date");
            }
        }
        
        private void btnactualizeaza_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rezultat.Nume = tbnume.Text;
                rezultat.DataNasterii = alegedata.SelectedDate.Value.Date;

                rezultat.Gen = (rbm.IsChecked == true ? "Masculin" : "Feminin");
                rezultat.An = comboan.SelectedIndex + 1;
                rezultat.Nivel = (chblicenta.IsChecked == true ? "Licenta" : "Master");
                rezultat.Specializarea = tbspecializare.Text;
                rezultat.Adresa = tbadrm.Text;
                model.Studentis.Add(rezultat);
                model.Entry(rezultat).State = System.Data.Entity.EntityState.Modified;
                model.SaveChanges();
                //this.DataContext = rezultat;
               //int id = Convert.ToInt32(tbID.Text);
               // var stud = model.Studentis.Where(x=> x.id == id).ToList();
                //((MainWindow)System.Windows.Application.Current.MainWindow).gridafisat.ItemsSource = stud;
               /* var tabelStudenti = (from x in model.Studentis where x.id==id
                                     select new
                                     {
                                         id = x.id,
                                         nume = x.Nume,
                                         dataNasterii = x.DataNasterii,
                                         gen = x.Gen,
                                         an = x.An,
                                         nivel = x.Nivel,
                                         specializare = x.Specializarea,
                                         adresa = x.Adresa
                                     }).ToList();

                ((MainWindow)System.Windows.Application.Current.MainWindow).gridafisat.ItemsSource = tabelStudenti.ToList();*/
                 {
                      Studenti StudentSelectat = new Studenti();


                          foreach (var item in model.Studentis)
                          {
                              collectionStudenti.Add(new ModelStudenti() { id = item.id, Nume = item.Nume, DataNasterii = item.DataNasterii, Adresa = item.Adresa, Gen = item.Gen, An = item.An, Nivel = item.Nivel, Specializarea = item.Specializarea });
                          }

                        ((MainWindow)System.Windows.Application.Current.MainWindow).gridafisat.ItemsSource = collectionStudenti;
                      } 



            }
            catch (System.NullReferenceException exception)
            {
                MessageBox.Show("Nu ati modificat nimic");
            }
            this.Close();
        }

        private void tbnmodificanote_Click(object sender, RoutedEventArgs e)
        {
            Modifica_note pagmodificanota = new Modifica_note();
            pagmodificanota.ShowDialog();

        }
    }
}
