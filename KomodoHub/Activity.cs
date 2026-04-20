using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoHub
{
    public class Activity
    {
        public string activity_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string activity_type { get; set; }
        public string due_date { get; set; }
        public string image_path { get; set; }
    }
}