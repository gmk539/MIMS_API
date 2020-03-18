using System;
using System.Collections.Generic;
using System.Collections;

namespace MIMS.DAL.Models
{
    public partial class Deviceslotsmaster
    {
        public Deviceslotsmaster()
        {
            Deviceslotsmapping = new HashSet<Deviceslotsmapping>();
            Patientcasedetails = new HashSet<Patientcasedetails>();
        }

        public int Slotid { get; set; }
        public string Fromtime { get; set; }
        public string Totime { get; set; }
        public BitArray Active { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }

        public virtual ICollection<Deviceslotsmapping> Deviceslotsmapping { get; set; }
        public virtual ICollection<Patientcasedetails> Patientcasedetails { get; set; }
    }
}
