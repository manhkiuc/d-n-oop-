using BaoHiem.Models;
namespace BaoHiem.DAO;

public class YeuCauBaoHiemDAO : ListDao<YeuCauBaoHiem>
{
    public YeuCauBaoHiemDAO() : base(x => x.MaYeuCau) { }
}
