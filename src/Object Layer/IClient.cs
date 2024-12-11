using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Layer
{
    internal interface IClient : IPerson
    {
        int ContactInfo {get; set;}
    }
}
