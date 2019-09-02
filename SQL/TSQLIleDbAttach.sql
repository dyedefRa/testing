

System.Data.SqlClient.SqlError: The database was backed up on a server running version 14.00.1000. That version is incompatible with this server, which is running version 13.00.4224. Either restore the database on a server that supports the backup, or use a backup that is compatible with this server. (Microsoft.SqlServer.SmoExtended)

USE [master]
RESTORE DATABASE [ARDB] 
FROM DISK = N'C:\ARDB20190529.bak' WITH FILE = 1, 
MOVE N'ARDB' TO N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\ARDB.mdf', 
MOVE N'ARDB_log' TO N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\ARDB_log.ldf', 
NOUNLOAD, STATS = 5
GO



RESTORE HEADERONLY FROM DISK = 'C:\ARDB20190529.bak';
GO