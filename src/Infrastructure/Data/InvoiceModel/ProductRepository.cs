using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Domain.InvoiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Toolkit.Search;

namespace Infrastructure.Data.InvoiceModel
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProjectContext _ctx;

        public ProductRepository(ProjectContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<SearchResult<ProductPreset>> Search(BaseSearchPattern searchPattern)
        {
            IQueryable<ProductPreset> query = _ctx.Product.AsQueryable();

            int totalCount = query.Count();

            // filters
            if (!string.IsNullOrWhiteSpace(searchPattern.SearchString))
            {
                string searchString = searchPattern.SearchString.Trim();
                query = query.Where(x => x.Product.Name.Contains(searchString));
            }

            // sorting
            query = query.OrderByDescending(x => x.Id);

            int filteredCount = query.Count();

            // taking
            query = query.Skip(searchPattern.Skip()).Take(searchPattern.Take());

            return new SearchResult<ProductPreset>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }

        public async Task<ProductPreset> GetById(int id)
        {
            return await _ctx.Product
                .SingleOrDefaultAsync( x => x.Id == id );
        }
        
        public async Task<IReadOnlyDictionary<int, ProductPreset>> GetDictionaryByIds(IReadOnlyList<int> productIds)
        {
            IReadOnlyList<ProductPreset> productPresetsList = await _ctx.Product
                .AsQueryable()
                .Where(x => productIds.Contains(x.Id))
                .ToListAsync();
            
            IDictionary<int, ProductPreset>
                productPresetDictionary = new Dictionary<int, ProductPreset>();
            foreach (var productPreset in productPresetsList)
            {
                productPresetDictionary.Add(productPreset.Id, productPreset);
            }

            return new ReadOnlyDictionary<int, ProductPreset>(productPresetDictionary);
        }

        public async Task<int> Add(ProductPreset productPreset)
        {
            EntityEntry<ProductPreset> c = await _ctx.Product.AddAsync( productPreset );
            return c.Entity.Id;
        }

        public Task Update(ProductPreset productPreset)
        {
            _ctx.Product.Update( productPreset );
            return Task.CompletedTask;
        }

        public Task Delete(ProductPreset productPreset)
        {
            _ctx.Product.Remove( productPreset );
            return Task.CompletedTask;
        }
    }
}