using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class CategoryParameters
    {
        public string OrderBy { get; set; } = "Name"; //Varsayılan sıralama
        public String? SearchTerm { get; set; }

    }
}
