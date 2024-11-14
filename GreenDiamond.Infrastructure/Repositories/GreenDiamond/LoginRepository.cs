using GreenDiamond.Domain.ErpEntities;
using GreenDiamond.Domain.Interface.GreenDiamond;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenDiamond.Infrastructure.Repositories.GreenDiamond
{
    public class LoginRepository : ILoginRepository
    {
        private readonly GreenDiamondContext _context;

        public LoginRepository(GreenDiamondContext context)
        {
            _context = context;
        }

        public async Task<Login> LoginBy(string username, string password)
        {
           var query = await(from LG in _context.Logins
                            where LG.UserName == username && LG.Password == password
                            select new Login
                            {
                                Id = LG.Id,
                                UserName = username,
                                Password = password
                            }).FirstOrDefaultAsync();

            return query;
        }
    }
}
