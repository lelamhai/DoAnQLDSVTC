USE [QLDSV_TC]
GO

CREATE PROC SP_CHECK_XOAMONHOC
    @MAMH NCHAR(10)
AS
BEGIN
   
    DECLARE @MAMH_TRIM NVARCHAR(10);
    SET @MAMH_TRIM = LTRIM(RTRIM(@MAMH));

    IF NOT EXISTS (SELECT 1 FROM MONHOC WHERE MAMH = @MAMH)
    BEGIN
        RAISERROR(N'Môn học "%s" không tồn tại!', 16, 1, @MAMH_TRIM);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM LOPTINCHI WHERE MAMH = @MAMH)
    BEGIN
        RAISERROR(N'Không thể xóa môn học "%s" vì môn học đã được mở lớp tín chỉ!', 16, 1, @MAMH_TRIM);
        RETURN;
    END
END
GO


