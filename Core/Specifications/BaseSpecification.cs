using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Interfaces;
using Core.Specifications;


namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        protected BaseSpecification() : this(null) { }
        // شرط اصلی (فیلتر)
        public Expression<Func<T, bool>>? Criteria { get; protected set; }

        // مرتب‌سازی صعودی
        public Expression<Func<T, object>>? OrderBy { get; private set; }

        // مرتب‌سازی نزولی
        public Expression<Func<T, object>>? OrderByDescending { get; private set; }

        public bool IsDistinct { get; protected set; }

        // سازندهٔ دارای شرط (criteria)
        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        // متد اضافه کردن مرتب‌سازی صعودی
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        // متد اضافه کردن مرتب‌سازی نزولی
        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        protected void ApplyDistinct()
        {
            IsDistinct = true;
        }
        //وقتی این تابع رو صدا بزنی، خروجی کوئری (Query) فقط داده‌های غیرتکراری رو برمی‌گردونه
    }
}

public class BaseSpecification<T, TResult> : BaseSpecification<T>, ISpecification<T, TResult>
{
    protected BaseSpecification() : this(null) { }
    // Select با getter عمومی و setter محافظت‌شده
    public Expression<Func<T, TResult>>? Select { get; protected set; }


    // سازندهٔ با criteria که به کلاس پایه پاس داده می‌شود
    protected BaseSpecification(Expression<Func<T, bool>> criteria) : base(criteria) { }

    // متد کمکی برای تنظیم Projection (Selector)
    protected void AddSelector(Expression<Func<T, TResult>> selector)
    {
        Select = selector;
    }
}
