using BokifyGrad.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokifyGrad.BLL.Services.Interfaces
{
    namespace BokifyGrad.BLL.Interfaces
    {
        public interface ITokenService
        {
            string CreateToken(ApplicationUser user);
        }
    }

}
