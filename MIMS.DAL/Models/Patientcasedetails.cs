using System;
using System.Collections.Generic;
using System.Collections;

namespace MIMS.DAL.Models
{
    public partial class Patientcasedetails
    {
        public Patientcasedetails()
        {
            Patientcaselog = new HashSet<Patientcaselog>();
        }

        public int Caseid { get; set; }
        public int Patientid { get; set; }
        public int Doctorid { get; set; }
        public int Slotid { get; set; }
        public int Deviceid { get; set; }
        public string Comments { get; set; }
        public BitArray Active { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }

        public virtual Testdevices Device { get; set; }
        public virtual Staffdetails Doctor { get; set; }
        public virtual Patientdetails Patient { get; set; }
        public virtual Deviceslotsmaster Slot { get; set; }
        public virtual ICollection<Patientcaselog> Patientcaselog { get; set; }
    }
}
