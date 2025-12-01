USE QLDSV_TC
GO

CREATE PROCEDURE SP_XOA_LOPTINCHI
    @NIENKHOA  NVARCHAR(9),
    @HOCKY     INT,
    @MAMH      NVARCHAR(10),
    @NHOM      INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1 FROM LOPTINCHI
        WHERE NIENKHOA = @NIENKHOA
          AND HOCKY    = @HOCKY
          AND MAMH     = @MAMH
          AND NHOM     = @NHOM
    )
    BEGIN
        SELECT KT = 0;   -- Không tìm thấy => Không thể xóa
    END
    ELSE
    BEGIN
        DELETE FROM LOPTINCHI
        WHERE NIENKHOA = @NIENKHOA
          AND HOCKY    = @HOCKY
          AND MAMH     = @MAMH
          AND NHOM     = @NHOM;

        SELECT KT = 1;   -- Xóa thành công
    END
END
GO

EXEC dbo.SP_XOA_LOPTINCHI N'2021-2022', 1, N'AV', 1