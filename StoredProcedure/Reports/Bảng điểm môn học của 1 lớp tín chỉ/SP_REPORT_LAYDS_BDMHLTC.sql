USE QLDSV_TC
GO

CREATE PROCEDURE SP_REPORT_LAYDS_BDMHLTC
    @NIENKHOA  NCHAR(9),
    @HOCKY     INT,
    @MAMH      NCHAR(10),
    @NHOM      INT

AS
BEGIN
    DECLARE @MONHOC_TRIM NVARCHAR(10);
    SET @MONHOC_TRIM = LTRIM(RTRIM(@MAMH));
    IF NOT EXISTS (
        SELECT 1
        FROM LOPTINCHI
        WHERE NIENKHOA = @NIENKHOA
          AND HOCKY    = @HOCKY
          AND MAMH     = @MONHOC_TRIM
          AND NHOM     = @NHOM
    )
    BEGIN
        RAISERROR(
            N'Không tồn tại lớp tín chỉ với Niên khóa=%s, Học kỳ=%d, Môn học=%s, Nhóm=%d.',
            16, 1,
            @NIENKHOA, @HOCKY, @MONHOC_TRIM, @NHOM
        );
        RETURN;
    END

    IF NOT EXISTS (
        SELECT 1
        FROM LOPTINCHI
        WHERE NIENKHOA = @NIENKHOA
          AND HOCKY    = @HOCKY
          AND MAMH     = @MONHOC_TRIM
          AND NHOM     = @NHOM
          AND (HUYLOP = 0 OR HUYLOP IS NULL)
    )
    BEGIN
        RAISERROR(
            N'Lớp tín chỉ đã bị hủy lớp với Niên khóa=%s, Học kỳ=%d, Môn học=%s, Nhóm=%d.',
            16, 1,
            @NIENKHOA, @HOCKY, @MONHOC_TRIM, @NHOM
        );
        RETURN;
    END

    DECLARE @MALTC INT;

    SELECT TOP 1 @MALTC = LTC.MALTC
    FROM dbo.LOPTINCHI LTC
    WHERE LTC.NIENKHOA = @NIENKHOA
      AND LTC.HOCKY    = @HOCKY
      AND LTC.MAMH     = @MAMH
      AND LTC.NHOM     = @NHOM;

    IF (@MALTC IS NULL)
    BEGIN
        RAISERROR(
            N'Không tìm thấy Lớp tín chỉ với Niên khóa = %s, Học kỳ = %d, Môn học = %s, Nhóm = %d.',
            16, 1, @NIENKHOA, @HOCKY, @MAMH, @NHOM
        );
        RETURN;
    END;

    SELECT
          ROW_NUMBER() OVER (
                ORDER BY
                    SV.TEN COLLATE Vietnamese_CI_AI,
                    SV.HO  COLLATE Vietnamese_CI_AI,
                    SV.MASV
          ) AS STT
        , SV.MASV
        , SV.HO
        , SV.TEN
        , DK.DIEM_CC
        , DK.DIEM_GK
        , DK.DIEM_CK
        , CAST(
            ROUND(
                ISNULL(DK.DIEM_CC, 0) * 0.10
              + ISNULL(DK.DIEM_GK, 0) * 0.30
              + ISNULL(DK.DIEM_CK, 0) * 0.60
            , 2)
          AS DECIMAL(5,2)
          ) AS DIEM_HM
    FROM
        (SELECT MALTC
         FROM dbo.LOPTINCHI
         WHERE NIENKHOA = @NIENKHOA
           AND HOCKY    = @HOCKY
           AND MAMH     = @MAMH
           AND NHOM     = @NHOM
        ) LTC
    JOIN
        (SELECT MASV, MALTC, DIEM_CC, DIEM_GK, DIEM_CK
         FROM dbo.DANGKY
         WHERE ISNULL(HUYDANGKY, 0) = 0
        ) DK
        ON DK.MALTC = LTC.MALTC
    JOIN
        (SELECT MASV, HO, TEN
         FROM dbo.SINHVIEN
        ) SV
        ON SV.MASV = DK.MASV
    ORDER BY
        SV.TEN COLLATE Vietnamese_CI_AI,
        SV.HO  COLLATE Vietnamese_CI_AI,
        SV.MASV;
END
GO