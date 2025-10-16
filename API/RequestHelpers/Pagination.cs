namespace API.RequestHelpers;

public class Pagination<T>(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
{
    public int PageIndex { get; set; } = pageIndex;
    public int PageCount { get; set; } = pageSize;
    public int Count { get; set; } = count;
    public IReadOnlyList<T> Data { get; set; } = data;
}
/*یعنی یه کلاس جنریک (generic) ساختیم که می‌تونه با هر نوع داده‌ای (T) کار کنه
(مثلاً Product یا User یا هر چیز دیگه).
🔹 پارامترهای سازنده:

pageIndex: شماره صفحه فعلی (مثلاً ۱ یا ۲)

pageSize: چند تا آیتم در هر صفحه نمایش داده بشه

count: تعداد کل آیتم‌ها در دیتابیس

data: لیست آیتم‌های همان صفحه (مثلاً ۶ تا محصول)*/
