using BookWormProject.Data.Repository;
using BookWormProject.Data.Services;
using BookWormProject.Models;
using BookWormProject.Utils.Filter;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Đăng kí BookWormDbContext và cấu hình nó để sử dụng SqlServer làm cơ sở dữ liệu
builder.Services.AddDbContext<BookWormDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookWormDb")));
// Đăng kí các controller và view cho ứng dụng, sau đó thêm CurrentControllerFilter vào option
builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add(typeof(CurrentControllerFilter));
});
// Đăng kí các Repository
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IGenresRepository, GenreRepository>();
builder.Services.AddScoped<IBookmarkRepository, BookmarkRepository>();
builder.Services.AddScoped<IChapterRepository, ChapterRepository>();
builder.Services.AddScoped<IReadHistoryRepository, ReadHistoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

// Đăng kí các service
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IBookmarkService, BookmarkService>();
builder.Services.AddScoped<IChapterService, ChapterService>();
builder.Services.AddScoped<IReadHistoryService, ReadHistoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Đăng kí HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Thêm chế độ xác thực dựa trên cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "MyApp.Cookie";
        options.LoginPath = "/dang-nhap";
        options.LogoutPath = "/dang-xuat";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromDays(30);
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCookiePolicy(); // Thêm middleware bật chính sách Cookie

app.UseAuthentication(); // Thêm middleware xác thực


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();