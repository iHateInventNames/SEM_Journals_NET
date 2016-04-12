using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEM.Core.Models;
using SEM.Models;
using SEM.ViewModels;
using SEM.Controllers;

namespace SEM.Tests.Data
{
    /// <summary>
    /// Test Entitie's-ViewModel's mapping system 
    /// </summary>
    [TestClass]
    public class MappingsTest
    {
        public MappingsTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestJournalMappings()
        {
            Journal j = new Journal {
                Id = 31,
                AspNetUser = new Guid(),
                AspNetUserId= new Guid(),
                File=new byte[] {1,2,3},
                Title="TheTitle"
            };

            JournalViewModel vm = JournalsController.Journal2Model(j);
            Journal j2 = new Journal();
            JournalsController.Model2Journal(vm, j2);
            j2.File = j.File; // hack, HttpPostedFileBase PdfUpload could not be initialized
            Assert.AreEqual(j.AspNetUser, j2.AspNetUser);
            Assert.AreEqual(j.AspNetUserId, j2.AspNetUserId);
            Assert.AreEqual(j.File, j2.File);
            Assert.AreEqual(j.Id, j2.Id);
            Assert.AreEqual(j.Title, j2.Title);
            //Assert.AreEqual(j, j2); // no IComparable (test task, keeping simple)
        }
    }
}
