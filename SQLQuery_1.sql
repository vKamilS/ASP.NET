select * from kln.BlogPosts

select * from kln.Users

drop table kln.BlogPost;



create table kln.Users(

    UserId int not null IDENTITY(1,1),

    constraint PK_Users_UserId primary key (UserId),

    [Name] nvarchar(100),

    [Email] nvarchar(100),

    [CakeDay] Date,

);



create table kln.BlogPosts(

    BlogPostId int not null IDENTITY(1,1),

    constraint PK_BlogPost_BlogPostId primary key (BlogPostId),

    [Title] nvarchar(100),

    [Content] nvarchar(2000),

    UserId int not null,

    CONSTRAINT FK_BlogPosts_UserId foreign key (UserId) REFERENCES kln.Users(UserId),

);





insert into kln.Users([Name], Email, CakeDay) values

('Krzysztof','Krzysztof@test.com', GETDATE() ),

('Kasia','Kasia@test2.com', GETDATE() );



insert into kln.BlogPosts(Title, Content, UserId) values

('How to peel a potate', 'An explanation on how to peel a potato', 1);



insert into kln.Users([Name], Email, CakeDay) values

('Marcin','Marcin@test.com', GETDATE() ),

('Alex','Alex@test2.com', GETDATE() ),

('Kevin','Kevin@test2.com', GETDATE() );




insert into kln.BlogPosts(Title, Content, UserId) values

('Dolphin', 'A dolphin is an aquatic mammal within the infraorder Cetacea. Dolphin species belong to the families Delphinidae (the oceanic dolphins), Platanistidae (the Indian river dolphins), Iniidae (the New World river dolphins), Pontoporiidae (the brackish dolphins), and the extinct Lipotidae (baiji or Chinese river dolphin). There are 40 extant species named as dolphins.', 2),
('Ireland', 'Geopolitically, Ireland is divided between the Republic of Ireland (officially named Ireland), which covers five-sixths of the island, and Northern Ireland, which is part of the United Kingdom.', 1005),
('How to draw realistic drawing?', 'n order to draw realistically, the artist must master proportion and pay close attention to every detail. Realistic drawing requires a keen eye and a super steady hand, along with the ability to concentrate and focus entirely on the subject. We’ll begin with the basics and go over 11 key points to help you to master realistic drawing.', 1006),
('How to tie a necktie', 'A comprehensive step by step guide on the different ways to tie a tie. Windsor, 4 in hand, Eldredge, Trinity, bow tie, and other simple knots from Ties.com.', 1007),
('What are best potatoes for roasting and frying?', 'Starchy potatoes such as Russet or Idaho potatoes are ideal for baking, mashing, and frying.Waxy potatoes are best to use in any recipe where you want the potato to keep its shape.', 1),
('Why is making money so hard?', 'They are rooted in psychological and behavioral deficiencies, such as lack of work ethic, lack of faith, lack of discipline, over-spending, excessive risk-taking in investments, greed, pride, and an insatiable desire to impress others.', 2),
('the white shark', 'The most deadly shark is the white shark which since 1900 until 1999 has caused 251 out of the 1860 confirmed unprovoked shark attacks on humans, 66 of which resulted in fatalities - the highest number for any species of shark.', 1005),
('Peacemaker', 'Peacemaker (2022) - Historia superbohatera, który oddany jest idei niesienia pokoju na świecie do tego stopnia, że gotów jest w tym celu zabić każdego.', 1006),
('What program will open a JSON file?', 'Because JSON files are plain text files, you can open them in any text editor, including: Microsoft Notepad (Windows) Apple TextEdit (Mac) Vim (Linux)', 1007),
('What smell kills mosquitoes?', 'Citronella oil is a natural mosquito repellent that will kill mosquitoes and drive them out of your house. Look for citronella candles or use citronella essential oil in your vaporizer or oil diffuser.', 1),
('Abraham Lincoln', 'Abraham Lincoln became the United States’ 16th President in 1861, issuing the Emancipation Proclamation that declared forever free those slaves within the Confederacy in 1863.', 2),
('Who is Riddick?', 'Richard B. Riddick, more commonly known as Riddick, is a fictional character and the antiheroic protagonist of the Chronicles of Riddick series, including the animated short movie Dark Fury and the video games Escape from Butcher Bay and Assault on Dark Athena.', 1005),
('What is .NET is used for?', '.NET is a free, cross-platform, open source developer platform for building many different types of applications. With .NET, you can use multiple languages, editors, and libraries to build for web, mobile, desktop, games, IoT, and more.', 1006),
('How is C# used?', 'What is C# used for? Like other general-purpose programming languages, C# can be used to create a number of different programs and applications: mobile apps, desktop apps, cloud-based services, websites, enterprise software and games. Lots and lots of games.', 1007),
('What is the most important ingredient in pancakes?', 'Flour is the main ingredient to any pancake. It provides the structure. Different types of flours alter the structure because some flours absorb more moisture or create more gluten (which binds the structure together) than others.', 1007);

