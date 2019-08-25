using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Timelogger.Api.Entities
{
    public class WorkData
    {
        public int UserId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int HoursSpend { get; set; }
    }
}
