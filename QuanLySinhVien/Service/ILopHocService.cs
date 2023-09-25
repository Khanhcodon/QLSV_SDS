using QuanLySinhVien.Data;
using Share;

namespace QuanLySinhVien.Service
{
    public interface ILopHocService
    {
        Task<List<LopHoc>> GetListLopHoc();
        Task<bool> UpdateLopHoc(List<LopHoc> lh);
        Task<LopHoc> GetLopHocByID(int id);
        Task<bool> AddLopHoc(List<LopHoc> lh);
        void DeleteLopHoc(LopHoc lophoc);
    }
}
