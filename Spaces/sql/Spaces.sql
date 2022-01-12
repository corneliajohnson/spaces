USE [master]
GO

IF db_id('Spaces') IS NULL
  CREATE DATABASE [Spaces]
GO

USE [Spaces]
GO

DROP TABLE IF EXISTS Request;
DROP TABLE IF EXISTS Payment;
DROP TABLE IF EXISTS Calendar;
DROP TABLE IF EXISTS Property;
DROP TABLE IF EXISTS Tenant;
DROP TABLE IF EXISTS UserProfile;


CREATE TABLE [UserProfile] (
  [Id] integer not null PRIMARY KEY,
  [Image] nvarchar(255),
  [FirstName] nvarchar(255) not null,
  [LastName] nvarchar(255) not null,
  [Email] nvarchar(255) not null,
  [Phone] nvarchar(255),
  [FirebaseId] nvarchar(50),
  [DateCreated] datetime

  CONSTRAINT UQ_FirebaseId UNIQUE(FirebaseId),
  CONSTRAINT UQ_Email UNIQUE(Email)
);

CREATE TABLE [Tenant] (
  [Id] integer NOT NULL PRIMARY KEY,
  [FirstName] nvarchar(255) NOT NULL,
  [LastName] nvarchar(255) NOT NULL,
  [Note] nvarchar(255),
  [Phone] nvarchar(255),
  [Email] nvarchar(255) NOT NULL,
  [Street] nvarchar(255),
  [City] nvarchar(255),
  [State] nvarchar(255),
  [Zip] integer

  CONSTRAINT UQ_TenantEmail UNIQUE(Email)
);

CREATE TABLE [Property] (
  [Id] integer NOT NULL PRIMARY KEY IDENTITY,
  [UserProfileId] integer NOT NULL,
  [Street] nvarchar(255) NOT NULL,
  [City] nvarchar(255) NOT NULL,
  [State] nvarchar(255) NOT NULL,
  [Zip] integer NOT NULL,
  [MonthlyMortageAmount] decimal,
  [SecurityDeposit] decimal,
  [DateAcquired] datetime,
  [WeekdayPrice] decimal,
  [WeekendPrice] decimal,
  [Image] nvarchar(255),
  [MonthlyTargetProfit] decimal,
  [MonthlyTargetBookings] integer,
  [AverageMontlyProfit] decimal,
  [AverageMontlyMaintenance] decimal,
  [TwelveMonthProfitLoss] decimal,
  [ThirtyDayProfitLoss] decimal,
  [AllTimeProfitLoss] decimal,
  [AllTimeMaintenance] decimal,
  [AllTimeMortageCost] decimal,
  [TwelveMonthProfit] decimal,
  [ThirtyDayProfit] decimal,
  [AllTimeProfit] decimal,
  [TenantId] integer,
  [Notes] nvarchar(255),
  [CheckOutTime] nvarchar(255),
  [CheckInTime] nvarchar(255)

  CONSTRAINT [FK_Property_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id]),
  CONSTRAINT [FK_Property_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [Tenant] ([Id])
);

CREATE TABLE [Request] (
  [Id] integer NOT NULL PRIMARY KEY,
  [PropertyId] integer NOT NULL,
  [Synopsis] nvarchar(255) NOT NULL,
  [Price] decimal,
  [Contractor] nvarchar(255) NOT NULL,
  [IsComplete] bit,
  [Note] nvarchar(255),
  [DateCompleted] datetime,
  [DateAdded] datetime

  CONSTRAINT [FK_Request_Property] FOREIGN KEY ([PropertyId]) REFERENCES [Property] ([Id])
);

CREATE TABLE [Payment] (
  [Id] integer NOT NULL PRIMARY KEY,
  [PropertyId] integer NOT NULL,
  [TenantId] integer NOT NULL,
  [Date] datetime NOT NULL,
  [PaymentAmount] decimal NOT NULL,
  [IsSecurityDeposit] bit NOT NULL

  CONSTRAINT [FK_Payment_Property] FOREIGN KEY ([PropertyId]) REFERENCES [Property] ([Id]),
  CONSTRAINT [FK_Payment_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [Tenant] ([Id])
);

CREATE TABLE [Calendar] (
  [Id] integer NOT NULL PRIMARY KEY,
  [PropertyId] integer NOT NULL,
  [TenantId] integer NOT NULL,
  [PaymentAmount] decimal,
  [IsPaidInFull] bit NOT NULL,
  [IsSecurityDepositPaid] bit NOT NULL,
  [IsSecurityDepositReturned] bit,
  [Date] datetime

  CONSTRAINT [FK_Calendar_Property] FOREIGN KEY ([PropertyId]) REFERENCES [Property] ([Id]),
  CONSTRAINT [FK_Calendar_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [Tenant] ([Id])
);

