
set identity_insert [UserProfile] on
insert into [UserProfile] ([Id], [Image], [FirstName], [LastName], [Email], [Phone], [FirebaseId], [DateCreated])
values (1, 'https://robohash.org/numquamutut.png?size=150x150&set=set1', 'Cornelia', 'Johnson', 'cjohnson@gmail.com', '8503338977', 'jpuhyzaicsokywncxveknzowdsku', '2020-03-15'), (2, 'https://robohash.org/nisiautemet.png?size=150x150&set=set1', 'Maggie', 'Stevens', 'mtest@gmail.com', '2225248811', 'jpuhyzaicsokywncxveknzoddds', '2020-10-01' ), (3, 'https://robohash.org/molestiaemagnamet.png?size=150x150&set=set1', 'Whitney', 'Atkins', 'wtest@gmail.com', '8504444911', 'jpuhyzaicsokywncxveknzoakndew', '2022-03-12');
set identity_insert [UserProfile] off

set identity_insert [Tenant] on
insert into [Tenant] ([Id], [FirstName], [LastName],  [Email], [Phone], [Street], [City], [State], [Zip]) 
values (1, 'Jane', 'Doe', 'jdoe@gmail.com', '2129852345', '222 Main Street', 'Miami', 'FL', '22211'), (2, 'Sue', 'Doe', 'sdoe@gmail.com', '4449852377', '333 Main Street', 'Dallas', 'TX', '88855'), (3, 'Mary', 'Doe', 'mdoe@gmail.com', '2129855555', '202 Forest Street', 'New York', 'NY', '90992'), (4, 'Cindy', 'Doe', 'cdoe@gmail.com', '8889852222', '876 Green Ave', 'Atlanta', 'GA', '44433')
set identity_insert [Tenant] off

set identity_insert [Property] on
insert into [Property] ([Id], [UserProfileId],  [Street], [City], [State], [Zip], [MonthlyMortageAmount], [SecurityDeposit], [DateAcquired], [WeekdayPrice], [WeekendPrice], [Image], [MonthlyTargetProfit], [MonthlyTargetBookings], [AverageMontlyProfit], [AverageMontlyMaintenance], [TwelveMonthProfitLoss], [ThirtyDayProfitLoss], [AllTimeProfitLoss], [AllTimeMaintenance], [AllTimeMortageCost], [TwelveMonthProfit], [ThirtyDayProfit], [AllTimeProfit], [TenantId], [Notes], [CheckOutTime], [CheckInTime]  ) 
values (1, 1, '333 Smith Grove', 'Dallas', 'TX', '22334', 1250.00, 200.00, '2020-03-19', 150.00, 180.00, null, 600.00, 25, 300.00, 150.00, 1225.00, 110.00, 333.00, 90.00, 325.00, 100.00, 50.25, 10.00, 1, 'Test Note', '12:00', '3:00')
set identity_insert [Property] off

set identity_insert [Request] on
insert into [Request] ([Id], [PropertyId], [Synopsis], [Price], [Contractor], [IsComplete], [Note], [DateCompleted], [DateAdded]) 
values (1, 1, 'Cleaning', 70.00, 'Milly Maid', true, null, '2021-12-07', '2021-12-06'), (2, 1, 'Plumbing', 50.00, 'Joes Pluming', true, null, '2022-01-03', '2022-01-03')
set identity_insert [Request] off

set identity_insert [Payment] on
insert into [Payment] ([Id], [PropertyId], [TenantId], [Date], [PaymentAmount], [IsSecurityDeposit]) 
values (1, 1, 1, '2020-12-01', 300.00, false), (2, 1, 2, '2020-12-05', 100.00, true)
set identity_insert [Payment] off

set identity_insert [Calendar] on
insert into [Calendar] ([Id], [PropertyId], [TenantId], [IsPaidInFull], [IsSecurityDepositReturned], [Date]) 
values (1, 1, 1, true, true, '2021-12-04'),(2, 1, 2, true, true, '2021-12-05'), (3, 1, 3, true, false, '2021-12-06')
set identity_insert [Calendar] off