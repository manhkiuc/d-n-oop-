namespace BaoHiem.Models;

public class QuyenLoi
{
    public string MaQuyenLoi { get; set; } = "";
    public string TenQuyenLoi { get; set; } = "";
    public string MoTa { get; set; } = "";
    public double TyLeChiTra { get; set; }
    public string MaLoaiBaoHiem { get; set; } = "";

    public QuyenLoi() { }
    public QuyenLoi(string ma, string ten, string moTa, double tyLeChiTra, string maLoai)
    {
        MaQuyenLoi = ma; TenQuyenLoi = ten; MoTa = moTa; TyLeChiTra = tyLeChiTra; MaLoaiBaoHiem = maLoai;
    }
    public override string ToString() => $"QuyenLoi[{MaQuyenLoi}, {TenQuyenLoi}, {TyLeChiTra}%, LBH={MaLoaiBaoHiem}]";
}
