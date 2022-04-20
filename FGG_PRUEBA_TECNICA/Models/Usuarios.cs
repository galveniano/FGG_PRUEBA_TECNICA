using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FGG_PRUEBA_TECNICA.Models
{
    [Table("Usuarios", Schema = "dbo")]
    public class Usuarios
    {
        [Key]
        public int idUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaAlta { get; set; }

        [ForeignKey("Clientes")]
        public int Clientes_idClientes { get; set; }

        public Clientes Clientes { get; set; }
    }
}
