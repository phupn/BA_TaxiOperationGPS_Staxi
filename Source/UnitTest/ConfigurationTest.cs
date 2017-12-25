using Taxi.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taxi.Common.DbBase.Attributes;

namespace UnitTest
{
    
    
    /// <summary>
    ///This is a test class for ConfigurationTest and is intended
    ///to contain all ConfigurationTest Unit Tests
    ///</summary>
    [TableInfo()]
    public class ConfigurationTest
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
        ///A test for GetSoDienThoaiGoiNhanh
        ///</summary>
        [TestMethod()]
        public void GetSoDienThoaiGoiNhanhTest()
        {
            string SoDienThoai = "0432323232";
            string expected = "32323232";
            string actual = Configuration.GetSoDienThoaiGoiNhanh(SoDienThoai);
            Assert.AreEqual(expected, actual);
        }
    }
}
