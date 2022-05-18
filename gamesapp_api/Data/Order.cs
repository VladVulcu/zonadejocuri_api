using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gamesapp_api.Data
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Product1 { get; set; }
        public string Product2 { get; set; }
        public string Product3 { get; set; }
        public string Product4 { get; set; }
        public string Product5 { get; set; }
    }
}
