using EdenredTest.Model.Dto;

namespace EdenredTest.Model.Interfaces
{
    public interface IClientDao
    {
        void CreateClient(ClientManagementDto client, ref ResultObj result);
        Client UpdateClient(int clientId, ClientManagementDto client, ref ResultObj result);
        ClientDto GetClientById(int clientId, ref ResultObj result);
        bool ValidateUser(string email, string password, ref ResultObj result);

    }
}
