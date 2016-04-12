using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEM.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace SEM.Tests.WCF
{
    /// <summary>
    /// Summary description for GetJournalTest
    /// </summary>
    [TestClass]
    public class GetJournalTest
    {
        public GetJournalTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private const string Password = "password";
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

        [TestMethod][Ignore] //("Need WCF service running and connected to same DB")
        public void TestGetJournal()
        {
            // create a user
            var db = new ApplicationDbContext();
            var user = db.Users.Create();
            user.Email = "test@test.test";

            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            um.Create(user, Password);

            var service = new SemWcfServiceReference.ServiceJournalsAccessClient();
            
            var subs = service.GetMySubscriptions(user.Email, Password);

            //var subscription
            //user.Subscriptions.Add()
            // ...integration
        }
    }
}
