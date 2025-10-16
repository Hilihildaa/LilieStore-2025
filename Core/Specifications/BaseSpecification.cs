using System;
using System.Linq;
using System.Linq.Expressions;
using Core.Interfaces;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        protected BaseSpecification() : this(null) { }

        public Expression<Func<T, bool>>? Criteria { get; protected set; }
        public Expression<Func<T, object>>? OrderBy { get; private set; }
        public Expression<Func<T, object>>? OrderByDescending { get; private set; }
        public bool IsDistinct { get; protected set; }
        public int Take { get; protected set; }
        public int Skip { get; protected set; }
        public bool IsPagingEnabled { get; protected set; }

        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        protected void ApplyDistinct()
        {
            IsDistinct = true;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

        // ✅ متد فیلتر کردن داده‌ها
        public IQueryable<T> ApplyCriteria(IQueryable<T> query)
        {
            if (Criteria != null)
            {
                query = query.Where(Criteria);
            }

            return query; 
        }
    }

    public class BaseSpecification<T, TResult> : BaseSpecification<T>, ISpecification<T, TResult>
    {
        protected BaseSpecification() : this(null) { }

        public Expression<Func<T, TResult>>? Select { get; protected set; }

        protected BaseSpecification(Expression<Func<T, bool>> criteria) : base(criteria) { }

        protected void AddSelector(Expression<Func<T, TResult>> selector)
        {
            Select = selector;
        }
    }
}
