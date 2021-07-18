namespace WebAPI_HiriartCorales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ListaEventoes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ListaEventoes()
        {
            Diarios = new HashSet<Diarios>();
        }

        [Key]
        public int ListaEventoID { get; set; }

        public int? IDDiario { get; set; }

        public string Titulo { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FechaEvento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diarios> Diarios { get; set; }
    }
}
