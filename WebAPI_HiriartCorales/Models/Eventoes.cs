namespace WebAPI_HiriartCorales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Eventoes
    {
        [Key]
        public int EventoID { get; set; }

        public int? DiarioID { get; set; }

        public int? NotificacionID { get; set; }

        public int? MemoID { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime Fin { get; set; }

        [Required]
        [StringLength(40)]
        public string Titulo { get; set; }

        [StringLength(140)]
        public string Descripcion { get; set; }

        [StringLength(100)]
        public string Ubicacion { get; set; }

        public bool EsSerie { get; set; }

        public string Dias { get; set; }

        public int? ListaContacto_ListaContactoID { get; set; }

        public int? Contacto_ContactoID { get; set; }

        public virtual Contactoes Contactoes { get; set; }

        public virtual Diarios Diarios { get; set; }

        public virtual ListaContactoes ListaContactoes { get; set; }

        public virtual Memos Memos { get; set; }

        public virtual Notificacions Notificacions { get; set; }
    }
}
