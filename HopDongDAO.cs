using BaoHiem.Models;
namespace BaoHiem.DAO;

public class HopDongDAO : ListDao<HopDong>
{
    public HopDongDAO() : base(x => x.SoHopDong) { }
}
