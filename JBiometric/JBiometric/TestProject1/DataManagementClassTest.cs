using AttendanceKeeper.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AttendanceKeeper.Data;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for DataManagementClassTest and is intended
    ///to contain all DataManagementClassTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataManagementClassTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for LoadEnrolleeAttendanceDTRAll
        ///</summary>
        [TestMethod()]
        [DeploymentItem("AttendanceKeeper.exe")]
        public void LoadEnrolleeAttendanceDTRAllTest()
        {
            List<Enrollee> lEnrollee = null; // TODO: Initialize to an appropriate value
            int iMonth = 0; // TODO: Initialize to an appropriate value
            int iYear = 0; // TODO: Initialize to an appropriate value
            List<MacDumpLog> lMacDumpLogs = null; // TODO: Initialize to an appropriate value
            List<MacDumpLog> lMacDumpLogsExpected = null; // TODO: Initialize to an appropriate value
            List<DTR> expected = null; // TODO: Initialize to an appropriate value
            List<DTR> actual;
            actual = DataManagementClass_Accessor.LoadEnrolleeAttendanceDTRAll(lEnrollee, iMonth, iYear, out lMacDumpLogs);
            Assert.AreEqual(lMacDumpLogsExpected, lMacDumpLogs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
