using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ExpenseTrackerTron.Models;

namespace ExpenseTrackerTron.Controllers
{
    public class ExpensesController : ApiController
    {
        private readonly ExpenseTrackerTronContext _db = new ExpenseTrackerTronContext();

        // GET: api/Expenses
        public IQueryable<ExpenseDTO> GetExpenses()
        {
            var expenses = from b in _db.Expenses
                        select new ExpenseDTO()
                        {
                            Id = b.Id,
                            Description = b.Description,
                            CategoryName = b.Category.Name
                        };

            return expenses;
        }

        // GET: api/Expenses/5
        [ResponseType(typeof(ExpenseDetailDTO))]
        public async Task<IHttpActionResult> GetExpense(int id)
        {
            var expense = await _db.Expenses.Include(b => b.Category).Select(b =>
                new ExpenseDetailDTO()
                {
                    Id = b.Id,
                    Description = b.Description,
                    DueDate = b.DueDate,
                    Amount = b.Amount,
                    CategoryName = b.Category.Name
                }).SingleOrDefaultAsync(b => b.Id == id);
            if (expense == null)
            {
                return NotFound();
            }
            return Ok(expense);
        }

        // PUT: api/Expenses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExpense(int id, Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expense.Id)
            {
                return BadRequest();
            }

            _db.Entry(expense).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Expenses
        [ResponseType(typeof(Expense))]
        public async Task<IHttpActionResult> PostExpense(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Expenses.Add(expense);
            await _db.SaveChangesAsync();

            // Load category name
            _db.Entry(expense).Reference(x => x.Category).Load();

            var dto = new ExpenseDTO()
            {
                Id = expense.Id,
                Description = expense.Description,
                CategoryName = expense.Category.Name
            };
            return CreatedAtRoute("DefaultApi", new { id = expense.Id }, dto);
        }

        // DELETE: api/Expenses/5
        [ResponseType(typeof(Expense))]
        public async Task<IHttpActionResult> DeleteExpense(int id)
        {
            Expense expense = await _db.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            _db.Expenses.Remove(expense);
            await _db.SaveChangesAsync();

            return Ok(expense);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExpenseExists(int id)
        {
            return _db.Expenses.Count(e => e.Id == id) > 0;
        }
    }
}