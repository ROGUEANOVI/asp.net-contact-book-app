using ContactBookApp.Data;
using ContactBookApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactBookApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Contacts.ToList());
        }


        [HttpGet]
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();

            var contact = _context.Contacts.Find(id);

            if (contact == null) return NotFound();

            return View(contact);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid) {
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();

                TempData["Mensaje"] = "Contacto creado exitosamente";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        [HttpGet]
        public  IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var contact = _context.Contacts.Find(id);

            if (contact == null) return NotFound();

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Update(contact);
                await _context.SaveChangesAsync();

                TempData["Mensaje"] = "Contacto actualizado exitosamente";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var contact = _context.Contacts.Find(id);

            if (contact == null) return NotFound();

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)return NotFound();

            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null) return View();
                
            _context.Remove(contact);
            await _context.SaveChangesAsync();

            TempData["Mensaje"] = "Contacto eliminado exitosamente";
            return RedirectToAction(nameof(Index));
        }
    }
}
