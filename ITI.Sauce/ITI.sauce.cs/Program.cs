
using Microsoft.Extensions.FileProviders;

public class Program
{
    public static int Main()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddControllersWithViews();
        var app = builder.Build();
        app.UseStaticFiles(new StaticFileOptions() 
        { 
            FileProvider= new PhysicalFileProvider
            ( 
            Path.Combine(Directory.GetCurrentDirectory(),"Content")
            ),
            RequestPath = "/Content"
        }
        );
        app.MapDefaultControllerRoute();
        app.Run();
        return 0;
    }
}