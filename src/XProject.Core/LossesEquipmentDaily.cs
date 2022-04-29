using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Core
{
    public class LossesEquipmentDaily
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public int? Day { get; set; }
        public int? Aircraft { get; set; }
        public int? Helicopter { get; set; }
        public int? Tank { get; set; }
        public int? APC { get; set; }
        public int? Field_artillery { get; set; }
        public int? MRL { get; set; }
        public int? Military_auto { get; set; }
        public int? Fuel_tank { get; set; }
        public int? Drone { get; set; }
        public int? Naval_ship { get; set; }
        public int? Anti_aircraft_warfare { get; set; }
        public int? Special_equipment { get; set; }
        public int? Mobile_SRBM_system { get; set; }
    }
}
