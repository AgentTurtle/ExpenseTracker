using ExpenseTrackerTron.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpenseTrackerTronUnitTest.Controllers
{
    [TestClass]
    public class CategoriesControllerTests
    {
        [TestMethod]
        public void GetCategoryTest()
        {
            //Fetch Single Data Ok
            var cc = new CategoriesController();
            var res = cc.GetCategory(1);

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetCategoriesTest()
        {
            //Fetch Data Ok
            var cc = new CategoriesController();
            cc.GetCategories();

            Assert.IsNotNull(cc);
        }

        // Currently not used.
        [TestMethod]
        public void PutCategoryTest()
        {
            // Assert.Fail();
        }

        // Currently not used.
        [TestMethod]
        public void PostCategoryTest()
        {
            // Assert.Fail();
        }

        // Currently not used.
        [TestMethod]
        public void DeleteCategoryTest()
        {
            // Assert.Fail();
        }
    }
}