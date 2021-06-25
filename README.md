# Api Biblioprojet

Pour la beauté du code (même si c'est du C#).

README à rédiger / améliorer, contributions bienvenues !

Ce projet d'école consiste à créer une API de gestion de ressources artistiques, pour le moment :

-   artistes
-   groupes
-   contenu (chansons, albums)

## Comment résoudre le problème de génération de code

Ceci s'adresse à ceux qui utilisent arch linux.

La commande qui génère le code d'un contrôleur à partir d'un modèle :

      dotnet aspnet-codegenerator controller -name TodoItemsController -async -api -m TodoItem -dc TodoContext -outDir Controllers

plantait de la sorte :

      Building project ...
      Finding the generator 'controller'...
      Running the generator 'controller'...
      Attempting to compile the application in memory.
      Attempting to figure out the EntityFramework metadata for the model and DbContext: 'TodoItem'
      A file matching the name ApiControllerWithContext.cshtml was not found within any of the folders:
      at Microsoft.VisualStudio.Web.CodeGeneration.ActionInvoker.<BuildCommandLine>b\_\_6_0()
      at Microsoft.Extensions.CommandLineUtils.CommandLineApplication.Execute(String[] args)
      at Microsoft.VisualStudio.Web.CodeGeneration.ActionInvoker.Execute(String[] args)
      at Microsoft.VisualStudio.Web.CodeGeneration.CodeGenCommand.Execute(String[] args)
      RunTime 00:00:05.98p

Heureusement il y a [Stack Overflow](https://stackoverflow.com/questions/63361534/attempting-to-figure-out-the-entityframework-metadata-for-the-model-and-dbcontex) !

Il faut aller dans `$HOME/.nuget/packages/microsoft.visualstudio.web.codegenerators.mvc/5.0.1` et recopier le dossier `Templates/` dans le projet. Le build va échouer à cause de redondances dans le namespace, il faut supprimer `Templates/Identity/` et un autre qui a un nom en `identity`. Ça builde sans problème. Relancer la longue commande de aspnet-codegenerator, Swagger nous donne le crud sur TodoItem.

**IMPORTANT**

Cette ligne du `startup.cs` doit être répétée pour chaque modèle dont on veut générer le contrôleur.

```cs
services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
```

Par exemple :

```cs
services.AddDbContext<ArtistContext>(opt => opt.UseInMemoryDatabase("Artistlist"));
```

### CORS

Il faut ajouter dans le `startup.cs`:

```cs
app.UseCors(options=>options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod() );

```

### Ajouter swagger

      dotnet add BiblioApi.csproj package Swashbuckle.AspNetCore -v 5.6.3

Follow [those instructions](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio)

After `dotnet run`, swagger is at <https://localhost:5001/swagger/index.html>
