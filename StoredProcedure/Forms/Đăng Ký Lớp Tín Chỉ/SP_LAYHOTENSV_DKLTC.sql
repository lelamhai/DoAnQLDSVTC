USE [QLDSV_TC]
GO

CREATE OR ALTER PROC [dbo].[SP_LAYHOTENSV_DKLTC]
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
        HOTEN = LTRIM(RTRIM(SV.HO)) + N' ' + LTRIM(RTRIM(SV.TEN)),
        L.MALOP,
        L.TENLOP,
        L.MAKHOA
    FROM (
        SELECT HO, TEN, MALOP
        FROM SINHVIEN
        WHERE MASV = @MASV_TRIM
          AND (DANGHIHOC = 0 OR DANGHIHOC IS NULL)
    ) SV
    JOIN LOP L ON SV.MALOP = L.MALOP;
END
GO

EXEC dbo.SP_LAYHOTENSV_DKLTC N'lelamhai11'