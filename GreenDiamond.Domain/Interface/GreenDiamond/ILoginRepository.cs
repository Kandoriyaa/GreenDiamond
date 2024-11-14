using GreenDiamond.Domain.ErpEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDiamond.Domain.Interface.GreenDiamond
{
    public interface ILoginRepository
    {
        Task<Login> LoginBy(string username, string password);
    }
}
