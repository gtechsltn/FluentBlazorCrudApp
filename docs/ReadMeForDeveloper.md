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
dotnet new blazorserver -o BlazorFluentApp
dotnet add package Microsoft.FluentUI.AspNetCore.Components
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

```
# D:\gtechsltn\FluentBlazorCrudApp\src\FluentBlazorApp
# FluentBlazorApp.csproj
dotnet add package Microsoft.FluentUI.AspNetCore.Components
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

```
# WeatherForecast.cs
public int Id { get; set; } 
```

```
dotnet ef migrations add AddIdToWeatherForecast
dotnet ef database update
```

```
Possible reasons for this include:
  * You misspelled a built-in dotnet command.
  * You intended to execute a .NET program, but dotnet-ef does not exist.
  * You intended to run a global tool, but a dotnet-prefixed executable with this name could not be found on the PATH.
```

```
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet tool install --global dotnet-ef
setx PATH "%PATH%;C:\Users\ADMIN\.dotnet\tools"
```

## dotnet ef migrations add AddIdToWeatherForecast

```
D:\gtechsltn\FluentBlazorCrudApp\src\FluentBlazorApp>dotnet ef migrations add AddIdToWeatherForecast
Build started...
Build succeeded.
Done. To undo this action, use 'ef migrations remove'

D:\gtechsltn\FluentBlazorCrudApp\src\FluentBlazorApp>
```

## dotnet ef database update
```
D:\gtechsltn\FluentBlazorCrudApp\src\FluentBlazorApp>dotnet ef database update
Build started...
Build succeeded.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (180ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      CREATE DATABASE [BlazorFluentDb];
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (36ms) [Parameters=[], CommandType='Text', CommandTimeout='60']
      IF SERVERPROPERTY('EngineEdition') <> 5
      BEGIN
          ALTER DATABASE [BlazorFluentDb] SET READ_COMMITTED_SNAPSHOT ON;
      END;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
info: Microsoft.EntityFrameworkCore.Migrations[20411]
      Acquiring an exclusive lock for migration application. See https://aka.ms/efcore-docs-migrations-lock for more information if this takes too long.
Acquiring an exclusive lock for migration application. See https://aka.ms/efcore-docs-migrations-lock for more information if this takes too long.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (14ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      DECLARE @result int;
      EXEC @result = sp_getapplock @Resource = '__EFMigrationsLock', @LockOwner = 'Session', @LockMode = 'Exclusive';
      SELECT @result
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
      BEGIN
          CREATE TABLE [__EFMigrationsHistory] (
              [MigrationId] nvarchar(150) NOT NULL,
              [ProductVersion] nvarchar(32) NOT NULL,
              CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
          );
      END;
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [MigrationId], [ProductVersion]
      FROM [__EFMigrationsHistory]
      ORDER BY [MigrationId];
info: Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20250805035432_AddIdToWeatherForecast'.
Applying migration '20250805035432_AddIdToWeatherForecast'.
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [WeatherForecasts] (
          [Id] int NOT NULL IDENTITY,
          [Date] date NOT NULL,
          [TemperatureC] int NOT NULL,
          [Summary] nvarchar(max) NULL,
          CONSTRAINT [PK_WeatherForecasts] PRIMARY KEY ([Id])
      );
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'20250805035432_AddIdToWeatherForecast', N'9.0.8');
info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      DECLARE @result int;
      EXEC @result = sp_releaseapplock @Resource = '__EFMigrationsLock', @LockOwner = 'Session';
      SELECT @result
Done.

D:\gtechsltn\FluentBlazorCrudApp\src\FluentBlazorApp>
```

## Lỗi sau khi deploy

```
Error.
An error occurred while processing your request.
Request ID: 00-8e33c87a28688c57e33f5b4940510f4b-813ee08feb16e1d9-00

Development Mode
Swapping to the Development environment displays detailed information about the error that occurred.

The Development environment shouldn't be enabled for deployed applications. It can result in displaying sensitive information from exceptions to end users. For local debugging, enable the Development environment by setting the ASPNETCORE_ENVIRONMENT environment variable to Development and restarting the app.
```

```
An unexpected error occurred: A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: SQL Network Interfaces, error: 50 - Local Database Runtime error occurred. Error occurred during LocalDB instance startup: SQL Server process failed to start. )

Please reload the page.
```

```
An unexpected error occurred: A connection was successfully established with the server, but then an error occurred during the login process. (provider: SSL Provider, error: 0 - The certificate chain was issued by an authority that is not trusted.)

Please reload the page.
```

```
An unexpected error occurred: An exception has been raised that is likely due to a transient failure. Consider enabling transient error resiliency by adding 'EnableRetryOnFailure' to the 'UseSqlServer' call.

Please reload the page.
```

```
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File
```

