namespace WebAPI_HiriartCorales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notificacions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Notificacions()
        {
            Eventoes = new HashSet<Eventoes>();
        }

        [Key]
        public int NotificacionID { get; set; }

        public string Titulo { get; set; }

        public DateTime Hora { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Eventoes> Eventoes { get; set; }
    }
}
