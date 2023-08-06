
/*-----------------------------------------------------------------------------------------------------------------
--Creado por: Fabian Vargas Tovar
--Fecha Creacion:04-08-2023
--Descripcion: Creacion tablas, insercion datos, validaciones, creacion Index, modificacion y creacion constraint 
-----------------------------------------------------------------------------------------------------------------*/

-- Validar si la base de datos ya existe
IF DB_ID('DigitalBank') IS NOT NULL
    PRINT 'La base de datos ya existe.'
ELSE
BEGIN
    -- Crear la base de datos
    CREATE DATABASE DigitalBank;
    PRINT 'La base de datos ha sido creada correctamente.'
END
--Usar base datos
USE DigitalBank
-- Validar si la tabla ya existe
IF OBJECT_ID('Usuario', 'U') IS NOT NULL
    PRINT 'La tabla Usuario ya existe en la base de datos.'
ELSE
BEGIN
    -- Crear la tabla con ID autoincremental
    CREATE TABLE Usuario (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(100),
        FechaNacimiento DATE,
        Sexo CHAR(1)
    );

    PRINT 'La tabla Usuario ha sido creada correctamente.'
END

  -- Crear índice si no existe en la columna Nombre
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Usuario_Nombre')
    BEGIN
        CREATE INDEX IX_Usuario_Nombre ON Usuario (Nombre);
        PRINT 'Se ha creado el índice en la columna Nombre.';
    END;

	-- Eliminar la restricción PK existente
IF EXISTS ( select * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS where CONSTRAINT_NAME='PK__Usuario__3214EC27DEDC434C')
BEGIN
ALTER TABLE Usuario
DROP CONSTRAINT PK__Usuario__3214EC27DEDC434C;
-- Modificar una nueva restricción PK
ALTER TABLE Usuario
ADD CONSTRAINT PK_Usuario PRIMARY KEY (Id);
END

--Insercion Datos
INSERT INTO Usuario(Nombre, FechaNacimiento, Sexo)
VALUES ('fabian', '1990-07-27', 'F');

--Crear table Monitoreo
IF OBJECT_ID('ErrorLog', 'U') IS NOT NULL
    PRINT 'La tabla ErrorLog ya existe en la base de datos.'
ELSE
BEGIN
CREATE TABLE ErrorLog (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FechaRegistro DATETIME DEFAULT GETDATE(),
    Mensaje NVARCHAR(MAX),
    Detalles NVARCHAR(MAX)
);
    PRINT 'La tabla ErrorLog ha sido creada correctamente.'
END


