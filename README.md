# Group Dispatcher

Group Dispatcher is an app that allow you to get the names of students from a text file, subject from another text file and then randomly organize that information in multiple groups.

Requirements to run the program:
- Must have .NET Core SDK 3.1. Can be found in the following link: https://dotnet.microsoft.com/download

Once you adquired the SDK download the files in the repository and navigate to the folder in which the files are through the command prompt. After you make it to the folder, use the command "dotnet publish" to obtain the exe and "dotnet run" to run the app.

Example: Let's say you downloaded the files in the following folder: "D:\Downloads\Repos\Group Distpacher".
Open the command line, navigate to the D: drive and write the following command: "cd D:\Downloads\Repos\Group Distpacher".
Once there write "dotnet publish" followed with "dotnet run" and the application will start running.

The app initially will ask you for three inputs. The first one is the absolute path of the students file, the second one the absolute path of the subjects file and the third one the amount of groups.

Example:
- Inserte la ruta completa del archivo de estudiantes: C:\Users\jorge_1anbma0\Desktop\Estudiantes.txt
- Inserte la ruta completa del archivo de temas: C:\Users\jorge_1anbma0\Desktop\Temas.txt
- Inserte la cantidad de grupos 6

The app will give you a random result. In my case i got:

    Grupo 1 (Estudiantes: 3, Temas: 1)
        Estudiantes:
            Joel
            Perla
            Isaac Perez
        Temas:
            Uso adecuado de linq en C#
    Grupo 2 (Estudiantes: 4, Temas: 1)
        Estudiantes:
            Tony Alonzo
            Janet Cristina
            Jorge
            Diego Velásquez
        Temas:
            Codigo nativo vs codigo en xamarin para desarrollo móvil
    Grupo 3 (Estudiantes: 3, Temas: 1)
        Estudiantes:
            Carlos Jose
            Jose Del Campo
            Juansito
        Temas:
            Los diferentes comandos de git
    Grupo 4 (Estudiantes: 3, Temas: 1)
        Estudiantes:
            Mariano Vásquez
            Carlos Rafael
            Maria
        Temas:
            Mejor lenguaje de programacion para crear videojuegos
    Grupo 5 (Estudiantes: 4, Temas: 1)
        Estudiantes:
            Amilkar Fleming
            Jan Rafael
            Pedro
            Carolina
        Temas:
            La importa de comer saludable
    Grupo 6 (Estudiantes: 3, Temas: 1)
        Estudiantes:
            Shailyn Alcantara
            Abril
            Juan Perez
        Temas:
            La política en Republica Dominicana