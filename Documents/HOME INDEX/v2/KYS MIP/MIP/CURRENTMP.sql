Select * from [User] Where UserType=3 
Select * from [User] Where UserType=14


Select * from InvestmentCategory Where STatus=1
Select * from Investment Where InvestmentCategoryId=6 AND Status=1

Select  imb.* from InvestmentBrandMap imb INNER JOIN Investment ii ON imb.InvestmentId=ii.Id 
Where   imb.BrandId=67   AND  ii.InvestmentCategoryId=6 AND ii.Status=1

Select *from InvestmentBrandMap imb INNER JOIN Investment ii ON imb.InvestmentId=ii.Id 
Where   imb.BrandId=67   AND  ii.InvestmentCategoryId=7 AND ii.Status=1

Select *from InvestmentBrandMap imb INNER JOIN Investment ii ON imb.InvestmentId=ii.Id 
Where   imb.BrandId=67   AND  ii.InvestmentCategoryId=8 AND ii.Status=1




Select * from Investment Where InvestmentCategoryId in (6,7,8) AND STatus=1


Select * from Investment Where Id in
(
616,
625,
687,
688,
689,
690,
691
)
Select * from Investment Where Id=64

Select InvestmentId,COUNT(*)  from InvestmentBrandMap imb  GROUp by imb.InvestmentId HAVING COUNT(*)<2
Select * from Investment Where Id in

(
453,
454,
455,
456,
457,
458,
459,
460,
461
)

Select * from InvestmentBrandMap Where InvestmentId in 
(
616,
625,
687,
688,
689,
690,
691
)

Select * from Dealer
Select * from Brand
Select * from InvestmentSubSectionMap Where InvestmentId  in
(
453,
454,
455,
456,
457,
458,
459,
460,
461
)

Select * from InvestmentSubSectionMap Where SubSectionId=52

Select * from SubSection Where Id=89