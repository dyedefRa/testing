

--Select MONTH(RecordDate) 'NameObject',SUM(WastageValue) 'y' from WastageReason Where YEAR(RecordDate)={recordDate.Year} AND IsArsive=0 Group by MONTH(RecordDate)


DECLARE @datem  datetime  ='2018-09-04'

Select MONTH(@datem)

Select MONTH(RecordDate) 'NameObject',SUM(WastageValue) 'y' from WastageReason Where YEAR(RecordDate)='2018' AND IsArsive=0 Group by MONTH(RecordDate)

Select SUM(MNG05) from Inventory Where RecordDate='2018-06-05' AND IsArsive=0
Select SUM(HPTOP) from Inventory Where ProductCode='000000000000004001' AND IsArsive=0 AND MONTH(RecordDate)

Select * from Inventory Where RecordDate='2018-06-05' AND IsArsive=0


