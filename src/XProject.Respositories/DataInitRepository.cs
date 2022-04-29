using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProject.Core;
using XProject.Repositories.Dtos;
using XProject.WebApp.Data;

namespace XProject.Repositories
{
    public class DataInitRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public DataInitRepository(AppDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LossesReadDto>> ParseDataFile(string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ","
            };

            List<LossesReadDto> records;

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                records = csv.GetRecords<LossesReadDto>().ToList();
            }

            var losses = _mapper.Map<IEnumerable<LossesEquipmentDaily>>(records.ToList());

            await _ctx.LossesEquipment.AddRangeAsync(losses);
            await _ctx.SaveChangesAsync();

            return records;
        }
    }
}
