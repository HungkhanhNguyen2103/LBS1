using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class UserMinuteModel
    {
        public string? UserName { get; set; }
        public int ReadMinute { get; set; }
        public int ListenMinute { get; set; }
        //Sunday = 0,
        //Monday = 1,
        //Tuesday = 2,
        //Wednesday = 3,
        //Thursday = 4,
        //Friday = 5,
        //Saturday = 6
        public DayOfWeek DayOfWeek { get; set; }
        public string DayOfWeekStr { get; set; }
        public DateTime Day { get; set; }
        public bool IsToday { get; set; }
    }
}
