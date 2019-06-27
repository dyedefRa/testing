Select NectarSyncedDate,NectarSyncedStatus from Product Where BrandId=1

sp_helptext pa_Product_List_UnSyncedProducts 

--Bu sp    (p.NectarSyncedStatus = 0 OR p.NectarSyncedStatus IS NULL OR p.NectarSyncedDate < DATEADD(DAY, -3, GETDATE()))  
--yani 3gun oncesine kadar guncellenmemiş olanları getiriyor. (20 tane)

Select top 100 * from Log2015 order By Id desc

Select top 100 * from LogD2C order By Id desc

Select top 100 * from LogApiActivity order By Id desc

Select top 100 * from LogSystemTrace order By Id desc

Select *from Product Where Code='CA051300' AND BrandId=4
select * from Product where Id in (17472,14952,14951,14950,14949,14542)

14949	4	CI283101	NULL	10000.00	0	NULL	NULL	NULL		0	NULL	http://medias.bsh-partner.com/Product_Shots/200x200/MCSA01861483_G9048_CI283101_1284193_cmyk_def.jpg	NULL	NULL	NULL	NULL	NULL	NULL	NULL	NULL	NULL	NULL	NULL	7600	1	NULL	1	2017-05-09 16:13:36.523	2018-10-31 15:38:00.133	NULL		1	2019-06-19 14:36:14.600	NULL	NULL	NULL
14949	4	CI283101	NULL	10000.00	0	NULL	NULL	NULL		0	NULL	http://medias.bsh-partner.com/Product_Shots/200x200/MCSA01861483_G9048_CI283101_1284193_cmyk_def.jpg	NULL	NULL	NULL	NULL	NULL	NULL	NULL	NULL	NULL	NULL	NULL	7600	1	NULL	1	2017-05-09 16:13:36.523	2018-10-31 15:38:00.133	NULL		1	2019-06-27 17:50:49.517	NULL	NULL	NULL
sp_helptext pa_ProductFeature_Single_BulkInsert
Select * from ProductFeature Where BrandId=4

Select * from Product Where YEAR(NectarSyncedDate)=2019 AND MONTH(NectarSyncedDate)=06 AND DAY(NectarSyncedDate)=27 AND Code='DF240160'-- '2019-06-27'

--NECTAR URUN FIYATLARI GUNCELLEMIYOR MU ?