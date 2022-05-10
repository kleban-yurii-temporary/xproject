using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XProject.Core
{
    public class DailyEquipmentLosses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public EquipmentType? EquipmentType { get; set; }

        [NotMapped]
        public int CountPlus { get; set; }
    }
}
