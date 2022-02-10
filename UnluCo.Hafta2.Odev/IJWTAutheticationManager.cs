using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.Hafta2.Odev
{
    //Middlewarede auth işlemlerini yönetecek olan classın implement edeceği interface
    public interface IJWTAutheticationManager
    {
        string Autheticate(User user);
    }
}