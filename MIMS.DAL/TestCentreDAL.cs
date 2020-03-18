using MIMS.DAL.Interfaces;
using MIMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIMS.DAL
{
    public class TestCentreDAL : ITestCentreDAL
    {
        public IList<Testcenter> GetTestCentres()
        {
            IList<Testcenter> objTestCenters = new List<Testcenter>();
            using (var dbContext = new mimsContext())
            {
                objTestCenters = dbContext.Testcenter.ToList();
            }
            return objTestCenters;
        }

        public Testcenter GetTestCentreDtailsById(int id)
        {
            Testcenter objTestCenter = new Testcenter();
            using (var dbContext = new mimsContext())
            {
                objTestCenter = dbContext.Testcenter.Where(obj => obj.Id == id).Select(obj => obj).FirstOrDefault();
            }
            return objTestCenter;
        }

        public string SaveTestCenter(Testcenter objTestCenter)
        {
            string status = string.Empty;
            using (var dbContext = new mimsContext())
            {
                dbContext.Testcenter.Add(objTestCenter);
                dbContext.SaveChanges();
            }
            return "Success";
        }

        public string UpdateTestCenter(Testcenter objTestCenter)
        {
            string status = string.Empty;
            using (var dbContext = new mimsContext())
            {
                var _objTestCenter =  dbContext.Testcenter.SingleOrDefault(b => b.Id == objTestCenter.Id);
                objTestCenter.Updatedon = DateTime.Now;
                dbContext.Entry(_objTestCenter).CurrentValues.SetValues(objTestCenter);
                dbContext.SaveChanges();
            }
            return "Success";
        }

        public string DeactivateTestCenterById(int id)
        {
            string status = string.Empty;
            using (var dbContext = new mimsContext())
            {
                Testcenter _objTestCenter = dbContext.Testcenter.Where(obj => obj.Id == id).Select(obj => obj).FirstOrDefault();
                _objTestCenter.Updatedon = DateTime.Now;
                _objTestCenter.Active = new System.Collections.BitArray(1,false);
                dbContext.SaveChanges();
            }
            return "Success";
        }
    }
}
