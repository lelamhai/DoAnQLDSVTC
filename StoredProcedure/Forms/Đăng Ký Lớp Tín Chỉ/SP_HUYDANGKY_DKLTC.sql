USE [QLDSV_TC]
GO

CREATE    PROC SP_HUYDANGKY_DKLTC
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

    IF NOT EXISTS (SELECT 1 FROM LOPTINCHI WHERE MALTC = @MASV_TRIM)
    BEGIN
        RAISERROR (N'Không tìm thấy mã lớp tín chỉ "%d" trong hệ thống.', 16, 1, @MALTC);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM LOPTINCHI WHERE HUYLOP = 1)
    BEGIN
        RAISERROR (N'Lớp tín chỉ "%d" đã bị hủy.', 16, 1, @MALTC);
        RETURN;
    END
    
    IF EXISTS (
        SELECT 1
        FROM DANGKY
        WHERE MALTC = @MALTC AND MASV = @MASV_TRIM
          AND (DIEM_CC IS NOT NULL OR DIEM_GK IS NOT NULL OR DIEM_CK IS NOT NULL)
    )
    BEGIN
        RAISERROR(N'Không thể hủy vì lớp tín chỉ "%d" đã có điểm.', 16, 1, @MALTC);
        RETURN;
    END



    UPDATE DANGKY
    SET HUYDANGKY = 1
    WHERE MALTC = @MALTC AND MASV = @MASV;
END
GO


