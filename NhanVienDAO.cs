using BaoHiem.Models;
namespace BaoHiem.DAO;

public class NhanVienDAO : MapDao<NhanVien>
{
    public NhanVienDAO() : base(x => x.MaNhanVien) { }
}
