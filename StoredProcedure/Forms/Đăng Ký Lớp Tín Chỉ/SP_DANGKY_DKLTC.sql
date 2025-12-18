USE [QLDSV_TC]
GO

CREATE   PROC SP_DANGKY_DKLTC
    @MASV  NCHAR(10),
    @MALTC INT
AS
BEGIN
    DECLARE @MASV_TRIM NVARCHAR(10);
    SET @MASV_TRIM = LTRIM(RTRIM(@MASV));

    IF NOT EXISTS (SELECT 1 FROM SINHVIEN WHERE MASV = @MASV_TRIM)
    BEGIN
        RAISERROR (N'Sinh viên "%s" không tồn tại trong hệ thống.', 16, 1, @MASV_TRIM);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM SINHVIEN WHERE MASV = @MASV_TRIM AND DANGHIHOC = 1)
    BEGIN
        RAISERROR (N'Sinh viên "%s" đã nghỉ học.', 16, 1, @MASV_TRIM);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM LOPTINCHI WHERE MALTC = @MALTC)
    BEGIN
        RAISERROR (N'Không tìm thấy mã lớp tín chỉ "%d" trong hệ thống.', 16, 1, @MALTC);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM LOPTINCHI WHERE HUYLOP = 1)
    BEGIN
        RAISERROR (N'Lớp tín chỉ "%d" đã bị hủy.', 16, 1, @MALTC);
        RETURN;
    END

    IF EXISTS (SELECT 1  FROM DANGKY WHERE MALTC = @MALTC AND MASV = @MASV_TRIM AND HUYDANGKY=1)
    BEGIN
        RAISERROR (N'Sinh viên đã hủy đăng ký lớp tín chỉ "%d" rồi.', 16, 1, @MALTC);
        RETURN;
    END

    IF EXISTS (SELECT 1  FROM DANGKY WHERE MALTC = @MALTC AND MASV = @MASV_TRIM AND (HUYDANGKY = 0 OR HUYDANGKY IS NULL))
    BEGIN
        RAISERROR (N'Sinh viên đã đăng ký mã lớp tín chỉ "%d" rồi.', 16, 1, @MALTC);
        RETURN;
    END

    INSERT INTO DANGKY (MALTC, MASV, HUYDANGKY)
    VALUES (@MALTC, @MASV_TRIM, 0);
END
GO


