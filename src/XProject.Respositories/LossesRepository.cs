using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProject.Core;
using XProject.Repositories.Dtos;
using XProject.WebApp.Data;

namespace XProject.Repositories
{
    public class LossesRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public LossesRepository(AppDbContext ctx, IMapper mapper)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public async Task<IEnumerable<DailyEquipmentLosses>> GetDataAsync()
        {
            var maxDate = _ctx.DailyLosses.Max(x => x.Date);

            var data = _ctx.DailyLosses.Include(x=> x.EquipmentType).Where(x=> x.Date == maxDate).ToList();  

            return data;
        }


    }
}
