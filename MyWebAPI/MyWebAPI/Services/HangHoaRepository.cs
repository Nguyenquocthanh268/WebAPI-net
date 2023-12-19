using MyWebAPI.Data;
using MyWebAPI.Models;

namespace MyWebAPI.Services
{
    public class  HangHoaRepository : IHangHoaRepository 
    {
        private readonly MyDbContext _context;

        public HangHoaRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy)
        {
            var allProducts = _context.HangHoas.AsQueryable();
            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(hh => hh.TenHh.Contains(search));
            }
            if (from.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.DonGia >= from);
            }
            if (to.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.DonGia <= to);
            }
            #endregion

            #region Sorting
            //Default sort by name (TenHh)
            allProducts = allProducts.OrderBy(hh => hh.TenHh);
            
            if(!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {

                    case "tenhh_desc": allProducts = allProducts.OrderByDescending(hh => hh.TenHh); break;
                    case "gia_asc": allProducts = allProducts.OrderBy(hh => hh.DonGia); break;
                    case "gia_desc": allProducts = allProducts.OrderByDescending(hh => hh.DonGia); break;
                }
            }
            #endregion

            var result = allProducts.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.MaHh,
                TenHangHoa = hh.TenHh,
                DonGia = hh.DonGia,
                TenLoai = hh.Loai.TenLoai
            });

            return result.ToList();

        }
    }
}
