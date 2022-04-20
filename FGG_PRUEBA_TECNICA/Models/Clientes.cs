using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FGG_PRUEBA_TECNICA.Models
{
    [Table("Clientes", Schema = "dbo")]
    public class Clientes
    {
        [Key]
        public int idClientes { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string CodCliente { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaInicio { get; set; }
        public string? CodigoComercial { get; set; }
        public bool Activo { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }

}
