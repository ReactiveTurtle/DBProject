using System.Threading.Tasks;
using Toolkit.Domain.Abstractions;
using Toolkit.Search;

namespace Domain.InvoiceModel
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<SearchResult<Invoice>> Search(BaseSearchPattern searchPattern);

        Task<Invoice> GetById(int id);

        Task<int> Add(Invoice invoice);

        Task Update(Invoice invoice);

        Task Delete(Invoice invoice);
    }
}