USE NewsfeedDB;
INSERT dbo.Users(Email, Username, Password, AvatarFilename)
VALUES ('admin@gmail.com', 'Admin', 'admin123','avatarPlaceholder.png'),
       ('test-email2@gmail.com', 'Test User 2', 'default_password','avatarPlaceholder.png'),
	   ('test-email3@gmail.com', 'Test User 3', 'default_password','avatarPlaceholder.png'),
	   ('test-email4@gmail.com', 'Test User 4', 'default_password','avatarPlaceholder.png'),
	   ('test-email5@gmail.com', 'Test User 5', 'default_password','avatarPlaceholder.png')
GO

INSERT dbo.Friendships(Friend1Id, Friend2Id)
VALUES (1, 2),
	   (1, 3),
	   (1, 4),
	   (1, 5),
	   (2, 3),
	   (2, 4),
	   (3, 5)
GO

INSERT dbo.Digests(CreatorId, Name, IsPublic)
VALUES (1, 'Digest #1', 1),
	   (2, 'Digest #2', 1),
	   (3, 'Digest #3', 1),
	   (4, 'Digest #4', 1),
	   (5, 'Digest #5', 1),
	   (1, 'Digest #6', 1),
	   (2, 'Digest #7', 1)
GO

INSERT dbo.Subscriptions(UserId, DigestId)
VALUES (1, 1),
	   (2, 2),
	   (3, 3),
	   (4, 4),
	   (5, 5),
	   (1, 2),
	   (1, 3),
	   (2, 3),
	   (3, 5)
GO

INSERT dbo.Sources(Name, Service, Url)
VALUES ('VK Source #1', 'VK', 'vkurl1'),
	   ('VK Source #2', 'VK', 'vkurl2'),
	   ('VK Source #3', 'VK', 'vkurl3'),
	   ('Twitter Source #1', 'Twitter', 'twitterurl1'),
	   ('Twitter Source #2', 'Twitter', 'twitterurl2')
GO

INSERT dbo.DigestSources(DigestId, SourceId)
VALUES (1, 1),
       (1, 2),
	   (1, 3),
	   (2, 1),
	   (2, 4),
	   (3, 5),
	   (4, 2),
	   (5, 2),
	   (6 ,1),
	   (7, 5)
GO

INSERT dbo.Posts([Content], SourceID, TimePosted)
VALUES ('Some content', 1, '2018-02-02 12:36:29. 1234567 +12:15'),
       ('Some content', 2, '2018-02-02 13:31:29. 1234567 +12:15'),
	   ('Some content', 3, '2018-02-02 14:35:29. 1234567 +12:15'),
	   ('Some content', 4, '2018-02-02 15:32:29. 1234567 +12:15'),
	   ('Some content', 5, '2018-02-02 13:35:29. 1234567 +12:15'),
	   ('Some content', 5, '2018-02-02 12:36:29. 1234567 +12:15'),
	   ('Some content', 4, '2018-02-02 11:35:29. 1234567 +12:15'),
	   ('Some content', 3, '2018-02-02 14:35:29. 1234567 +12:15'),
	   ('Some content', 2, '2018-02-02 15:33:29. 1234567 +12:15'),
	   ('Some content', 1, '2018-02-02 12:35:29. 1234567 +12:15')
GO

