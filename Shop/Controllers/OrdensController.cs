using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    [Authorize]
    public class OrdensController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Claim claim;

        public OrdensController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            claim = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            _context = context;
        }

        // GET: Ordens
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Ordens.Include(t => t.Cliente).ToListAsync());
        }

        // GET: Ordens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // GET: Ordens/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre");
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre");
            return View();
        }

        // POST: Ordens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrdenRef,Direccion,Ciudad,CodigoPostal,Products,ClienteId")] OrdenViewModel orden)
        {
            if (ModelState.IsValid)
            {
                orden.Cliente = _context.Users.FirstOrDefault(c => c.Id == orden.ClienteId);
                _context.Add(orden);
                foreach (var productId in orden.Products)
                {
                    OrdenProducto ordenProducto = new OrdenProducto
                    {
                        ProductoId = productId,
                        OrdenId = orden.Id
                    };

                    _context.Add(ordenProducto);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Products"] = _context.OrdenProductos.ToList();

            return View(orden);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder(int cartId)
        {
            var cliente = _context.Users.FirstOrDefault(c => c.Id == claim.Value);
            var cart = _context.Cart.Include(t => t.Items).FirstOrDefault(c => c.Id == cartId);
            var order = new Orden();
            order.Cliente = cliente;
            order.Direccion = cliente.Address;

            _context.Add(order);
            
            foreach(var item in cart.Items)
            {
                var producto = _context.Productos.FirstOrDefault(i => i.Id == item.ProductoId);
                var orderItem = new OrdenProducto
                {
                    Producto = producto,
                    Orden = order
                };

                _context.Add(orderItem);
            }

            await _context.SaveChangesAsync();

            return View(order);
        }

        // GET: Ordens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordens.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }
            return View(orden);
        }

        // POST: Ordens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrdenRef,Direccion1,Ciudad,CodigoPostal")] Orden orden)
        {
            if (id != orden.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenExists(orden.Id))
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
            return View(orden);
        }

        // GET: Ordens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // POST: Ordens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orden = await _context.Ordens.FindAsync(id);
            _context.Ordens.Remove(orden);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenExists(int id)
        {
            return _context.Ordens.Any(e => e.Id == id);
        }
    }
}
