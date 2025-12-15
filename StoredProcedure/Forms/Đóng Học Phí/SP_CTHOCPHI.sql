USE [QLDSV_TC]
GO

CREATE PROC [dbo].[SP_CTHOCPHI]
    @MASV     NCHAR(10),
    @NIENKHOA NCHAR(9),
    @HOCKY    INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM CT_DONGHOCPHI
        WHERE MASV     = @MASV
          AND NIENKHOA = @NIENKHOA
          AND HOCKY    = @HOCKY
    )
    BEGIN
        RAISERROR (N'Chưa đóng học phí cho niên khóa %s và học kỳ %d!', 16, 1, @NIENKHOA, @HOCKY);
        RETURN;
    END

    SELECT NGAYDONG, SOTIENDONG
    FROM CT_DONGHOCPHI
    WHERE MASV     = @MASV
      AND NIENKHOA = @NIENKHOA
      AND HOCKY    = @HOCKY;
END

GO


