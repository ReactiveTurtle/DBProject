using System;
using System.Collections.Generic;
using System.Reflection;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace Toolkit.Domain.Abstractions
{
    /// <summary>
    /// Сущность (Entity) - это доменный объект, который является отражением в коде сущности из предметной (domain)
    /// области. Сущность определяется своей индивидуальностью (идентификатором), а не атрибутами. В отличии от
    /// объекта-значения <see cref="ValueObject{T}"/>, индивидуальность которого определяется атрибутами (свойствами).
    /// 
    /// Индивидуальность сущности не изменяется с течением времени. То есть у сущности нельзя изменить идентификатор,
    /// иначе это будет уже другая сущность.
    /// 
    /// Другой важной характеристикой сущностей является то, что они имеют состояние, которое может изменяться с
    /// течением времени. В отличии от объекта-значения (<see cref="ValueObject{T}"/>), не имеющего состояния.
    /// 
    /// В качестве идентификатора сущности лучше выбирать ключ из предметной области (конечно, если это возможно):
    /// например, код страны, номер ИНН, ISBN для книг. Идентификатор может быть составным. Основная проблема такого
    /// подхода - он сложен в реализации и при использовании ORM бывает проблематично работать с такими ключами.
    /// Альтернативным решением будут искусственные ключи: инкрементные целые значения, GUID, строки.
    /// 
    /// Не стоит перегружать сущности логикой, присущей объектам-значениям (<see cref="ValueObject{T}"/>). Такую логику
    /// стоит выносить в соответствующие объекты-значения. Всякий раз, наделяя сущность новыми характеристиками и
    /// функциями, задумайтесь, нельзя ли реализовать их в объекте-значении.
    /// 
    /// Сущности всегда должны осуществлять проверку инвариантов, чтобы всегда находиться в допустимом состоянии для
    /// данного контекста. В конструкторах, фабричных методах и во всех методах, которые изменяют состояние сущности,
    /// всегда должна производиться проверка допустимости инвариантов. Сущность, как и объект-значение, никогда не
    /// должна быть в несогласованном состоянии.
    /// 
    /// Инварианты являются для сущностей непреложными истинами, поэтому они должны гарантироваться всегда.
    /// 
    /// При проектировании сущностей нужно сосредоточиться на поведении, а не на данных. Сущности должны экспортировать
    /// методы с выразительными именами, сообщающие особенности поведения сущности в предметной области, а не свое
    /// состояние. Должен соблюдаться принцип ООП "Говори, а не спрашивай" (Tell-Don’t-Ask).
    /// 
    /// В идеале сущность не должна содержать сеттеров, и нужно с вниманием относиться к геттерам, чтобы не раскрыть
    /// ненужное состояние сущности. Открывая лишние подробности с помощью геттеров, вы, вероятно, можете дать
    /// возможность реализовать поведение, которое должно принадлежать сущности, где-то в другом месте, что ухудшит
    /// ясность и выразительность кода. Например, вы можете предоставлять некоторые промежуточные сведения, вместо
    /// полноценного вывода о результате метода.
    /// 
    /// Сущности нужно стараться проектировать максимально выразительными, избегая нюансов пользовательских интерфейсов,
    /// баз данных, а также других технических и инфраструктурных деталей.
    /// 
    /// Функциональные возможности сущности должны соответствовать потребностям приложения. Моделирование поведения
    /// реального мира не является целью для сущностей.
    /// 
    /// Нужно внимательно моделировать некоторые "большие" физические сущности, н-р, Customer. Так как в реальном мире
    /// такая сущность содержит довольно много различных данных: адрес, информация о платеже, история заказов, данные о
    /// лояльности, данные об авторизации и т.д. В таких случаях лучше спроектировать несколько сущностей в разных
    /// ограниченных контекстах.
    /// </summary>
    [Serializable]
    public abstract class Entity : Entity<int>, IEntity
    {
    }

    [Serializable]
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Unique identifier for this entity
        /// </summary>
        public virtual TPrimaryKey Id { get; protected set; }

        /// <summary>
        /// Checks if this entity is transient (it has not an Id)
        /// </summary>
        /// <returns>True, if this entity is transient</returns>
        public virtual bool IsTransient()
        {
            if ( EqualityComparer<TPrimaryKey>.Default.Equals( Id, default ) )
            {
                return true;
            }

            // Workaround for EF Core since it sets int/long to min value when attaching to dbcontext
            if ( typeof(TPrimaryKey) == typeof(int) )
            {
                return Convert.ToInt32( Id ) <= 0;
            }

            if ( typeof(TPrimaryKey) == typeof(long) )
            {
                return Convert.ToInt64( Id ) <= 0;
            }

            return false;
        }

        public override bool Equals( object obj )
        {
            if ( !( obj is Entity<TPrimaryKey> ) )
            {
                return false;
            }

            // Same instances must be considered as equal
            if ( ReferenceEquals( this, obj ) )
            {
                return true;
            }

            // Transient objects are not considered as equal
            var other = (Entity<TPrimaryKey>) obj;
            if ( IsTransient() && other.IsTransient() )
            {
                return false;
            }

            // Must have a IS-A relation of types or must be same type
            var typeOfThis = GetType();
            var typeOfOther = other.GetType();
            if ( !typeOfThis.GetTypeInfo().IsAssignableFrom( typeOfOther ) &&
                 !typeOfOther.GetTypeInfo().IsAssignableFrom( typeOfThis ) )
            {
                return false;
            }

            return Id.Equals( other.Id );
        }

        private int? _requestedHashCode;

        public override int GetHashCode()
        {
            if ( IsTransient() )
            {
                return base.GetHashCode();
            }

            if ( !_requestedHashCode.HasValue )
            {
                _requestedHashCode =
                    Id.GetHashCode() ^
                    31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
            }

            return _requestedHashCode.Value;
        }

        public static bool operator ==( Entity<TPrimaryKey> left, Entity<TPrimaryKey> right )
        {
            if ( Equals( left, null ) )
            {
                return Equals( right, null );
            }

            return left.Equals( right );
        }

        public static bool operator !=( Entity<TPrimaryKey> left, Entity<TPrimaryKey> right )
        {
            return !( left == right );
        }

        public override string ToString()
        {
            return $"[{GetType().Name} {Id}]";
        }
    }
}
