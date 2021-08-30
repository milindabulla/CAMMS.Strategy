-- =============================================
-- PROCEDURE:	UserLoginForAPI
-- DESCRIPTION:	retatails using username and password(s) fro API
-- HISTORY: 
-- 27/08/2021	Milinda Bulumulla	Created
-- ================================================

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UserLoginForAPI')
	BEGIN
		DROP  Procedure  dbo.UserLoginForAPI
	END
GO

CREATE PROC dbo.UserLoginForAPI
(
	@UserName		AS VARCHAR(100),
	@Sha1Password		AS binary(20),
	@Md5Password	AS uniqueidentifier
)	
AS
BEGIN

declare @USERID uniqueidentifier;
--
SELECT @USERID = USERID FROM [USER]
WHERE [USERNAME] = @USERNAME AND [ACTIVE]='true' AND	
	  (
		  (
			SHA1PASSWORD = @Sha1Password
		  )
		  OR
		  (
			MD5PASSWORD = @Md5Password AND
			SHA1PASSWORD IS NULL
		  )
	  )	
IF @@ROWCOUNT = 0
BEGIN
	
	RAISERROR 
			(
				N'Login unsuccessful. Please try again.',
				16,
				1
			)
	goto PROCEDURE_END;
end 
DECLARE @SYSTEMPERIODID	AS uniqueidentifier

SET @SYSTEMPERIODID = (SELECT 
							TOP(1) SYSTEMPERIODID
						FROM 
							dbo.SYSTEMPERIOD
						WHERE 
							CURRENTPERIOD = 'TRUE')

update 
	[USER] 
set 
	SHA1PASSWORD = @SHA1PASSWORD, 
	MD5PASSWORD = null
where 
	USERID = @USERID
	and SHA1PASSWORD is null;
	
--UPDATE [USER]
--SET TOTALLOGINS=ISNULL(TOTALLOGINS,0) + 1 ,
--	CURRENTSYSTEMPERIODID = ISNULL(CURRENTSYSTEMPERIODID,@SYSTEMPERIODID)
--WHERE USERID=@USERID;
	
select * FROM [USER] WHERE UserId = @userid
	
PROCEDURE_END:
	
END

Go
