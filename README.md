# Console.ReadAppSettings.json

La plantilla de aplicación de consola .NET Core nos permite probar ideas rápidamente (PoC) y en entorno de producción ejecutar tarea definida de manera intermitente (a petición).
</br>Porque es una plantilla ligera NO tiene algunas funcionalidades incorporada por defecto como configuración e inyección de dependencia.</p>

**Este es un PoC de aplicación de consola C# .NET Core que leerá los valores de un archivo appsettings.json además usando inyección de dependencias (dependency injection) accederemos al objeto IConfigurationRoot**

Los paquetes NuGet que hemos usado son:</p>
- `Install-Package Microsoft.Extensions.Configuration`
- `Install-Package Microsoft.Extensions.Configuration.Binder`
- `Install-Package Microsoft.Extensions.Configuration.Json`
- `Install-Package Microsoft.Extensions.DependencyInjection`

</p>
</p>

**Nota:**</br>
Si se necesita un aplicación de consola para tareas o procesos de larga duración, probablemente la mejor opción es utilizar la plantilla de [Service Worker](https://devblogs.microsoft.com/premier-developer/demystifying-the-new-net-core-3-worker-service).
</br> *"Esta plantilla está diseñada para brindarle un punto de partida para los servicios multiplataforma. Como caso de uso alternativo, configura un entorno muy agradable para aplicaciones de consola general que es perfecto para contenedores y microservicios."* - Extracto del articulo



Referencia:
1. [Configuración en ASP.NET Core](https://docs.microsoft.com/es-es/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1)
2. [Inyección de dependencias en ASP.NET Core](https://docs.microsoft.com/es-es/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1)
3. [IConfiguration ](https://docs.microsoft.com/es-es/dotnet/api/microsoft.extensions.configuration.iconfiguration)
4. [Configuración de entornos en la aplicación de consola .NET](https://www.damirscorner.com/blog/posts/20210305-ConfiguringEnvironmentsInNetConsoleApp.html)
 
