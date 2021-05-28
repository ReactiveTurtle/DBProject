using System;
using System.Threading;
using System.Threading.Tasks;

namespace Toolkit.Domain.Abstractions
{
    /// <summary>
    /// Паттерн "Unit of work".
    /// 
    /// Управление транзациями осуществляется только на прикладном уровне. Доменный слой, как и предметная область,
    /// ничего не знает о транзакциях.
    /// 
    /// Транзакция - это единица работы. Паттерн unit-of-work нужен для того, чтобы гарантировать согласованное
    /// изменение всех агрегатов. После внесения всех изменений в агрегаты unit-of-work по сути совершает
    /// коммит транзакции в хранилище данных.
    /// 
    /// Реализация находится на инфраструктурном уровне, так как зависит от фреймворка работы с базой данных.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveEntitiesAsync( CancellationToken cancellationToken = default );
    }
}
