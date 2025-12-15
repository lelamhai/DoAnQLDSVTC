USE [QLDSV_TC]
GO

CREATE   PROC [dbo].[SP_CHECK_CAPNHATLOP]
@TENLOP NVARCHAR(50)
AS 
    IF EXISTS (SELECT 1 FROM dbo.LOP WHERE LTRIM(RTRIM(TENLOP)) = LTRIM(RTRIM(@TENLOP)))
    BEGIN
        RAISERROR(N'Tên lớp "%s" đã tồn tại trên chi Khoa hiện tại!', 16, 1, @TENLOP);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM LINK0.QLDSV_TC.dbo.LOP WHERE LTRIM(RTRIM(TENLOP)) = LTRIM(RTRIM(@TENLOP)))
    BEGIN
        RAISERROR(N'Tên lớp "%s" đã tồn tại trên Khoa còn lại!', 16, 1, @TENLOP);
        RETURN;
    END
GO


