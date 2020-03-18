using System;
using System.Collections.Generic;
using System.Collections;

namespace MIMS.DAL.Models
{
    public partial class Deviceslotsmapping
    {
        public int Id { get; set; }
        public int Deviceid { get; set; }
        public int Slotid { get; set; }
        public BitArray Active { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }

        public virtual Testdevices Device { get; set; }
        public virtual Deviceslotsmaster Slot { get; set; }
    }
}
