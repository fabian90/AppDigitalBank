/*-----------------------------------------------------------------------------------------------------------------
--SP:dbo.sp_GestionarUsuario
--Creado por: Fabian Vargas Tovar
--Fecha Creacion:04-08-2023
--Descripcion: CRUD segun la operacion 
-----------------------------------------------------------------------------------------------------------------*/

USE DigitalBank
-- Crear o alterar el procedimiento almacenado
IF OBJECT_ID('dbo.sp_GestionarUsuario', 'P') IS NOT NULL
    DROP PROCEDURE dbo.GestionarUsuario;
GO
-- Crear procedimiento para CRUD
CREATE PROCEDURE dbo.sp_GestionarUsuario
    @Operacion NVARCHAR(10),
    @Nombre NVARCHAR(100)=null,
    @FechaNacimiento DATE=null,
    @Sexo CHAR(1)=null,
    @ID INT = NULL,
	@RowCount INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF @Operacion = 'Crear'
    BEGIN
	  BEGIN TRY
		BEGIN TRANSACTION;
        INSERT INTO Usuario (Nombre, FechaNacimiento, Sexo)
        VALUES (@Nombre, @FechaNacimiento, @Sexo);
		SET @RowCount = @@ROWCOUNT;
		 --Commit la transacción si todo va bien
		 COMMIT TRANSACTION;
	  END TRY
	  BEGIN CATCH
			-- Rollback la transacción si ocurre un error
			IF @@TRANCOUNT > 0
				ROLLBACK TRANSACTION;
			-- Devolver un valor de error
			SET @RowCount = -1;
	  END CATCH;
	   -- Devolver el número de filas afectadas o el valor de error como resultado
		SELECT @RowCount AS 'RowCount';
    END
    ELSE IF @Operacion = 'Actualizar'
    BEGIN
	 BEGIN TRY
		BEGIN TRANSACTION;
        UPDATE Usuario
        SET Nombre = @Nombre,
            FechaNacimiento = @FechaNacimiento,
            Sexo = @Sexo
        WHERE ID = @ID;
		SET @RowCount = @@ROWCOUNT;
		--Commit la transacción si todo va bien
		 COMMIT TRANSACTION;
		 END TRY
		 BEGIN CATCH
			-- Rollback la transacción si ocurre un error
			IF @@TRANCOUNT > 0
				ROLLBACK TRANSACTION;
			-- Devolver un valor de error
			SET @RowCount = -1;
	  END CATCH;
	     -- Devolver el número de filas afectadas o el valor de error como resultado
			SELECT @RowCount AS 'RowCount';
    END
    ELSE IF @Operacion = 'Borrar'
    BEGIN
	  IF EXISTS (SELECT * FROM Usuario WHERE ID = @ID)
		BEGIN
		    BEGIN TRY
				 BEGIN TRANSACTION;
			-- Borrar el registro
			DELETE FROM Usuario WHERE Id = @ID;
			SET @RowCount = @@ROWCOUNT;
        -- Commit la transacción si todo va bien
			COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
			-- Rollback la transacción si ocurre un error
			IF @@TRANCOUNT > 0
				ROLLBACK TRANSACTION;
			-- Devolver un valor de error
			SET @RowCount = -1;
		END CATCH;
		END
		ELSE
		BEGIN
			PRINT 'El registro no existe.';
		END
		  -- Devolver el número de filas afectadas o el valor de error como resultado
			SELECT @RowCount AS 'RowCount';
    END
    ELSE IF @Operacion = 'Leer'
    BEGIN
	   BEGIN TRY
		  BEGIN TRANSACTION;
			SELECT *
			FROM Usuario
			WHERE ID = @ID;
			SET @RowCount = @@ROWCOUNT;
		 --Commit la transacción si todo va bien
		 COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
			-- Rollback la transacción si ocurre un error
			IF @@TRANCOUNT > 0
				ROLLBACK TRANSACTION;
			-- Devolver un valor de error
			SET @RowCount = -1;
		END CATCH;
    END
    ELSE
    BEGIN
        PRINT 'Operación no válida';
    END
	 -- Devolver el número de filas afectadas o el valor de error como resultado
	 SELECT @RowCount AS 'RowCount';
END;