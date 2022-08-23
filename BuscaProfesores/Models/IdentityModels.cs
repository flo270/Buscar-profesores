using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BuscaProfesores.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(30)]
        public string Apellido { get; set; }
        [Required]
        [StringLength(30)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(30)]
        public string Telefono { get; set; }

        public ICollection <ProfesorMateriaModalidad> ProfesorMateriaModalidades { get; set; }




        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public DbSet<Materia> Materias { get; set; }
        public DbSet<Modalidad> Modalidades { get; set; }
        public DbSet<ProfesorMateriaModalidad> ProfesorMateriaModalidades { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           

            modelBuilder.Entity<Materia>()
                .HasMany(e => e.ProfesorMateriaModalidades)
                .WithRequired(e => e.Materias)
                .HasForeignKey(e => e.MateriaId)
                .WillCascadeOnDelete(false);

           
            modelBuilder.Entity<Modalidad>()
                .HasMany(e => e.ProfesorMateriaModalidades)
                .WithRequired(e => e.Modalidades)
                .HasForeignKey(e => e.ModalidadaId)
                .WillCascadeOnDelete(false);

               
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.ProfesorMateriaModalidades)
                .WithRequired(e => e.ApplicationUsers)
                .HasForeignKey(e => e.ApplicationUserId)
                .WillCascadeOnDelete(false);

        }


            public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       
    }
}