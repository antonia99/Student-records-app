using Evidenta_Studenti.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidenta_Studenti
{
    class ModelStudenti : Studenti, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propNume)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propNume));
        }
        private string nume;

        public new string Nume
        {
            get { return nume; }
            set
            {
                if (this.nume != value)
                {
                    this.nume = value;
                    this.NotifyPropertyChanged("NumeStudent");
                }
            }
        }
    }
}
