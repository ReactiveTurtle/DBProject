using System.Collections.Generic;
using System.Threading.Tasks;
using Toolkit.Domain.Abstractions;
using Toolkit.Search;

namespace Domain.InvoiceModel
{
    public interface ISignerRepository : IRepository<SignerPreset>
    {
        Task<SearchResult<SignerPreset>> Search(BaseSearchPattern searchPattern);

        Task<SignerPreset> GetById(int id);

        Task<IReadOnlyDictionary<int, SignerPreset>> GetDictionaryByIds(IReadOnlyList<int> signerIds);

        Task<int> Add(SignerPreset signerPreset);

        Task Update(SignerPreset signerPreset);

        Task Delete(SignerPreset signerPreset);
    }
}