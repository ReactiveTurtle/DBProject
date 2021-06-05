using System.Collections.Generic;
using System.Threading.Tasks;
using Toolkit.Domain.Abstractions;
using Toolkit.Search;

namespace Domain.InvoiceModel
{
    public interface IProductRepository : IRepository<ProductPreset>
    {
        Task<SearchResult<ProductPreset>> Search(BaseSearchPattern searchPattern);

        Task<ProductPreset> GetById(int id);

        Task<IReadOnlyDictionary<int, ProductPreset>> GetDictionaryByIds(IReadOnlyList<int> productIds);

        Task<int> Add(ProductPreset productPreset);

        Task Update(ProductPreset productPreset);

        Task Delete(ProductPreset productPreset);
    }
}