USE [QLDSV_TC]
GO

CREATE PROCEDURE SP_REPORT_LAYDS_SVDKLTC @NIENKHOA NCHAR(9),
    @HOCKY INT,
    @MONHOC NCHAR(10),
    @NHOM INT
AS
BEGIN
    DECLARE @MONHOC_TRIM NVARCHAR(10);
    SET @MONHOC_TRIM = LTRIM(RTRIM(@MONHOC));

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
        ROW_NUMBER() OVER (ORDER BY SV.TEN, SV.HO) AS STT,
        SV.MASV, SV.HO, SV.TEN,
        PHAI = CASE WHEN SV.PHAI = 0 THEN N'Nam' ELSE N'Nữ' END,
        SV.MALOP,
        LTC.MALTC
    FROM
        (SELECT MALTC
         FROM LOPTINCHI
         WHERE NIENKHOA = @NIENKHOA
           AND HOCKY    = @HOCKY
           AND MAMH     = @MONHOC_TRIM
           AND NHOM     = @NHOM
           AND (HUYLOP = 0 OR HUYLOP IS NULL)
        ) LTC
    JOIN
        (SELECT MALTC, MASV
         FROM DANGKY
         WHERE HUYDANGKY = 0 OR HUYDANGKY IS NULL
        ) DK
        ON DK.MALTC = LTC.MALTC
    JOIN
        (SELECT MASV, HO, TEN, PHAI, MALOP
         FROM SINHVIEN
        ) SV
        ON SV.MASV = DK.MASV
    ORDER BY SV.TEN, SV.HO;
END

GO


