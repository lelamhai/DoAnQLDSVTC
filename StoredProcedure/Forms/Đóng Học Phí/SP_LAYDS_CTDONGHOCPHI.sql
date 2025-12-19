USE [QLDSV_TC]
GO


CREATE PROC SP_LAYDS_CTDONGHOCPHI
    @MASV     NCHAR(10),
    @NIENKHOA NCHAR(9),
    @HOCKY    INT
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


    IF NOT EXISTS (
        SELECT 1
        FROM CT_DONGHOCPHI
        WHERE MASV     = @MASV
          AND NIENKHOA = @NIENKHOA
          AND HOCKY    = @HOCKY
    )
    BEGIN
        RAISERROR (N'Sinh viên "%s" chưa đóng học phí cho niên khóa: "%s" và học kỳ: "%d"!', 16, 1,@MASV_TRIM, @NIENKHOA, @HOCKY);
        RETURN;
    END

    SELECT NGAYDONG, SOTIENDONG
    FROM CT_DONGHOCPHI
    WHERE MASV     = @MASV
      AND NIENKHOA = @NIENKHOA
      AND HOCKY    = @HOCKY;
END

GO


