using System;
using System.Collections.Generic;
using System.Collections;

namespace MIMS.DAL.Models
{
    public partial class Devicetechnicianmapping
    {
        public int Id { get; set; }
        public int Deviceid { get; set; }
        public int Technicianid { get; set; }
        public BitArray Active { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }

        public virtual Testdevices Device { get; set; }
        public virtual Staffdetails Technician { get; set; }
    }
}
