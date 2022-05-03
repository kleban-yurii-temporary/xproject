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
           /* var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ","
            };*/

            List<LossesReadDto> records = new List<LossesReadDto>();

           /* using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                records = csv.GetRecords<LossesReadDto>().ToList();
            }*/

            //  var losses = _mapper.Map<IEnumerable<LossesEquipmentDaily>>(records.ToList());

           // var losses = records.Select(x => new LossesEquipmentDaily
          //  {
                /*Aircraft = x.Aircraft,
                Anti_aircraft_warfare = x.Anti_aircraft_warfare,
                APC = x.APC,
                Date = x.Date,
                Day = x.Day,
                Drone = x.Drone,    
                Field_artillery = x.Field_artillery,
                Fuel_tank = x.Fuel_tank,
                Helicopter = x.Helicopter,
                Military_auto = x.Military_auto,
                Mobile_SRBM_system = x.Mobile_SRBM_system,
                MRL = x.MRL,
                Naval_ship = x.Naval_ship,
                Special_equipment = x.Special_equipment,
                Tank = x.Tank*/
           // });

            if (_ctx.LossesEquipment.Any())
            {
                _ctx.LossesEquipment.RemoveRange(_ctx.LossesEquipment.ToList());
                await _ctx.SaveChangesAsync();
            }

            for (int i = 0; i < 10; i++)
            {
                await _ctx.LossesEquipment.AddAsync(new LossesEquipmentDaily
                {
                    Date = DateTime.Now                    
                });
                //await _ctx.LossesEquipment.AddRangeAsync(losses);
            }
            await _ctx.SaveChangesAsync();

            return records;
        }
    }
}
