using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopBridge.Model;
using Microsoft.EntityFrameworkCore;

namespace ShopBridge.Pages.ItemList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Item> Items { get; set; }
        public async Task OnGet()
        {
            Items = await _db.Item.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            try
            {
                var data = await _db.Item.FindAsync(id);
                if (data == null)
                {
                    return NotFound();
                }
                _db.Item.Remove(data);
                await _db.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return RedirectToPage("Index");
        }
    }
}
