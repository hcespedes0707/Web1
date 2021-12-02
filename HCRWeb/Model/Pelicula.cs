using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCRWeb.Model
{
    public class Pelicula
    {
        [Key]
        public int PeliculaId { get; set; }
       
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string NombrePelicula { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string  Temporada { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string Capitulo { get; set; }


        public Imagen Imagen { get; set; }

        public int? ImagenId { get; set; }



    }
}
