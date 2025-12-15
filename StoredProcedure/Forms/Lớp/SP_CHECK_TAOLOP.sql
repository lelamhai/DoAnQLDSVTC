USE [QLDSV_TC]
GO

CREATE     PROC [dbo].[SP_CHECK_TAOLOP]
@MLOP NCHAR(10),
@TENLOP NVARCHAR(50)
AS 

    IF EXISTS (SELECT 1 FROM dbo.LOP WHERE MALOP = @MLOP)
    BEGIN
        RAISERROR(N'Mã lớp "%s" đã tồn tại trên Khoa hiện tại!', 16, 1, @MLOP);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM LINK0.QLDSV_TC.dbo.LOP WHERE MALOP = @MLOP)
    BEGIN
        RAISERROR(N'Mã lớp "%s" đã tồn tại trên Khoa còn lại!', 16, 1, @MLOP);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM dbo.LOP WHERE LTRIM(RTRIM(TENLOP)) = LTRIM(RTRIM(@TENLOP)))
    BEGIN
        RAISERROR(N'Tên lớp "%s" đã tồn tại trên Khoa hiện tại!', 16, 1, @TENLOP);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM LINK0.QLDSV_TC.dbo.LOP WHERE LTRIM(RTRIM(TENLOP)) = LTRIM(RTRIM(@TENLOP)))
    BEGIN
        RAISERROR(N'Tên lớp "%s" đã tồn tại trên Khoa còn lại!', 16, 1, @TENLOP);
        RETURN;
    END
GO


