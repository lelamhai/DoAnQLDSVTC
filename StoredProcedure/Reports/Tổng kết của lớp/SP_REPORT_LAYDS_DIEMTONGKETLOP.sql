USE [QLDSV_TC]
GO


CREATE PROCEDURE SP_REPORT_LAYDS_DIEMTONGKETLOP
    @MALOP NCHAR(10)
AS
BEGIN
    DECLARE @MALOP_TRIM NVARCHAR(20) = LTRIM(RTRIM(@MALOP));

    IF (ISNULL(@MALOP_TRIM, N'') = N'')
    BEGIN
        RAISERROR(N'Mã lớp không được để trống.', 16, 1);
        RETURN;
    END;

    IF NOT EXISTS (SELECT 1 FROM dbo.LOP WHERE MALOP = @MALOP_TRIM)
    BEGIN
        RAISERROR(N'Mã lớp "%s" không tồn tại.', 16, 1, @MALOP_TRIM);
        RETURN;
    END;

    SELECT 
        ROW_NUMBER() OVER (ORDER BY T.MASV, T.NIENKHOA, T.HOCKY, T.TENMH) AS STT,
        T.MASV,
        T.HOTEN,
        T.TENMH,
        T.DIEM_TK
    FROM (
        SELECT 
            SV.MASV,
            HOTEN = LTRIM(RTRIM(ISNULL(SV.HO, N''))) + N' ' + LTRIM(RTRIM(ISNULL(SV.TEN, N''))),
            SV.NGAYSINH,
            PHAI = CASE WHEN SV.PHAI = 1 THEN N'Nam' ELSE N'Nữ' END,
            SV.MALOP,
            TENLOP = L.TENLOP,
            L.KHOAHOC,
            L.MAKHOA,
            LTC.MALTC,
            LTC.NIENKHOA,
            LTC.HOCKY,
            LTC.MAMH,
            TENMH = MH.TENMH,
            LTC.NHOM,
            DK.DIEM_CC,
            DK.DIEM_GK,
            DK.DIEM_CK,
            DIEM_TK =
            CASE
                WHEN DK.DIEM_CC IS NULL OR DK.DIEM_GK IS NULL OR DK.DIEM_CK IS NULL
                    THEN CAST(-1 AS DECIMAL(5,2))
                ELSE CAST(ROUND(
                        DK.DIEM_CC * 0.10
                      + DK.DIEM_GK * 0.30
                      + DK.DIEM_CK * 0.60
                    , 2) AS DECIMAL(5,2))
            END,
            RANK_DIEM = ROW_NUMBER() OVER (
                PARTITION BY SV.MASV, LTC.MAMH 
                ORDER BY (DK.DIEM_CC * 0.10 + DK.DIEM_GK * 0.30 + DK.DIEM_CK * 0.60) DESC
            )
        FROM dbo.SINHVIEN SV
        INNER JOIN dbo.LOP L ON L.MALOP = SV.MALOP
        INNER JOIN dbo.DANGKY DK ON DK.MASV = SV.MASV
        INNER JOIN dbo.LOPTINCHI LTC ON LTC.MALTC = DK.MALTC
        INNER JOIN dbo.MONHOC MH ON MH.MAMH = LTC.MAMH
        WHERE SV.MALOP = @MALOP_TRIM 
          AND ISNULL(DK.HUYDANGKY, 0) = 0
    ) AS T
    WHERE T.RANK_DIEM = 1
    ORDER BY T.MASV, T.NIENKHOA, T.HOCKY, T.TENMH;
END;
GO


