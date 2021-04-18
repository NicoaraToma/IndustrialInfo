//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EZVax_Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Comentariu = new HashSet<Comentariu>();
            this.Postare = new HashSet<Postare>();
            this.ProfilMedical = new HashSet<ProfilMedical>();
            this.Programare = new HashSet<Programare>();
        }
    
        public int id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [DisplayName("Last Name")]
        public string nume { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("First Name")]
        public string prenume { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("CNP")]
        public string CNP { get; set; }
        [DisplayName("E-Mail Address")]
        public string email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Phone Number")]
        public string numarTelefon { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Enter Password")]
        public string password { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("password")]
        public string confirmPassword { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentariu> Comentariu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Postare> Postare { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProfilMedical> ProfilMedical { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Programare> Programare { get; set; }
    }
}
