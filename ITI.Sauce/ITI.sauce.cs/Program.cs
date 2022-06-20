
public class Program
{
    public static int Main()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddControllersWithViews();
        var app = builder.Build();
        app.MapDefaultControllerRoute();
        app.Run();
        return 0;
    }
}