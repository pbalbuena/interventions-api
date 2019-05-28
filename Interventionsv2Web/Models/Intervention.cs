using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Interventionsv2Web.Models
{
    [Table("intervention")]
    public class Intervention
    {
        [Key, Column("Id_intervention")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idintervention { get; set; }
        [ForeignKey("Id_employee"), Column("Id_employee")]
        public int Idemployee { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("Id_system"), Column("Id_system")]
        public int Idsystem { get; set; }
        public System System { get; set; }
        public DateTime Date { get; set; }
        public int Complexity_level { get; set; }
        public String Description { get; set; }
        public String Workaround { get; set; }
        public String Comment { get; set; }
        public int isDeleted { get; set; }
    }
}
