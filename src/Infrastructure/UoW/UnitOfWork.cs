using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Data;
using Toolkit.Domain.Abstractions;

namespace Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext _ctx;

        public UnitOfWork( ProjectContext ctx )
        {
            _ctx = ctx;
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public async Task<bool> SaveEntitiesAsync( CancellationToken cancellationToken = default )
        {
            return await _ctx.SaveEntitiesAsync( cancellationToken );
        }
    }
}
