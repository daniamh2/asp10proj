using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using project.Context;
using project.Models;

namespace project.Services
{
    public class categoryServices : ICategory_services
    {
        ApplicationDbContext _context;
        public categoryServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public Category Add(Category category)
        {

            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        public bool Edit(int id, Category category)
        {
            var categoryInDb = _context.Categories.AsNoTracking().FirstOrDefault(c => c.Id == id);
            if (categoryInDb == null) return false;
            category.Id = categoryInDb.Id;
            _context.Categories.Update(category);
            _context.SaveChanges();
            return true;

        }

        public Category? Get(Expression<Func<Category, bool>> expression)
        {
            var category = _context.Categories.FirstOrDefault(expression);

            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = _context.Categories;
            return categories.ToList();
        }

        public bool Remove(int id)
        {
            Category? category = _context.Categories.Find(id);
            if (category == null) return false;
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return true;
        }
    }
}
