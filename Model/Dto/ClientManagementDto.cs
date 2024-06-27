using System.ComponentModel.DataAnnotations;

namespace EdenredTest.Model.Dto
{
    /// <summary>
    /// Gestión de datos del objeto 'Client'
    /// </summary>
    public class ClientManagementDto
    {
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        [Required(ErrorMessage = "Dato obligatorio, el campo 'nombre' debe poseer un largo entre 2 y 50 caracteres")]
        [MaxLength(50, ErrorMessage = "El nombre debe poseer un largo máximo de 50 caracteres")]
        [MinLength(2, ErrorMessage = "El nombre debe poseer un largo de al menos 2 caracteres")]
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido paterno del cliente
        /// </summary>
        [Required(ErrorMessage = "Dato obligatorio, el campo 'apellido paterno' debe poseer un largo entre 2 y 50 caracteres")]
        [MaxLength(50, ErrorMessage = "El apellido paterno debe poseer un largo máximo de 50 caracteres")]
        [MinLength(2, ErrorMessage = "El apellido paterno debe poseer un largo de al menos 2 caracteres")]
        public string ApellidoPaterno { get; set; }

        /// <summary>
        /// Apellido materno del cliente
        /// </summary>
        [Required(ErrorMessage = "Dato obligatorio, el campo 'apellido materno' debe poseer un largo entre 2 y 50 caracteres")]
        [MaxLength(50, ErrorMessage = "El apellido materno debe poseer un largo máximo de 50 caracteres")]
        [MinLength(2, ErrorMessage = "El apellido materno debe poseer un largo de al menos 2 caracteres")]
        public string ApellidoMaterno { get; set; }

        /// <summary>
        /// Email del cliente
        /// </summary>
        [Required(ErrorMessage = "Dato obligatorio, el campo 'email' debe poseer un largo entre 8 y 80 caracteres")]
        [MaxLength(80, ErrorMessage = "El email ingresado debe poseer un largo máximo de 80 caracteres")]
        [MinLength(8, ErrorMessage = "El email debe poseer un largo de al menos 8 caracteres")]
        [EmailAddress(ErrorMessage = "El dato ingresado en el campo 'email' debe poseer el formato del siguiente ejemplo: user@example.com")]
        public string Email { get; set; }

        /// <summary>
        /// Contraseña del cliente
        /// </summary>
        [Required(ErrorMessage = "Dato obligatorio, el campo 'password' debe poseer un largo entre 8 y 30 caracteres")]
        [MaxLength(30, ErrorMessage = "El password ingresado debe poseer un largo máximo de 30 caracteres")]
        [MinLength(8, ErrorMessage = "El password debe poseer un largo de al menos 8 caracteres")]
        public string Password { get; set; }

    }
}
