using BookWormProject.Data.Repository;
using BookWormProject.Data.Services;
using BookWormProject.Models;
using BookWormProject.Utils.Filter;
using BookWormProject.Utils.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Đăng kí BookWormDbContext và cấu hình nó để sử dụng SqlServer làm cơ sở dữ liệu
builder.Services.AddDbContext<BookWormDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookWormDb")));

// Đăng kí các controller và view cho ứng dụng, sau đó thêm các Filter vào option
builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add(typeof(CurrentControllerFilter));
    option.Filters.Add<RoleFilter>();
});
// Đăng kí các Repository
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IGenresRepository, GenreRepository>();
builder.Services.AddScoped<IBookmarkRepository, BookmarkRepository>();
builder.Services.AddScoped<IChapterRepository, ChapterRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

// Đăng kí các service
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IBookmarkService, BookmarkService>();
builder.Services.AddScoped<IChapterService, ChapterService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IGithubService, GithubService>();

// Cấu hình cho GithubOption
var githubSection = builder.Configuration.GetSection("GithubOption");
builder.Services.Configure<GithubOption>(option =>
{
    option.AccessToken = githubSection.GetValue<string>("AccessToken");
    option.RepositoryName = githubSection.GetValue<string>("RepositoryName");
    option.RepositoryOwner = githubSection.GetValue<string>("RepositoryOwner");
});

// Đăng ký Filter
builder.Services.AddScoped<IAuthorizationFilter, RoleFilter>();

// Đăng kí HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Đăng ký cache
builder.Services.AddMemoryCache();

// Đăng ký SendGrid
builder.Services.AddSendGrid(option =>
{
    option.ApiKey = builder.Configuration.GetSection("SendGrid").GetValue<string>("ApiKey");
});


// Thêm chế độ xác thực dựa trên cookie
var cookieAuthenticationSection = builder.Configuration.GetSection("Authentication:CookieAuthentication");
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = cookieAuthenticationSection.GetValue<string>("CookieName");
        options.LoginPath = cookieAuthenticationSection.GetValue<string>("LoginPath");
        options.LogoutPath = cookieAuthenticationSection.GetValue<string>("LogoutPath");
        options.AccessDeniedPath = cookieAuthenticationSection.GetValue<string>("AccessDeniedPath");
        options.ExpireTimeSpan = TimeSpan.FromDays(30);
    })
    .AddFacebook(options =>
    {
        options.AppId = "165784553012702";
        options.AppSecret = "0f232f4899a9adb388e6e2f12f5b544d";
        options.CallbackPath = "/facebook-response";
    }).AddGoogle(options =>
    {
        options.ClientId = "934602762375-h4o5lllie4h6npohnncvbi6ilvu6i7pk.apps.googleusercontent.com";
        options.ClientSecret = "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";
        options.CallbackPath = "/google-response";
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
app.UseAuthorization(); // Thêm middleware phân quyền

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


    app.Run();