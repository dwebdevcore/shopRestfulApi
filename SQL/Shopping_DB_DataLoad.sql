-- Initial Data Load
-- Users
insert into Users(Id,Firstname,Lastname,AddressOne,City,[State],Zip) values('01F5EEDA-B841-4C82-A814-C5C5E1DD6F69','Cleo','Montage','10000 W O''Hare Ave', 'Chicago', 'IL', '60666')
insert into Users(Id,Firstname,Lastname,AddressOne,City,[State],Zip) values('B847B03E-CB9F-4DF6-BA8E-672BC0C18071', 'Jhansi','Doddapaneni','8888 SW 136th St', 'Miami', 'FL', '33176')
insert into Users(Id,Firstname,Lastname,AddressOne,City,[State],Zip) values('052308A8-0E56-434E-9266-EABEE46BD480','Samuel','White','99 Washington St','New York', 'NY', '10006')
insert into Users(Id,Firstname,Lastname,AddressOne,City,[State],Zip) values('D0A9AF02-619A-4390-AA10-84AB0399A4AF','Micheline','Sweeting','4 Clinton St','New York', 'NY', '10002')


-- Products 
insert into Products(Id,[Name],[Description],PurchasePrice,SalePrice,ImageUrl) values('40C11AE1-AE17-4AC6-94EF-A13452112918','iPhone X','5.8‑inch Super Retina screen','729.00','999.00','https://wallpapersite.com/images/wallpapers/iphone-x-2560x1440-hd-11143.png')
insert into Products(Id,[Name],[Description],PurchasePrice,SalePrice,ImageUrl) values('7340C850-F59C-460A-A53B-55B0A6A49020','iPhone 8 Plus','5.5‑inch display','649.00','799.00','https://images.idgesg.net/images/article/2017/10/iphone-x-iphone-8-plus-100737887-large.jpg')
insert into Products(Id,[Name],[Description],PurchasePrice,SalePrice,ImageUrl) values('8E05F838-B0F9-47AC-AA32-7E762BDEC4E2','iPhone 8','4.7‑inch display','599.00','699.00','https://cdn2.macworld.co.uk/cmsdata/reviews/3672880/iphone_8_review_24.jpg')
insert into Products(Id,[Name],[Description],PurchasePrice,SalePrice,ImageUrl) values('EC68F2C4-5810-4018-9151-076F6B39E83A','iPad Pro','10.5‑inch display','549.00','649.00','https://support.apple.com/library/APPLE/APPLECARE_ALLGEOS/SP739/SP739.png')
insert into Products(Id,[Name],[Description],PurchasePrice,SalePrice,ImageUrl) values('52D219D0-E1F4-43BC-85D5-FA6A3C331B7A','iPad','9.7‑inch display','279.00','329.00','https://d15shllkswkct0.cloudfront.net/wp-content/blogs.dir/1/files/2016/03/iPad-Pro-range.png')

-- Orders
insert into Orders(Id,TransactionDate, UserId) Values('C37753BA-B435-4695-A437-4CCF5651DBFB',dateadd(day,-25,getdate()), '01F5EEDA-B841-4C82-A814-C5C5E1DD6F69')
insert into Orders(Id,TransactionDate, UserId) Values('1EEF4607-4993-44DF-AC7E-77521D6D7FE6',dateadd(day,-15,getdate()), 'B847B03E-CB9F-4DF6-BA8E-672BC0C18071')
insert into Orders(Id,TransactionDate, UserId) Values('0A153C0A-2DB8-413E-A432-12660F899861',dateadd(day,-10,getdate()), '052308A8-0E56-434E-9266-EABEE46BD480')
insert into Orders(Id,TransactionDate, UserId) Values('3A36E03A-D98D-463E-A7F2-1B610036FAC7',dateadd(day,-5,getdate()), 'D0A9AF02-619A-4390-AA10-84AB0399A4AF')

-- Order Items
insert into OrderItems(Id,OrderId,ProductId,Qty,PurchasePrice,SalePrice) values(NewId(),'C37753BA-B435-4695-A437-4CCF5651DBFB','40C11AE1-AE17-4AC6-94EF-A13452112918',2,729.00,999.00)
insert into OrderItems(Id,OrderId,ProductId,Qty,PurchasePrice,SalePrice) values(NewId(),'1EEF4607-4993-44DF-AC7E-77521D6D7FE6','7340C850-F59C-460A-A53B-55B0A6A49020',1,649.00,799.00)
insert into OrderItems(Id,OrderId,ProductId,Qty,PurchasePrice,SalePrice) values(NewId(),'1EEF4607-4993-44DF-AC7E-77521D6D7FE6','8E05F838-B0F9-47AC-AA32-7E762BDEC4E2',1,599.00,699.00)
insert into OrderItems(Id,OrderId,ProductId,Qty,PurchasePrice,SalePrice) values(NewId(),'0A153C0A-2DB8-413E-A432-12660F899861','EC68F2C4-5810-4018-9151-076F6B39E83A',5,549.00,649.00)
insert into OrderItems(Id,OrderId,ProductId,Qty,PurchasePrice,SalePrice) values(NewId(),'3A36E03A-D98D-463E-A7F2-1B610036FAC7','8E05F838-B0F9-47AC-AA32-7E762BDEC4E2',10,599.00,699.00)
insert into OrderItems(Id,OrderId,ProductId,Qty,PurchasePrice,SalePrice) values(NewId(),'3A36E03A-D98D-463E-A7F2-1B610036FAC7','52D219D0-E1F4-43BC-85D5-FA6A3C331B7A',20,279.00,329.00)
