using System.Linq;
using System.Threading.Tasks;
using Domain.InvoiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Toolkit.Search;

namespace Infrastructure.Data.InvoiceModel
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ProjectContext _ctx;

        public InvoiceRepository(ProjectContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<SearchResult<Invoice>> Search(BaseSearchPattern searchPattern)
        {
            IQueryable<Invoice> query = _ctx.Invoice.AsQueryable();

            int totalCount = query.Count();

            // filters
            if (!string.IsNullOrWhiteSpace(searchPattern.SearchString))
            {
                string searchString = searchPattern.SearchString.Trim();
                query = query.Where(x => x.Name.Contains(searchString));
            }

            // sorting
            query = query.OrderByDescending(x => x.Id);

            int filteredCount = query.Count();

            // taking
            query = query.Skip(searchPattern.Skip()).Take(searchPattern.Take());

            // include 
            query = query.Include(x => x.Products);

            return new SearchResult<Invoice>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }

        public async Task<Invoice> GetById(int id)
        {
            return await _ctx.Invoice
                .Include( x => x.Products )
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Add(Invoice invoice)
        {
            EntityEntry<Invoice> c = await _ctx.Invoice.AddAsync(invoice);
            return c.Entity.Id;
        }

        public Task Update(Invoice invoice)
        {
            _ctx.Invoice.Update(invoice);
            return Task.CompletedTask;
        }

        public Task Delete(Invoice invoice)
        {
            _ctx.Invoice.Remove(invoice);
            return Task.CompletedTask;
        }
    }
}