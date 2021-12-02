using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCRWeb.Model
{
    public class Usuario
    { 
       [Key]
        public int UsuarioId { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string FullName { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string UserName { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string Password { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string Tipo { get; set; }
    }
}
