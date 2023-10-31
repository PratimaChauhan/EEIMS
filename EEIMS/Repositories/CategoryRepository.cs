using EEIMS.Functionalities;
using EEIMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace EEIMS.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository()
        {
            _context = new ApplicationDbContext();
        }
        int ICategoryRepository.DeleteCategory(int id)
        {
            _context.Categories.Remove(_context.Categories.Where(c => c.CategoryId == id).FirstOrDefault());
            return _context.SaveChanges();
        }

        IEnumerable<AddCategoryViewModel> ICategoryRepository.GetCategories()
        {
            return _context.Categories.Select(c => new AddCategoryViewModel 
            { 
                CategoryId = c.CategoryId, 
                CategoryName = c.CategoryName 
            }).ToList();
        }

        AddCategoryViewModel ICategoryRepository.GetCategoryById(int id)
        {
             var category = _context.Categories.Where(c => c.CategoryId == id).Select(c => new AddCategoryViewModel 
                { 
                    CategoryId = c.CategoryId, 
                    CategoryName = c.CategoryName 
                }).FirstOrDefault();

            return category;
        }

        int ICategoryRepository.InsertCategory(AddCategoryViewModel model)
        {
            var category =new Category 
            { 
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName 
            };

            _context.Categories.Add(category);
            return _context.SaveChanges();
        }



        int ICategoryRepository.UpdateCategory(AddCategoryViewModel category)
        {
            _context.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId).CategoryName = category.CategoryName;  
            return _context.SaveChanges();
        }
    }
}