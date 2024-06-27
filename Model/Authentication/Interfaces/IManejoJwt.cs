namespace EdenredTest.Model.Authentication.Interfaces
{
    public interface IManejoJwt
    {
        public string GenerarToken(string Email, string Password);
    }
}
