# PruebaTecnica

### Descripción

El proyecto ha sido estructurado usando arquitectura limpia, se ha usado el patron CQRS y buenas practicas de codigo.

El proyecto incluye la configuración necesaria para ser usado con Docker.

*Por favor cambiar la configuración de la conección a base de datos en appsettings*

*La documentación se encuentra en: http://localhost:puerto/swagger/index.html*
### Construcción 🛠️
* **Language:** C# (.NET Core 7)
* **Framework:** ASP.NET Core, EntityFramework 7

## Requerimientos
- .NET Core 7 (Solo si no se usara docker)
- Docker (Solo si se va a utilizar)

## Instalación y ejecución

### Sin usar docker

1. Clonar el proyecto
2. En una terminal desplazarse a la carpeta "src/WebServices" del proyecto
3. Ejecutar el comando: ```dotnet run "WebServices.csproj" -c Release```
4. Se ejecutará el proyecto y se podrá acceder a el en la url mostrada en la terminal.


### Usando docker

1. Clonar el proyecto
2. En una terminal desplazarse a la carpeta src del proyecto (Donde se encuentra el Dockerfile)
3. Construir la imagen: ```docker build . -t pruebatecnica:latest```
4. Iniciar el contenedor: ```docker run -p 8080:80 -it -d --name pruebatecnica pruebatecnica:latest bash ```

*Despues de hacer esto se podra acceder al proyecto mediante **localhost:8080***

5. Para deterner el contenedor ```‍docker stop <ID CONTENEDOR>```

### Autores ✒️

* **Autor:** Jerson O. Perez, jperez061@outlook.com
