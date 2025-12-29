USE [QLDSV_TC]
GO


CREATE   PROCEDURE SP_REPORT_TONGHOCPHI_DONGHOCPHILOP
    @MALOP    NVARCHAR(20),
    @NIENKHOA NVARCHAR(20),
    @HOCKY    INT
AS
BEGIN
   
    DECLARE 
        @MALOP_TRIM    NVARCHAR(20) = LTRIM(RTRIM(@MALOP)),
        @NIENKHOA_TRIM NVARCHAR(20) = LTRIM(RTRIM(@NIENKHOA));

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.LOP
        WHERE MALOP = @MALOP_TRIM
    )
    BEGIN
        RAISERROR(N'Mã lớp "%s" không tồn tại.', 16, 1, @MALOP_TRIM);
        RETURN;
    END;

    IF (@NIENKHOA_TRIM IS NULL OR @NIENKHOA_TRIM = N'')
    BEGIN
        RAISERROR(N'Niên khóa không được để trống.', 16, 1);
        RETURN;
    END;

    IF (@HOCKY IS NULL OR @HOCKY <= 0)
    BEGIN
        RAISERROR(N'Học kỳ không hợp lệ (phải > 0).', 16, 1);
        RETURN;
    END;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.LOP
        WHERE MALOP = @MALOP_TRIM
    )
    BEGIN
        RAISERROR(N'Mã lớp "%s" không tồn tại.', 16, 1, @MALOP_TRIM);
        RETURN;
    END;

   
    SELECT
        TONG_SINHVIEN = COUNT(SV.MASV),
        TONG_DA_DONG  = ISNULL(SUM(DD.SOTIENDADONG), 0)
    FROM
     
        (SELECT MASV
         FROM dbo.SINHVIEN
         WHERE MALOP = @MALOP_TRIM
        ) SV
    LEFT JOIN
       
        (
            SELECT
                  MASV
                , SUM(ISNULL(SOTIENDONG, 0)) AS SOTIENDADONG
            FROM dbo.CT_DONGHOCPHI
            WHERE NIENKHOA = @NIENKHOA_TRIM
              AND HOCKY    = @HOCKY
            GROUP BY MASV
        ) DD
        ON DD.MASV = SV.MASV;
END

GO


