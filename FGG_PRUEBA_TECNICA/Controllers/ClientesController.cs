using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FGG_PRUEBA_TECNICA.Data;
using FGG_PRUEBA_TECNICA.Models;

namespace FGG_PRUEBA_TECNICA
{
    public class ClientesController : Controller
    {
        private readonly BBDDContext _context;

        public ClientesController(BBDDContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index(string CodClienteSearch = null, string NombreSearch = null, string FechaInicioSearch = null, string CodigoComercialSearch = null, string ActivoSearch = null)
        {
            if(CodClienteSearch != null || NombreSearch != null || FechaInicioSearch != null || CodigoComercialSearch != null || ActivoSearch != null)
            {
                return View(await _context.Clientes.FromSqlRaw("SELECT * FROM dbo.Clientes Where Activo ='"+ ActivoSearch + "' AND CodCliente='" + CodClienteSearch + "' AND Nombre='" + NombreSearch + "' AND FechaInicio='" + FechaInicioSearch + "' AND CodigoComercial='" + CodigoComercialSearch + "'").ToListAsync());

            }
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.idClientes == id);

            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idClientes,CodCliente,Nombre,FechaInicio,CodigoComercial,Activo")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idClientes,CodCliente,Nombre,FechaInicio,CodigoComercial,Activo")] Clientes clientes)
        {
            if (id != clientes.idClientes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.idClientes))
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
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.idClientes == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesExists(int id)
        {
            return _context.Clientes.Any(e => e.idClientes == id);
        }
    }
}
