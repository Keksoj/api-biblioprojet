# Api Biblioprojet

Pour la beauté du code (même si c'est du C#).

README à rédiger / améliorer, contributions bienvenues !

Ce projet d'école consiste à créer une API de gestion de ressources artistiques, pour le moment :

-   artistes
-   groupes
-   contenu (chansons, albums)

## Récupérer le code

Avec git en ligne de commande :

```sh
git clone https://github.com/Keksoj/api-biblioprojet.git
cd api-biblioprojet
```

Dans Windows, à l'ouverture de Visual Studio, faire `cloner un dépôt`, donner l'adresse du repo : `https://github.com/Keksoj/api-biblioprojet.git`, puis indiquer le dossier où sauvegarder le code.
Pour que le code compile bien, retrouver le fichier `BiblioApi.csproj` dans l'explorateur de fichiers et l'ouvrir avec Visual Studio.

Ensuite, installer Git Bash sur Windows pour utiliser git en ligne de commande. Git, c'est le bien.

## Comment contribuer avec git

Demandez à faire partie des contributeurs !

Une fois le code cloné, ouvrir un terminal (ou git bash). Aller dans le dossier où le code a été cloné :

```sh
cd le/chemin/vers/api-biblioprojet
```

Vérifiez que tout va bien et que vous êtes sur la branche main.

```sh
git status
```

### IMPORTANT AVANT D'ÉCRIRE QUELQUE CODE QUE CE SOIT !

Créez votre branche qui explique ce que vous faites au juste :

```sh
git checkout -b ma-branche-a-moi
```

CODEZ !

Une fois votre code édité, utilisez `git status` pour voir quels changements seront appliqués. Utilisez `git add telfichier` pour que git prenne en compte les changements faits à tel fichier. Raccourci : `git add .` ajoute tout à la fois.

Commitez vos changements :

```sh
git commit -m "tels et tels changements sont effectués"
```

Poussez le code vers le repo en ligne :

```sh
git push
```

Git va vous disputer parce que le repo ne connaît pas cette branche, mais va aussi vous indiquer quelle est la bonne commande :

```sh
git push --set-upstream origin ma-branche-a-moi
```

Une fois que ça c'est fait, allez sur <https://github.com/Keksoj/api-biblioprojet> et vous verrez que github propose de faire un pull request, suivez votre instinct de cliqueur-né et ça va bien se passer.

Demandez au autres de revoir votre code ! Vous pouvez continuer à éditer votre code, ensuite ce n'est qu'une longue suite de :

-   `git status`
-   `git add`
-   `git commit -m "mes changements"`
-   `git push`

Et votre Pull Request sur github est mise à jour. Une fois que votre code a été mergé, retournez dans votre terminal et faites bien :

```sh
git checkout main
```

pour ne pas rester sur `ma-branche-a-moi` ! Ensuite, récupérer le reste du code :

```sh
git pull
```

Git c'est dur. Ça se passe jamais bien. Si tout plante, pas de panique, faites comme les pros, détruisez tout et recommencez de zéro. Le code en ligne, lui, ne souffre pas.

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
