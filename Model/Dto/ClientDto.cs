using System.ComponentModel.DataAnnotations;

namespace EdenredTest.Model.Dto
{
    /// <summary>
    /// Estructura del objeto 'Client' para consulta de datos
    /// </summary>
    public class ClientDto
    {
        /// <summary>
        /// Id del cliente
        /// </summary>
        [Required]
        public int IdClient { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        [Required]
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido paterno del cliente
        /// </summary>
        [Required]
        public string ApellidoPaterno { get; set; }

        /// <summary>
        /// Apellido materno del cliente
        /// </summary>
        [Required]
        public string ApellidoMaterno { get; set; }

        /// <summary>
        /// Email del cliente
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Contraseña del cliente
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Fecha de creación del cliente en BD
        /// </summary>
        [Required]
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Fecha de actualización del cliente en BD
        /// </summary>
        public DateTime? FechaActualizacion { get; set; }
    }
}
