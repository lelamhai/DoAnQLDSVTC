USE [QLDSV_TC]
GO


CREATE  PROCEDURE SP_REPORT_PHIEUDIEM
    @MASV NCHAR(10)
AS

BEGIN
    DECLARE @MASV_TRIM NVARCHAR(50);
    SET @MASV_TRIM = LTRIM(RTRIM(@MASV));

    IF NOT EXISTS (SELECT 1 FROM SINHVIEN WHERE MASV = @MASV_TRIM)
    BEGIN
        RAISERROR(N'Mã sinh viên "%s" không tồn tại trên Khoa hiện tại!', 16, 1, @MASV_TRIM);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM LINK0.QLDSV_TC.dbo.SINHVIEN WHERE MASV = @MASV_TRIM)
    BEGIN
        RAISERROR(N'Mã sinh viên "%s" không tồn tại trong hệ thống!', 16, 1, @MASV_TRIM);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM SINHVIEN WHERE MASV = @MASV_TRIM AND DANGHIHOC = 0)
    BEGIN
        RAISERROR(N'Mã sinh viên "%s" đã nghỉ học!', 16, 1, @MASV_TRIM);
        RETURN;
    END

    SELECT
        ROW_NUMBER() OVER (ORDER BY TENMH) AS STT,
        mh.TENMH,
        MAX(
            CASE
                WHEN dk.DIEM_CC IS NULL
                 AND dk.DIEM_GK IS NULL
                 AND dk.DIEM_CK IS NULL
                THEN NULL
                ELSE CAST(ROUND(
                         ISNULL(dk.DIEM_CC, 0) * 0.10
                       + ISNULL(dk.DIEM_GK, 0) * 0.30
                       + ISNULL(dk.DIEM_CK, 0) * 0.60
                     , 2) AS DECIMAL(5,2))
            END
        ) AS DIEM
    FROM
        DANGKY dk
    JOIN
        LOPTINCHI ltc
            ON ltc.MALTC = dk.MALTC
    JOIN
        MONHOC mh
            ON mh.MAMH = ltc.MAMH
    WHERE
        dk.MASV = @MASV
        AND (dk.HUYDANGKY = 0 OR dk.HUYDANGKY IS NULL)
        AND (ltc.HUYLOP   = 0 OR ltc.HUYLOP   IS NULL)
    GROUP BY
        mh.TENMH
    ORDER BY
        mh.TENMH;
END;
GO


