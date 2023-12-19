using MyWebAPI.Models;

namespace MyWebAPI.Services
{
    public interface IHangHoaRepository
    {
        List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy);
    }
}
