using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BuscaProfesores.Models
{
    public class Materia
    {
        
        [Key]
        public int Id { get; set; }

       
        [StringLength(30)]
        public string NombreMateria { get; set; }

       
        public ICollection<ProfesorMateriaModalidad> ProfesorMateriaModalidades { get; set; }
    }
}