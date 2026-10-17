using BaoHiem.Models;
namespace BaoHiem.DAO;

public class LoaiBaoHiemDAO : MapDao<LoaiBaoHiem>
{
    public LoaiBaoHiemDAO() : base(x => x.MaLoaiBaoHiem) { }
}
