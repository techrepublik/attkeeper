using System;
using AttendanceKeeper.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AttendanceKeeper.Data;
using System.Collections.Generic;

namespace TestProject2
{
    
    
    /// <summary>
    ///This is a test class for UtilityClassTest and is intended
    ///to contain all UtilityClassTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UtilityClassTest
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
        ///A test for ImportEnrollees
        ///</summary>
        [TestMethod()]
        public void ImportEnrolleesTest()
        {
            string path = @"C:\Users\kryptonite\Desktop\Book1.xls"; // TODO: Initialize to an appropriate value
            //List<Enrollee> expected = null; // TODO: Initialize to an appropriate value
            List<Enrollee> actual;
            actual = UtilityClass.ImportEnrollees(path);
            foreach (var enrollee in actual)
            {
                Console.WriteLine(enrollee.EnrolleeNo.ToString() + " - " + enrollee.LastName.ToUpper());
            }
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
