using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopBridge.Model;
namespace ShopBridge.Pages.ItemList

{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Item Item { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            try {
                if (ModelState.IsValid)
                {

                    await _db.Item.AddAsync(Item);
                    await _db.SaveChangesAsync();
                   
                }
                else
                {
                    return Page();
                }
            }
            catch(Exception ex)
            {
                var message = ex.Message;
            }
            return RedirectToPage("Index");
        }
    }
}
