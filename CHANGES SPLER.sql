--DEGISIMLER :@q:Q:Q:Q:
-- TABLO    
---Offer   InstallmentId  int  InstallmentRate  decimal(18, 2)
---Order  InstallmentId  int  InstallmentRate  decimal(18, 2)
---InstallmentOffer  Id  Month int   ,Rate  decimal(18, 2)   UpdatedDate datetime ( allow nullable)
spa_Offer_Insert
spa_Offer_Update_ById
spa_Offer_Get_ById
spa_Offer_Delete_ById
spa_Offer_List_ByBrandIdAndDealerCodeAndCustomerId
spa_Offer_Delete_ByBrandIdAndDealerCodeAndCustomerId
spa_Offer_Update_StatusById

sp_helptext  spa_Offer_Update_StatusById


-- =============================================  
-- Author:  Nuevo T4 SP Generator  
-- Description: Updates a record on Offer By Status  
-- =============================================  
CREATE PROCEDURE spa_Offer_Update_StatusById  
 @Id bigint,  
 @Status tinyint  
AS  
BEGIN  
 UPDATE [Offer]  
    SET [Status] = @Status  
 WHERE [Id] = @Id  
END  
----
sp_helptext  spa_Offer_Delete_ByBrandIdAndDealerCodeAndCustomerId

  
-- =============================================  
-- Author:  Nuevo T4 SP Generator  
-- Description: Deletes Offer record _ByBrandIdAndDealerCodeAndCustomerId   
-- =============================================  
CREATE PROCEDURE spa_Offer_Delete_ByBrandIdAndDealerCodeAndCustomerId  
    @BrandId int,  @DealerCode nvarchar(20) = NULL,  @CustomerId int  
AS  
BEGIN  
 DELETE FROM [Offer]  
 WHERE [BrandId]=@BrandId AND ((@DealerCode IS NULL AND DealerCode IS NULL) OR (@DealerCode IS NOT NULL AND DealerCode = @DealerCode)) AND [CustomerId]=@CustomerId  
END  
---
sp_helptext  spa_Offer_List_ByBrandIdAndDealerCodeAndCustomerId

  
-- =============================================  
-- Author:  Nuevo T4 SP Generator  
-- Description: Gets records from Offer _ByBrandIdAndDealerCodeAndCustomerId   
-- =============================================  
CREATE PROCEDURE spa_Offer_List_ByBrandIdAndDealerCodeAndCustomerId  
    @BrandId int,  @DealerCode nvarchar(20) = NULL,  @CustomerId int  
AS  
BEGIN  
 SELECT * FROM [Offer] (NOLOCK)  
 WHERE [BrandId]=@BrandId AND ((@DealerCode IS NULL AND DealerCode IS NULL) OR (@DealerCode IS NOT NULL AND DealerCode = @DealerCode)) AND [CustomerId]=@CustomerId  
END  
-----
sp_helptext  spa_Offer_Delete_ById

  
-- =============================================  
-- Author:  Nuevo T4 SP Generator  
-- Description: Deletes Offer record _ById   
-- =============================================  
CREATE PROCEDURE spa_Offer_Delete_ById  
    @Id bigint  
AS  
BEGIN  
 DELETE FROM [Offer]  
 WHERE [Id]=@Id  
END  
-------------
sp_helptext  spa_Offer_Get_ById

  
-- =============================================  
-- Author:  Nuevo T4 SP Generator  
-- Description: Get a record from Offer _ById   
-- =============================================  
CREATE PROCEDURE spa_Offer_Get_ById  
    @Id bigint  
AS  
BEGIN  
 SELECT TOP 1 * FROM [Offer] (NOLOCK)  
 WHERE [Id]=@Id  
END  
-------------
sp_helptext spa_Offer_Update_ById

  
-- =============================================  
-- Author:  Nuevo T4 SP Generator  
-- Description: Updates a record on Offer _ById   
-- =============================================  
CREATE PROCEDURE spa_Offer_Update_ById  
    @Id bigint,  @BrandId int,  @DealerCode nvarchar(20) = NULL,  @CustomerId int,  @OfferCode nvarchar(50),  @OfferStatus tinyint,  @CreatedDate datetime,  @CreatedBy int = NULL,  @ValidityDate datetime,  @ArchitectFullName nvarchar(50) = NULL,  @Archite
ctEmail nvarchar(50) = NULL,  @ArchitectPhoneNumber nvarchar(30) = NULL,  @ArchitectGSMNumber nvarchar(30) = NULL,  @Exploration bit,  @ExplorationAddress nvarchar(250) = NULL,  @ExplorationCityId int = NULL,  @ExplorationTownId int = NULL,  @ExplorationD
istrictId int = NULL,  @ContactFullname nvarchar(50) = NULL,  @ContactPhoneNumber nvarchar(30) = NULL,  @ContactGSMNumber nvarchar(30) = NULL,  @IsOrder bit,  @Status tinyint,  @ParentId bigint = NULL,  @OfferVersion tinyint,  @IsLatestVersion bit,  @IsPr
ojectOffer bit,  @Annotate nvarchar(500) = NULL,  @IsCurrent bit,  @OfferName nvarchar(200) = NULL,  @CompanyName nvarchar(200) = NULL,  @PaymentType int = NULL,  @PaymentDay nvarchar(10) = NULL,  @InstallmentId int = NULL,  @InstallmentRate decimal(18,2)
 = NULL  
AS  
BEGIN  
 UPDATE [Offer]  
    SET [BrandId]=@BrandId,[DealerCode]=@DealerCode,[CustomerId]=@CustomerId,[OfferCode]=@OfferCode,[OfferStatus]=@OfferStatus,[CreatedDate]=@CreatedDate,[CreatedBy]=@CreatedBy,[ValidityDate]=@ValidityDate,[ArchitectFullName]=@ArchitectFullName,[Architect
Email]=@ArchitectEmail,[ArchitectPhoneNumber]=@ArchitectPhoneNumber,[ArchitectGSMNumber]=@ArchitectGSMNumber,[Exploration]=@Exploration,[ExplorationAddress]=@ExplorationAddress,[ExplorationCityId]=@ExplorationCityId,[ExplorationTownId]=@ExplorationTownId,
[ExplorationDistrictId]=@ExplorationDistrictId,[ContactFullname]=@ContactFullname,[ContactPhoneNumber]=@ContactPhoneNumber,[ContactGSMNumber]=@ContactGSMNumber,[IsOrder]=@IsOrder,[Status]=@Status,[ParentId]=@ParentId,[OfferVersion]=@OfferVersion,[IsLatest
Version]=@IsLatestVersion,[IsProjectOffer]=@IsProjectOffer,[Annotate]=@Annotate,[IsCurrent]=@IsCurrent,[OfferName]=@OfferName,[CompanyName]=@CompanyName,[PaymentType]=@PaymentType,[PaymentDay]=@PaymentDay,[InstallmentId]=@InstallmentId,[InstallmentRate]=@
InstallmentRate  
 WHERE [Id]=@Id  
END  
---

sp_helptext  spa_Offer_Insert

  
-- =============================================  
-- Author:  Nuevo T4 SP Generator  
-- Description: Inserts a record into Offer  
-- =============================================  
CREATE PROCEDURE spa_Offer_Insert  
    @BrandId int,  @DealerCode nvarchar(20) = NULL,  @CustomerId int,  @OfferCode nvarchar(50),  @OfferStatus tinyint,  @CreatedDate datetime,  @CreatedBy int = NULL,  @ValidityDate datetime,  @ArchitectFullName nvarchar(50) = NULL,  @ArchitectEmail nvarc
har(50) = NULL,  @ArchitectPhoneNumber nvarchar(30) = NULL,  @ArchitectGSMNumber nvarchar(30) = NULL,  @Exploration bit,  @ExplorationAddress nvarchar(250) = NULL,  @ExplorationCityId int = NULL,  @ExplorationTownId int = NULL,  @ExplorationDistrictId int
 = NULL,  @ContactFullname nvarchar(50) = NULL,  @ContactPhoneNumber nvarchar(30) = NULL,  @ContactGSMNumber nvarchar(30) = NULL,  @IsOrder bit,  @Status tinyint,  @ParentId bigint = NULL,  @OfferVersion tinyint,  @IsLatestVersion bit,  @IsProjectOffer bi
t,  @Annotate nvarchar(500) = NULL,  @IsCurrent bit,  @OfferName nvarchar(200) = NULL,  @CompanyName nvarchar(200) = NULL,  @PaymentType int = NULL,  @PaymentDay nvarchar(10) = NULL,  @InstallmentId int = NULL,  @InstallmentRate decimal(18,2) = NULL  
AS  
BEGIN  
 INSERT INTO [Offer]([BrandId],[DealerCode],[CustomerId],[OfferCode],[OfferStatus],[CreatedDate],[CreatedBy],[ValidityDate],[ArchitectFullName],[ArchitectEmail],[ArchitectPhoneNumber],[ArchitectGSMNumber],[Exploration],[ExplorationAddress],[ExplorationCit
yId],[ExplorationTownId],[ExplorationDistrictId],[ContactFullname],[ContactPhoneNumber],[ContactGSMNumber],[IsOrder],[Status],[ParentId],[OfferVersion],[IsLatestVersion],[IsProjectOffer],[Annotate],[IsCurrent],[OfferName],[CompanyName],[PaymentType],[Paym
entDay],[InstallmentId],[InstallmentRate])  
    VALUES (@BrandId,@DealerCode,@CustomerId,@OfferCode,@OfferStatus,@CreatedDate,@CreatedBy,@ValidityDate,@ArchitectFullName,@ArchitectEmail,@ArchitectPhoneNumber,@ArchitectGSMNumber,@Exploration,@ExplorationAddress,@ExplorationCityId,@ExplorationTownId,
@ExplorationDistrictId,@ContactFullname,@ContactPhoneNumber,@ContactGSMNumber,@IsOrder,@Status,@ParentId,@OfferVersion,@IsLatestVersion,@IsProjectOffer,@Annotate,@IsCurrent,@OfferName,@CompanyName,@PaymentType,@PaymentDay,@InstallmentId,@InstallmentRate) 
   
    SELECT @@IDENTITY  
END       