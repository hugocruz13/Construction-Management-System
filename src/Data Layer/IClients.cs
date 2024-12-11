using Data_Tier;
using Object_Tier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Tier
{
    internal interface IClients
    {
        short AddClient(Client client);
        bool ExistClient(short idCliente);
        bool UpdateContact(short idClient, int contacto);
        
        
    }
}
