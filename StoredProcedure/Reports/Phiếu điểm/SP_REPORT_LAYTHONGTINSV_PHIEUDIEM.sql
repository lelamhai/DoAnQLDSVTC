USE [QLDSV_TC]
GO


CREATE PROCEDURE SP_REPORT_LAYTHONGTINSV_PHIEUDIEM
    @MASV NCHAR(10)
AS

BEGIN
    DECLARE @MASV_TRIM NVARCHAR(50);
    SET @MASV_TRIM = LTRIM(RTRIM(@MASV));

    IF NOT EXISTS (SELECT 1 FROM SINHVIEN WHERE MASV = @MASV_TRIM)
    BEGIN
        RAISERROR(N'Mã sinh viên "%s" không tồn tại trên Khoa hiện tại!', 16, 1, @MASV_TRIM);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM LINK0.QLDSV_TC.dbo.SINHVIEN WHERE MASV = @MASV_TRIM)
    BEGIN
        RAISERROR(N'Mã sinh viên "%s" không tồn tại trong hệ thống!', 16, 1, @MASV_TRIM);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM SINHVIEN WHERE MASV = @MASV_TRIM AND DANGHIHOC = 0)
    BEGIN
        RAISERROR(N'Mã sinh viên "%s" đã nghỉ học!', 16, 1, @MASV_TRIM);
        RETURN;
    END

    SELECT
        sv.MASV,
        LTRIM(RTRIM(sv.HO)) + N' ' + LTRIM(RTRIM(sv.TEN)) AS HOTEN,
        lop.KHOAHOC,
        CONVERT(VARCHAR(10), sv.NGAYSINH, 103) AS NGAYSINH,
        lop.TENLOP,
        k.TENKHOA
    FROM dbo.SINHVIEN sv
    JOIN dbo.LOP  lop ON lop.MALOP  = sv.MALOP
    JOIN dbo.KHOA k   ON k.MAKHOA   = lop.MAKHOA
    WHERE sv.MASV = @MASV_TRIM;
END
GO


