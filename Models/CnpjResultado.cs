using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgoraVai_Cnpj.Models
{
    public class CnpjResultado
    {
        
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Fantasia { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Municipio { get; set; }
        [Required]
        public string Uf { get; set; }
        }
}
