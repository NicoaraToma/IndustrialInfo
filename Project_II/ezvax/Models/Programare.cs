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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Programare
    {
        public int id { get; set; }
        public int idUser { get; set; }
        [DisplayName("Clinica")]
        [Required(ErrorMessage = "Acest camp este necesar")]
        public int idClinica { get; set; }
        [DisplayName("Vaccin")]
        [Required(ErrorMessage = "Acest camp este necesar")]
        public int idVaccin { get; set; }
        [DisplayName("Data vaccin")]
        [Required(ErrorMessage = "Acest camp este necesar")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime dataVaccin { get; set; }
        [DisplayName("Data rapel")]
        [Required(ErrorMessage = "Acest camp este necesar")]
        public System.DateTime dataRapel { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string scheduleErrorMessage { get; set; }
        public virtual Clinica Clinica { get; set; }
        public virtual Users Users { get; set; }
        public virtual Vaccin Vaccin { get; set; }

        [NotMapped]
        public List<Clinica> clinici { get; set; }
        [NotMapped]
        public List<Vaccin> vaccine { get; set; }
    }
}
