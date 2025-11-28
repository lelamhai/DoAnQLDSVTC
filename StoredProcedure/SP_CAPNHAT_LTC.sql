USE [QLDSV_TC]
GO
ALTER PROCEDURE SP_CAPNHAT_LOPTINCHI
    @KEY_NIENKHOA      NVARCHAR(9),
    @KEY_HOCKY         INT,
    @KEY_MAMH          NVARCHAR(10),
    @KEY_NHOM          INT,
    @NIENKHOA      NVARCHAR(9),
    @HOCKY         INT,
    @MAMH          NVARCHAR(10),
    @NHOM          INT,
    @MAGV          NVARCHAR(10),
    @MAKHOA        NVARCHAR(10),
    @SOSVTOITHIEU  INT,
    @HUYLOP        BIT
AS
BEGIN
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
        WHERE NIENKHOA      = @KEY_NIENKHOA
          AND HOCKY         = @KEY_HOCKY
          AND MAMH          = @KEY_MAMH
          AND NHOM          = @KEY_NHOM;
END
GO

EXEC SP_CAPNHAT_LOPTINCHI N'2021-2022','2',N'CTDL','2', N'2021-2022','1',N'CTDL','1', N'GV01', N'CNTT', '10', False