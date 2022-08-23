using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BuscaProfesores.Models
{
    public class Modalidad
    {


        [Key]
        public int Id { get; set; }

       
        [StringLength(30)]
        public string TiposDeModalidad { get; set; }

       
        public virtual ICollection<ProfesorMateriaModalidad> ProfesorMateriaModalidades { get; set; }
    }
}