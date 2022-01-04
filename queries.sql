--querys hiper verdes(no llegué a ponerme con ellos, sumado a que estoy un poco oxidado con la logica de los SP por tanto EF, con mas tiempo los podía hacer sin problema)

CREATE TABLE tAlquiler (cod_alquiler INT PRIMARY KEY IDENTITY, usuario
VARCHAR(500), precio_alquiler NUMERIC(18,2), fecha Datetime)
GO

CREATE TABLE tCompra (cod_compra INT PRIMARY KEY IDENTITY, usuario
VARCHAR(500), precio_compra NUMERIC(18,2), fecha Datetime)
GO


CREATE PROCEDURE CreateUSer @txtuser nvarchar(50),@txtpass nvarchar(50),@txtnombre nvarchar(200),@txtapellido varchar(50),@nrodoc varchar(50),@codrol int,@snactivo int
AS
DECLARE @cod_usuario_result INT;
IF EXISTS (SELECT cod_usuario FROM dbo.tUsers WHERE nrodoc = @nrodoc)
    BEGIN
       INSERT INTO dbo.tUsers (txt_user, txt_password, txt_nombre, nro_doc, cod_rol, sn_activo) VALUES (@txtuser,@txtpass,@txtnombre,@txtapellido,@nrodoc,@codrol,@snactivo)
    END
	ELSE
	BEGIN
    RAISERROR ('User already exist')
	END

GO;