using Esty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Esty_Context.DataSeed
{
    public static class DataSeedContext
    {
        public static async Task DataSeedingAsync (EtsyDbContext etsyDbContext)
        {
            if(!etsyDbContext.baseCategories.Any() &&
                !etsyDbContext.categories.Any() &&
                !etsyDbContext.products.Any())
            {
                var BaseCategoryData = File.ReadAllText("../Esty-Context/DataSeed/BaseCategory.json");
                var JSONBaseCategoryData = JsonSerializer.Deserialize<List<BaseCategory>>(BaseCategoryData);
                if (JSONBaseCategoryData?.Count() > 0)
                {
                    foreach (var item in JSONBaseCategoryData)
                    {
                        etsyDbContext.baseCategories.Add(item);
                    }
                    await etsyDbContext.SaveChangesAsync();
                }

                var CategoryData = File.ReadAllText("../Esty-Context/DataSeed/Category.json");
                var JSONCategoryData = JsonSerializer.Deserialize<List<Category>>(CategoryData);
                if (JSONCategoryData?.Count() > 0)
                {
                    foreach (var item in JSONCategoryData)
                    {
                        etsyDbContext.categories.Add(item);
                    }
                    await etsyDbContext.SaveChangesAsync();
                }

                var ProductsData = File.ReadAllText("../Esty-Context/DataSeed/Products.json");
                var JSONProductsData = JsonSerializer.Deserialize<List<Products>>(ProductsData);
                if (JSONProductsData?.Count() > 0)
                {
                    foreach (var item in JSONProductsData)
                    {
                        etsyDbContext.products.Add(item);
                    }
                    await etsyDbContext.SaveChangesAsync();
                }
            }
        }
    }
}
