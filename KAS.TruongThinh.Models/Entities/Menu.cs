using System;
using System.Collections.Generic;
using System.Text;

namespace KAS.TruongThinh.Models.Entities
{
    public class Menu
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public string URL { set; get; }

        public int? DisplayOrder { set; get; }

        public string Target { set; get; }

        public bool Status { set; get; }
    }
}
