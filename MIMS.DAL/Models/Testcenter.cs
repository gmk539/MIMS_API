using System;
using System.Collections.Generic;
using System.Collections;

namespace MIMS.DAL.Models
{
    public partial class Testcenter
    {
        public Testcenter()
        {
            Testdevices = new HashSet<Testdevices>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public BitArray Active { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }

        public virtual ICollection<Testdevices> Testdevices { get; set; }
    }
}
