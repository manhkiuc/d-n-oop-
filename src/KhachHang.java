import java.time.LocalDate;
public class KhachHang {
    private String maKhachHang;
    private String hoTen;
    private LocalDate ngaySinh;
    private String cccd;
    private String ngheNghiep;

    //==========================CONTRUCTOR==========================
    public KhachHang(String mkh, String ht, LocalDate ns, int cd, String nn) {
        maKhachHang = mkh;
        hoTen = ht;
        ngaySinh = ns;
        cccd = cd;
        ngheNghiep = nn;
    }

    //==========================SET==========================
    public void SetmaKhachHang(String mkh) {
        if (mkh == null || mkh.isBlank()) {   // cái is blank này được hỗ trợ từ java 11 trở lên
            throw new IllegalArgumentException("mã khách hàng không hợp lệ"); // cái này để thông báo lỗi
            maKhachHang = mkh;
        }
    }

    public void SethoTen(String ht) {
        if (ht == null || ht.isBlank()) {   // cái is blank này được hỗ trợ từ java 11 trở lên
            throw new IllegalArgumentException("họ tên không hợp lệ"); // cái này để thông báo lỗi
            hoTen = ht;
        }
    }

    public void SethoTen(String ht) {
        if (ht == null || ht.isBlank()) {
            throw new IllegalArgumentException("họ tên không hợp lệ");
            hoTen = ht;
        }
    }

    public void setNs(LocalDate ns) {
        if (ns == null || ns.isAfter(LocalDate.now().minusYears(18))) {
            throw new IllegalArgumentException("Người mua bảo hiểm phải đủ 18 tuổi");
        }
        this.ns = ns;
    }

    public void Setcccd(String cc) {
        if (cc == null || cc.isBlank() || cc.length() != 12)
            throw new IllegalArgumentException("mã căn cước khongo hợp lệ");
        cccd = cc;
    }

    public void SetngheNghiep(String nn) {
        if (nn == null || nn.isBlank())
            throw new IllegalArgumentException("nghề nghiệp không hợp lệ");
        ngheNghiep = nn;
    }
    //==========================GET==========================
    public String getMaKhachHang() { return maKhachHang; }
    public String getHoTen() { return hoTen; }
    public LocalDate getNgaySinh() { return ngaySinh; }
    public String getSoCanCuocCongDan() { return soCanCuocCongDan; }
    public String getNgheNghiep() { return ngheNghiep; }
}
