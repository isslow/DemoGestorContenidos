namespace GestorContenido.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contenido")]
    public partial class Contenido
    {
        public int id { get; set; }

        [Required]
        [StringLength(250)]
        public string titulo { get; set; }

        [Required]
        [StringLength(500)]
        public string texto { get; set; }

        [Required]
        [StringLength(250)]
        public string imageDir { get; set; }

        [Required]
        [StringLength(10)]
        public string row { get; set; }

        public int idUser { get; set; }

        [NotMapped]
        public string userString { get; set; }

        public DateTime? create { get; set; }

        public DateTime? modified { get; set; }
    }
}
