USE [QLDSV_TC]
GO

CREATE PROCEDURE SP_CAPNHAT_LOPTINCHI
    @NIENKHOA      NVARCHAR(9),
    @HOCKY         INT,
    @MAMH          NVARCHAR(10),
    @NHOM          INT,
    @MAGV          NVARCHAR(10),
    @MAKHOA        NVARCHAR(10),
    @SOSVTOITHIEU  INT,
    @HUYLOP        BIT,
    @NEW_NIENKHOA      NVARCHAR(9),
    @NEW_HOCKY         INT,
    @NEW_MAMH          NVARCHAR(10),
    @NEW_NHOM          INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM LOPTINCHI
        WHERE NIENKHOA = @NEW_NIENKHOA
          AND HOCKY    = @NEW_HOCKY
          AND MAMH     = @NEW_MAMH
          AND NHOM     = @NEW_NHOM
    )
    BEGIN
        RAISERROR (N'Không tìm thấy lớp tín chỉ.',16, 1);
        RETURN;
    END

    UPDATE LOPTINCHI
    SET 
        NIENKHOA        = @NIENKHOA,
        HOCKY           = @HOCKY,
        MAMH            = @MAMH,
        NHOM            = @NHOM,
        MAGV            = @MAGV,
        MAKHOA          = @MAKHOA,
        SOSVTOITHIEU    = @SOSVTOITHIEU,
        HUYLOP          = @HUYLOP
    WHERE NIENKHOA      = @NEW_NIENKHOA
        AND HOCKY       = @NEW_HOCKY
        AND MAMH        = @NEW_MAMH
        AND NHOM        = @NEW_NHOM;
END
GO


