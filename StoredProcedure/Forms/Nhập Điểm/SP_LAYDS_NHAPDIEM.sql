USE [QLDSV_TC]
GO

CREATE PROC SP_LAYDS_NHAPDIEM
    @NIENKHOA  NVARCHAR(9),
    @HOCKY     INT,
    @MAMH      NVARCHAR(10),
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

    SELECT 
        DK.MALTC,
        SV.MASV,
        SV.HO + ' ' + SV.TEN AS HOTEN,
        DK.DIEM_CC,
        DK.DIEM_GK,
        DK.DIEM_CK,
        CASE
            WHEN DK.DIEM_CC IS NULL AND DK.DIEM_GK IS NULL AND DK.DIEM_CK IS NULL
                THEN NULL
                ELSE CAST(ROUND(ISNULL(DK.DIEM_CC, 0) * 0.10+ ISNULL(DK.DIEM_GK, 0) * 0.30+ ISNULL(DK.DIEM_CK, 0) * 0.60, 2)
                AS DECIMAL(5,2))
         END AS DIEM_HM
    FROM
        (SELECT *
         FROM LOPTINCHI
         WHERE NIENKHOA = @NIENKHOA
           AND HOCKY    = @HOCKY
           AND MAMH     = @MAMH
           AND NHOM     = @NHOM
           AND (HUYLOP IS NULL OR HUYLOP = 0)
        ) LTC
    JOIN
        (SELECT *
         FROM DANGKY
         WHERE HUYDANGKY IS NULL OR HUYDANGKY = 0
        ) DK
        ON DK.MALTC = LTC.MALTC
    JOIN
        (SELECT *
         FROM SINHVIEN
         WHERE DANGHIHOC IS NULL OR DANGHIHOC = 0
        ) SV
        ON SV.MASV = DK.MASV;
END;
GO


