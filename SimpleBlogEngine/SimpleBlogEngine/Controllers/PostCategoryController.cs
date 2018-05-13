using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleBlogEngine.Data;
using SimpleBlogEngine.Models.Blog;
using Microsoft.AspNetCore.Authorization;

namespace SimpleBlogEngine.Controllers
{
    [Authorize]
    public class PostCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostCategories.ToListAsync());
        }

        // GET: PostCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCategory = await _context.PostCategories
                .SingleOrDefaultAsync(m => m.Id == id);
            if (postCategory == null)
            {
                return NotFound();
            }

            return View(postCategory);
        }

        // GET: PostCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,CreatedDate")] PostCategory postCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postCategory);
        }

        // GET: PostCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCategory = await _context.PostCategories.SingleOrDefaultAsync(m => m.Id == id);
            if (postCategory == null)
            {
                return NotFound();
            }
            return View(postCategory);
        }

        // POST: PostCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CreatedDate")] PostCategory postCategory)
        {
            if (id != postCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostCategoryExists(postCategory.Id))
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
            return View(postCategory);
        }

        // GET: PostCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCategory = await _context.PostCategories
                .SingleOrDefaultAsync(m => m.Id == id);
            if (postCategory == null)
            {
                return NotFound();
            }

            return View(postCategory);
        }

        // POST: PostCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postCategory = await _context.PostCategories.SingleOrDefaultAsync(m => m.Id == id);
            _context.PostCategories.Remove(postCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostCategoryExists(int id)
        {
            return _context.PostCategories.Any(e => e.Id == id);
        }
    }
}
