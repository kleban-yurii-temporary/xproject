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
            CreateMap<LossesReadDto, LossesEquipmentDaily>()
                .AddTransform<int?>(num => num ?? 0).ReverseMap();
        }
    }
}
