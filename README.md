# Prueba técnica TR3SDETR3S

El presente repositorio corresponde a la solución de la prueba técnica de TR3SDETR3S para el puesto de desarrollador full-stack. Para entender la tarea a realizar, recomiendo leer el archivo test_5720.pdf, en el que está escrito el requerimiento.

El proyecto consta de dos componentes principales: La API (backend) desarrollada con ASP.NET Core 5 y el frontend desarrollado con React. A continuación, se explica cómo realizar la instalación de ambos componentes para correr el proyecto de forma local.

Primero se debe clonar el repositorio:
```
git clone https://github.com/JuanCRdrums/TR3SDETR3S
```

## API

Como se mencionó anteriormente, la API para el backend del proyecto está hecha con ASP.NET Core 5, usando C# como lenguaje de programación y SQL Server como base de datos (ver la carpeta database para explorar los scripts de la base de datos y ver un ejemplo de cómo quedan guardados los datos). El paso a paso para hacer funcionar la API es el siguiente:

1. Ejecutar los scripts para crear la base de datos y las tablas (ver carpeta de database).
2. Configurar el archivo appsettings.developer.json con la cadena de conexión para la base de datos. En caso de que el entorno sea de producción y no de desarrollo, cambiar el nombre del archivo a appsettings.json.
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "ConnectionStrings": {
    "local": "Server=***;Database=***;User ID=***;Password=***;"
  }
}

```
3. Correr y probar la aplicación (se recomienda el uso de Microsoft Visual Studio 2019 para realizar depuración). La API tiene Swagger incorporado, así que la documentación del único método existente puede verse en https://localhost:44310/swagger/index.html una vez que se esté corriendo la API (por defecto, el proyecto corre en https://localhost:44310).


## Frontend

Como se mencionó al principio, el frontend del proyecto está hecho con React. Después de haber clonado el repositorio, se debe hacer lo siguiente:

1. Instalar dependencias. Correr el comando ``` npm install ```.
2. Abrir el archivo API.js para configurar la URL de la API que se va a consumir (backend), editando el campo baseURL.
```
export default axios.create({
    baseURL: "https://localhost:44310/api/Result",
    headers: {
        'Accept':'application/json',
        'Content-Type':'application/json',
    }
})
```
3. Correr el proyecto localmente con el comando ``` npm start ```

---------------------------------------
En caso de dudas o inconvenientes:

Email: juankdrums14@gmail.com
