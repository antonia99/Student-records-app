//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Evidenta_Studenti.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Note
    {
        public string codDisc { get; set; }
        public string numeDisc { get; set; }
        public Nullable<int> credite { get; set; }
        public Nullable<int> nota { get; set; }
        public int idStudent { get; set; }

        public virtual Studenti Studenti { get; set; }
    }
}