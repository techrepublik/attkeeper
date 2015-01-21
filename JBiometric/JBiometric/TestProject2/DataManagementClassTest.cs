using AttendanceKeeper.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AttendanceKeeper.Data;
using System.Collections.Generic;
using System;

namespace TestProject2
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
            //List<Enrollee> lEnrollee = ActionClass_Accessor.FillEnrollees(true); // TODO: Initialize to an appropriate value
            //int iMonth = 2; // TODO: Initialize to an appropriate value
            //int iYear = 2011; // TODO: Initialize to an appropriate value
            //List<MacDumpLog> lMacDumpLogs = null; // TODO: Initialize to an appropriate value
            ////List<MacDumpLog> lMacDumpLogsExpected = null; // TODO: Initialize to an appropriate value
            ////List<DTR> expected = null; // TODO: Initialize to an appropriate value
            //List<DTR> actual;
            //actual = DataManagementClass_Accessor.LoadEnrolleeAttendanceDTRAll(lEnrollee, out lMacDumpLogs);
            ////Assert.AreEqual(lMacDumpLogsExpected, lMacDumpLogs);
            ////Assert.AreEqual(expected, actual);
            ////Assert.Inconclusive("Verify the correctness of this test method.");
            //foreach (var dtr in actual)
            //{
            //    Console.WriteLine(@"{0}, {1}", dtr.EnrolleeNo.ToString(), dtr.DTRDate.ToString());
            //}
        }
    }
}
