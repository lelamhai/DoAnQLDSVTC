USE [QLDSV_TC]
GO

CREATE PROCEDURE SP_XOA_LOPTINCHI
    @NIENKHOA  NVARCHAR(9),
    @HOCKY     INT,
    @MAMH      NVARCHAR(10),
    @NHOM      INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM LOPTINCHI
        WHERE NIENKHOA = @NIENKHOA
          AND HOCKY    = @HOCKY
          AND MAMH     = @MAMH
          AND NHOM     = @NHOM
    )
    BEGIN
        RAISERROR (N'Không tìm thấy lớp tín chỉ.',16, 1);
        RETURN;
    END

   
    IF EXISTS (
        SELECT 1
        FROM DANGKY DK
        JOIN (
            SELECT MALTC
            FROM LOPTINCHI
            WHERE NIENKHOA = @NIENKHOA
              AND HOCKY    = @HOCKY
              AND MAMH     = @MAMH
              AND NHOM     = @NHOM
        ) LTC ON DK.MALTC = LTC.MALTC
    )
    BEGIN
        RAISERROR ( N'Không thể xóa lớp tín vì đã có sinh viên đăng ký.',16, 1);
        RETURN;
    END

   
    DELETE FROM LOPTINCHI
    WHERE NIENKHOA = @NIENKHOA
      AND HOCKY    = @HOCKY
      AND MAMH     = @MAMH
      AND NHOM     = @NHOM;
END
GO



