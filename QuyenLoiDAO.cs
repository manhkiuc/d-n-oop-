using BaoHiem.Models;
namespace BaoHiem.DAO;

/// <summary>List + Dictionary gom theo MaLoaiBaoHiem.</summary>
public class QuyenLoiDAO : ListDao<QuyenLoi>
{
    public QuyenLoiDAO() : base(x => x.MaQuyenLoi, x => x.MaLoaiBaoHiem) { }
    public IReadOnlyList<QuyenLoi> GetByLoaiBaoHiem(string maLoai) => GetByGroup(maLoai);
}
