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
using System.Data.Linq;

namespace Evidenta_Studenti
{
    /// <summary>
    /// Interaction logic for Adauga.xaml
    /// </summary>
    public partial class Adauga : Window
    {Evidenta_StudentiEntities model = new Evidenta_StudentiEntities();
        Studenti stu = new Studenti();
        ObservableCollection<ModelStudenti> collectionStudenti;

        public Adauga()
        {
            InitializeComponent();
            collectionStudenti = new ObservableCollection<ModelStudenti>();
        }

        private void btniesire_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           Adauga_note pagadauganote = new Adauga_note();
            pagadauganote.ShowDialog();
           
        }

        private void btnadauga_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                stu.Nume = tbnume.Text;
                stu.DataNasterii = alegedata.SelectedDate.Value.Date;

                stu.Gen = (rbm.IsChecked == true ? "Masculin" : "Feminin");
                stu.An = comboan.SelectedIndex + 1;
                stu.Nivel = (chblicenta.IsChecked == true ? "Licenta" : "Master");
                stu.Specializarea = tbspecializare.Text;
                stu.Adresa = tbadresa.Text;
                model.Studentis.Add(stu);
                model.SaveChanges();

                StergeCampurile();
                this.DataContext = stu;
                {
                    Studenti StudentSelectat = new Studenti();
                    foreach (var item in model.Studentis)
                    {
                        collectionStudenti.Add(new ModelStudenti() { id = item.id, Nume = item.Nume, DataNasterii = item.DataNasterii, Adresa = item.Adresa, Gen = item.Gen, An = item.An, Nivel = item.Nivel, Specializarea = item.Specializarea });
                    }

                    ((MainWindow)System.Windows.Application.Current.MainWindow).gridafisat.ItemsSource = collectionStudenti;
                }
            }catch(System.InvalidOperationException exception)
            {
                MessageBox.Show("Nu ati selectat data nasterii");
            }
        }

        private void StergeCampurile()
        {
            tbnume.Clear();
            tbspecializare.Clear();
            tbadresa.Clear();
           
            alegedata.SelectedDate = null;
            rbm.IsChecked = false;
            rbf.IsChecked = false;
            chblicenta.IsChecked = false;
            chbmaster.IsChecked = false;
            comboan.Text = "";
        }

        private void btnstergecampuri_Click(object sender, RoutedEventArgs e)
        {
            StergeCampurile();
        }
    }
}
