using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<LossesReadDto> GetAsync(DateTime date)
        {
            var data = _ctx.LossesEquipment.FirstOrDefault(x => x.Date.Date == date.Date);
           
            if(data == null)
            {
                data = await _ctx.LossesEquipment.FirstAsync(x => x.Date == _ctx.LossesEquipment.Max(x => x.Date));
            }

            return _mapper.Map<LossesReadDto>(data);
        }
    }
}
