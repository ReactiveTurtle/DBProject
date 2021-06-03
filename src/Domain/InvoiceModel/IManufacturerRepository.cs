using System.Collections.Generic;
using System.Threading.Tasks;
using Toolkit.Domain.Abstractions;
using Toolkit.Search;

namespace Domain.InvoiceModel
{
    public interface IManufacturerRepository : IRepository<ManufacturerPreset>
    {
        Task<SearchResult<ManufacturerPreset>> Search(BaseSearchPattern searchPattern);

        Task<ManufacturerPreset> GetById(int id);

        Task<int> Add(ManufacturerPreset manufacturerPreset);

        Task Update(ManufacturerPreset manufacturerPreset);

        Task Delete(ManufacturerPreset manufacturerPreset);
    }
}