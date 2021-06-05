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
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly ProjectContext _ctx;

        public ManufacturerRepository(ProjectContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<SearchResult<ManufacturerPreset>> Search(BaseSearchPattern searchPattern)
        {
            IQueryable<ManufacturerPreset> query = _ctx.Manufacturer.AsQueryable();

            int totalCount = query.Count();

            // filters
            if (!string.IsNullOrWhiteSpace(searchPattern.SearchString))
            {
                string searchString = searchPattern.SearchString.Trim();
                query = query.Where(x =>
                    x.Manufacturer.Name.Contains(searchString) ||
                    x.Manufacturer.ManagerFullname.Contains(searchString) ||
                    x.Manufacturer.PhoneNumber.Contains(searchString));
            }

            // sorting
            query = query.OrderByDescending(x => x.Id);

            int filteredCount = query.Count();

            // taking
            query = query.Skip(searchPattern.Skip()).Take(searchPattern.Take());

            return new SearchResult<ManufacturerPreset>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }

        public async Task<ManufacturerPreset> GetById(int id)
        {
            return await _ctx.Manufacturer
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyDictionary<int, ManufacturerPreset>> GetDictionaryByIds(IReadOnlyList<int> manufacturerIds)
        {
            IReadOnlyList<ManufacturerPreset> manufacturerPresetsList = await _ctx.Manufacturer
                .AsQueryable()
                .Where(x => manufacturerIds.Contains(x.Id))
                .ToListAsync();
            
            IDictionary<int, ManufacturerPreset>
                manufacturerPresetsDictionary = new Dictionary<int, ManufacturerPreset>();
            foreach (var manufacturerPreset in manufacturerPresetsList)
            {
                manufacturerPresetsDictionary.Add(manufacturerPreset.Id, manufacturerPreset);
            }

            return new ReadOnlyDictionary<int, ManufacturerPreset>(manufacturerPresetsDictionary);
        }

        public async Task<int> Add(ManufacturerPreset manufacturerPreset)
        {
            EntityEntry<ManufacturerPreset> c = await _ctx.Manufacturer.AddAsync(manufacturerPreset);
            return c.Entity.Id;
        }

        public Task Update(ManufacturerPreset manufacturerPreset)
        {
            _ctx.Manufacturer.Update(manufacturerPreset);
            return Task.CompletedTask;
        }

        public Task Delete(ManufacturerPreset manufacturerPreset)
        {
            _ctx.Manufacturer.Remove(manufacturerPreset);
            return Task.CompletedTask;
        }
    }
}