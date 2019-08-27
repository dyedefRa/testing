Select * from Product Where Code='WAQ20461TR'

--Update Product Set Price='1455.00',CampaignNote='Peşin fiyata taksit felan'

-- WAQ20461TR
Select * from ProductInstallment Where ProductCode='WAQ20461TR' 

503175	1	7652	1455.00	RDG8025TR	1	2	0.00	0.00	2019-08-02 10:12:19.440	
503176	1	7652	1455.00	RDG8025TR	1	6	219.00	1533.00	2019-08-02 10:12:19.440	Bonus'a özel 12 taksit
503177	1	7652	1455.00	RDG8025TR	1	12	131.00	1703.00	2019-08-02 10:12:19.440	Bonus'a özel 18 taksit
503178	1	7652	1455.00	RDG8025TR	1	18	101.00	1919.00	2019-08-02 10:12:19.440	


30737	1	17488	0.00	WAQ20461TR	1	2	0.00	0.00	2018-11-01 17:09:50.250	
30738	1	17488	0.00	WAQ20461TR	1	5	0.00	0.00	2018-11-01 17:09:50.250	
30739	1	17488	0.00	WAQ20461TR	1	11	0.00	0.00	2018-11-01 17:09:50.250	


-- Update ProductInstallment Set CashPrice=1455.00,InstallmentCount=6,InstallmentMonthlyPrice=219.00,InstallmentTotalPrice=1533.00,CampaignNote='Bonusa özel 12 taksit' where ID=30738
-- Update ProductInstallment Set CashPrice=1455.00,InstallmentCount=12,InstallmentMonthlyPrice=131.00,InstallmentTotalPrice=1703.00,CampaignNote='Bonusa özel 18 taksit' where ID=30739
-- Insert ProductInstallment Values(1,17488,1455.00,'WAQ20461TR',1,18,101.00,1919.00,GETDATE(),'')

277.7953

-- Update Product Set Feature1='ÖZellik 1',Feature2='Özellik 2',Feature3='Özel 3' where ID=17488
