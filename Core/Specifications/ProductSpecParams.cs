using System.Globalization;

namespace Core.Specifications
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;

        // شماره صفحه فعلی (پیش‌فرض 1)
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;

        // تعداد آیتم‌ها در هر صفحه (حداکثر 50)
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        // 🔹 لیست برندها
        private List<string> _brands = [];

        public List<string> Brands
        {
            get => _brands;
            set
            {
                _brands = value
                    .SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    .ToList();
            }
        }

        // 🔹 لیست نوع محصولات
        private List<string> _types = [];

        public List<string> Types
        {
            get => _types;
            set
            {
                _types = value
                    .SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    .ToList();
            }
        }

        // 🔹 مرتب‌سازی (priceAsc, priceDesc, name)
        public string? Sort { get; set; }

        // 🔹 جستجو
        private string? _search;
        public string? Search
        {
            get => _search;
            set => _search = value;
        }

    }
}
