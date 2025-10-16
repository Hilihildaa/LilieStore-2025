using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        // 📘 برای Specification‌های معمولی
        public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
        {
            // 🎯 اعمال فیلتر
            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);

            // ⬆️ مرتب‌سازی صعودی
            if (spec.OrderBy != null)
                query = query.OrderBy(spec.OrderBy);

            // ⬇️ مرتب‌سازی نزولی
            if (spec.OrderByDescending != null)
                query = query.OrderByDescending(spec.OrderByDescending);

            // 🔁 حذف داده‌های تکراری
            if (spec.IsDistinct)
                query = query.Distinct();

            // 📄 صفحه‌بندی
            if (spec. IsPagingEnabled )
                query = query.Skip(spec.Skip).Take(spec.Take);

            return query;
        }

        // 🎯 برای Specification‌هایی که TResult دارند (مثلاً فقط Brand یا Type)
        public static IQueryable<TResult> GetQuery<TResult>(IQueryable<T> query, ISpecification<T, TResult> spec)
        {
            // فیلتر
            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);

            // مرتب‌سازی صعودی
            if (spec.OrderBy != null)
                query = query.OrderBy(spec.OrderBy);

            // مرتب‌سازی نزولی
            if (spec.OrderByDescending != null)
                query = query.OrderByDescending(spec.OrderByDescending);

            // انتخاب فیلدهای خاص (Projection)
            IQueryable<TResult> selectQuery;
            if (spec.Select != null)
                selectQuery = query.Select(spec.Select);
            else
                throw new InvalidOperationException("Select expression must be provided for TResult specification.");

            // حذف داده‌های تکراری
            if (spec.IsDistinct)
                selectQuery = selectQuery.Distinct();

            // صفحه‌بندی
            if (spec.IsPagingEnabled)
            selectQuery = selectQuery.Skip(spec.Skip).Take(spec.Take);

            return selectQuery;
        }
    }
}
