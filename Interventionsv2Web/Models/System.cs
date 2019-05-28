using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Interventionsv2Web.Models
{
    [Table("system")]
    public class System
    {       
        [Key, Column("Id_system")]
        public int Idsystem { get; set; }
        public String Name { get; set; }

        public ICollection<Intervention> Interventions { get; set; }
    }
}
