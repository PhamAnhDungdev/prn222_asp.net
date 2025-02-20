using FUNewsManagement_Assigment01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FUNewsManagement_Assigment01.Component.Category
{
    public class Category : ViewComponent
    {
        private readonly FunewsManagementContext _context;

        public Category(FunewsManagementContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories
                .AsNoTracking()
                .ToListAsync();
            return View(categories);
        }
    }
}
