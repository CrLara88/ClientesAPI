namespace EdenredTest.Model.Authentication
{
    /// <summary>
    /// Estructura del objeto para validar usuarios existentes
    /// </summary>
    public class User
    {
        /// <summary>
        /// Email a validar
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password a validar
        /// </summary>
        public string Password { get; set; }
    }
}
