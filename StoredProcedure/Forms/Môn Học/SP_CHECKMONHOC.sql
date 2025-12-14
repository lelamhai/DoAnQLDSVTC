USE [QLDSV_TC]
GO

CREATE PROC [dbo].[SP_CHECKMONHOC]
@MAMH  NCHAR(10),
@TENMH NVARCHAR(50)
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM dbo.MONHOC
        WHERE MAMH = @MAMH
    )
    BEGIN
        RAISERROR(N'Mã môn học %s đã tồn tại.', 16, 1, @MAMH);
        RETURN;
    END

    IF EXISTS (
        SELECT 1
        FROM dbo.MONHOC
        WHERE TENMH = @TENMH
    )
    BEGIN
        RAISERROR(N'Tên môn học %s đã tồn tại.', 16, 1, @TENMH);
        RETURN;
    END
END
GO


EXEC SP_CHECKMONHOC N'JAVA1', N'Lập trình java'