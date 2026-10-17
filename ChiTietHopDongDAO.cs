using BaoHiem.Models;
namespace BaoHiem.DAO;

/// <summary>List + Dictionary gom theo SoHopDong (quan hệ GOM).</summary>
public class ChiTietHopDongDAO : ListDao<ChiTietHopDong>
{
    public ChiTietHopDongDAO() : base(x => x.MaChiTietHopDong, x => x.SoHopDong) { }
    public IReadOnlyList<ChiTietHopDong> GetByHopDong(string soHopDong) => GetByGroup(soHopDong);
}
