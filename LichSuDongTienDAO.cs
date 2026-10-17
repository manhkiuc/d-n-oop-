using BaoHiem.Models;
namespace BaoHiem.DAO;

/// <summary>List + Dictionary gom theo MaChiTietHopDong.</summary>
public class LichSuDongTienDAO : ListDao<LichSuDongTien>
{
    public LichSuDongTienDAO() : base(x => x.MaGiaoDich, x => x.MaChiTietHopDong) { }
    public IReadOnlyList<LichSuDongTien> GetByChiTiet(string maChiTiet) => GetByGroup(maChiTiet);
}
