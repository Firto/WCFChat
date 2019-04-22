CREATE TABLE Roles (ID int IDENTITY not null,
					Name nvarchar(30) not null,
					CONSTRAINT RO_PK PRIMARY KEY (ID));

CREATE TABLE Users (ID int IDENTITY not null,
					Login nvarchar(30) not null,
					PasswordHash nvarchar(200) not null,
					DCreate DateTime not null,
					LastActivity DateTime not null,
					Blocked bit not null,
					CONSTRAINT US_PK PRIMARY KEY (ID));

CREATE TABLE Groups (ID int IDENTITY not null,
					Name nvarchar(30) not null,
					Deleted bit not null,
					CONSTRAINT GR_PK PRIMARY KEY (ID));

CREATE TABLE UsersInGroups (UserID int not null,
						   GroupID int not null,
						   RoleID int not null,
						   Muted bit not null,
						   CONSTRAINT UIG_PK PRIMARY KEY (UserID, GroupID),
						   CONSTRAINT UIG_FK_US FOREIGN KEY (UserID) REFERENCES Users(ID),
						   CONSTRAINT UIG_FK_GR FOREIGN KEY (GroupID) REFERENCES Groups(ID),
						   CONSTRAINT UIG_FK_RL FOREIGN KEY (RoleID) REFERENCES Roles(ID));

CREATE TABLE GroupsMessages (ID int IDENTITY not null,
							UserID int not null,
							GroupID int not null,
							MessageSource nvarchar(1000) not null,
							Deleted bit not null,
							CONSTRAINT GM_PK PRIMARY KEY (ID),
							CONSTRAINT GM_FK_US FOREIGN KEY (UserID) REFERENCES Users(ID),
							CONSTRAINT GM_FK_GR FOREIGN KEY (GroupID) REFERENCES Groups(ID));

DROP TABLE GroupsMessages, UsersInGroups, Groups, Users, Roles;