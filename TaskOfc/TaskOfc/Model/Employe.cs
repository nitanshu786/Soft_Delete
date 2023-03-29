using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskOfc.Model
{
    public class Employe
    {
        public int ID { get; set; }
        public string Name  { get; set; }
        public string Address  { get; set; }
        public string Email  { get; set; }
        public string Picture { get; set; }
        public bool IsDeleted  { get; set; }


    }
}
