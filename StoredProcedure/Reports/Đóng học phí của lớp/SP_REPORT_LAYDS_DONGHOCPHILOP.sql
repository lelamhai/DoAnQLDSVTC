USE [QLDSV_TC]
GO


CREATE   PROCEDURE SP_REPORT_LAYDS_DONGHOCPHILOP
      @MALOP    NVARCHAR(20),
      @NIENKHOA NVARCHAR(20),
      @HOCKY    INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE 
        @MALOP_TRIM    NVARCHAR(20) = LTRIM(RTRIM(@MALOP)),
        @NIENKHOA_TRIM NVARCHAR(20) = LTRIM(RTRIM(@NIENKHOA));

    IF (ISNULL(@MALOP_TRIM, N'') = N'')
    BEGIN
        RAISERROR(N'Mã lớp không được để trống.', 16, 1);
        RETURN;
    END;

    IF (ISNULL(@NIENKHOA_TRIM, N'') = N'')
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
        ROW_NUMBER() OVER (ORDER BY SV.TEN, SV.HO, SV.MASV) AS STT,
        HOTEN =
            LTRIM(RTRIM(ISNULL(SV.HO, N''))) + N' ' +
            LTRIM(RTRIM(ISNULL(SV.TEN, N''))),
        HOCPHI       = ISNULL(HP.HOCPHI, 0),
        SOTIENDADONG = ISNULL(DD.SOTIENDADONG, 0)
    FROM
        (SELECT MASV, HO, TEN
         FROM dbo.SINHVIEN
         WHERE MALOP = @MALOP_TRIM
        ) SV
    LEFT JOIN
        (SELECT MASV, HOCPHI
         FROM dbo.HOCPHI
         WHERE NIENKHOA = @NIENKHOA_TRIM
           AND HOCKY    = @HOCKY
        ) HP
        ON HP.MASV = SV.MASV
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
        ON DD.MASV = SV.MASV
    ORDER BY
        SV.TEN, SV.HO, SV.MASV;
END

GO


