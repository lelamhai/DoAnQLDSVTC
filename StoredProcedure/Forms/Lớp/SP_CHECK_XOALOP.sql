USE [QLDSV_TC]
GO

CREATE PROC [dbo].[SP_CHECK_XOALOP]
    @MALOP NCHAR(10)
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM dbo.LOP
        WHERE MALOP = @MALOP
    )
    BEGIN
        RAISERROR(N'Mã lớp "%s" không tồn tại!', 16, 1, @MALOP);
        RETURN;
    END

    
    IF EXISTS (
        SELECT 1
        FROM dbo.SINHVIEN
        WHERE MALOP = @MALOP
    )
    BEGIN
        RAISERROR(N'Không thể xóa mã lớp "%s" vì lớp đã có sinh viên!',16, 1, @MALOP);
        RETURN;
    END
END
GO


