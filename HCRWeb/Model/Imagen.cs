using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCRWeb.Model
{
    public class Imagen
    {

        [Key]
        public int ImagenId { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string FileName { get; set; }

        public string Path { get; set; }

        public string Temporal { get; set; }

        public DateTime FechaSubida { get; set; }

    }
}
