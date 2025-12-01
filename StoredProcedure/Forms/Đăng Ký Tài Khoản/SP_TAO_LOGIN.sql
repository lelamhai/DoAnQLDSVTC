CREATE PROC SP_TAO_LOGIN
@USERNAME NCHAR(20),
@PASSWORD NVARCHAR(40),
@MAGV NCHAR(10),
@ROLE NCHAR(20)

AS

DECLARE @RET INT
EXEC @RET = [sys].[sp_addlogin] @USERNAME,@PASSWORD,'QLDSV_TC'
													
IF(@RET = 1)
	BEGIN
		RETURN 1
	END


EXEC @RET = [sys].[sp_grantdbaccess] @USERNAME,@MAGV
			
IF(@RET = 1)
	BEGIN
		EXEC [sys].[sp_droplogin] @USERNAME
		RETURN 2		
	END

EXEC sys.sp_addrolemember @ROLE,@MAGV
IF(@ROLE = 'PGV' OR @ROLE = 'KHOA' OR @ROLE = 'PKT')
	BEGIN
		EXEC sys.sp_addsrvrolemember @USERNAME,'securityadmin'
	END
RETURN 0
GO

EXEC SP_TAO_LOGIN N'haitho', N'123456', N'GV05', N'KHOA'