using PayrollBSI.BLL;
using PayrollBSI.BLL.InterfaceBLL;
using PayrollBSI.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//register session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});
//Register DI
builder.Services.AddScoped<IPositionBLL, PositionBLL>();
builder.Services.AddScoped<IEmployeeBLL, EmployeeBLL>();
builder.Services.AddScoped<IPayrollDetailsBLL, PayrollDetailsBLL>();
builder.Services.AddScoped<IAttendanceBLL, AttendanceBLL>();

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//	app.UseExceptionHandler("/Home/Error");
//	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//	app.UseHsts();
//}






//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
