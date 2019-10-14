
-- Amaç    MVM DEKI MAILLERI @ TEN SONRASINI SILIP  mailinator.com EKLEMEK
Update Products set ProductName=SUBSTRING(ProductName,0,CHARINDEX('@',ProductName))+'@mailinator.com'



--Mailinator yap
Update [User] set Email=SUBSTRING(Email,0,CHARINDEX('@',Email))+'@mailinator.com'

--Geri çek
Update [User] set Email=SUBSTRING(Email,0,CHARINDEX('@',Email))+'@BSHG.COM'

