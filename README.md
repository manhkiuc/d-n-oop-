# Hệ thống Quản lý Hợp đồng Bảo hiểm Nhân thọ — bản C# (ASP.NET Core 8)

## Chạy
```bash
dotnet run                 # web:  http://localhost:5000  (xem cổng in ra ở terminal)
dotnet run -- console      # Main trình bày cả 20 truy vấn trên console
dotnet run -- console 7    # chỉ chạy Query 7
```

## Cấu trúc project (dùng để trình bày trong video)
| Thư mục / file | Vai trò |
|---|---|
| `Enums/` | 4 enum: KyThanhToan, PhuongThuc, TrangThaiYeuCau, ChucVu |
| `Models/` | 9 class thực thể (chuyển từ ERD): thuộc tính, constructor, getter/setter, ToString |
| `DAO/` | `IDao<T>` (CRUD); `MapDao<T>` (Dictionary) cho nhóm danh mục; `ListDao<T>` (List + Dictionary gom theo khóa ngoại) cho nhóm giao dịch; 9 DAO cụ thể |
| `Data/Db.cs`, `DataSeeder.cs` | Kho dữ liệu in-memory + dữ liệu mẫu theo Mục 10 đặc tả |
| `Queries/` | `TruyVanThanhVien1` (Q1–10), `TruyVanThanhVien2` (Q11–20) viết bằng LINQ; `QueryCatalog` danh bạ truy vấn |
| `ApiRoutes.cs` | Server: CRUD REST 9 thực thể (kiểm tra khóa ngoại) + `/api/queries` + `/api/tongquan` |
| `Program.cs` | `Main`: nạp dữ liệu, chọn chế độ console/web |
| `wwwroot/index.html` | Giao diện web (SPA): dashboard, CRUD 9 thực thể, chạy 20 truy vấn |

## Các bước làm ra project
1. Khảo sát nghiệp vụ → phát biểu bài toán → xác định 9 thực thể, thuộc tính, khóa, quan hệ → ERD.
2. Chuyển thực thể thành class (Models) + enum.
3. Chọn cấu trúc dữ liệu theo 20 truy vấn (file phân tích): danh mục → Dictionary, giao dịch → List (+ Dictionary gom theo FK).
4. Viết DAO cho từng thực thể.
5. Nạp dữ liệu mẫu.
6. Viết 20 truy vấn LINQ (mỗi thành viên 10 câu).
7. Viết server REST + giao diện web.
8. Kiểm thử bằng chế độ console và web.

## Kết quả mong đợi với dữ liệu mẫu (để đối chiếu khi kiểm thử)
Q4 = 3.300.000.000 · Q5 = HD001 (Nguyễn Văn An / Hoàng Minh Tuấn) · Q6(2024) = 600.000.000 ·
Q8: LBH03 (3 chi tiết) · Q9(KH002) = true · Q10 = KH006 · Q12 = LBH01 · Q13: HD001 = 26.400.000 ·
Q14: CHUYEN_KHOAN (3) · Q15(2024) = 15.000.000 · Q19: NV01 = 10.560.000 · Q20 = CT005
