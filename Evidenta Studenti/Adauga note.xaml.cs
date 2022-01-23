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
    /// Interaction logic for Adauga_note.xaml
    /// </summary>
    public partial class Adauga_note : Window
    {Evidenta_StudentiEntities model = new Evidenta_StudentiEntities();
        Note stun = new Note();
        ObservableCollection<ModelNote> collectionNote;
        public Adauga_note()
        {
            InitializeComponent();
            collectionNote = new ObservableCollection<ModelNote>();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            
            this.Close();
        }
        private void StergeCampurile()
        {
            tbcoddisc.Clear();
            tbcredite.Clear();
            tbidstudent.Clear();
            tbnumedisc.Clear();
            tbnota.Clear();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                stun.idStudent = Convert.ToInt32(tbidstudent.Text);
                stun.numeDisc = tbnumedisc.Text;
                stun.credite = Convert.ToInt32(tbcredite.Text);
                stun.codDisc = tbcoddisc.Text;
                stun.nota = Convert.ToInt32(tbnota.Text);
                model.Notes.Add(stun);
                model.SaveChanges();
                StergeCampurile();
                this.DataContext = stun;
                {
                    Note NotestudSelectat = new Note();
                    foreach (var item in model.Notes)
                    {
                        collectionNote.Add(new ModelNote() { idStudent = item.idStudent, codDisc = item.codDisc, credite = item.credite, numeDisc = item.numeDisc, nota = item.nota });
                    }

                    ((MainWindow)System.Windows.Application.Current.MainWindow).gridafisat.ItemsSource = collectionNote;
                }
            }catch(Exception exception)
            {
                MessageBox.Show("Toate campurile trebuie completate,{0}",Convert.ToString(exception));
            }
            this.Close();
        }

        private void btnstergecamp_Click(object sender, RoutedEventArgs e)
        {
            StergeCampurile();
        }
    }
}
