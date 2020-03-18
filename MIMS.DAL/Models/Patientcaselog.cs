using System;
using System.Collections.Generic;
using System.Collections;

namespace MIMS.DAL.Models
{
    public partial class Patientcaselog
    {
        public int Id { get; set; }
        public int Caseid { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public BitArray Iscurrentstatus { get; set; }
        public BitArray Active { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }

        public virtual Patientcasedetails Case { get; set; }
    }
}
