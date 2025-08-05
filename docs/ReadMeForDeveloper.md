+ .NET 10.0
+ Blazor Server App
+ Microsoft.FluentUI.AspNetCore

```
Microsoft.FluentUI.AspNetCore là một bộ thư viện thành phần (component library) dành cho Blazor, cho phép các nhà phát triển xây dựng các ứng dụng web với giao diện người dùng theo hệ thống thiết kế Fluent UI của Microsoft. 🎨

Fluent UI là một hệ thống thiết kế hiện đại, được Microsoft sử dụng trong các sản phẩm như Microsoft 365, Teams và Windows. Mục tiêu là tạo ra trải nghiệm người dùng nhất quán, dễ tiếp cận và có tính thẩm mỹ cao trên nhiều nền tảng.

Đặc điểm chính của thư viện:
Thành phần dựng sẵn: Thư viện này cung cấp một loạt các thành phần Blazor dựng sẵn, như nút bấm (FluentButton), lưới dữ liệu (FluentDataGrid), hộp thoại (FluentDialog), biểu tượng (FluentIcon), v.v., giúp bạn nhanh chóng xây dựng giao diện ứng dụng mà không cần phải tự thiết kế từng chi tiết.

Tích hợp Blazor: Các thành phần được viết bằng C# và Razor, tận dụng toàn bộ sức mạnh của Blazor. Điều này cho phép bạn xây dựng giao diện người dùng tương tác mà không cần phải viết JavaScript.

Dựa trên Web Components: Một số thành phần là lớp bọc (wrapper) cho các Fluent UI Web Components chính thức của Microsoft, đảm bảo hiệu suất tốt và khả năng tương thích cao.

Mã nguồn mở và miễn phí: Thư viện này là mã nguồn mở, cho phép cộng đồng đóng góp và phát triển.

Lợi ích khi sử dụng:

Giao diện chuyên nghiệp: Ứng dụng của bạn sẽ có giao diện hiện đại và chuyên nghiệp, giống như các sản phẩm của Microsoft.

Tăng tốc phát triển: Nhờ có các thành phần dựng sẵn, bạn có thể tiết kiệm đáng kể thời gian và công sức xây dựng UI.

Dễ tiếp cận: Fluent UI được thiết kế với tiêu chuẩn về khả năng tiếp cận (accessibility) cao, giúp ứng dụng của bạn thân thiện hơn với nhiều đối tượng người dùng.

```

```
# D:\gtechsltn\FluentBlazorCrudApp\src\FluentBlazorApp
# FluentBlazorApp.csproj
dotnet add package Microsoft.FluentUI.AspNetCore.Components
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```