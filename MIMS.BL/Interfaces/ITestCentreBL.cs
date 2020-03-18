using MIMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MIMS.BL.Interfaces
{
    public interface ITestCentreBL
    {
        IList<Testcenter> GetTestCentres();
        Testcenter GetTestCentreDtailsById(int id);
        string SaveTestCenter(Testcenter objTestCenter);

        string UpdateTestCenter(Testcenter objTestCenter);
        string DeactivateTestCenterById(int id);
    }
}
