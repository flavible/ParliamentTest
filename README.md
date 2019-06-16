# ParliamentTest

Please run the API project and Front End projects to start the solution. 

Due to Cors restrictions the solution will only work if using localhost:5004 for the UI (which is the default for this project). This can be changed within the commonsAPI project by changing the following line:

app.UseCors(options => options.WithOrigins("https://localhost:5004"));
