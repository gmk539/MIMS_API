using System;
using System.Collections.Generic;
using System.Text;
using MIMS.BL.Interfaces;
using MIMS.DAL.Interfaces;
using MIMS.DAL.Models;

namespace MIMS.BL
{
    public class TestCentreBL : Interfaces.ITestCentreBL
    {

        private ITestCentreDAL dal;
        public TestCentreBL(ITestCentreDAL _objTestCenterDAL)
        {
            dal = _objTestCenterDAL;
        }

        public IList<Testcenter> GetTestCentres()
        {

            return dal.GetTestCentres();
        }

        public Testcenter GetTestCentreDtailsById(int id)
        {
            return dal.GetTestCentreDtailsById(id);
        }

        public string SaveTestCenter(Testcenter objTestCenter)
        {
            return dal.SaveTestCenter(objTestCenter);
        }

        public string UpdateTestCenter(Testcenter objTestCenter)
        {
            return dal.UpdateTestCenter(objTestCenter);
        }

        public string DeactivateTestCenterById(int id)
        {
            return dal.DeactivateTestCenterById(id);
        }
    }
}
