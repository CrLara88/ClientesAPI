using EdenredTest.Data;
using EdenredTest.Model.Dto;
using EdenredTest.Model.Interfaces;

namespace EdenredTest.Model.Dao
{
    public class ClientDao: IClientDao
    {
        private readonly DbContextClient _context;
        private readonly ILogger<ClientDao> _logger;

        public ClientDao(DbContextClient context, ILogger<ClientDao> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Método de creación de cliente
        /// </summary>
        public void CreateClient(ClientManagementDto client, ref ResultObj result)
        {
            try
            {
                var lastClient = _context.client.OrderByDescending(x => x.IdClient).FirstOrDefault();


                Client newClient = new()
                {
                    IdClient = (lastClient is null) ? 1 : lastClient.IdClient + 1,
                    Nombre = client.Nombre,
                    ApellidoPaterno = client.ApellidoPaterno,
                    ApellidoMaterno = client.ApellidoMaterno,
                    Email = client.Email,
                    Password = client.Password,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = null
                };

                _context.client.Add(newClient);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Error = ex;
                _logger.LogError(result.Error, "Error durante el proceso de creación del cliente");
            }
        }

        /// <summary>
        /// Método de actualización de cliente
        /// </summary>
        public Client UpdateClient(int clientId, ClientManagementDto client, ref ResultObj result)
        {
            try
            {
                var clientResult = _context.client.FirstOrDefault(c => c.IdClient == clientId);
                
                if (clientResult is null)
                    return clientResult;

                clientResult.Nombre = client.Nombre;
                clientResult.ApellidoPaterno = client.ApellidoPaterno;
                clientResult.ApellidoMaterno = client.ApellidoMaterno;
                clientResult.Email = client.Email;
                clientResult.Password = client.Password;
                clientResult.FechaActualizacion = DateTime.Now;
                _context.SaveChanges();
                return clientResult;
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Error = ex;
                _logger.LogError(result.Error, "Error durante el proceso de actualizáción del cliente");
                return null;
            }
        }

        /// <summary>
        /// Método de consulta de cliente por Id
        /// </summary>
        public ClientDto GetClientById(int clientId, ref ResultObj result)
        {
            try
            {
                Client clientResult = _context.client.FirstOrDefault(x => x.IdClient == clientId);
                
                if (clientResult is null)
                    return null;

                ClientDto client = new ClientDto()
                {
                    IdClient = clientResult.IdClient,
                    Nombre = clientResult.Nombre,
                    ApellidoPaterno = clientResult.ApellidoPaterno,
                    ApellidoMaterno = clientResult.ApellidoMaterno,
                    Email = clientResult.Email,
                    Password = clientResult.Password,
                    FechaCreacion = clientResult.FechaCreacion,
                    FechaActualizacion = clientResult.FechaActualizacion
                };
                return client;
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Error = ex;
                _logger.LogError(result.Error, "Error durante la obtención del cliente");
                return null;
            }
        }

        /// <summary>
        /// Método para validar si usuario es válido dentro de los clientes existentes en BD
        /// </summary>
        public bool ValidateUser(string email, string password, ref ResultObj result)
        {
            try
            {
                Client clientResult = _context.client.FirstOrDefault(x=> x.Email == email && x.Password == password);
                
                if (clientResult is null)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Error = ex;
                _logger.LogError(result.Error, "Error durante la validación del cliente");
                return false;
            }
        }





    }
}
