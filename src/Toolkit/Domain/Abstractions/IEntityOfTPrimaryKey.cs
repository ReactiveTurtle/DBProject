namespace Toolkit.Domain.Abstractions
{
    /// <summary>
    /// Описание Entity <see cref="Entity"/>
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Уникальный идентификатор, определяет индивидуальность сущности
        /// </summary>
        TPrimaryKey Id { get; }

        /// <summary>
        /// Определена ли сущность в хранилище.
        /// В данном случае это некий компромисс между чистотой модели и возможностью технической реализации.
        /// </summary>
        /// <returns>
        /// Возвращает true, если сущность еще не определена в хранилище и не обладает уникальным идентификатором
        /// </returns>
        bool IsTransient();
    }
}
