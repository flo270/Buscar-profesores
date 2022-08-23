using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BuscaProfesores.Models
{
    public class ProfesorMateriaModalidad
    {
        [Key]
        public int Id { get; set; }

        public int MateriaId { get; set; }

        public string ApplicationUserId { get; set; }

        public int ModalidadaId { get; set; }

        public double Precio { get; set; }

        public Materia Materias { get; set; }

        public Modalidad Modalidades { get; set; }

        public ApplicationUser ApplicationUsers { get; set; }
    }

    public class JoinProfesorMateriaModalida
    {
        public int id { get; set; }
        public Materia Materia { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Modalidad Modalidad { get; set; }
        public double Precio { get; set; }

    }

    public class JoinMateriaPmm
    {
        public Materia Materia { get; set; }
        public ProfesorMateriaModalidad ProfesorMateriaModalidad { get; set; }
    }

    public class ContenedorProfesorMaterias
    {
        private int materiaId;
        private string profesorId;
        private string nombreMateria;
        private int profesoresPorMateria;
        public ContenedorProfesorMaterias()
        { }

        public string NombreMateria { get => nombreMateria; set => nombreMateria = value; }
        public int ProfesoresPorMateria { get => profesoresPorMateria; set => profesoresPorMateria = value; }
        public int MateriaId { get => materiaId; set => materiaId = value; }
        public string ProfesorId { get => profesorId; set => profesorId = value; }
    }


    public class ContenedorProfesorMateriaModalidad
    {
        private int id;
        private string aplicationUserId;
        private string nombre;
        private string apellido;
        private string direccion;
        private string telefono;
        private string email;
        private string Nombremateria;
        private int materiaId;
        private List<ContenedorModalidad> contenedorDeModalidades;

        public ContenedorProfesorMateriaModalidad()
        {
            this.contenedorDeModalidades = new List<ContenedorModalidad>();
        }

        public string AplicationUserId { get => aplicationUserId; set => aplicationUserId = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public List<ContenedorModalidad> ContenedorDeModalidades { get => contenedorDeModalidades; set => contenedorDeModalidades = value; }
        public int Id { get => id; set => id = value; }
        public string Nombremateria1 { get => Nombremateria; set => Nombremateria = value; }
        public int MateriaId { get => materiaId; set => materiaId = value; }
    }

    public class ContenedorModalidad
    {
        private string aplicationUserId;
        private string modalidad;
        private double precion;

        public ContenedorModalidad(string modalidad, double precion)
        {
            this.modalidad = modalidad;
            this.precion = precion;
        }

        public string Modalidad { get => modalidad; set => modalidad = value; }
        public double Precion { get => precion; set => precion = value; }
        public string AplicationUserId { get => aplicationUserId; set => aplicationUserId = value; }
    }

   

}