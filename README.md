# Dapper-Tutorial
Dapper Tutorial CRUD

## Create Database
The first step is to create a database using the following script.

```sql
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Tutorial')
  BEGIN
    CREATE DATABASE Tutorial
  END
```
This script will add a database named Tutorial if it doesn't exist.

## Create Table
Once the database is created, you can now create a table in the database.

```sql
CREATE TABLE [dbo].[Customers] (
    [CustomerID] INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (MAX) NULL,
    [LastName]   NVARCHAR (MAX) NULL,
    [Email]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);
```

from https://dapper-tutorial.net/create-sql-database
