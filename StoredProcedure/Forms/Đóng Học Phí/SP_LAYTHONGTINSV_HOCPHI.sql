USE [QLDSV_TC]
GO

CREATE PROCEDURE SP_LAYTHONGTINSV_HOCPHI
    @MASV NCHAR(10)
AS
	
BEGIN
    DECLARE @MASV_TRIM NVARCHAR(10);
    SET @MASV_TRIM = LTRIM(RTRIM(@MASV));

    IF NOT EXISTS (
        SELECT 1
        FROM SINHVIEN
        WHERE MASV = @MASV_TRIM
    )
    BEGIN
        RAISERROR (N'Sinh viên "%s" không tồn tại trong hệ thống.', 16, 1, @MASV_TRIM);
        RETURN;
    END

    IF EXISTS (
        SELECT 1
        FROM SINHVIEN
        WHERE MASV = @MASV_TRIM AND DANGHIHOC = 1
    )
    BEGIN
        RAISERROR (N'Sinh viên "%s" đã nghỉ học.', 16, 1, @MASV_TRIM);
        RETURN;
    END

    SELECT 
        HO + ' ' + TEN AS HOTEN,
        MALOP
    FROM SINHVIEN
    WHERE MASV = @MASV;
END
GO


