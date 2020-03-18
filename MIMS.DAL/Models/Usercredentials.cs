using System;
using System.Collections.Generic;
using System.Collections;

namespace MIMS.DAL.Models
{
    public partial class Usercredentials
    {
        public Usercredentials()
        {
            Patientdetails = new HashSet<Patientdetails>();
            Staffdetails = new HashSet<Staffdetails>();
        }

        public int Credentialid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public BitArray Active { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }

        public virtual ICollection<Patientdetails> Patientdetails { get; set; }
        public virtual ICollection<Staffdetails> Staffdetails { get; set; }
    }
}
