using Microsoft.EntityFrameworkCore.Query;
using project.Models;
using System.Linq.Expressions;

namespace project.Services
{
    public interface ICategory_services
    {
 
        IEnumerable<Category> GetAll();
        Category? Get(Expression<Func<Category, bool>> expression);
        Category Add (Category category);   
        bool Edit(int id , Category category);
        bool Remove(int id);    
    }
}
