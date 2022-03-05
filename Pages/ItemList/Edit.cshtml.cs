using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopBridge.Model;

namespace ShopBridge.Pages.ItemList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Item Item { get; set; }

        public async Task OnGet(int id)
        {
            Item = await _db.Item.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DatafromDb = await _db.Item.FindAsync(Item.Id);
                    DatafromDb.Name = Item.Name;
                    DatafromDb.Description = Item.Description;
                    DatafromDb.Price = Item.Price;

                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            
            return RedirectToPage();
        }
    }
}
