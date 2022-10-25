namespace MoiteRecepti.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MoiteRecepti.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Starter" });
            await dbContext.Categories.AddAsync(new Category { Name = "Main Dish" });
            await dbContext.Categories.AddAsync(new Category { Name = "Dessert" });

            await dbContext.SaveChangesAsync();
        }
    }
}
