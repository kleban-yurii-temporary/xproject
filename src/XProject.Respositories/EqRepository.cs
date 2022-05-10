using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProject.Core;
using XProject.WebApp.Data;

namespace XProject.Repositories
{
    public class EqRepository
    {
        private readonly AppDbContext _ctx;
        public EqRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<EquipmentType> GetByIdAsync(int id)
        {
            return await _ctx.EquipmentTypes.FirstAsync(x=> x.Id == id);
        }
    }
}
