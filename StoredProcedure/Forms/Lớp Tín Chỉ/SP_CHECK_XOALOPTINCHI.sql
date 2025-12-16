USE [QLDSV_TC]
GO

CREATE PROCEDURE SP_CHECK_XOALOPTINCHI
    @MALTC int
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM LOPTINCHI WHERE MALTC = @MALTC)
    BEGIN
        RAISERROR ( N'Lớp tín chỉ không tồn tại.',16, 1);
        RETURN;
    END

    IF EXISTS (
        SELECT 1
        FROM DANGKY DK
        JOIN (
            SELECT MALTC
            FROM LOPTINCHI
            WHERE MALTC = @MALTC
        ) LTC ON DK.MALTC = LTC.MALTC
    )
    BEGIN
        RAISERROR ( N'Không thể xóa lớp tín vì đã có sinh viên đăng ký.',16, 1);
        RETURN;
    END
END
GO
