/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ID]
      ,[First Name]
      ,[Last Name]
      ,[Age]
      ,[City]
      ,[Wallet]
  FROM [HumaneSociety].[dbo].[AdopterInfo]
  DELETE FROM [HumaneSociety].[dbo].[AdopterInfo]