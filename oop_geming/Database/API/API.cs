using Godot;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

public partial class InitApi : Node
{
    public void StartApi()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<GameContext>(options =>
            options.UseSqlite("Data Source=game.db"));
        
        var app = builder.Build();

        app.UseRouting();
        app.MapControllers();

        app.Run();
    }
}