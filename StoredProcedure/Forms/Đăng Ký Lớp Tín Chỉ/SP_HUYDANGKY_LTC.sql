USE [QLDSV_TC]
GO

CREATE OR ALTER PROC [dbo].[SP_HUYDANGKY_LTC]
    @MASV  NCHAR(10),
    @MALTC INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM DANGKY WHERE MALTC = @MALTC AND MASV = @MASV)
    BEGIN
        RAISERROR(N'Không tìm thấy đăng ký lớp tín chỉ của sinh viên.', 16, 1);
        RETURN;
    END

    IF EXISTS (
        SELECT 1
        FROM DANGKY
        WHERE MALTC = @MALTC AND MASV = @MASV
          AND (DIEM_CC IS NOT NULL OR DIEM_GK IS NOT NULL OR DIEM_CK IS NOT NULL)
    )
    BEGIN
        RAISERROR(N'Không thể hủy vì lớp tín chỉ đã có điểm.', 16, 1);
        RETURN;
    END

    UPDATE DANGKY
    SET HUYDANGKY = 1
    WHERE MALTC = @MALTC AND MASV = @MASV;
END
GO