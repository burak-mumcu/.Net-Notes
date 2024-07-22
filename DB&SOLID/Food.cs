using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_SOLID
{
    public class Food
    {
        public int id {  get; set; }
        public required string name { get; set; }
        public required decimal price { get; set; }
        public string? description { get; set; }
        
    }
}
