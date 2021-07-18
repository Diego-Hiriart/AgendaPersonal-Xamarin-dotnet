namespace WebAPI_HiriartCorales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contactoes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contactoes()
        {
            Eventoes = new HashSet<Eventoes>();
        }

        [Key]
        public int ContactoID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(30)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(30)]
        public string Telefono { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

        [StringLength(60)]
        public string Organizacion { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [StringLength(140)]
        public string InformacionAdicional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Eventoes> Eventoes { get; set; }
    }
}
