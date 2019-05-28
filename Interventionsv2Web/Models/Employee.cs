using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Interventionsv2Web.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key, Column("Id_employee")]
        public int Idemployee { get; set; }
        [Column("Id_capgemini")]
        public String Idcapgemini { get; set; }
        public String Name { get; set; }
        public String Surnames { get; set; }

        public ICollection<Intervention> Interventions { get; set; }
    }
}
