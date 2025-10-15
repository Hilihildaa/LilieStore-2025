using System.Linq.Expressions;

namespace Core.Interfaces
{
    // نسخه اصلی برای Specification
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>>? Criteria { get; }
        Expression<Func<T, object>>? OrderBy { get; }
        Expression<Func<T, object>>? OrderByDescending { get; }
        bool IsDistinct { get; }
    }

    // نسخه مخصوص Projection
    public interface ISpecification<T, TResult> : ISpecification<T>
    {
        Expression<Func<T, TResult>>? Select { get; }
    }
}
