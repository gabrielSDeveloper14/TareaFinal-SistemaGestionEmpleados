CREATE DATABASE SistemaGestionEmpleadosDB;
GO

USE SistemaGestionEmpleadosDB;
GO

CREATE TABLE Empleados (
Id INT PRIMARY KEY IDENTITY(1,1),
Nombre NVARCHAR(50),
Apellido NVARCHAR(50),
Cargo NVARCHAR(50),
Sueldo DECIMAL(10,2),
);
GO


SELECT * FROM Empleados;
GO

