CORS Configuration (for AppSmith):

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAppSmith", builder =>
    {
        builder.WithOrigins("https://your-appsmith-domain.com") // Your AppSmith URL
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

app.UseCors("AllowAppSmith");