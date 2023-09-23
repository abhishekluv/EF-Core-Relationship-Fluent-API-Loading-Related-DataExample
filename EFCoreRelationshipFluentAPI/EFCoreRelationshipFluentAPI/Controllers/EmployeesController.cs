using EFCoreRelationshipFluentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipFluentAPI.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MyApplicationContext _context;

        public EmployeesController(MyApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [OutputCache(Duration = 60)]
        public IActionResult Index()
        {
            var employees = _context.Employees
                                    .Include(x => x.Profile)
                                    .Include(x => x.Department)
                                    .Include(x => x.Skills)
                                    .AsSingleQuery()
                                    .ToList();

            return View(employees);
        }
    }
}
