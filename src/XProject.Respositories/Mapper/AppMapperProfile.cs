using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XProject.Core;
using XProject.Repositories.Dtos;

namespace XProject.Repositories.Mapper
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            //CreateMap<LossesReadDto, LossesEquipmentDaily>()
            //    .AddTransform<int?>(num => num ?? 0).ReverseMap();

           /* CreateMap<LossesReadDto, LossesEquipmentDaily>()
                .ForMember(LossesEquipmentDaily => LossesEquipmentDaily.Date,
                    opt => opt.MapFrom(LossesReadDto => LossesReadDto.Date))

                .ForMember(LossesEquipmentDaily => LossesEquipmentDaily.Day,
                    opt => opt.MapFrom(LossesReadDto => LossesReadDto.Day))

                .ForMember(LossesEquipmentDaily => LossesEquipmentDaily.Aircraft,
                    opt => opt.MapFrom(LossesReadDto => LossesReadDto.Aircraft))

                .ForMember(LossesEquipmentDaily => LossesEquipmentDaily.Helicopter,
                    opt => opt.MapFrom(LossesReadDto => LossesReadDto.Helicopter))

                .ForMember(LossesEquipmentDaily => LossesEquipmentDaily.Tank,
                    opt => opt.MapFrom(LossesReadDto => LossesReadDto.Tank))

                .ForMember(LossesEquipmentDaily => LossesEquipmentDaily.APC,
                    opt => opt.MapFrom(LossesReadDto => LossesReadDto.APC))

                .ForMember(LossesEquipmentDaily => LossesEquipmentDaily.Field_artillery,
                    opt => opt.MapFrom(LossesReadDto => LossesReadDto.Field_artillery))

                .ForMember(LossesEquipmentDaily => LossesEquipmentDaily.MRL,
                    opt => opt.MapFrom(LossesReadDto => LossesReadDto.MRL))

                .ForMember(LossesEquipmentDaily => LossesEquipmentDaily.Military_auto,
                    opt => opt.MapFrom(LossesReadDto => LossesReadDto.Military_auto))

                .ForMember(LossesEquipmentDaily => LossesEquipmentDaily.Fuel_tank,
                    opt => opt.MapFrom(LossesReadDto => LossesReadDto.Fuel_tank))

                .ForMember(LossesEquipmentDaily => LossesEquipmentDaily.Drone,
                    opt => opt.MapFrom(LossesReadDto => LossesReadDto.Drone))

                .ForMember(LossesEquipmentDaily => LossesEquipmentDaily.Naval_ship,
                    opt => opt.MapFrom(LossesReadDto => LossesReadDto.Naval_ship))

                .ForMember(LossesEquipmentDaily => LossesEquipmentDaily.Anti_aircraft_warfare,
                    opt => opt.MapFrom(LossesReadDto => LossesReadDto.Anti_aircraft_warfare))

                .ForMember(LossesEquipmentDaily => LossesEquipmentDaily.Special_equipment,
                    opt => opt.MapFrom(LossesReadDto => LossesReadDto.Special_equipment))

                .ForMember(LossesEquipmentDaily => LossesEquipmentDaily.Mobile_SRBM_system,
                    opt => opt.MapFrom(LossesReadDto => LossesReadDto.Mobile_SRBM_system));*/
        }
    }
}
