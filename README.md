<h1 align="center"> Dotnet 8 bacic dev environment </h1>
<h3>A Dotnet 8 dev environment ready to run on existing applications or to create a new application.</h3>

# ✔️ Techs:
- `Dotnet`
- `Docker`

# :hammer: How to run the application

<h4>Run ´docker compose -f dev.docker-compose.yml up´ to start the application</h4>

<h4>Add to Program.cs to prevent https redirect:</h4>
<p>
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000);
});
</p>

<h4>Run ´docker compose -f dev.docker-compose.yml down --rmi all --remove-orphans´ to stop the application and destroy all docker artifacts</h4>

# :hammer: How to generate and run the migrations

<h3>Generate the migrations:</h3>
<p>dotnet ef migrations add {{  Migration Name }} -p Infrastructure/Infrastructure.csproj -s WebAPI/WebAPI.csproj</p>

<h3>Run the migrations:</h3>
<p>dotnet ef database update -p Infrastructure/Infrastructure.csproj -s WebAPI/WebAPI.csproj</p>
