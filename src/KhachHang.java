import java.time.LocalDate;
public class KhachHang {
    private String maKhachHang ;
    private String hoTen ;
    private LocalDate ngaySinh ;
    private int cccd ;
    private String ngheNghiep ;

    public KhachHang(String mkh ,String ht , LocalDate ns , int cd , String nn){
        maKhachHang = mkh ;
        hoTen = ht ;
        ngaySinh = ns ;
        cccd = cd ;
        ngheNghiep = nn ;
    }

}
