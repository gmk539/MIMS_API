using System;
using System.Collections.Generic;
using System.Collections;

namespace MIMS.DAL.Models
{
    public partial class Staffdetails
    {
        public Staffdetails()
        {
            Devicetechnicianmapping = new HashSet<Devicetechnicianmapping>();
            Patientcasedetails = new HashSet<Patientcasedetails>();
        }

        public int Userid { get; set; }
        public int Credentialid { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Role { get; set; }
        public string Phonenumber { get; set; }
        public string Emailid { get; set; }
        public string Address { get; set; }
        public BitArray Active { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }

        public virtual Usercredentials Credential { get; set; }
        public virtual ICollection<Devicetechnicianmapping> Devicetechnicianmapping { get; set; }
        public virtual ICollection<Patientcasedetails> Patientcasedetails { get; set; }
    }
}
