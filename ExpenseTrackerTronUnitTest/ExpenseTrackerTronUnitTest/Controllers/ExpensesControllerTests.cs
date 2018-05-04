using ExpenseTrackerTron.Controllers;
using ExpenseTrackerTron.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpenseTrackerTronUnitTest.Controllers
{
    [TestClass]
    public class ExpensesControllerTests
    {
        [TestMethod]
        public void GetExpenseTest()
        {
            //Fetch Single Data Ok
            var ec = new ExpensesController();
            var res = ec.GetExpense(1);

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void GetExpensesTest()
        {
            //Fetch Data Ok
            var ec = new ExpensesController();
            var res = ec.GetExpense(1);

            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void PutExpenseTest()
        {
            var ec = new ExpensesController();
            var res = ec.PutExpense(1, new Expense());
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void PostExpenseTest()
        {
            var ec = new ExpensesController();
            var res = ec.PostExpense(new Expense());
            Assert.IsNotNull(res);
        }

        // Currently not used.
        [TestMethod]
        public void DeleteExpenseTest()
        {
            // Assert.Fail();
        }
    }
}