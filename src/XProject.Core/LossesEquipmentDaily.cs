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
        public DateTime Date { get; set; } = new DateTime(2000, 1, 1);
        public int Day { get; set; } = 0;
        public int Aircraft { get; set; } = 0;
        public int Helicopter { get; set; } = 0;
        public int Tank { get; set; } = 0;
        public int APC { get; set; } = 0;
        public int Field_artillery { get; set; } = 0;
        public int MRL { get; set; } = 0;
        public int Military_auto { get; set; } = 0;
        public int Fuel_tank { get; set; } = 0;
        public int Drone { get; set; } = 0;
        public int Naval_ship { get; set; } = 0;
        public int Anti_aircraft_warfare { get; set; } = 0;
        public int Special_equipment { get; set; } = 0;
        public int Mobile_SRBM_system { get; set; } = 0;
    }
}
