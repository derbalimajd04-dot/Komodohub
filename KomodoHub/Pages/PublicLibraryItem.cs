using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoHub.Pages
{
    public class PublicLibraryItem
    {
        public int id { get; set; }
        public string title { get; set; } = "";
        public string author { get; set; } = "";
        public string animal_name { get; set; } = "";
        public string species { get; set; } = "";
        public string habitat { get; set; } = "";
        public string conservation_status { get; set; } = "";
        public string content { get; set; } = "";
        public string image_url { get; set; } = "";
        public string created_at { get; set; } = "";
    }
}
