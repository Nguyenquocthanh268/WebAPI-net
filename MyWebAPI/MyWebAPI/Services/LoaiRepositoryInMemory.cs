using MyWebAPI.Models;

namespace MyWebAPI.Services
{
    public class LoaiRepositoryInMemory : ILoaiRepository
    {
        static List<LoaiVM> loais = new List<LoaiVM>
        {
            new  LoaiVM{MaLoai = 1, TenLoai = "Tivi"},
            new  LoaiVM{MaLoai = 2, TenLoai = "Tủ lạnh"},
            new  LoaiVM{MaLoai = 3, TenLoai = "Điều hòa"},
            new  LoaiVM{MaLoai = 4, TenLoai = "Máy giặt"}
        };
        LoaiVM ILoaiRepository.Add(LoaiModel loai)
        {
            var _loai = new LoaiVM
            {
                MaLoai = loais.Max(lo => lo.MaLoai) + 1,
                TenLoai = loai.TenLoai
            };
            loais.Add(_loai);
            return _loai;
        }

        void ILoaiRepository.Delete(int id)
        {
            var _loai = loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (_loai != null)
            {
                loais.Remove(_loai);
            }
        }

        List<LoaiVM> ILoaiRepository.GetAll()
        {
            return loais;
        }

        LoaiVM ILoaiRepository.GetById(int id)
        {
            return loais.SingleOrDefault(lo => lo.MaLoai == id);
        }

        void ILoaiRepository.Update(LoaiVM loai)
        {
            var _loai = loais.SingleOrDefault(lo => lo.MaLoai == loai.MaLoai);
            if (_loai != null)
            {
                _loai.TenLoai = loai.TenLoai;
            }
            throw new NotImplementedException();
        }
    }
}
