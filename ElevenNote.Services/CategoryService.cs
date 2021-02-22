using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
   public class CategoryService
    {
        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    Name = model.Name
                };
            using (var ctx=new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoryListItems> GetCategories()
        {
            using (var ctx =new ApplicationDbContext())
            {
                var query = ctx
                    .Categories
                    .Select(
                    e =>
                    new CategoryListItems
                    {
                        CategoryId = e.CategoryID,
                        Name = e.Name
                    });
                return query.ToArray();
            }
        }
        public CategoryDetail CategoryById(int id)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var entity =
                    ctx.
                    Categories.
                    Single(e => e.CategoryID == id);
                return new CategoryDetail
                {
                    CategoryId = entity.CategoryID,
                    Name = entity.Name,
                    Notes = entity.Notes
                    .Select(e => new NoteListItem()
                    {
                        NoteId = e.NoteId,
                        Title = e.Title,
                        CreatedUtc = e.CreatedUtc
                    }).ToList()
                };
            }
        }
    }
}
