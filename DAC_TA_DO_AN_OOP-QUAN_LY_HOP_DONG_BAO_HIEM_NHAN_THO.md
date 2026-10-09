# ĐẶC TẢ DỰ ÁN OOP – QUẢN LÝ HỢP ĐỒNG BẢO HIỂM NHÂN THỌ

## 1. Thông tin chung

- **Tên dự án : **Hệ thống quản lý hợp đồng bảo hiểm nhân thọ
- **Môn học : **Lập trình hướng đối tượng(OOP)
- **Ngôn ngữ : **Java
- **IDE : **IntelliJ IDEA
- **Số thành viên : **2
- **Thành viên : **Ngô Công Lợi, Nguyễn Khánh Nguyên
- **Mục tiêu : **Xây dựng mô hình hướng đối tượng cho hệ thống quản lý hợp đồng bảo hiểm nhân thọ, bao gồm khách hàng, loại bảo hiểm, hợp đồng, việc đóng phí, yêu cầu chi trả, nhân viên tư vấn và hoa hồng.

-- -

# 2. Phát biểu vấn đề

## 2.1.Bối cảnh

Một công ty bảo hiểm nhân thọ cần quản lý chi tiết các hợp đồng bảo hiểm, cũng như các yêu cầu chi trả bảo hiểm từ khách hàng.

Công ty cung cấp nhiều** loại bảo hiểm** .Mỗi loại bảo hiểm có mã loại, tên loại, số tiền bảo hiểm tối đa có thể nhận được, số tiền định kỳ khách hàng phải đóng và kỳ thanh toán.Mỗi loại bảo hiểm có nhiều** quyền lợi** đi kèm.

** Khách hàng** là người mua bảo hiểm hoặc là người thụ hưởng bảo hiểm.Mỗi khách hàng có một mã khách hàng riêng biệt cùng các thông tin cá nhân như họ tên, ngày sinh, số căn cước công dân, nghề nghiệp.

Khi khách hàng mua bảo hiểm, hệ thống ghi nhận một** hợp đồng** .Mỗi hợp đồng do một khách hàng đại diện ký và do một** nhân viên** tư vấn phụ trách.Hợp đồng có ngày ký, ngày có hiệu lực, ngày hết hạn và trị giá hợp đồng.

Một hợp đồng gồm nhiều** chi tiết hợp đồng** .Mỗi chi tiết cho biết khách hàng thụ hưởng nào được bảo hiểm theo loại bảo hiểm nào trong hợp đồng.

Với mỗi chi tiết hợp đồng, khách hàng phải đóng phí định kỳ.Mỗi lần đóng phí được ghi lại trong** lịch sử đóng tiền** .Khi xảy ra sự kiện bảo hiểm, khách hàng gửi** yêu cầu bảo hiểm** để được chi trả, và công ty sẽ xử lý, duyệt hoặc từ chối yêu cầu đó.

Khi hợp đồng được ký, nhân viên tư vấn nhận được** hoa hồng** tương ứng.

## 2.2.Mục tiêu của hệ thống

Hệ thống cần hỗ trợ :

-Quản lý thông tin khách hàng.
- Quản lý các loại bảo hiểm và quyền lợi của từng loại.
- Quản lý hợp đồng bảo hiểm và chi tiết hợp đồng.
- Quản lý lịch sử đóng tiền của khách hàng.
- Quản lý yêu cầu chi trả bảo hiểm và theo dõi trạng thái xử lý.
- Quản lý nhân viên tư vấn.
- Quản lý hoa hồng của nhân viên.
- Tra cứu hợp đồng, lịch sử đóng tiền, yêu cầu chi trả của khách hàng.
- Thống kê hoạt động kinh doanh bảo hiểm.

-- -

# 3. Xác định các thực thể(Entities)

## 3.1.Danh sách thực thể

| STT | Thực thể | Mô tả |
|-- - | -- - | -- - |
| 1 | KhachHang | Khách hàng mua bảo hiểm / người thụ hưởng |
| 2 | LoaiBaoHiem | Loại bảo hiểm công ty cung cấp |
| 3 | HopDong | Hợp đồng bảo hiểm đã ký kết |
| 4 | ChiTietHopDong | Chi tiết hợp đồng(ai được bảo hiểm theo loại nào) |
| 5 | LichSuDongTien | Lịch sử đóng tiền của chi tiết hợp đồng |
| 6 | YeuCauBaoHiem | Yêu cầu chi trả quyền lợi bảo hiểm |
| 7 | NhanVien | Nhân viên tư vấn phụ trách hợp đồng * (bổ sung) * |
| 8 | QuyenLoi | Quyền lợi của từng loại bảo hiểm * (bổ sung) * |
| 9 | HoaHong | Hoa hồng nhân viên nhận theo hợp đồng * (bổ sung) * |

-- -

# 4. Thuộc tính của các thực thể

## 4.1.KhachHang

| Thuộc tính | Loại | Mô tả |
|-- - | -- - | -- - |
| MaKhachHang | Khóa | Mã khách hàng |
| HoTen | Mô tả | Họ và tên |
| NgaySinh | Mô tả | Ngày sinh |
| CCCD | Mô tả | Số căn cước công dân |
| NgheNghiep | Mô tả | Nghề nghiệp |

**Khóa chính : **`MaKhachHang`

-- -

## 4.2.LoaiBaoHiem

| Thuộc tính | Loại | Mô tả |
|-- - | -- - | -- - |
| MaLoaiBaoHiem | Khóa | Mã loại bảo hiểm |
| TenLoaiBaoHiem | Mô tả | Tên loại bảo hiểm |
| SoTienBaoHiem | Mô tả | Số tiền bảo hiểm tối đa có thể nhận được |
| SoTienDongDinhKy | Mô tả | Số tiền định kỳ khách hàng phải đóng |
| KyThanhToan | Enum | Kỳ thanh toán |

**Khóa chính : **`MaLoaiBaoHiem`

-- -

## 4.3.HopDong

| Thuộc tính | Loại | Mô tả |
|-- - | -- - | -- - |
| SoHopDong | Khóa | Số hợp đồng |
| NgayKyHopDong | Mô tả | Ngày ký hợp đồng |
| NgayHieuLuc | Mô tả | Ngày hợp đồng có hiệu lực |
| NgayHetHan | Mô tả | Ngày hết hạn hợp đồng |
| TriGia | Mô tả | Trị giá hợp đồng |
| MaKhachHangDaiDien | Khóa ngoại | Khách hàng đại diện ký hợp đồng |
| MaNhanVien | Khóa ngoại | Nhân viên tư vấn phụ trách |

**Khóa chính : **`SoHopDong`

* *Khóa ngoại : **`MaKhachHangDaiDien`, `MaNhanVien`

-- -

## 4.4.ChiTietHopDong

| Thuộc tính | Loại | Mô tả |
|-- - | -- - | -- - |
| MaChiTietHopDong | Khóa | Mã chi tiết hợp đồng |
| SoHopDong | Khóa ngoại | Hợp đồng chứa chi tiết |
| MaKhachHangThuHuong | Khóa ngoại | Khách hàng thụ hưởng |
| MaLoaiBaoHiem | Khóa ngoại | Loại bảo hiểm được mua |

**Khóa chính : **`MaChiTietHopDong`

* *Khóa ngoại : **`SoHopDong`, `MaKhachHangThuHuong`, `MaLoaiBaoHiem`

-- -

## 4.5.LichSuDongTien

| Thuộc tính | Loại | Mô tả |
|-- - | -- - | -- - |
| MaGiaoDich | Khóa | Mã giao dịch |
| NgayDongTien | Mô tả | Ngày đóng tiền |
| SoTienDong | Mô tả | Số tiền đã đóng |
| PhuongThuc | Enum | Phương thức đóng tiền |
| MaChiTietHopDong | Khóa ngoại | Chi tiết hợp đồng được đóng tiền |

**Khóa chính : **`MaGiaoDich`

* *Khóa ngoại : **`MaChiTietHopDong`

-- -

## 4.6.YeuCauBaoHiem

| Thuộc tính | Loại | Mô tả |
|-- - | -- - | -- - |
| MaYeuCau | Khóa | Mã yêu cầu |
| SoTienYeuCau | Mô tả | Số tiền yêu cầu chi trả |
| SoTienDuyetChi | Mô tả | Số tiền công ty đã duyệt |
| NgayYeuCau | Mô tả | Ngày gửi yêu cầu |
| TrangThai | Enum | Trạng thái xử lý |
| MaChiTietHopDong | Khóa ngoại | Chi tiết hợp đồng liên quan |

**Khóa chính : **`MaYeuCau`

* *Khóa ngoại : **`MaChiTietHopDong`

-- -

## 4.7.NhanVien

| Thuộc tính | Loại | Mô tả |
|-- - | -- - | -- - |
| MaNhanVien | Khóa | Mã nhân viên |
| HoTen | Mô tả | Họ và tên |
| SoDienThoai | Mô tả | Số điện thoại |
| Email | Mô tả | Email |
| ChucVu | Enum | Chức vụ |

**Khóa chính : **`MaNhanVien`

-- -

## 4.8.QuyenLoi

| Thuộc tính | Loại | Mô tả |
|-- - | -- - | -- - |
| MaQuyenLoi | Khóa | Mã quyền lợi |
| TenQuyenLoi | Mô tả | Tên quyền lợi |
| MoTa | Mô tả | Mô tả chi tiết quyền lợi |
| TyLeChiTra | Mô tả | Tỷ lệ chi trả(% trên số tiền bảo hiểm) |
| MaLoaiBaoHiem | Khóa ngoại | Loại bảo hiểm áp dụng quyền lợi |

**Khóa chính : **`MaQuyenLoi`

* *Khóa ngoại : **`MaLoaiBaoHiem`

-- -

## 4.9.HoaHong

| Thuộc tính | Loại | Mô tả |
|-- - | -- - | -- - |
| MaHoaHong | Khóa | Mã hoa hồng |
| TyLeHoaHong | Mô tả | Tỷ lệ hoa hồng(% phí năm đầu) |
| SoTienHoaHong | Mô tả | Số tiền hoa hồng |
| NgayChiHoaHong | Mô tả | Ngày chi hoa hồng |
| SoHopDong | Khóa ngoại | Hợp đồng phát sinh hoa hồng |
| MaNhanVien | Khóa ngoại | Nhân viên nhận hoa hồng |

**Khóa chính : **`MaHoaHong`

* *Khóa ngoại : **`SoHopDong`, `MaNhanVien`

-- -

# 5. Xác định các mối liên kết(Relationships)

## 5.1.KhachHang – HopDong

* *Quan hệ : **`DAI_DIEN_KY`

- Một KhachHang có thể đại diện ký nhiều HopDong.
- Một HopDong chỉ có đúng một KhachHang đại diện ký.

* *Cardinality:**`KhachHang 1 : N HopDong`

-- -

## 5.2.NhanVien – HopDong

* *Quan hệ : **`PHU_TRACH`

- Một NhanVien có thể phụ trách nhiều HopDong.
- Một HopDong do đúng một NhanVien phụ trách.

** Cardinality:**`NhanVien 1 : N HopDong`

-- -

## 5.3.HopDong – ChiTietHopDong

* *Quan hệ : **`GOM`

- Một HopDong gồm nhiều ChiTietHopDong.
- Một ChiTietHopDong thuộc về đúng một HopDong.

* *Cardinality:**`HopDong 1 : N ChiTietHopDong`

-- -

## 5.4.LoaiBaoHiem – ChiTietHopDong

* *Quan hệ : **`AP_DUNG`

- Một LoaiBaoHiem có thể xuất hiện trong nhiều ChiTietHopDong.
- Một ChiTietHopDong chỉ mua đúng một LoaiBaoHiem.

* *Cardinality:**`LoaiBaoHiem 1 : N ChiTietHopDong`

-- -

## 5.5.KhachHang – ChiTietHopDong

* *Quan hệ : **`THU_HUONG`

- Một KhachHang có thể là người thụ hưởng của nhiều ChiTietHopDong.
- Một ChiTietHopDong có đúng một KhachHang thụ hưởng.

* *Cardinality:**`KhachHang 1 : N ChiTietHopDong`

-- -

## 5.6.ChiTietHopDong – LichSuDongTien

* *Quan hệ : **`GHI_NHAN_DONG_TIEN`

- Một ChiTietHopDong có nhiều lần đóng tiền(LichSuDongTien) theo thời gian.
- Một LichSuDongTien thuộc về đúng một ChiTietHopDong.

* *Cardinality:**`ChiTietHopDong 1 : N LichSuDongTien`

-- -

## 5.7.ChiTietHopDong – YeuCauBaoHiem

* *Quan hệ : **`PHAT_SINH_YEU_CAU`

- Một ChiTietHopDong có thể phát sinh nhiều YeuCauBaoHiem.
- Một YeuCauBaoHiem thuộc về đúng một ChiTietHopDong.

* *Cardinality:**`ChiTietHopDong 1 : N YeuCauBaoHiem`

-- -

## 5.8.LoaiBaoHiem – QuyenLoi

* *Quan hệ : **`CO_QUYEN_LOI`

- Một LoaiBaoHiem có nhiều QuyenLoi.
- Một QuyenLoi thuộc về đúng một LoaiBaoHiem.

* *Cardinality:**`LoaiBaoHiem 1 : N QuyenLoi`

-- -

## 5.9.HopDong – HoaHong

* *Quan hệ : **`PHAT_SINH_HOA_HONG`

- Một HopDong có thể phát sinh nhiều khoản HoaHong.
- Một HoaHong thuộc về đúng một HopDong.

* *Cardinality:**`HopDong 1 : N HoaHong`

-- -

## 5.10.NhanVien – HoaHong

* *Quan hệ : **`NHAN_HOA_HONG`

- Một NhanVien có thể nhận nhiều khoản HoaHong.
- Một HoaHong được chi cho đúng một NhanVien.

* *Cardinality:**`NhanVien 1 : N HoaHong`

-- -

# 6. ERD

ERD tổng quát của hệ thống :

```text
+ ------------------------------ +
| KHACHHANG |
+------------------------------ +
| PK MaKhachHang               |
| HoTen                        |
| NgaySinh                     |
| SoCanCuocCongDan             |
| NgheNghiep |
+-------------- + -------------- - +
|
|  1 : N(đại diện ký)
|
+--------------v-------------- - +
| HOPDONG |
+------------------------------ +
| PK SoHopDong                 |
| NgayKyHopDong                |
| NgayHieuLuc                  |
| NgayHetHan                   |
| TriGia                       |
| FK MaKhachHangDaiDien        |
| FK MaNhanVien |
+-------------- + -------------- - +
|
|  1 : N
|
+--------------v-------------- - +
| CHITIETHOPDONG |
+------------------------------ +
| PK MaChiTietHopDong          |
| FK SoHopDong                 |
| FK MaKhachHangThuHuong       |
| FK MaLoaiBaoHiem |
+-------------- + -------------- - +
|
+-------------------------------------- - +
|                                       |
|  1 : N | 1 : N
|                                       |
+--------------v-------------- - ++--------------v-------------- - +
| LICHSUDONGTIEN        |        |        YEUCAUBAOHIEM |
+------------------------------ + +------------------------------ +
| PK MaGiaoDich                |        | PK MaYeuCau                  |
| NgayDongTien                 |        | SoTienYeuCau                 |
| SoTienDong                   |        | SoTienDuyetChi               |
| PhuongThuc                   |        | NgayYeuCau                   |
| FK MaChiTietHopDong          |        | TrangThai |
+------------------------------ + | FK MaChiTietHopDong |
+------------------------------ +


(Nhân viên)  NHANVIEN 1 : N HOPDONG(MaNhanVien); NHANVIEN 1 : N HOAHONG; HOPDONG 1 : N HOAHONG


+ ------------------------------ +
| NHANVIEN |
+------------------------------ +
| PK MaNhanVien                |
| HoTen                        |
| SoDienThoai                  |
| Email                        |
| ChucVu |
+-------------- + -------------- - +
|
|  1 : N
|
+--------------v-------------- - +
| HOAHONG |
+------------------------------ +
| PK MaHoaHong                 |
| TyLeHoaHong                  |
| SoTienHoaHong                |
| NgayChiHoaHong               |
| FK SoHopDong                 |
| FK MaNhanVien |
+------------------------------ +


(Loại bảo hiểm)  LOAIBAOHIEM 1 : N CHITIETHOPDONG(MaLoaiBaoHiem)


+ ------------------------------ +
| LOAIBAOHIEM |
+------------------------------ +
| PK MaLoaiBaoHiem             |
| TenLoaiBaoHiem               |
| SoTienBaoHiem                |
| SoTienDongDinhKy             |
| KyThanhToan |
+-------------- + -------------- - +
|
|  1 : N
|
+--------------v-------------- - +
| QUYENLOI |
+------------------------------ +
| PK MaQuyenLoi                |
| TenQuyenLoi                  |
| MoTa                         |
| TyLeChiTra                   |
| FK MaLoaiBaoHiem |
+------------------------------ +


Liên kết bổ sung :
KHACHHANG(MaKhachHang) ---- 1 : N(thụ hưởng) ---- > CHITIETHOPDONG(MaKhachHangThuHuong)
```

> **Lưu ý : **Khi vẽ ERD chính thức, nhóm có thể sử dụng draw.io, Lucidchart hoặc công cụ ERD khác.Sơ đồ trên là mô hình logic để chuyển sang ERD.

-- -

# 7. Chuyển ERs / RRs thành các lớp Java

Mỗi thực thể được chuyển thành một class Java.

## 7.1.Cấu trúc project đề xuất

```text
src /
└── main /
└── java /
└── baohiem /
├── model /
│   ├── KhachHang.java
│   ├── LoaiBaoHiem.java
│   ├── HopDong.java
│   ├── ChiTietHopDong.java
│   ├── LichSuDongTien.java
│   ├── YeuCauBaoHiem.java
│   ├── NhanVien.java
│   ├── QuyenLoi.java
│   └── HoaHong.java
│
├── enums /
│   ├── KyThanhToan.java
│   ├── PhuongThuc.java
│   ├── TrangThaiYeuCau.java
│   └── ChucVu.java
│
└── Main.java
```

-- -

# 8. Các class chính

## 8.1.KhachHang

```java
public class KhachHang {
    private String maKhachHang;
    private String hoTen;
    private LocalDate ngaySinh;
    private String soCanCuocCongDan;
    private String ngheNghiep;
}
```

## 8.2.LoaiBaoHiem

```java
public class LoaiBaoHiem {
    private String maLoaiBaoHiem;
    private String tenLoaiBaoHiem;
    private long soTienBaoHiem;
    private long soTienDongDinhKy;
    private KyThanhToan kyThanhToan;
}
```

## 8.3.HopDong

```java
public class HopDong {
    private String soHopDong;
    private LocalDate ngayKyHopDong;
    private LocalDate ngayHieuLuc;
    private LocalDate ngayHetHan;
    private long triGia;
    private String maKhachHangDaiDien;
    private String maNhanVien;
}
```

## 8.4.ChiTietHopDong

```java
public class ChiTietHopDong {
    private String maChiTietHopDong;
    private String soHopDong;
    private String maKhachHangThuHuong;
    private String maLoaiBaoHiem;
}
```

## 8.5.LichSuDongTien

```java
public class LichSuDongTien {
    private String maGiaoDich;
    private LocalDate ngayDongTien;
    private long soTienDong;
    private PhuongThuc phuongThuc;
    private String maChiTietHopDong;
}
```

## 8.6.YeuCauBaoHiem

```java
public class YeuCauBaoHiem {
    private String maYeuCau;
    private long soTienYeuCau;
    private long soTienDuyetChi;
    private LocalDate ngayYeuCau;
    private TrangThaiYeuCau trangThai;
    private String maChiTietHopDong;
}
```

## 8.7.NhanVien

```java
public class NhanVien {
    private String maNhanVien;
    private String hoTen;
    private String soDienThoai;
    private String email;
    private ChucVu chucVu;
}
```

## 8.8.QuyenLoi

```java
public class QuyenLoi {
    private String maQuyenLoi;
    private String tenQuyenLoi;
    private String moTa;
    private double tyLeChiTra;
    private String maLoaiBaoHiem;
}
```

## 8.9.HoaHong

```java
public class HoaHong {
    private String maHoaHong;
    private double tyLeHoaHong;
    private long soTienHoaHong;
    private LocalDate ngayChiHoaHong;
    private String soHopDong;
    private String maNhanVien;
}
```

-- -

# 9. Các Enum

## 9.1.KyThanhToan

```java
public enum KyThanhToan {
    HANG_THANG,
    HANG_QUY,
    NUA_NAM,
    HANG_NAM
}
```

## 9.2.PhuongThuc

```java
public enum PhuongThuc {
    TIEN_MAT,
    CHUYEN_KHOAN,
    THE,
    VI_DIEN_TU
}
```

## 9.3.TrangThaiYeuCau

```java
public enum TrangThaiYeuCau {
    CHO_XU_LY,
    DANG_THAM_DINH,
    DA_DUYET,
    TU_CHOI
}
```

## 9.4.ChucVu

```java
public enum ChucVu {
    TU_VAN_VIEN,
    TRUONG_NHOM,
    QUAN_LY
}
```

-- -

# 10. Dữ liệu mẫu cho các thực thể

## 10.1.KhachHang

| MaKhachHang | HoTen | NgaySinh | SoCanCuocCongDan | NgheNghiep |
|-- - | -- - | -- - | -- - | -- - |
| KH001 | Nguyễn Văn An | 1985 - 03 - 12 | 079085001234 | Kỹ sư |
| KH002 | Trần Thị Bình | 1990 - 07 - 25 | 079190005678 | Giáo viên |
| KH003 | Lê Hoàng Cường | 1978 - 11 - 02 | 079078009012 | Kinh doanh |
| KH004 | Phạm Thu Dung | 1995 - 01 - 18 | 079195003456 | Nhân viên văn phòng |
| KH005 | Trần Minh Khang | 2016 - 08 - 14 | 079216001111 | Học sinh |
| KH006 | Võ Quốc Em | 1982 - 05 - 30 | 079082007890 | Bác sĩ |

## 10.2.LoaiBaoHiem

| MaLoaiBaoHiem | TenLoaiBaoHiem | SoTienBaoHiem | SoTienDongDinhKy | KyThanhToan |
|-- - | -- - | -- - : | -- - : | -- - |
| LBH01 | Bảo hiểm nhân thọ trọn đời | 1000000000 | 12000000 | HANG_NAM |
| LBH02 | Bảo hiểm tử kỳ 20 năm | 500000000 | 3000000 | HANG_QUY |
| LBH03 | Bảo hiểm sức khỏe cao cấp | 300000000 | 1200000 | HANG_THANG |
| LBH04 | Bảo hiểm giáo dục | 400000000 | 6000000 | NUA_NAM |

## 10.3.NhanVien

| MaNhanVien | HoTen | SoDienThoai | Email | ChucVu |
|-- - | -- - | -- - | -- - | -- - |
| NV01 | Hoàng Minh Tuấn | 0901111111 | tuan.hm@baohiem.vn | TU_VAN_VIEN |
| NV02 | Đỗ Thị Lan | 0902222222 | lan.dt@baohiem.vn | TRUONG_NHOM |
| NV03 | Bùi Quang Huy | 0903333333 | huy.bq@baohiem.vn | QUAN_LY |

## 10.4.HopDong

| SoHopDong | NgayKyHopDong | NgayHieuLuc | NgayHetHan | TriGia | MaKhachHangDaiDien | MaNhanVien |
|-- - | -- - | -- - | -- - | -- - : | -- - | -- - |
| HD001 | 2023 - 01 - 10 | 2023 - 01 - 15 | 2043 - 01 - 15 | 1300000000 | KH001 | NV01 |
| HD002 | 2023 - 06 - 01 | 2023 - 06 - 10 | 2043 - 06 - 10 | 500000000 | KH003 | NV01 |
| HD003 | 2024 - 02 - 20 | 2024 - 03 - 01 | 2044 - 03 - 01 | 700000000 | KH002 | NV02 |
| HD004 | 2024 - 09 - 05 | 2024 - 09 - 15 | 2034 - 09 - 15 | 500000000 | KH004 | NV02 |
| HD005 | 2025 - 04 - 12 | 2025 - 04 - 20 | 2045 - 04 - 20 | 300000000 | KH001 | NV01 |

## 10.5.ChiTietHopDong

| MaChiTietHopDong | SoHopDong | MaKhachHangThuHuong | MaLoaiBaoHiem |
|-- - | -- - | -- - | -- - |
| CT001 | HD001 | KH002 | LBH01 |
| CT002 | HD001 | KH001 | LBH03 |
| CT003 | HD002 | KH003 | LBH02 |
| CT004 | HD003 | KH005 | LBH04 |
| CT005 | HD003 | KH002 | LBH03 |
| CT006 | HD004 | KH004 | LBH02 |
| CT007 | HD005 | KH005 | LBH03 |

## 10.6.LichSuDongTien

| MaGiaoDich | NgayDongTien | SoTienDong | PhuongThuc | MaChiTietHopDong |
|-- - | -- - | -- - : | -- - | -- - |
| GD001 | 2023 - 01 - 15 | 12000000 | CHUYEN_KHOAN | CT001 |
| GD002 | 2024 - 01 - 15 | 12000000 | CHUYEN_KHOAN | CT001 |
| GD003 | 2023 - 01 - 15 | 1200000 | THE | CT002 |
| GD004 | 2023 - 02 - 15 | 1200000 | THE | CT002 |
| GD005 | 2023 - 06 - 10 | 3000000 | TIEN_MAT | CT003 |
| GD006 | 2023 - 09 - 10 | 3000000 | TIEN_MAT | CT003 |
| GD007 | 2024 - 03 - 01 | 6000000 | VI_DIEN_TU | CT004 |
| GD008 | 2024 - 09 - 15 | 3000000 | CHUYEN_KHOAN | CT006 |
| GD009 | 2025 - 04 - 20 | 1200000 | VI_DIEN_TU | CT007 |

## 10.7.YeuCauBaoHiem

| MaYeuCau | SoTienYeuCau | SoTienDuyetChi | NgayYeuCau | TrangThai | MaChiTietHopDong |
|-- - | -- - : | -- - : | -- - | -- - | -- - |
| YC001 | 15000000 | 15000000 | 2024 - 05 - 10 | DA_DUYET | CT002 |
| YC002 | 200000000 | 0 | 2024 - 08 - 01 | TU_CHOI | CT003 |
| YC003 | 20000000 | 18000000 | 2025 - 01 - 12 | DA_DUYET | CT005 |
| YC004 | 10000000 | 0 | 2025 - 06 - 20 | DANG_THAM_DINH | CT004 |
| YC005 | 5000000 | 0 | 2025 - 09 - 01 | CHO_XU_LY | CT006 |

## 10.8.QuyenLoi

| MaQuyenLoi | TenQuyenLoi | MoTa | TyLeChiTra | MaLoaiBaoHiem |
|-- - | -- - | -- - | -- - : | -- - |
| QL01 | Tử vong tự nhiên | Chi trả toàn bộ số tiền bảo hiểm khi tử vong | 100 | LBH01 |
| QL02 | Thương tật toàn bộ vĩnh viễn | Chi trả khi mất khả năng lao động vĩnh viễn | 100 | LBH01 |
| QL03 | Tử vong do tai nạn | Chi trả gấp đôi nếu tử vong do tai nạn | 200 | LBH02 |
| QL04 | Nằm viện nội trú | Chi trả chi phí điều trị nội trú | 10 | LBH03 |
| QL05 | Phẫu thuật | Chi trả chi phí phẫu thuật | 30 | LBH03 |
| QL06 | Hỗ trợ học phí | Hỗ trợ học phí khi người đóng phí gặp rủi ro | 25 | LBH04 |

## 10.9.HoaHong

| MaHoaHong | TyLeHoaHong | SoTienHoaHong | NgayChiHoaHong | SoHopDong | MaNhanVien |
|-- - | -- - : | -- - : | -- - | -- - | -- - |
| HH001 | 20 | 5280000 | 2023 - 02 - 01 | HD001 | NV01 |
| HH002 | 20 | 2400000 | 2023 - 07 - 01 | HD002 | NV01 |
| HH003 | 25 | 6600000 | 2024 - 04 - 01 | HD003 | NV02 |
| HH004 | 25 | 3000000 | 2024 - 10 - 01 | HD004 | NV02 |
| HH005 | 20 | 2880000 | 2025 - 05 - 01 | HD005 | NV01 |

-- -

# 11. Phân công cho 2 thành viên

## Thành viên 1 – Quản lý khách hàng và hợp đồng

### Phụ trách :

-KhachHang
- HopDong
- ChiTietHopDong
- Quan hệ KhachHang – HopDong, HopDong – ChiTietHopDong, KhachHang – ChiTietHopDong
- Dữ liệu mẫu KhachHang, HopDong, ChiTietHopDong
- Các truy vấn liên quan khách hàng và hợp đồng.

### Class chính :

```text
KhachHang.java
HopDong.java
ChiTietHopDong.java
```

### Nhiệm vụ :

1. Thiết kế thuộc tính.
2. Tạo constructor.
3. Getter / Setter.
4. `toString()`.
5. Tạo dữ liệu mẫu.
6. Viết 10 câu truy vấn.

-- -

## Thành viên 2 – Quản lý bảo hiểm, thanh toán và nhân viên

### Phụ trách :

-LoaiBaoHiem
- QuyenLoi
- LichSuDongTien
- YeuCauBaoHiem
- NhanVien
- HoaHong
- Các Enum.
- Dữ liệu mẫu.
- Quan hệ giữa loại bảo hiểm, quyền lợi, đóng tiền, yêu cầu chi trả, nhân viên và hoa hồng.
- Các truy vấn liên quan.

### Class chính :

```text
LoaiBaoHiem.java
QuyenLoi.java
LichSuDongTien.java
YeuCauBaoHiem.java
NhanVien.java
HoaHong.java
```

### Enum:

```text
KyThanhToan.java
PhuongThuc.java
TrangThaiYeuCau.java
ChucVu.java
```

### Nhiệm vụ :

1. Thiết kế thuộc tính.
2. Tạo constructor.
3. Getter / Setter.
4. `toString()`.
5. Tạo dữ liệu mẫu.
6. Viết 10 câu truy vấn.

-- -

# 12. 20 câu truy vấn của dự án

> Các câu truy vấn dưới đây mới chỉ là * *yêu cầu truy vấn**, chưa thực hiện code Java.
>
> Mỗi thành viên chỉ có** 1 câu dạng liệt kê**; 9 câu còn lại thuộc các dạng khác nhau(tìm kiếm, đếm, tính tổng, trung bình, lớn nhất / nhỏ nhất, sắp xếp, kiểm tra, ...).

## 12.1.Thành viên 1 – KhachHang, HopDong& ChiTietHopDong

### Query 1
Liệt kê toàn bộ khách hàng trong hệ thống.

### Query 2
Tìm khách hàng theo số căn cước công dân.

### Query 3
Đếm số hợp đồng mà mỗi khách hàng đại diện ký.

### Query 4
Tính tổng trị giá của tất cả các hợp đồng trong hệ thống.

### Query 5
Tìm hợp đồng có trị giá cao nhất, kèm họ tên khách hàng đại diện và tên nhân viên phụ trách.

### Query 6
Tính trị giá trung bình của các hợp đồng được ký trong năm 2024.

### Query 7
Sắp xếp các hợp đồng theo ngày hết hạn tăng dần và cho biết 3 hợp đồng sắp hết hạn nhất.

### Query 8
Đếm số chi tiết hợp đồng theo từng loại bảo hiểm và cho biết loại bảo hiểm được mua nhiều nhất.

### Query 9
Kiểm tra một khách hàng cụ thể có đang là người thụ hưởng của hợp đồng do người khác đại diện ký hay không.

### Query 10
Tìm các khách hàng chưa đại diện ký hợp đồng nào và cũng chưa là người thụ hưởng của chi tiết hợp đồng nào.

-- -

## 12.2.Thành viên 2 – LoaiBaoHiem, QuyenLoi, LichSuDongTien, YeuCauBaoHiem, NhanVien& HoaHong

### Query 11
Liệt kê các quyền lợi của một loại bảo hiểm cụ thể.

### Query 12
Tìm loại bảo hiểm có số tiền bảo hiểm tối đa cao nhất.

### Query 13
Tính tổng số tiền đã đóng của từng hợp đồng.

### Query 14
Đếm số giao dịch đóng tiền theo từng phương thức thanh toán và cho biết phương thức được dùng nhiều nhất.

### Query 15
Tính tổng số tiền khách hàng đã đóng bằng chuyển khoản trong năm 2024.

### Query 16
Đếm số yêu cầu bảo hiểm theo từng trạng thái xử lý.

### Query 17
Tính tổng số tiền công ty đã duyệt chi cho từng khách hàng thụ hưởng.

### Query 18
Tìm yêu cầu bảo hiểm có số tiền yêu cầu lớn nhất, kèm họ tên khách hàng thụ hưởng và tên loại bảo hiểm.

### Query 19
Tính tổng số tiền hoa hồng của từng nhân viên và xác định nhân viên có tổng hoa hồng cao nhất.

### Query 20
Tìm các chi tiết hợp đồng chưa có lần đóng tiền nào.

-- -

# 13. Quy tắc đặt tên

## Class

Sử dụng PascalCase, viết đầy đủ từ :

```text
KhachHang
LoaiBaoHiem
HopDong
ChiTietHopDong
LichSuDongTien
YeuCauBaoHiem
```

## Attribute

Trong bảng đặc tả, tên thuộc tính viết PascalCase đầy đủ từ :

```text
MaKhachHang
HoTen
SoTienBaoHiem
SoHopDong
NgayDongTien
```

Khi chuyển sang code Java, tên thuộc tính của class viết camelCase tương ứng :

```text
maKhachHang
hoTen
soTienBaoHiem
soHopDong
ngayDongTien
```

## Enum

Tên enum sử dụng PascalCase :

```text
KyThanhToan
PhuongThuc
TrangThaiYeuCau
ChucVu
```

Giá trị enum viết hoa :

    ```text
    HANG_THANG
    CHUYEN_KHOAN
    DA_DUYET
    TU_CHOI
    TU_VAN_VIEN
    ```

    -- -

    # 14. Kết quả cần đạt của bài

    Sau khi hoàn thành giai đoạn này, nhóm cần có :

-[x] Phát biểu vấn đề của hệ thống.
- [x] Xác định các thực thể.
- [x] Xác định thuộc tính của từng thực thể.
- [x] Xác định khóa chính.
- [x] Xác định khóa ngoại.
- [x] Xác định các mối liên kết.
- [x] Xây dựng ERD.
- [x] Chuyển các thực thể thành Java class.
- [x] Xác định các enum cần thiết.
- [x] Tạo dữ liệu mẫu cho 9 thực thể.
- [x] Phân chia công việc cho 2 thành viên.
- [x] Mỗi thành viên xây dựng 10 câu truy vấn.
- [] Code các truy vấn.
- [] Kiểm thử chương trình.
- [] Hoàn thiện `Main.java`.
- [] Hoàn thiện báo cáo và thuyết trình.

-- -

# 15. Tổng quan mô hình

```text
+ ------------ - ++------------ - +
| KHACHHANG   |                |  NHANVIEN |
+------ + ------ + +-- - +---- - +-- - +
|                           |     |
| 1 : N | 1 : N |
v                           |     |
+------------ - +<---------------- - +|
    |   HOPDONG | v
    + ------ + ------ + ------------------> +---------- - +
    | 1 : N | HOAHONG  |
    | 1 : N + ---------- - +
    v
    + ---------------------- + N : 1 + -------------- + 1 : N + ---------- - +
    | CHITIETHOPDONG | <-------- + LOAIBAOHIEM + --------> | QUYENLOI |
    +---------- - +---------- + +-------------- + +---------- - +
    |
    +-------- + -------- - +
    | 1 : N | 1 : N
    v                  v
    + ---------------- + +---------------- +
    | LICHSUDONGTIEN |  | YEUCAUBAOHIEM |
    +---------------- + +---------------- +

    KHACHHANG---- 1 : N(thụ hưởng) ---- > CHITIETHOPDONG
    ```

    ## Mô hình nghiệp vụ cốt lõi

    * *KhachHang → HopDong → ChiTietHopDong → LichSuDongTien / YeuCauBaoHiem * *

    và

    * *LoaiBaoHiem → ChiTietHopDong**, ** LoaiBaoHiem → QuyenLoi**

    và

    ** NhanVien → HopDong → HoaHong**

    Các chuỗi quan hệ này tạo thành phần lõi của hệ thống quản lý hợp đồng bảo hiểm nhân thọ.