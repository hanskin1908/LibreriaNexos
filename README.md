# LibreriaNexos  Backend De la prueba
fue desarrollada en visual studio 2019 y Sql server en su version 2019
.net core 
se realizo migracion desde la base de datos hacia la solucion para crear los modelos de las entidades
Scaffold-DbContext "Server=LAPTOP-9H09STR1\MSSQLSERVER_HANS;Database=BDLibreriaNexos;Integrated Security= true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data

Para Ejecutar se debe cambiar en el startup las politicas para que permita el consumo desde el cliente de angular

 app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:4200");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });
            
            cambiar el puerto con el cual se ejcute la aplicacion angular en su equipo.
            
            a su vez se debe cambiar el puerto de la api al cual apunta el cliente angular en el archivo environments
            
            
export const environment = {
  production: false,
  apiURL: 'https://localhost:44310/api/'
};
