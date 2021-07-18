namespace WebAPI_HiriartCorales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Diarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diarios()
        {
            Eventoes = new HashSet<Eventoes>();
        }

        [Key]
        public int DiarioID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Fecha { get; set; }

        [Required]
        public string Contenido { get; set; }

        public int? ListaEvento_ListaEventoID { get; set; }

        public virtual ListaEventoes ListaEventoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Eventoes> Eventoes { get; set; }
    }
}
