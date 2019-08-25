using System;
using System.Collections.Generic;
using System.Text;

namespace Timelogger.Entities
{
    public class Work
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int HoursSpend { get; set; }
    }
}
