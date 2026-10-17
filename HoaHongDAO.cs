using BaoHiem.Models;
namespace BaoHiem.DAO;

/// <summary>List + Dictionary gom theo MaNhanVien.</summary>
public class HoaHongDAO : ListDao<HoaHong>
{
    public HoaHongDAO() : base(x => x.MaHoaHong, x => x.MaNhanVien) { }
    public IReadOnlyList<HoaHong> GetByNhanVien(string maNv) => GetByGroup(maNv);
}
