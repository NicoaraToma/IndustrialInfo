//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ezvax.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Programare
    {
        public int id { get; set; }
        public int idUser { get; set; }
        public int idClinica { get; set; }
        public System.DateTime dataVaccin { get; set; }
        public System.DateTime dataRapel { get; set; }
    
        public virtual Clinica Clinica { get; set; }
        public virtual Users Users { get; set; }
    }
}