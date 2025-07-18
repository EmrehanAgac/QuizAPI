using QuizApi.Repositories;
using QuizApi.Services;

var builder = WebApplication.CreateBuilder(args);

// CORS policy ekle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// Service ve Repository'leri ekle
builder.Services.AddSingleton<IQuestionRepository, QuestionRepository>();
builder.Services.AddSingleton<QuestionService>(); // sadece 1 kez ekliyoruz

// Controller'lar� ekle
builder.Services.AddControllers();

// Swagger tan�m�
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger'� aktif et (prod da dahil)
app.UseSwagger();
app.UseSwaggerUI();

// CORS middleware'i kullan
app.UseCors("AllowAll");

// Authorization middleware'i (kullan�lm�yorsa silebilirsin)
app.UseAuthorization();

// Controller endpoint'lerini map et
app.MapControllers();

app.Run();
