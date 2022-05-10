using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XProject.Core;
using XProject.Repositories.Dtos;
using XProject.Repositories.Json;
using XProject.Repositories.Models;
using XProject.WebApp.Data;

namespace XProject.Repositories
{
    public class UpdateRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IConfiguration _configuration;

        public UpdateRepository(AppDbContext ctx, IConfiguration configuration)
        {
            _ctx = ctx;
            _configuration = configuration;
        }

        public async Task<List<string>> UpdateAsync()
        {
            HttpClient _client = new HttpClient();
            string filePath = _configuration["Update:Url"];

            var messageList = new List<string>();

            var jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.Converters.Add(new Int32JsonConverter());

            var data = await _client.GetStringAsync(filePath);
            data = data.Replace("NaN", "0");

            var list = JsonSerializer.Deserialize<List<LossesReadJson>>(data, jsonSerializerOptions);

            var existing = _ctx.DailyLosses.ToList();

            foreach (var item in list)
            {
                if (!existing.Any(x => x.Date.Date == item.Date))
                {
                    messageList.Add($"Додано дані за {item.Date.Value.ToString("dd.MM.yyyy")}.");

                    await _ctx.DailyLosses.AddRangeAsync(new List<DailyEquipmentLosses> {
                        new DailyEquipmentLosses
                        {
                            Date = item.Date.Value,
                            EquipmentType = await _ctx.EquipmentTypes.FindAsync(1),
                            Count = item.Aircraft
                        },
                        new DailyEquipmentLosses
                        {
                            Date = item.Date.Value,
                            EquipmentType = await _ctx.EquipmentTypes.FindAsync(2),
                            Count = item.Helicopter
                        },
                         new DailyEquipmentLosses
                        {
                            Date = item.Date.Value,
                            EquipmentType = await _ctx.EquipmentTypes.FindAsync(3),
                            Count = item.Drone
                        },
                          new DailyEquipmentLosses
                        {
                            Date = item.Date.Value,
                            EquipmentType = await _ctx.EquipmentTypes.FindAsync(4),
                            Count = item.Anti_aircraft_warfare
                        },
                        new DailyEquipmentLosses
                        {
                            Date = item.Date.Value,
                            EquipmentType = await _ctx.EquipmentTypes.FindAsync(5),
                            Count = item.Cruise_missiles
                        },
                         new DailyEquipmentLosses
                        {
                            Date = item.Date.Value,
                            EquipmentType = await _ctx.EquipmentTypes.FindAsync(6),
                            Count = item.Tank
                        },
                           new DailyEquipmentLosses
                        {
                            Date = item.Date.Value,
                            EquipmentType = await _ctx.EquipmentTypes.FindAsync(7),
                            Count = item.APC
                        },
                                 new DailyEquipmentLosses
                        {
                            Date = item.Date.Value,
                            EquipmentType = await _ctx.EquipmentTypes.FindAsync(8),
                            Count = item.Field_artillery
                        },
                        new DailyEquipmentLosses
                        {
                            Date = item.Date.Value,
                            EquipmentType = await _ctx.EquipmentTypes.FindAsync(9),
                            Count = item.MRL
                        },
                        new DailyEquipmentLosses
                        {
                            Date = item.Date.Value,
                            EquipmentType = await _ctx.EquipmentTypes.FindAsync(10),
                            Count = item.Fuel_tank + item.Vehicles_and_fuel_tanks + item.Military_auto
                    },
                        new DailyEquipmentLosses
                        {
                            Date = item.Date.Value,
                            EquipmentType = await _ctx.EquipmentTypes.FindAsync(11),
                            Count = item.Naval_ship
                        },
                           new DailyEquipmentLosses
                        {
                            Date = item.Date.Value,
                            EquipmentType = await _ctx.EquipmentTypes.FindAsync(12),
                            Count = item.Special_equipment
                        }
                    });

                }
            }

            if (!messageList.Any())
            {
                messageList.Add($"[{DateTime.Now.ToString("dd.MM.yyyy")}] Оновлення відсутні");
            }
            else
            {
                _ctx.Options.First(x => x.Key == "latest_update").Value = DateTime.Now.ToString("dd.MM.yyyy");
                await _ctx.SaveChangesAsync();

            }

            return messageList;
        }
    }
}
