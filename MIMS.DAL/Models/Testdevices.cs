using System;
using System.Collections.Generic;
using System.Collections;

namespace MIMS.DAL.Models
{
    public partial class Testdevices
    {
        public Testdevices()
        {
            Deviceslotsmapping = new HashSet<Deviceslotsmapping>();
            Devicetechnicianmapping = new HashSet<Devicetechnicianmapping>();
            Patientcasedetails = new HashSet<Patientcasedetails>();
        }

        public int Deviceid { get; set; }
        public string Devicename { get; set; }
        public string Devicetype { get; set; }
        public int Locationid { get; set; }
        public BitArray Active { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }

        public virtual Testcenter Location { get; set; }
        public virtual ICollection<Deviceslotsmapping> Deviceslotsmapping { get; set; }
        public virtual ICollection<Devicetechnicianmapping> Devicetechnicianmapping { get; set; }
        public virtual ICollection<Patientcasedetails> Patientcasedetails { get; set; }
    }
}
