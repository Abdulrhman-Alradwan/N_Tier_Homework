using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NTierTodoApp.Business;
using NTierTodoApp.DataAccess;

// إنشاء تطبيق الويب
// Create web application
var builder = WebApplication.CreateBuilder(args);

// إضافة خدمات MVC
// Add MVC services
builder.Services.AddControllersWithViews();

// تسجيل الخدمات التابعة
// Register dependent services
builder.Services.AddSingleton<TaskRepository>(); // المحاكاة بالذاكرة باستخدام Singleton
builder.Services.AddTransient<TaskService>();    // Memory simulation using Singleton

// بناء التطبيق
// Build the application
var app = builder.Build();

// تكوين خط أنابيب الطلب HTTP
// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// إضافة middleware الضرورية
// Add required middleware
app.UseStaticFiles();
app.UseRouting();

// تعيين مسار التحكم الافتراضي
// Set default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// تشغيل التطبيق
// Run the application
app.Run();