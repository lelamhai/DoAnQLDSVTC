USE [QLDSV_TC]
GO

CREATE PROC SP_CHECK_XOASINHVIEN
    @MASV NCHAR(10)
AS
BEGIN
    DECLARE @MASV_TRIM NVARCHAR(10);
    SET @MASV_TRIM = LTRIM(RTRIM(@MASV));

    IF NOT EXISTS (SELECT 1 FROM SINHVIEN WHERE MASV = @MASV_TRIM)
    BEGIN
        RAISERROR(N'Sinh viên có mã "%s" không tồn tại!', 16, 1, @MASV_TRIM);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM DANGKY WHERE MASV = @MASV_TRIM)
    BEGIN
        RAISERROR(N'Không thể xóa sinh viên "%s" vì sinh viên đã có đăng ký lớp tín chỉ!', 16, 1, @MASV_TRIM);
        RETURN;
    END
END
GO


