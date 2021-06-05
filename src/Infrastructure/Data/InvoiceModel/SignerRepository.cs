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
    public class SignerRepository : ISignerRepository
    {
        private readonly ProjectContext _ctx;

        public SignerRepository(ProjectContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<SearchResult<SignerPreset>> Search(BaseSearchPattern searchPattern)
        {
            IQueryable<SignerPreset> query = _ctx.Signer.AsQueryable();

            int totalCount = query.Count();

            // filters
            if (!string.IsNullOrWhiteSpace(searchPattern.SearchString))
            {
                string searchString = searchPattern.SearchString.Trim();
                query = query.Where(x => x.Signer.Fullname.Contains(searchString));
            }

            // sorting
            query = query.OrderByDescending(x => x.Id);

            int filteredCount = query.Count();

            // taking
            query = query.Skip(searchPattern.Skip()).Take(searchPattern.Take());

            return new SearchResult<SignerPreset>
            {
                Items = await query.ToListAsync(),
                TotalCount = totalCount,
                FilteredCount = filteredCount
            };
        }

        public async Task<SignerPreset> GetById(int id)
        {
            return await _ctx.Signer
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task<IReadOnlyDictionary<int, SignerPreset>> GetDictionaryByIds(IReadOnlyList<int> signerIds)
        {
            IReadOnlyList<SignerPreset> signerPresetsList = await _ctx.Signer
                .AsQueryable()
                .Where(x => signerIds.Contains(x.Id))
                .ToListAsync();
            
            IDictionary<int, SignerPreset>
                signerPresetsDictionary = new Dictionary<int, SignerPreset>();
            foreach (var signerPreset in signerPresetsList)
            {
                signerPresetsDictionary.Add(signerPreset.Id, signerPreset);
            }

            return new ReadOnlyDictionary<int, SignerPreset>(signerPresetsDictionary);
        }

        public async Task<int> Add(SignerPreset signerPreset)
        {
            EntityEntry<SignerPreset> c = await _ctx.Signer.AddAsync(signerPreset);
            return c.Entity.Id;
        }

        public Task Update(SignerPreset signerPreset)
        {
            _ctx.Signer.Update(signerPreset);
            return Task.CompletedTask;
        }

        public Task Delete(SignerPreset signerPreset)
        {
            _ctx.Signer.Remove(signerPreset);
            return Task.CompletedTask;
        }
    }
}