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

        public async Task<IEnumerable<DailyEquipmentLosses>> GetDataAsync(string? date = null)
        {
            var maxDate = _ctx.DailyLosses.Max(x => x.Date);

            var data = _ctx.DailyLosses.Include(x => x.EquipmentType).Where(x => x.Date == maxDate).ToList();
            var dataBefore = _ctx.DailyLosses.Include(x => x.EquipmentType).Where(x => x.Date == maxDate.AddDays(-1)).ToList();

            for (int i = 0; i < data.Count; i++)
            {
                data[i].CountPlus = data[i].Count - dataBefore[i].Count;
            }

            return data;
        }

        public async Task<string> GetMaxDateAsStringAsync()
        {
            if (_ctx.DailyLosses.Any())
                return (await _ctx.DailyLosses.MaxAsync(x => x.Date)).ToString("dd.MM.yyyy");
            return DateTime.Now.ToString("dd.MM.yyyy");
        }

        public async Task<KeyValuePair<List<string>, List<int>>> GetMiniChartDataAsync(int id)
        {
            var eqt = await _ctx.DailyLosses.Where(x => x.EquipmentType.Id == id)
                .OrderByDescending(x => x.Date).Take(14)
                .OrderBy(x => x.Date).ToListAsync();

            var data = new KeyValuePair<List<string>, List<int>>(
                eqt.Select(x => "d" + x.Date.ToString("ddMMyyyy")).ToList(),
                eqt.Select(x => x.Count).ToList());

            return data;
        }

        public async Task<IEnumerable<DailyEquipmentLosses>> GetMiniChartDataAsync2(int id)
        {
            var data = await _ctx.DailyLosses.Where(x => x.EquipmentType.Id == id)
                .OrderByDescending(x => x.Date).Take(14)
                .OrderBy(x => x.Date).ToListAsync();

            return data;
        }
    }
}
