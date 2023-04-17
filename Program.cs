using BookWormProject.Data.Repository;
using BookWormProject.Data.Services;
using BookWormProject.Models;
using BookWormProject.Utils.Filter;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Đăng kí BookWormDbContext và cấu hình nó để sử dụng SqlServer làm cơ sở dữ liệu
builder.Services.AddDbContext<BookWormDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookWormDb")));
// Đăng kí các controller và view cho ứng dụng, sau đó thêm CurrentViewFilter vào option
builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add(typeof(CurrentViewFilter));
});
// Đăng kí các Repository
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IGenresRepository, GenreRepository>();
builder.Services.AddScoped<IBookmarkRepository, BookmarkRepository>();
builder.Services.AddScoped<IChapterRepository, ChapterRepository>();
builder.Services.AddScoped<IReadHistoryRepository, ReadHistoryRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Đăng kí các service
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IBookmarkService, BookmarkService>();
builder.Services.AddScoped<IChapterService, ChapterService>();
builder.Services.AddScoped<IReadHistoryService, ReadHistoryService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();