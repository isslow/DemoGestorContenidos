namespace GestorContenido.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
        }

        public virtual DbSet<Contenido> Contenido { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contenido>()
                .Property(e => e.texto)
                .IsUnicode(false);

            modelBuilder.Entity<Contenido>()
                .Property(e => e.imageDir)
                .IsUnicode(false);

            modelBuilder.Entity<Contenido>()
                .Property(e => e.row)
                .IsUnicode(false);
        }
    }
}
