USE [TEFlashCards]
GO
SET IDENTITY_INSERT [dbo].[users] ON 
GO
INSERT [dbo].[users] ([id], [username], [password], [salt], [role]) VALUES (1, N'kbk15@case.edu', N'katherine1313', N'Logged In User', N'katherinekimes')
GO
INSERT [dbo].[users] ([id], [username], [password], [salt], [role]) VALUES (2, N'gen2', N'iyiGkNKALzg/xF709zzA+mB6ZPM=', N'psnUBi0wZBA=', N'User')
GO
INSERT [dbo].[users] ([id], [username], [password], [salt], [role]) VALUES (3, N'gen', N'UbPsWFVE3dxTO9D719tChxOk6k0=', N'hnOedOKlLgs=', N'User')
GO
SET IDENTITY_INSERT [dbo].[users] OFF
GO
SET IDENTITY_INSERT [dbo].[Deck] ON 
GO
INSERT [dbo].[Deck] ([DeckId], [UserId], [DeckName], [DeckDescription]) VALUES (1, 1, N'Module 1', N'These are cards from module 1')
GO
INSERT [dbo].[Deck] ([DeckId], [UserId], [DeckName], [DeckDescription]) VALUES (2, 1, N'Module 2', N'These are cards from module 2')
GO
INSERT [dbo].[Deck] ([DeckId], [UserId], [DeckName], [DeckDescription]) VALUES (3, 2, N'Module 3', N'This is module 3')
GO
INSERT [dbo].[Deck] ([DeckId], [UserId], [DeckName], [DeckDescription]) VALUES (4, 2, N'Module 4', N'This is module 4')
GO
INSERT [dbo].[Deck] ([DeckId], [UserId], [DeckName], [DeckDescription]) VALUES (5, 2, N'Interview Prep', N'behavioral interview questions')
GO
SET IDENTITY_INSERT [dbo].[Deck] OFF
GO
SET IDENTITY_INSERT [dbo].[Card] ON 
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (1, 1, N'What are the 4 principles of OOP?', N'Encapsulation, Inheritance, Polymorphism, Abstraction', N'OOP')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (2, 1, N'What are the 4 components of a method signature?', N'Access Modifier, Return Type, Method Name, Parameter List', N'Methods')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (3, 1, N'What are 3 ways to break a loop?', N'Break, Continue, Return', N'Loops')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (8, 2, N'What are the types of loops?', N'For, foreach, while', N'module 1')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (9, 3, N'In SQL, what does CRUD stand for?', N'Create, Read, Update, Delete', N'module 2')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (10, 3, N'Why do we use aliases in SQL?', N'SQL aliases are used to give a table, or a column in a table, a temporary name.  Aliases are often used to make column names more readable.', N'module 2')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (11, 3, N'What does MVC stand for?', N'Model, View, Controller', N'module 3')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (12, 3, N'In MVC, where does the user interaction happen?', N'View', N'module 3')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (13, 3, N'In MVC, where is the business data stored?', N'Model', N'module 3')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (14, 3, N'In MVC, which part is the "glue" or "mediator"?', N'Controller', N'module 3')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (15, 3, N'What are the variable value types?', N'Int, long, bool, char, float, double, decimal', N'module 1')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (16, 3, N'What are the variable reference types?', N'String', N'module 1')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (17, 3, N'What is the term for a construct that gets evaluated to a single value?', N'Expression', N'module 1')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (18, 3, N'What is the term for a conversion from one data type to another that occurs automatically or by default?', N'Implicit conversion', N'module 1')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (19, 3, N'The data type transformation caused using a cast operator.', N'Explicit conversion', N'module 1')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (20, 3, N'A code block that contains a series of statements.', N'Method', N'module 1')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (21, 3, N'A statement that can be written as: if; if - else; if - else if; if - else if - else', N'Conditional Statement', N'module 1')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (22, 2, N'A key in a relational database that is unique for each record.', N'Primary key', N'module 2')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (24, 2, N'Stores all the data for a specific type of entity (e.g., a Car)', N'Table', N'module 2')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (25, 2, N'Represents a data field (make, model, year) ', N'Column', N'module 2')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (28, 2, N'What does STAR stand for?', N'Situation, Task, Action, Result', N'interview prep')
GO
INSERT [dbo].[Card] ([CardId], [UserId], [FrontText], [BackText], [Tags]) VALUES (29, 2, N'When should you send a thank you after an interview?', N'Within 24 hours', N'interview prep')
GO
SET IDENTITY_INSERT [dbo].[Card] OFF
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (1, 1)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (3, 1)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (8, 1)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (9, 2)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (10, 2)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (11, 3)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (12, 3)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (13, 3)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (14, 3)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (15, 1)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (16, 1)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (17, 1)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (18, 1)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (19, 1)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (20, 1)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (21, 1)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (22, 2)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (24, 2)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (25, 2)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (28, 5)
GO
INSERT [dbo].[card_deck] ([CardId], [DeckId]) VALUES (29, 5)
GO
