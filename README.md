# Sistema de gestión dental

Aplicación de escritorio académica en C# para organizar información de pacientes, dentistas y citas. La solución separa modelos, acceso a datos, lógica de negocio y pantallas de Windows Forms.

## Arquitectura

- `Proyecto1_Dental.Models`: entidades del dominio.
- `Proyecto1_Dental.Data`: contexto de datos y persistencia con Entity Framework.
- `Proyecto1_Dental.Business`: lógica de negocio.
- `Proyecto1_Dental.Presentation` y `Proyecto1_Dental.UI`: aplicaciones y formularios de escritorio.

## Requisitos

- Windows
- Visual Studio con soporte para .NET Framework 4.7.2
- SQL Server LocalDB

La configuración de datos apunta a una base local llamada `Proyecto1_Dental_DB`. Ajusta la cadena de conexión en el entorno local si necesitas usar otra instancia.

## Abrir el proyecto

1. Clona el repositorio.
2. Abre `SolutionProyectoDental.slnx` en una versión de Visual Studio que lo admita.
3. Restaura los paquetes NuGet.
4. Configura la base de datos local y ejecuta el proyecto de interfaz que quieras iniciar.

## Tecnologías

- C#
- Windows Forms
- .NET Framework 4.7.2
- Entity Framework 6
- SQL Server LocalDB

## Estado

Proyecto académico en evolución. Antes de usarlo con datos reales, se necesita completar y verificar el flujo de persistencia, validaciones y manejo de errores.

## Autor

Alonzo Yariel
