
# **XÂY DỰNG WEBSITE ĐỌC TRUYỆN TRỰC TUYẾN**
**Hà Nội, tháng 2 năm 2024**

# MỤC LỤC

[MỤC LỤC](#_Toc159704725)

[DANH MỤC BẢNG BIỂU](#_Toc159704726)

[DANH MỤC HÌNH ẢNH](#_Toc159704727)

[NỘI DUNG CÔNG VIỆC](#_Toc159704728)

[CHƯƠNG 1: TÌM HIỂU CÔNG NGHỆ SỬ DỤNG](#_Toc159704729)

[1.1. ASP.NET ](#_Toc159704730)

[1.2. Hệ quản trị cơ sở dữ liệu SQL Server ](#_Toc159704731)

[1.3. HTML, CSS và Javascript ](#_Toc159704732)

[CHƯƠNG 2: TÌM HIỂU BÀI TOÁN VÀ PHÂN TÍCH THIẾT KẾ HỆ THỐNG ](#_Toc159704733)

[2.1. Mục tiêu bài toán ](#_Toc159704734)

[2.2. Khảo sát ](#_Toc159704735)

[2.3. Các chức năng của website ](#_Toc159704736)

[2.4. Phân tích và thiết kế cơ sở dữ liệu ](#_Toc159704737)

[2.4.1. Mô hình quan hệ ](#_Toc159704738)

[2.4.2. Mô tả dữ liệu ](#_Toc159704739)

[CHƯƠNG 3: XÂY DỰNG CHƯƠNG TRÌNH ](#_Toc159704740)

[3.1. Xây dựng giao diện trang chủ ](#_Toc159704741)

[3.2. Giao diện xem bài đăng ](#_Toc159704742)

[3.3. Chức năng đăng nhập, đăng ký, quên mật khẩu ](#_Toc159704743)

[3.4. Chức năng xem và quản lý thông tin tài khoản ](#_Toc159704744)

[3.5. Chức năng tìm kiếm truyện theo tên ](#_Toc159704745)

[3.6. Xem danh sách các truyện của một thể loại ](#_Toc159704746)

[3.7. Giao diện trang quản trị ](#_Toc159704747)

[3.8. Chức năng quản lý truyện ](#_Toc159704748)

[3.9. Chức năng quản lý chương truyện ](#_Toc159704749)

[3.10. Chức năng quản lý tác giả ](#_Toc159704750)

[3.11. Chức năng quản lý tài khoản người dùng ](#_Toc159704751)

[3.12. Chức năng quản lý thể loại ](#_Toc159704752)

[3.13. Chức năng quản lý menu danh mục ](#_Toc159704753)

[KẾT LUẬN ](#_Toc159704754)

# DANH MỤC BẢNG BIỂU

[Bảng 2.1: Mô tả bảng Articles ](#_Toc159706848)

[Bảng 2.2: Mô tả bảng Authors ](#_Toc159706849)

[Bảng 2.3: Mô tả bảng Genres ](#_Toc159706850)

[Bảng 2.4: Mô tả bảng Chapters ](#_Toc159706851)

[Bảng 2.5: Mô tả bảng Users ](#_Toc159706852)

[Bảng 2.6: Mô tả bảng Articles_Authors ](#_Toc159706853)

[Bảng 2.7: Mô tả bảng Articles_Genres ](#_Toc159706854)

[Bảng 2.8: Mô tả bảng Bookmarks ](#_Toc159706855)

[Bảng 2.9: Mô tả bảng Comments ](#_Toc159706856)

[Bảng 2.10: Mô tả bảng Categories ](#_Toc159706857)

# DANH MỤC HÌNH ẢNH

[Hình 2.1. Mô hình quan hệ ](#_Toc159706860)

[Hình 3.1. Giao diện trang chủ ](#_Toc159706871)

[Hình 3.2. Giao diện xem bài đăng ](#_Toc159706872)

[Hình 3.3. Giao diện thêm dấu trang ](#_Toc159706873)

[Hình 3.4. Giao diện đọc một chương truyện ](#_Toc159706874)

[Hình 3.5. Giao diện trang đăng nhập ](#_Toc159706875)

[Hình 3.6. Giao diện trang đăng ký ](#_Toc159706876)

[Hình 3.7. Giao diện trang quên mật khẩu ](#_Toc159706877)

[Hình 3.8. Giao diện xem thông tin tài khoản ](#_Toc159706878)

[Hình 3.9. Giao diện sửa thông tin tài khoản ](#_Toc159706879)

[Hình 3.10. Giao diện trang tìm kiếm truyện ](#_Toc159706880)

[Hình 3.11. Giao diện xem danh sách truyện của một thể loại ](#_Toc159706881)

[Hình 3.12. Giao diện trang quản trị ](#_Toc159706882)

[Hình 3.13. Giao diện trang hiển thị danh sách truyện ](#_Toc159706883)

[Hình 3.14. Giao diện trang thêm truyện ](#_Toc159706884)

[Hình 3.15. Giao diện trang sửa truyện ](#_Toc159706885)

[Hình 3.16. Giao diện trang hiển thị danh sách chương ](#_Toc159706886)

[Hình 3.17. Giao diện trang thêm chương mới ](#_Toc159706887)

[Hình 3.18. Giao diện trang sửa chương ](#_Toc159706888)

[Hình 3.19. Giao diện trang hiển thị danh sách tác giả ](#_Toc159706889)

[Hình 3.20. Giao diện trang thêm tác giả ](#_Toc159706890)

[Hình 3.21. Giao diện trang sửa tác giả ](#_Toc159706891)

[Hình 3.22. Giao diện trang hiển thị danh sách tài khoản ](#_Toc159706892)

[Hình 3.23. Giao diện trang sửa thông tin người dùng ](#_Toc159706893)

[Hình 3.24. Giao diện trang hiển thị danh sách thể loại ](#_Toc159706894)

[Hình 3.25. Giao diện trang thêm thể loại ](#_Toc159706895)

[Hình 3.26. Giao diện trang sửa thể loại ](#_Toc159706896)

[Hình 3.27. Giao diện trang hiển thị danh sách các đường liên kết ](#_Toc159706897)

[Hình 3.28. Giao diện menu danh mục ](#_Toc159706898)

[Hình 3.29. Giao diện trang thêm liên kết mới ](#_Toc159706899)

[Hình 3.30. Giao diện trang sửa liên kết ](#_Toc159706900)

# NỘI DUNG CÔNG VIỆC

| STT | Nhiệm vụ | Thời gian |
| --- | --- | --- |
| 1   | Tìm hiểu các công nghệ sử dụng | 01/01 – 07/01 |
| 2   | Khảo sát, phân tích chức năng, nghiệp vụ | 08/01 – 11/01 |
| 3   | Phân tích và thiết kế cơ sở dữ liệu | 12/01 – 14/01 |
| 4   | Thiết kế giao diện cho website | 15/01 – 21/01 |
| 5   | Khởi tạo dự án, kết nối cơ sở dữ liệu | 22/01 – 28/01 |
| 6   | Lập trình chức năng bên phía người dùng | 29/01 – 11/02 |
| 7   | Lập trình chức năng bên phía người quản trị | 12/02 – 18/02 |
| 8   | Kiểm thử và sửa lỗi | 19/02 – 22/02 |
| 9   | Hoàn thiện báo cáo | 23/02 – 24/02 |

# CHƯƠNG 1: TÌM HIỂU CÔNG NGHỆ SỬ DỤNG

## ASP.NET

ASP.NET là một nền tảng phát triển ứng dụng web mạnh mẽ và linh hoạt, có thể xây dựng các ứng dụng web chuyên nghiệp, tương tác và bảo mật, phục vụ người dùng trên nhiều nền tảng khác nhau.

Với ASP.NET Core, phiên bản open-source mới nhất của nền tảng ASP.NET hỗ trợ phát triển ứng dụng web chạy trên đa nền tảng và cung cấp các công cụ và thư viện mạnh mẽ để phát triển ứng dụng web nhanh chóng và an toàn. Điều này mang lại sự linh hoạt lớn cho việc triển khai ứng dụng trên các môi trường máy chủ khác nhau. ASP.NET Core có thể xây dựng ứng dụng web đa tầng, từ ứng dụng web phía máy chủ (server-side rendering) đến ứng dụng web phía khách hàng (client-side rendering) hoặc phát triển các restful API để cung cấp dữ liệu cho các ứng dụng di động và trình duyệt.

Không chỉ vậy, ASP.NET Core còn cung cấp hiệu suất cao và khả năng mở rộng trong việc xử lý yêu cầu web. ASP.NET Core được tối ưu hóa để đạt hiệu suất cao. Nó sử dụng mô hình xử lý yêu cầu và phản hồi không đồng bộ, giúp ứng dụng xử lý đồng thời nhiều yêu cầu mà không bị chặn. Ngoài ra, ASP.NET Core cũng hỗ trợ bộ đệm, nén dữ liệu và các kỹ thuật tối ưu hóa khác để cải thiện tốc độ tải trang. Với việc hỗ trợ các giao thức xác thực tiêu chuẩn trong ngành và tính năng bảo mật tích hợp, ASP.NET Core có thể bảo vệ ứng dụng chống lại các cuộc tấn công như cross-site scripting (XSS) và cross-site request forgery (CSRF).

Với sự kết hợp của tính linh hoạt, hiệu suất, bảo mật và hỗ trợ từ cộng đồng, ASP.NET đã trở thành một công cụ ưu việt cho việc phát triển ứng dụng web.

## Hệ quản trị cơ sở dữ liệu SQL Server

SQL Server là một hệ quản trị cơ sở dữ liệu quan hệ mạnh mẽ được phát triển bởi Microsoft. SQL Server hỗ trợ các tính năng quản lý dữ liệu mạnh mẽ như giao nhận và đồng bộ hóa dữ liệu, sao lưu và khôi phục dữ liệu, và bảo mật dữ liệu thông qua quyền truy cập và mã hóa. Nó cũng hỗ trợ các tính năng phân tích dữ liệu như xử lý phân tán, truy vấn phân tích và khả năng tạo báo cáo. Đồng thời, SQL Server cung cấp khả năng mở rộng và hiệu suất cao cho việc xử lý dữ liệu, có khả năng xử lý đồng thời nhiều yêu cầu truy vấn và hỗ trợ các công nghệ như các chỉ mục, tối ưu hóa truy vấn và bộ nhớ đệm để cải thiện hiệu suất truy vấn dữ liệu.

Ngoài ra, SQL Server cũng chú trọng đến tính bảo mật dữ liệu, cung cấp các cơ chế bảo mật như chứng thực và phân quyền người dùng, kiểm soát truy cập dữ liệu và mã hóa dữ liệu để đảm bảo an toàn cho dữ liệu. SQL Server còn cho phép sao lưu và khôi phục dữ liệu để đảm bảo tính toàn vẹn và khả năng phục hồi sau sự cố, đồng thời cho phép tích hợp dữ liệu từ nhiều nguồn khác nhau, có thể tạo liên kết với các cơ sở dữ liệu, truy vấn dữ liệu từ các nguồn khác và thực hiện các thao tác kết hợp và phân tích dữ liệu, tạo báo cáo, thực hiện các thao tác gom nhóm, tổng hợp và tính toán trên dữ liệu.

Với tính mạnh mẽ, khả năng mở rộng và khả năng bảo mật, SQL Server là một lựa chọn hàng đầu trong các ứng dụng web, hệ thống quản lý cơ sở dữ liệu doanh nghiệp và nhiều lĩnh vực khác trên toàn thế giới.

## HTML, CSS và Javascript

HTML (Hypertext Markup Language), CSS (Cascading Style Sheets), và JavaScript là ba ngôn ngữ chính được sử dụng trong lập trình frontend, tức là phần giao diện và tương tác mà người dùng thấy khi truy cập vào một trang web.

HTML là ngôn ngữ cơ bản được sử dụng để xây dựng cấu trúc của một trang web. Nó định nghĩa các phần tử như tiêu đề, đoạn văn bản, hình ảnh, và các phần tử khác, cho phép trình duyệt hiển thị nội dung một cách đúng đắn.

CSS là ngôn ngữ định dạng được sử dụng để tạo kiểu và trang trí cho các phần tử HTML. Nó giúp điều chỉnh màu sắc, kích thước, font chữ, và bố trí của các phần tử trên trang web, tạo ra giao diện thẩm mỹ và chuyên nghiệp.

JavaScript là ngôn ngữ lập trình phía client được sử dụng để tạo ra các tương tác động trên trang web. Nó cho phép thêm các chức năng tương tác như điều khiển các phần tử HTML, xử lý sự kiện từ người dùng, và tạo ra các hiệu ứng động, cải thiện trải nghiệm người dùng.

Nói chung, HTML, CSS, và JavaScript là ba ngôn ngữ chính trong thiết kế giao diện người dùng, cho phép nhà phát triển tạo ra giao diện trực quan, thẩm mỹ và tương tác cho người dùng khi duyệt web. Sự kết hợp của ba ngôn ngữ này làm cho trang web trở nên linh hoạt và đa dạng trong thiết kế và chức năng.

# CHƯƠNG 2: TÌM HIỂU BÀI TOÁN VÀ PHÂN TÍCH THIẾT KẾ HỆ THỐNG

## 2.1. Mục tiêu bài toán

Việc xây dựng một trang web đọc truyện trực tuyến là để đáp ứng nhu cầu ngày càng tăng của cộng đồng đọc truyện trong thời đại số hóa ngày nay. Một trong những lí do quan trọng nhất là sự tiện lợi mà nó mang lại. Trang web này cung cấp cho người đọc khả năng truy cập vào một thư viện truyện đa dạng từ bất kỳ nơi đâu và bất kỳ thiết bị nào chỉ cần có kết nối internet. Việc này loại bỏ rào cản về thời gian và địa điểm, giúp người đọc dễ dàng tận hưởng những câu chuyện mà họ yêu thích mà không cần phải đến các cửa hàng sách hay thư viện truyện.

Mục tiêu của việc xây dựng trang web này là tạo ra một không gian trực tuyến chất lượng và thú vị cho người đọc. Trang web sẽ tập trung vào việc cung cấp một thư viện truyện đa dạng và phong phú từ nhiều thể loại khác nhau nhằm đáp ứng mọi sở thích và nhu cầu đọc truyện của mọi đối tượng độc giả. Đồng thời, giao diện người dùng sẽ được thiết kế để đảm bảo sự thuận tiện và dễ sử dụng, giúp người đọc dễ dàng tìm kiếm, lựa chọn và thưởng thức các truyện một cách thoải mái trên mọi thiết bị.

## 2.2. Khảo sát

**Khảo sát trang web TruyenFull.Vn**

TruyenFull.Vn là một trang web đọc truyện online miễn phí với kho tàng truyện khổng lồ, đa dạng thể loại, được cập nhật liên tục. Đây là điểm đến quen thuộc của đông đảo độc giả yêu thích đọc truyện chữ, đặc biệt là các bạn trẻ Việt Nam. Trang web này có những tính năng như:

+, Đọc truyện

+, Tìm kiếm truyện

+, Lưu trữ truyện yêu thích

+, Bình luận, đánh giá truyện

+, Cài đặt phông chữ, cỡ chữ, màu nền,...

+, Bật/tắt chế độ ban đêm

+, Báo cáo vi phạm

Tuy có đầy đủ tính năng của một trang web đọc truyện, nhưng TruyenFull.Vn lại thiếu vắng mất một tính năng quan trọng làm tăng sự tương tác giữa các độc giả đó là tính năng Tài khoản (Đăng nhập, đăng ký, quản lý tài khoản).

## 2.3. Các chức năng của website

Sau khi khảo sát một lượt, ta xác định được hệ thống có 3 lớp người dùng là Khách, Người Dùng và Quản Trị Viên.

\- Lớp Khách có các chức năng:

+, Đọc truyện: Khách truy cập có thể đọc được tất cả các truyện trên website mà không cần phải đăng nhập

+, Xem danh sách truyện: Khách truy cập có thể xem danh sách truyện được liệt kê theo danh mục, thể loại, các truyện mới nhất, được xem nhiều nhất và các truyện đã hoàn thành

+, Tìm kiếm truyện: có thể tìm kiếm các truyện có trên website thông qua tên truyện

+, Bình luận bằng tài khoản Facebook: Nếu chưa đăng nhập, khách truy cập vẫn có thể bình luận vào truyện nếu đã có tài khoản Facebook

\- Lớp Người Dùng có các chức năng cơ bản giống như lớp Khách, ngoài ra còn có thêm các chức năng:

+, Đăng kí, đăng nhập: Người dùng có thể đăng ký, đăng nhập vào hệ thống, ngoài ra có thể sử dụng tài khoản của bên thứ ba như Facebook hoặc Google để đăng nhập

+, Quên mật khẩu: người dùng có thể yêu cầu dặt lại mật khẩu nếu vô tình quên mật khẩu cũ

+, Bình luận bằng tài khoản hệ thống: có thể để thêm mới bình luận trong truyện và xoá chúng đi nếu thấy không cần thiết

+, Thêm truyện vào bookmark

+, Xem trang cá nhân của người dùng khác

+, Chỉnh sửa thông tin cá nhân của tài khoản

\- Lớp Quản Trị Viên có các chức năng cơ bản giống với lớp Người Dùng, ngoài ra còn có thêm các chức năng:

+, Quản lý truyện: quản lý thông tin về truyện, gồm các chức năng thêm/sửa/xoá truyện, và ứng với mỗi truyện chúng ta còn có thể thêm/sửa/xoá các chương của truyện đó

+, Quản lý tác giả: quản lý thông tin về tác giả, gồm các chức năng thêm/sửa/xoá tác giả

+, Quản lý tài khoản: quản lý sửa/xoá thông tin tài khoản người dùng

+, Quản lý menu danh mục: quản lý các đường link trên menu Danh mục, gồm các chức năng thêm/sửa/xoá

+, Quản lý thể loại: quản lý thông tin về thể loại, gồm các chức năng thêm/sửa/xoá thể loại

## 2.4. Phân tích và thiết kế cơ sở dữ liệu

### 2.4.1. Mô hình quan hệ

![](/readme_images/image2.png)

Hình 2.1. Mô hình quan hệ

### 2.4.2. Mô tả dữ liệu

Bảng 2.1: Mô tả bảng Articles

| Tên thuộc tính | Kiểu dữ liệu | Mô tả | Ràng buộc |
| --- | --- | --- | --- |
| ArticleID | INT | Mã truyện | Khoá chính |
| UserID | INT | Mã người dùng |     |
| Title | NVARCHAR(255) | Tiêu đề truyện |     |
| Description | NVARCHAR(1000) | Mô tả truyện |     |
| IsCompleted | BIT | Đã hoàn thành ?<br><br>(0-Chưa, 1-Rồi) |     |
| CreatedAt | DATETIME | Ngày tạo |     |
| CoverImage | NVARCHAR(255) | Đường dẫn đến ảnh bìa |     |
| UpdatedAt | DATETIME | Ngày sửa |     |
| ViewCount | INT | Số lượt xem |     |
| IsDeleted | BIT | Đã bị xoá ?<br><br>(0-Chưa xoá, 1-Đã xoá) |     |

Bảng 2.2: Mô tả bảng Authors

| Tên thuộc tính | Kiểu dữ liệu | Mô tả | Ràng buộc |
| --- | --- | --- | --- |
| AuthorID | INT | Mã tác giả | Khoá chính |
| Name | NVARCHAR(100) | Tên tác giả |     |
| Avatar | NVARCHAR(255) | Đường dẫn đến ảnh tác giả |     |
| Description | NVARCHAR(1000) | Mô tả về tác giả |     |
| IsDeleted | BIT | Đã bị xoá ?<br><br>(0-Chưa xoá, 1-Đã xoá) |     |

Bảng 2.3: Mô tả bảng Genres

| Tên thuộc tính | Kiểu dữ liệu | Mô tả | Ràng buộc |
| --- | --- | --- | --- |
| GenreID | INT | Mã thể loại | Khoá chính |
| Name | NVARCHAR(255) | Tên thể loại |     |
| Description | NVARCHAR(1000) | Mô tả về thể loại |     |
| ViewCount | INT | Số lượt xem thể loại |     |
| IsDeleted | BIT | Đã bị xoá ?<br><br>(0-Chưa xoá, 1-Đã xoá) |     |

Bảng 2.4: Mô tả bảng Chapters

| Tên thuộc tính | Kiểu dữ liệu | Mô tả | Ràng buộc |
| --- | --- | --- | --- |
| ChapterID | INT | Mã chương truyện | Khoá chính |
| Title | NVARCHAR(255) | Tên chương truyện |     |
| \[Content\] | NVARCHAR(MAX) | Nội dung của chương |     |
| CreatedAt | DATETIME | Ngày tạo chương |     |
| \[Index\] | INT | Số thứ tự chương |     |
| ViewCount | INT | Số lượt xem |     |
| ArticleID | INT | Mã truyện | Liên kết khoá ngoại đến bảng Articles |
| IsDeleted | BIT | Đã bị xoá ?<br><br>(0-Chưa xoá, 1-Đã xoá) |     |

Bảng 2.5: Mô tả bảng Users

| Tên thuộc tính | Kiểu dữ liệu | Mô tả | Ràng buộc |
| --- | --- | --- | --- |
| UserID | INT | Mã người dùng | Khoá chính |
| UserName | VARCHAR(20) | Tên người dùng |     |
| Name | NVARCHAR(100) | Tên đầy đủ |     |
| Email | VARCHAR(100) | Thư điện tử |     |
| PhoneNumber | VARCHAR(20) | Số điện thoại |     |
| Address | NVARCHAR(MAX) | Địa chỉ |     |
| DateOfBirth | DATE | Ngày sinh |     |
| Avatar | NVARCHAR(255) | Đường dẫn đến ảnh đại diện |     |
| Description | NVARCHAR(1000) | Mô tả về bản thân |     |
| CreatedAt | DATETIME | Ngày tạo |     |
| Role | INT | Vai trò<br><br>(0-Người dùng, 1-Quản trị viên) |     |
| Password | VARBINARY(MAX) | Mật khẩu đã được mã hoá |     |
| Gender | BIT | Giới tính<br><br>(0-Nam, 1-Nữ) |     |
| IsDeleted | BIT | Đã bị xoá ?<br><br>(0-Chưa xoá, 1-Đã xoá) |     |

Bảng 2.6: Mô tả bảng Articles_Authors

| Tên thuộc tính | Kiểu dữ liệu | Mô tả | Ràng buộc |
| --- | --- | --- | --- |
| ArticleID | INT | Mã truyện | Khoá chính, Liên kết khoá ngoại đến bảng Articles, Authors |
| AuthorID | INT | Mã tác giả |

Bảng 2.7: Mô tả bảng Articles_Genres

| Tên thuộc tính | Kiểu dữ liệu | Mô tả | Ràng buộc |
| --- | --- | --- | --- |
| ArticleID | INT | Mã truyện | Khoá chính, Liên kết khoá ngoại đến bảng Articles, Genres |
| GenreID | INT | Mã thể loại |

Bảng 2.8: Mô tả bảng Bookmarks

| Tên thuộc tính | Kiểu dữ liệu | Mô tả | Ràng buộc |
| --- | --- | --- | --- |
| BookmarkID | INT | Mã dấu trang | Khoá chính, Liên kết khoá ngoại đến bảng Users, Articles |
| UserID | INT | Mã người dùng |
| ArticleID | INT | Mã truyện |
| Name | NVARCHAR(255) | Tên dấu trang |     |
| Description | NVARCHAR(1000) | Mô tả về dấu trang |     |
| IsPublic | BIT | Có công khai không?<br><br>(0-Không, 1-Có) |     |

Bảng 2.9: Mô tả bảng Comments

| Tên thuộc tính | Kiểu dữ liệu | Mô tả | Ràng buộc |
| --- | --- | --- | --- |
| CommentID | INT | Mã bình luận | Khoá chính, Liên kết khoá ngoại đến bảng Users, Articles |
| UserID | INT | Mã người dùng |
| ArticleID | INT | Mã truyện |
| \[Content\] | NVARCHAR(1000) | Nội dung bình luận |     |
| CreatedAt | DATETIME | Thời gian bình luận |     |

Bảng 2.10: Mô tả bảng Categories

| Tên thuộc tính | Kiểu dữ liệu | Mô tả | Ràng buộc |
| --- | --- | --- | --- |
| CategoryID | INT | Mã menu danh mục | Khoá chính |
| Name | NVARCHAR(255) | Tên liên kết trên menu |     |
| Description | NVARCHAR(1000) | Mô tả về liên kết |     |
| Link | NVARCHAR(1000) | Đường link liên kết trên menu |     |

# CHƯƠNG 3: XÂY DỰNG CHƯƠNG TRÌNH

## 3.1. Xây dựng giao diện trang chủ

![](/readme_images/image3.png))

Hình 3.1. Giao diện trang chủ

## 3.2. Giao diện xem bài đăng

![](/readme_images/image4.png)

Hình 3.2. Giao diện xem bài đăng

![](/readme_images/image5.png)

Hình 3.3. Giao diện thêm dấu trang

![](/readme_images/image6.png)

Hình 3.4. Giao diện đọc một chương truyện

## 3.3. Chức năng đăng nhập, đăng ký, quên mật khẩu

![](/readme_images/image7.png)

Hình 3.5. Giao diện trang đăng nhập

![](/readme_images/image8.png)

Hình 3.6. Giao diện trang đăng ký

![](/readme_images/image9.png)

Hình 3.7. Giao diện trang quên mật khẩu

## 3.4. Chức năng xem và quản lý thông tin tài khoản

![](/readme_images/image10.png)

Hình 3.8. Giao diện xem thông tin tài khoản

![](/readme_images/image11.png)

Hình 3.9. Giao diện sửa thông tin tài khoản

## 3.5. Chức năng tìm kiếm truyện theo tên

![](/readme_images/image12.png)

Hình 3.10. Giao diện trang tìm kiếm truyện

## 3.6. Xem danh sách các truyện của một thể loại

![](/readme_images/image13.png)

Hình 3.11. Giao diện xem danh sách truyện của một thể loại

## 3.7. Giao diện trang quản trị

![](/readme_images/image14.png)

Hình 3.12. Giao diện trang quản trị

## 3.8. Chức năng quản lý truyện

![](/readme_images/image15.png)

Hình 3.13. Giao diện trang hiển thị danh sách truyện

![](/readme_images/image16.png)

Hình 3.14. Giao diện trang thêm truyện

![](/readme_images/image17.png)

Hình 3.15. Giao diện trang sửa truyện

## 3.9. Chức năng quản lý chương truyện

![](/readme_images/image18.png)

Hình 3.16. Giao diện trang hiển thị danh sách chương

![](/readme_images/image19.png)

Hình 3.17. Giao diện trang thêm chương mới

![](/readme_images/image20.png)

Hình 3.18. Giao diện trang sửa chương

## 3.10. Chức năng quản lý tác giả

![](/readme_images/image21.png)

Hình 3.19. Giao diện trang hiển thị danh sách tác giả

![](/readme_images/image22.png)

Hình 3.20. Giao diện trang thêm tác giả

![](/readme_images/image23.png)

Hình 3.21. Giao diện trang sửa tác giả

## 3.11. Chức năng quản lý tài khoản người dùng

![](/readme_images/image24.png)

Hình 3.22. Giao diện trang hiển thị danh sách tài khoản

![](/readme_images/image25.png)

Hình 3.23. Giao diện trang sửa thông tin người dùng

## 3.12. Chức năng quản lý thể loại

![](/readme_images/image26.png)

Hình 3.24. Giao diện trang hiển thị danh sách thể loại

![](/readme_images/image27.png)

Hình 3.25. Giao diện trang thêm thể loại

![](/readme_images/image28.png)

Hình 3.26. Giao diện trang sửa thể loại

## 3.13. Chức năng quản lý menu danh mục

![](/readme_images/image29.png)

Hình 3.27. Giao diện trang hiển thị danh sách các đường liên kết

![](/readme_images/image30.png)

Hình 3.28. Giao diện menu danh mục

![](/readme_images/image31.png)

Hình 3.29. Giao diện trang thêm liên kết mới

![](/readme_images/image32.png)

Hình 3.30. Giao diện trang sửa liên kết

# KẾT LUẬN

Đề tài “xây dựng website đọc truyện trực tuyến” đã được xây dựng và phát triển bằng cách sử dụng kiến thức về framework ASP.NET Core MVC, với mục đích tạo ra sản phẩm hoàn chỉnh và có tính khả dụng cao cho người dùng. Bên cạnh mô hình MVC, tôi cũng đã áp dụng các kiến thức về API và AJAX để giúp cho việc kết nối giữa cơ sở dữ liệu và front-end được dễ dàng hơn, nhằm tối ưu trải nghiệm người dùng.

Trong quá trình xây dựng đề tài, tôi đã trau dồi và luyện tập được nhiều kiến thức hữu ích đồng thời rút ra được kinh nghiệm cho các dự án sau này. Đề tài có thể vẫn còn một vài thiếu sót, tôi mong nhận được sự góp ý của các bạn để đề tài ngày càng hoàn thiện hơn.
