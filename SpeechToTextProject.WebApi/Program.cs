using Microsoft.AspNetCore.Identity;
using SpeechToTextProject.BusinessLayer;
using SpeechToTextProject.BusinessLayer.Abstract;
using SpeechToTextProject.BusinessLayer.Concrete;
using SpeechToTextProject.DataAccessLayer.Abstract;
using SpeechToTextProject.DataAccessLayer.Context;
using SpeechToTextProject.DataAccessLayer.EntityFramework;
using SpeechToTextProject.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IAudioService, AudioManager>();
builder.Services.AddScoped<IAudioDal, EfAudioDal>();

builder.Services.AddScoped<ITranscriptionService, TranscriptionManager>();
builder.Services.AddScoped<ITranscriptionDal, EfTranscriptionDal>();
builder.Services.AddDbContext<ApiContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
