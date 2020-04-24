using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanSimplyByCJ.Models
{
    public class GalleryModel
    {
        public IEnumerable<string> fileNames { get; set; }
        public IEnumerable<string> captions { get; set; }
        public IEnumerable<string> thumbnails { get; set; }
        public string title { get; set; }

        public string descriptions { get; set; }
        public Dictionary<string, string[]> accredits;
    }
}