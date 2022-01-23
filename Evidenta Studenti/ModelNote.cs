using Evidenta_Studenti.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidenta_Studenti
{
    class ModelNote : Note, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propNumeDisc)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propNumeDisc));
        }
        private string NumeDisc;

        public new string numeDisc
        {
            get { return NumeDisc; }
            set
            {
                if (this.NumeDisc != value)
                {
                    this.NumeDisc = value;
                    this.NotifyPropertyChanged("NumeDisc");
                }
            }
        }

    }
}
