using Dating_API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating_API.Interface
{
    public interface ITokenServices
    {
        string CreateToken(AppUser u);
    }
}
