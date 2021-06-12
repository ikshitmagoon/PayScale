using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCoreAzure.Models;

namespace WebAppCoreAzure.Controllers
{
    public class PayScalesController : Controller
    {
        private readonly PayScaleDbContext _context;

        public PayScalesController(PayScaleDbContext context)
        {
            _context = context;
        }

        // GET: PayScales
        public async Task<IActionResult> Index()
        {
            return View(await _context.PayScale.ToListAsync());
        }

        // GET: PayScales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payScale = await _context.PayScale
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (payScale == null)
            {
                return NotFound();
            }

            return View(payScale);
        }

        // GET: PayScales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PayScales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,PayBand,BasicSalary,Hra,Da,Ta,Tds,NetSalary,InHandSalary")] PayScale payScale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payScale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payScale);
        }

        // GET: PayScales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payScale = await _context.PayScale.FindAsync(id);
            if (payScale == null)
            {
                return NotFound();
            }
            return View(payScale);
        }

        // POST: PayScales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,PayBand,BasicSalary,Hra,Da,Ta,Tds,NetSalary,InHandSalary")] PayScale payScale)
        {
            if (id != payScale.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payScale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayScaleExists(payScale.EmployeeId))
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
            return View(payScale);
        }

        // GET: PayScales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payScale = await _context.PayScale
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (payScale == null)
            {
                return NotFound();
            }

            return View(payScale);
        }

        // POST: PayScales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payScale = await _context.PayScale.FindAsync(id);
            _context.PayScale.Remove(payScale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayScaleExists(int id)
        {
            return _context.PayScale.Any(e => e.EmployeeId == id);
        }
    }
}
