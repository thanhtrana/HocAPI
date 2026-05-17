using HocApi;
using HocApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Lấy chuỗi kết nối từ file appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Đăng ký ApplicationDbContext
builder.Services.AddDbContext<Db>(options =>
    options.UseSqlServer(connectionString));

// 3. ĐĂNG KÝ TOÀN BỘ REPOSITORY VÀ SERVICE QUA FILE GOM NHÓM
builder.Services.AddProjectServices();

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();
app.Run();
