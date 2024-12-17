using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Object_Tier;

namespace Interface_Tier
{
     public interface IClients
    {
        int AddClient(Client client);
        bool RemoveClient(int idClient);
        bool ExistClient(int idClient);
        bool UpdateContact(int idClient, int contacto);
        Client GetClient(int idClient);

    }
}
