using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Repositories.Dtos
{
    public class LossesReadDto
    {
        [Name("date")]
        public DateTime? Date { get; set; }

        [Name("day")]
        public int? Day { get; set; }

        [Name("aircraft")]
        public int? Aircraft { get; set; }

        [Name("helicopter")]
        public int? Helicopter { get; set; }

        [Name("tank")]
        public int? Tank { get; set; }

        [Name("APC")]
        public int? APC { get; set; }

        [Name("field artillery")]
        public int? Field_artillery { get; set; }

        [Name("MRL")]
        public int? MRL { get; set; }

        [Name("military auto")]
        public int? Military_auto { get; set; }

        [Name("fuel tank")]
        public int? Fuel_tank { get; set; }

        [Name("drone")]
        public int? Drone { get; set; }

        [Name("naval ship")]
        public int? Naval_ship { get; set; }

        [Name("anti-aircraft warfare")]
        public int? Anti_aircraft_warfare { get; set; }

        [Name("special equipment")]
        public int? Special_equipment { get; set; }

        [Name("mobile SRBM system")]
        public int? Mobile_SRBM_system { get; set; }
    }
}
