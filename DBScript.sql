USE [master]
GO
/****** Object:  Database [md]    Script Date: 12/17/2015 5:56:29 PM ******/
CREATE DATABASE [md]
 GO
ALTER DATABASE [md] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [md].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [md] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [md] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [md] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [md] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [md] SET ARITHABORT OFF 
GO
ALTER DATABASE [md] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [md] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [md] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [md] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [md] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [md] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [md] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [md] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [md] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [md] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [md] SET  DISABLE_BROKER 
GO
ALTER DATABASE [md] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [md] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [md] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [md] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [md] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [md] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [md] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [md] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [md] SET  MULTI_USER 
GO
ALTER DATABASE [md] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [md] SET DB_CHAINING OFF 
GO
ALTER DATABASE [md] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [md] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'md', N'ON'
GO
USE [md]
GO
/****** Object:  StoredProcedure [dbo].[addLateMessage]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[addLateMessage]
@uid int,
@toID int,
@message nvarchar(256),
@pm bit,
@time datetime
as
begin
insert into MessageFor(msg, msg_for, msg_from, pm, sent, msg_time) values(@message, @toID, @uid, @pm, 0, @time)
select top(1) id from MessageFor order by id desc
end




GO
/****** Object:  StoredProcedure [dbo].[blacklist_add]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[blacklist_add]
@username int,
@reason nvarchar(200)
as
begin
insert into blacklist(uid,reason)values(@username,@reason)
end




GO
/****** Object:  StoredProcedure [dbo].[blacklist_get_reason]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[blacklist_get_reason]
@uid int
as
begin
select reason from blacklist where uid=@uid
end




GO
/****** Object:  StoredProcedure [dbo].[blacklist_remove]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[blacklist_remove]
@username int
as
begin
delete from blacklist where uid=@username
end




GO
/****** Object:  StoredProcedure [dbo].[chat_add]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[chat_add]
@message nvarchar(300),
@username nvarchar(100),
@uid bigint,
@time datetime
as
declare @user nvarchar(100)
declare @response smallint
begin
set @user = (select username from site_user where UID=@uid)
if (@user is null)
begin
 insert into site_user(uid, username, Usertype ) values (@uid, @username, 'user')
 
end
if (@user = '')
begin
update site_user set username=@username where uid=@uid
end
set @response=0
insert into chatlog(message,uid,time) values(@message,@uid,@time)
update site_user set lastactive=@time, lastmessage=@message where UID=@uid
select @response as resp
end




GO
/****** Object:  StoredProcedure [dbo].[get_user_id]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[get_user_id]
@uid bigint
as
begin
select * from site_user where UID=@uid
end




GO
/****** Object:  StoredProcedure [dbo].[get_user_name]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[get_user_name]
@username nvarchar(100)
as
begin
select * from site_user where username like @username
end




GO
/****** Object:  StoredProcedure [dbo].[GetLateMessage]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[GetLateMessage]
@uid int
as
begin
select * from MessageFor where msg_for=@uid and sent=0
end




GO
/****** Object:  StoredProcedure [dbo].[getstatus]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getstatus]
@uid int
as
declare @status int
declare @tmpid int
begin
	set @tmpid=(select uid from blacklist where @uid=uid)
	if (@tmpid is not null)	
		set @status=2	
	else
	begin
		set @tmpid=(select uid from redlist where @uid=uid)
		if (@tmpid is not null)
			set @status=1
		else
			set @status = 0		
	end
	select @status as status
end




GO
/****** Object:  StoredProcedure [dbo].[getTotalUsersBalance]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[getTotalUsersBalance]
as
begin
select sum( balance ) as balance from site_user 
end




GO
/****** Object:  StoredProcedure [dbo].[LOG_add]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LOG_add]
@time datetime,
@username nvarchar(100),
@entry nvarchar(500)
as
begin
insert into log(logentry, time, username) values(@entry,@time,@username)
end




GO
/****** Object:  StoredProcedure [dbo].[MessageSent]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[MessageSent]
@id int

as
begin
update MessageFor set sent=1 where id=@id
end




GO
/****** Object:  StoredProcedure [dbo].[rain_add]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[rain_add]
@amount decimal(18,9),
@time datetime,
@uid int,
@force bit
as
begin
insert into Rains(amount, Time, instigator) values(@amount, @time, @uid)
if (@force=1)
begin
update site_user set balance=balance-@amount where UID=@uid
end
select max(txid) as txid from rains
end




GO
/****** Object:  StoredProcedure [dbo].[rain_user_add]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[rain_user_add]
@txid bigint,
@username int
as
declare @amount decimal(18,9)
begin
insert into rain_user(txID, uid) values(@txid, @username)
set @amount = (select amount from Rains where txid=@txid)
update site_user set rained=rained+@amount, times=times+1 where UID=@username
end




GO
/****** Object:  StoredProcedure [dbo].[rains_getTotal]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[rains_getTotal]

as
begin
SELECT SUM(RAINS.AMOUNT) AS RAINED, COUNT(RAINS.AMOUNT) AS TIMES FROM RAINS
end




GO
/****** Object:  StoredProcedure [dbo].[redlist_add]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[redlist_add]
@username int,
@reason nvarchar(200)
as
begin
insert into redlist(uid,reason)values(@username,@reason)
end




GO
/****** Object:  StoredProcedure [dbo].[redlist_get_reason]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[redlist_get_reason]
@uid int
as
begin
select reason from redlist where uid=@uid
end




GO
/****** Object:  StoredProcedure [dbo].[redlist_remove]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[redlist_remove]
@username int
as
begin
delete from redlist where uid=@username
end




GO
/****** Object:  StoredProcedure [dbo].[ReduceUserBalance]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[ReduceUserBalance]
@uid int,
@amount decimal(18,9)
as
begin
update site_user set balance=balance-@amount where UID=@uid
end




GO
/****** Object:  StoredProcedure [dbo].[TipReceived]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[TipReceived]
@uid int,
@amount decimal(18,9),
@time datetime

as
begin
insert into tip(tip_from_uid, tip_amount, tip_time) values(@uid, @amount, @time)
update site_user set balance=balance+@amount where UID=@uid
end




GO
/****** Object:  StoredProcedure [dbo].[USER_EDIT]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USER_EDIT]
@USERNAME NVARCHAR(100),
@ADDRESS NVARCHAR(34),
@title nvarchar(100),
@note NVARCHAR(300),
@usertype nvarchar(100),
@uid int
as
begin
update site_user set
Address=@ADDRESS,
title=@title,
Note=@note,
Usertype=@usertype,
username=@USERNAME
where uid=@uid
select * from site_user where UID=@uid
end




GO
/****** Object:  StoredProcedure [dbo].[user_getRAINS]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[user_getRAINS]
@USERNAME bigint
as
begin
SELECT SUM(RAINS.AMOUNT) AS RAINED, COUNT(RAINS.AMOUNT) AS TIMES FROM RAINS, RAIN_USER WHERE RAINS.TXID=RAIN_USER.TXID AND RAIN_USER.uid=@USERNAME
end




GO
/****** Object:  Table [dbo].[blacklist]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[blacklist](
	[uid] [int] NOT NULL,
	[reason] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_blacklist] PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[chatlog]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chatlog](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[uid] [int] NOT NULL,
	[time] [datetime] NOT NULL,
	[message] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_chatlog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[log]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[log](
	[log_id] [bigint] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[logentry] [nvarchar](1000) NOT NULL,
	[time] [datetime] NOT NULL,
 CONSTRAINT [PK_log] PRIMARY KEY CLUSTERED 
(
	[log_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MessageFor]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageFor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[msg_for] [int] NOT NULL,
	[msg_from] [int] NOT NULL,
	[msg] [nvarchar](256) NOT NULL,
	[sent] [bit] NOT NULL,
	[pm] [bit] NOT NULL,
	[msg_time] [datetime] NOT NULL,
 CONSTRAINT [PK_MessageFor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rain_user]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rain_user](
	[txID] [bigint] NOT NULL,
	[uid] [int] NOT NULL,
 CONSTRAINT [PK_rain_user] PRIMARY KEY CLUSTERED 
(
	[txID] ASC,
	[uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rains]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rains](
	[txid] [bigint] IDENTITY(1,1) NOT NULL,
	[amount] [decimal](18, 9) NOT NULL,
	[Time] [datetime] NOT NULL,
	[instigator] [int] NULL,
 CONSTRAINT [PK_Rains] PRIMARY KEY CLUSTERED 
(
	[txid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[redlist]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[redlist](
	[uid] [int] NOT NULL,
	[reason] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_redlist] PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[site_user]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[site_user](
	[username] [nvarchar](100) NULL,
	[Title] [nvarchar](100) NULL,
	[Note] [nvarchar](100) NULL,
	[Usertype] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](34) NULL,
	[UID] [int] NOT NULL,
	[lastactive] [datetime] NULL,
	[lastmessage] [nvarchar](256) NULL,
	[rained] [decimal](18, 9) NULL,
	[times] [int] NULL,
	[balance] [decimal](18, 9) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tip]    Script Date: 12/17/2015 5:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tip](
	[tip_id] [int] IDENTITY(1,1) NOT NULL,
	[tip_from_uid] [int] NOT NULL,
	[tip_amount] [decimal](18, 9) NOT NULL,
	[tip_time] [datetime] NOT NULL,
 CONSTRAINT [PK_tip] PRIMARY KEY CLUSTERED 
(
	[tip_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[MessageFor]  WITH CHECK ADD  CONSTRAINT [FK_MessageFor_site_user] FOREIGN KEY([msg_for])
REFERENCES [dbo].[site_user] ([UID])
GO
ALTER TABLE [dbo].[MessageFor] CHECK CONSTRAINT [FK_MessageFor_site_user]
GO
ALTER TABLE [dbo].[MessageFor]  WITH CHECK ADD  CONSTRAINT [FK_MessageFor_site_user1] FOREIGN KEY([msg_from])
REFERENCES [dbo].[site_user] ([UID])
GO
ALTER TABLE [dbo].[MessageFor] CHECK CONSTRAINT [FK_MessageFor_site_user1]
GO
ALTER TABLE [dbo].[Rains]  WITH CHECK ADD  CONSTRAINT [FK_Rains_site_user] FOREIGN KEY([instigator])
REFERENCES [dbo].[site_user] ([UID])
GO
ALTER TABLE [dbo].[Rains] CHECK CONSTRAINT [FK_Rains_site_user]
GO
ALTER TABLE [dbo].[tip]  WITH CHECK ADD  CONSTRAINT [FK_tip_site_user] FOREIGN KEY([tip_from_uid])
REFERENCES [dbo].[site_user] ([UID])
GO
ALTER TABLE [dbo].[tip] CHECK CONSTRAINT [FK_tip_site_user]
GO
USE [master]
GO
ALTER DATABASE [md] SET  READ_WRITE 
GO
