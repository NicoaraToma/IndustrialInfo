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
    
    public partial class Vaccin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vaccin()
        {
            this.Programare = new HashSet<Programare>();
        }
    
        public int id { get; set; }
        public string nume { get; set; }
        public int durataRapel { get; set; }
        public int cantitate { get; set; }
        public string contraindicatii { get; set; }
        public string alergii { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Programare> Programare { get; set; }
    }
}
