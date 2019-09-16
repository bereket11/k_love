using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using k_love.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace k_love.Controllers
{
    public class EmployeeController : Controller
    {
        static int DepID;
        private readonly LoveContext _context;

        public EmployeeController(LoveContext context)
        {
            _context = context;
        }

        public IActionResult IndexWithID(int deptId)
        {
            Department dept = (k_love.Models.Department)_context.Departments.SingleOrDefault(c => c.Id == deptId);
            DepID = dept.Id;
            //var employees = _context.Employees.ToList();
            List<Employee> empys = _context.Employees.Where(c => c.DeptId == dept.Id).ToList();
            ViewData["DName"] = "test";
            ViewBag.DName = "test";
            //ViewBag.DeptName = _context.Departments.FirstOrDefault(x => x.Id == dept.Id).ToString();
            return RedirectToAction(nameof(Index));

    }

        public IActionResult Index()
        {
            List<Employee> employees = _context.Employees.Where(c => c.DeptId == DepID).ToList();
            return View(employees);

        }

        //// GET: Employee/Create
        //public IActionResult GetEmployee()
        //{ 
        //    List<Employee> employees = _context.Employees.Where(c => c.DeptId == DepID).ToList();
        //    return View(employees);
        //}

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,Name,Role,Location,Age,Salary,DeptId")] Employee employee)
        {
            if (ModelState.IsValid)
            {

                //int DeptID = int.Parse(this.RouteData.Values["DeptId"].ToString());
                int id = employee.DeptId = DepID;

                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }


        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.Employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpId,Name,Role,Location,Age,Salary,DeptId")] Employee employee)
        {
            if (id != employee.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        private bool EmployeeExists(int id)
        {
            throw new NotImplementedException();
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
