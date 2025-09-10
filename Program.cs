using TodoListBackend;

var builder = WebApplication.CreateBuilder(args);

ProgramInitializer.Configure(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/", (AppDbContext db) => "Hello World");

app.Run();