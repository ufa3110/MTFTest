using MTFTest.Mapper;
using MTFTest.UsersModule.Abstractions;
using MTFTest.UsersModule.Repository;
using MTFTest.UsersModule.Service;

namespace MTFTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddAutoMapper(typeof(AppMappingProfile));

            builder.Services.AddSignalR();

            //Singleton, т.к. это list в памяти.
            builder.Services.AddSingleton<IUsersRepository, UsersRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapHub<UserService>("/userservice");

            app.Run();
        }
    }
}