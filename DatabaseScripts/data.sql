SET IDENTITY_INSERT [dbo].[Company] ON
INSERT INTO [dbo].[Company] ([Id], [CompanyName], [Website]) VALUES (1, N'Techno V', N'www.technov.com')
INSERT INTO [dbo].[Company] ([Id], [CompanyName], [Website]) VALUES (2, N'Industry X', N'www.industrx.com')
SET IDENTITY_INSERT [dbo].[Company] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON
INSERT INTO [dbo].[Employee] ([Id], [Name], [CompanyId], [Phone], [SalaryPerAnnum], [TaxCode]) VALUES (1, N'Gareth Miller', 2, N'02144566777', CAST(80000.00 AS Decimal(18, 2)), N'TAX3')
INSERT INTO [dbo].[Employee] ([Id], [Name], [CompanyId], [Phone], [SalaryPerAnnum], [TaxCode]) VALUES (2, N'Frank Wilson', 1, N'0213456789', CAST(60000.00 AS Decimal(18, 2)), N'TAX1')
INSERT INTO [dbo].[Employee] ([Id], [Name], [CompanyId], [Phone], [SalaryPerAnnum], [TaxCode]) VALUES (3, N'Harry James', 1, N'02188883456', CAST(70000.00 AS Decimal(18, 2)), N'TAX2')
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[SalaryPayment] ON
INSERT INTO [dbo].[SalaryPayment] ([Id], [Year], [EmployeeId], [CalculatedTax]) VALUES (2, 2019, 3, CAST(7000.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[SalaryPayment] ([Id], [Year], [EmployeeId], [CalculatedTax]) VALUES (3, 2019, 2, CAST(3000.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[SalaryPayment] ([Id], [Year], [EmployeeId], [CalculatedTax]) VALUES (4, 2019, 1, CAST(12800.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[SalaryPayment] OFF
SET IDENTITY_INSERT [dbo].[TaxTable] ON
INSERT INTO [dbo].[TaxTable] ([Id], [TaxCode], [TaxPercentage]) VALUES (1, N'TAX1', CAST(5.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[TaxTable] ([Id], [TaxCode], [TaxPercentage]) VALUES (2, N'TAX2', CAST(10.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[TaxTable] ([Id], [TaxCode], [TaxPercentage]) VALUES (3, N'TAX3', CAST(16.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[TaxTable] OFF
