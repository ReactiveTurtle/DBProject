using System.Linq;
using System.Threading.Tasks;
using Domain.InvoiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Toolkit.Search;

namespace Infrastructure.Data.InvoiceModel
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly ProjectContext _ctx;

        public ManufacturerRepository( ProjectContext ctx )
        {
            _ctx = ctx;
        }
        
        public async Task<SearchResult<ManufacturerPreset>> Search(BaseSearchPattern searchPattern)
        {
            IQueryable<ManufacturerPreset> query = _ctx.Manufacturers.AsQueryable();

            int totalCount = query.Count();

            // filters
            if ( !string.IsNullOrWhiteSpace( searchPattern.SearchString ) )
            {
                string searchString = searchPattern.SearchString.Trim();
                query = query.Where( x => 
                    x.Manufacturer.Name.Contains( searchString ) || 
                    x.Manufacturer.ManagerFullname.Contains( searchString ) || 
                    x.Manufacturer.PhoneNumber.Contains( searchString ) );
            }

            // sorting
            query = query.OrderByDescending( x => x.Id );

            int filteredCount = query.Count();

            // taking
            query = query.Skip( searchPattern.Skip() ).Take( searchPattern.Take() );

            return new SearchResult<ManufacturerPreset>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }

        public async Task<ManufacturerPreset> GetById(int id)
        {
            return await _ctx.Manufacturers
                .SingleOrDefaultAsync( x => x.Id == id );
        }

        public async Task<int> Add(ManufacturerPreset counterparty)
        {
            EntityEntry<ManufacturerPreset> c = await _ctx.Manufacturers.AddAsync( counterparty );
            return c.Entity.Id;
        }

        public Task Update(ManufacturerPreset counterparty)
        {
            _ctx.Manufacturers.Update( counterparty );
            return Task.CompletedTask;
        }

        public Task Delete(ManufacturerPreset manufacturerPreset)
        {
            _ctx.Manufacturers.Remove( manufacturerPreset );
            return Task.CompletedTask;
        }
    }
}