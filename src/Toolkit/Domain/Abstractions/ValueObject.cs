using System;
using System.Collections.Generic;
using System.Linq;

namespace Toolkit.Domain.Abstractions
{
    /// <summary>
    /// Объект-значение (Value Object) - это доменный объект, который включает в себя описательные свойства и
    /// характеристики в рамках предметной области. Например, такие величины, как единицы измерения (Money, Currency,
    /// Name, Color).
    /// 
    /// Не имеет индивидуальности (идентификатора). Индивидуальность определяется атрибутами. В отличии от сущности
    /// (<see cref="Entity"/>), которая обладает индивидуальностью.
    /// 
    /// Неизменяемый (immutable) - после создания никогда не меняет своего состояния. Вместо изменения всегда создается
    /// новый объект. Например, объект DateTime тоже immutable.
    /// 
    /// Может иметь множество атрибутов для отражения одного единственного понятия из предметной области. Например
    /// объект-значение PersonName, может содержать в себе атрибуты Surname, Name и LastName (ФИО), описывающие сущность
    /// "Имя" из предметной области.
    /// 
    /// Всегда согласован с точки зрения инвариантов предметной области. Автоматически осуществляет проверку самого себя
    /// при создании и никогда не должен находиться в несогласованном состоянии в рамках данного контекста.
    /// 
    /// Содержит и инкапсулирует в себе разнообразие возможностей работы на данным объектом-значением. Например, Money
    /// может содержать метод Add и Subsctract, которые будут возвращать новый объект Money (помним про неизменяемость).
    /// Но с другой стороны не нужно "захламлять" объекты-значения методами, которые должны принадлежать сущностям
    /// (<see cref="Entity"/>).
    /// 
    /// Над объектами-значениями можно выполнять различные операции, переопределяя операторы +, - и т.д. Например,
    /// переопределив "+" у Money, можно использовать знак "+" между двумя объектами-значениями Money, тем самым
    /// суммируя их.
    /// 
    /// Равенство объектов-значений определяется только их атрибутами (ни в коем случае не идентификаторами или ссылками
    /// на объекты). Это нужно учитывать при реализации.
    /// </summary>
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public abstract T Copy();

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals( object obj )
        {
            var valueObject = obj as ValueObject<T>;

            if ( ReferenceEquals( valueObject, null ) )
                return false;

            Type thisType = GetType();
            Type objType = obj.GetType();

            if ( !thisType.IsAssignableFrom( objType )
                 && !objType.IsAssignableFrom( thisType ) )
                return false;

            return GetEqualityComponents().SequenceEqual( valueObject.GetEqualityComponents() );
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate( 1, ( current, obj ) =>
                {
                    unchecked
                    {
                        return current * 23 + ( obj?.GetHashCode() ?? 0 );
                    }
                } );
        }

        public static bool operator ==( ValueObject<T> a, ValueObject<T> b )
        {
            if ( ReferenceEquals( a, null ) && ReferenceEquals( b, null ) )
                return true;

            if ( ReferenceEquals( a, null ) || ReferenceEquals( b, null ) )
                return false;

            return a.Equals( b );
        }

        public static bool operator !=( ValueObject<T> a, ValueObject<T> b )
        {
            return !( a == b );
        }
    }
}
