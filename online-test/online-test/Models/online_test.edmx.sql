
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/19/2022 17:33:46
-- Generated from EDMX file: C:\Users\imran\Desktop\E-project\demo\online-test\online-test\Models\online_test.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__assigned___exam___403A8C7D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[assigned_user_exam] DROP CONSTRAINT [FK__assigned___exam___403A8C7D];
GO
IF OBJECT_ID(N'[dbo].[FK__assigned___user___3F466844]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[assigned_user_exam] DROP CONSTRAINT [FK__assigned___user___3F466844];
GO
IF OBJECT_ID(N'[dbo].[FK__Question___Cours__31EC6D26]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Question_bank] DROP CONSTRAINT [FK__Question___Cours__31EC6D26];
GO
IF OBJECT_ID(N'[dbo].[FK__User_Exam__exam___35BCFE0A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Exam_Answer] DROP CONSTRAINT [FK__User_Exam__exam___35BCFE0A];
GO
IF OBJECT_ID(N'[dbo].[FK__User_Exam__Quest__36B12243]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Exam_Answer] DROP CONSTRAINT [FK__User_Exam__Quest__36B12243];
GO
IF OBJECT_ID(N'[dbo].[FK__User_Exam__user___34C8D9D1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Exam_Answer] DROP CONSTRAINT [FK__User_Exam__user___34C8D9D1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[assigned_user_exam]', 'U') IS NOT NULL
    DROP TABLE [dbo].[assigned_user_exam];
GO
IF OBJECT_ID(N'[dbo].[Canditate_info]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Canditate_info];
GO
IF OBJECT_ID(N'[dbo].[Course_tbl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Course_tbl];
GO
IF OBJECT_ID(N'[dbo].[Exam_Schedule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Exam_Schedule];
GO
IF OBJECT_ID(N'[dbo].[Manager_info]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Manager_info];
GO
IF OBJECT_ID(N'[dbo].[Question_bank]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question_bank];
GO
IF OBJECT_ID(N'[dbo].[User_Exam_Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_Exam_Answer];
GO
IF OBJECT_ID(N'[dbo].[work_dtl_tbl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[work_dtl_tbl];
GO
IF OBJECT_ID(N'[Database1ModelStoreContainer].[edu_dtl_tbl]', 'U') IS NOT NULL
    DROP TABLE [Database1ModelStoreContainer].[edu_dtl_tbl];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'assigned_user_exam'
CREATE TABLE [dbo].[assigned_user_exam] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [user_id] int  NULL,
    [exam_id] int  NULL
);
GO

-- Creating table 'Canditate_info'
CREATE TABLE [dbo].[Canditate_info] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [Cell_no] varchar(50)  NOT NULL,
    [DOB] datetime  NOT NULL,
    [Gender] varchar(50)  NOT NULL,
    [Password] varchar(50)  NOT NULL,
    [CNIC] varchar(50)  NOT NULL,
    [edu_dtl] int  NOT NULL,
    [work_exp] int  NOT NULL
);
GO

-- Creating table 'Course_tbl'
CREATE TABLE [dbo].[Course_tbl] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(50)  NOT NULL,
    [Credit_hr] varchar(20)  NOT NULL,
    [Course_id] int  NOT NULL
);
GO

-- Creating table 'Edu_tbl'



-- Creating table 'Exam_Schedule'
CREATE TABLE [dbo].[Exam_Schedule] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Exam_date] datetime  NOT NULL,
    [Exam_title] varchar(50)  NOT NULL,
    [Exam_duration] int  NOT NULL,
    [Exam_total_question] int  NOT NULL,
    [Exam_status] varchar(50)  NOT NULL,
    [Course_id] int  NOT NULL
);
GO

-- Creating table 'Manager_info'
CREATE TABLE [dbo].[Manager_info] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [Pasword] varchar(50)  NOT NULL,
    [Cell_no] varchar(50)  NOT NULL,
    [Gender] varchar(50)  NOT NULL
);
GO

-- Creating table 'Question_bank'
CREATE TABLE [dbo].[Question_bank] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Question] varchar(250)  NOT NULL,
    [Answer] varchar(50)  NOT NULL,
    [Option_1] varchar(50)  NOT NULL,
    [Option_2] varchar(50)  NOT NULL,
    [Option_3] varchar(50)  NOT NULL,
    [C_Option_4] varchar(50)  NOT NULL,
    [Course_id] int  NOT NULL
);
GO

-- Creating table 'User_Exam_Answer'
CREATE TABLE [dbo].[User_Exam_Answer] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [user_id] int  NULL,
    [exam_id] int  NULL,
    [Answer] varchar(50)  NULL,
    [Question_id] int  NULL,
    [Marks] int  NULL
);
GO

-- Creating table 'work_dtl_tbl'
CREATE TABLE [dbo].[work_dtl_tbl] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [work_id] int  NOT NULL,
    [Company_name] varchar(50)  NOT NULL,
    [Job_title] varchar(50)  NOT NULL,
    [Start_year] varchar(50)  NOT NULL,
    [End_year] varchar(50)  NOT NULL,
    [Job_description] varchar(50)  NOT NULL
);
GO




-- Creating table 'edu_dtl_tbl'
CREATE TABLE [dbo].[edu_dtl_tbl] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [edu_id] int  NOT NULL,
    [Passing_year] varchar(50)  NOT NULL,
    [Grade] varchar(50)  NOT NULL,
    [Percentage] varchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'assigned_user_exam'
ALTER TABLE [dbo].[assigned_user_exam]
ADD CONSTRAINT [PK_assigned_user_exam]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Canditate_info'
ALTER TABLE [dbo].[Canditate_info]
ADD CONSTRAINT [PK_Canditate_info]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Course_tbl'
ALTER TABLE [dbo].[Course_tbl]
ADD CONSTRAINT [PK_Course_tbl]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Edu_tbl'
ALTER TABLE [dbo].[Edu_tbl]
ADD CONSTRAINT [PK_Edu_tbl]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Exam_Schedule'
ALTER TABLE [dbo].[Exam_Schedule]
ADD CONSTRAINT [PK_Exam_Schedule]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Manager_info'
ALTER TABLE [dbo].[Manager_info]
ADD CONSTRAINT [PK_Manager_info]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Question_bank'
ALTER TABLE [dbo].[Question_bank]
ADD CONSTRAINT [PK_Question_bank]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User_Exam_Answer'
ALTER TABLE [dbo].[User_Exam_Answer]
ADD CONSTRAINT [PK_User_Exam_Answer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'work_dtl_tbl'
ALTER TABLE [dbo].[work_dtl_tbl]
ADD CONSTRAINT [PK_work_dtl_tbl]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'work_tbl'
ALTER TABLE [dbo].[work_tbl]
ADD CONSTRAINT [PK_work_tbl]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [edu_id], [Passing_year], [Grade], [Percentage] in table 'edu_dtl_tbl'
ALTER TABLE [dbo].[edu_dtl_tbl]
ADD CONSTRAINT [PK_edu_dtl_tbl]
    PRIMARY KEY CLUSTERED ([Id], [edu_id], [Passing_year], [Grade], [Percentage] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [exam_id] in table 'assigned_user_exam'
ALTER TABLE [dbo].[assigned_user_exam]
ADD CONSTRAINT [FK__assigned___exam___403A8C7D]
    FOREIGN KEY ([exam_id])
    REFERENCES [dbo].[Exam_Schedule]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__assigned___exam___403A8C7D'
CREATE INDEX [IX_FK__assigned___exam___403A8C7D]
ON [dbo].[assigned_user_exam]
    ([exam_id]);
GO

-- Creating foreign key on [user_id] in table 'assigned_user_exam'
ALTER TABLE [dbo].[assigned_user_exam]
ADD CONSTRAINT [FK__assigned___user___3F466844]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Canditate_info]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__assigned___user___3F466844'
CREATE INDEX [IX_FK__assigned___user___3F466844]
ON [dbo].[assigned_user_exam]
    ([user_id]);
GO

-- Creating foreign key on [edu_dtl] in table 'Canditate_info'
ALTER TABLE [dbo].[Canditate_info]
ADD CONSTRAINT [FK__Canditate__edu_d__3E52440B]
    FOREIGN KEY ([edu_dtl])
    REFERENCES [dbo].[Edu_tbl]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Canditate__edu_d__3E52440B'
CREATE INDEX [IX_FK__Canditate__edu_d__3E52440B]
ON [dbo].[Canditate_info]
    ([edu_dtl]);
GO

-- Creating foreign key on [work_exp] in table 'Canditate_info'
ALTER TABLE [dbo].[Canditate_info]
ADD CONSTRAINT [FK__Canditate__work___3D5E1FD2]
    FOREIGN KEY ([work_exp])
    REFERENCES [dbo].[work_tbl]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Canditate__work___3D5E1FD2'
CREATE INDEX [IX_FK__Canditate__work___3D5E1FD2]
ON [dbo].[Canditate_info]
    ([work_exp]);
GO

-- Creating foreign key on [Candidate_id] in table 'Edu_tbl'
ALTER TABLE [dbo].[Edu_tbl]
ADD CONSTRAINT [FK__Edu_tbl__Candida__2B3F6F97]
    FOREIGN KEY ([Candidate_id])
    REFERENCES [dbo].[Canditate_info]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Edu_tbl__Candida__2B3F6F97'
CREATE INDEX [IX_FK__Edu_tbl__Candida__2B3F6F97]
ON [dbo].[Edu_tbl]
    ([Candidate_id]);
GO

-- Creating foreign key on [user_id] in table 'User_Exam_Answer'
ALTER TABLE [dbo].[User_Exam_Answer]
ADD CONSTRAINT [FK__User_Exam__user___34C8D9D1]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Canditate_info]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__User_Exam__user___34C8D9D1'
CREATE INDEX [IX_FK__User_Exam__user___34C8D9D1]
ON [dbo].[User_Exam_Answer]
    ([user_id]);
GO

-- Creating foreign key on [Candidate_id] in table 'work_tbl'
ALTER TABLE [dbo].[work_tbl]
ADD CONSTRAINT [FK__work_tbl__Candid__3B75D760]
    FOREIGN KEY ([Candidate_id])
    REFERENCES [dbo].[Canditate_info]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__work_tbl__Candid__3B75D760'
CREATE INDEX [IX_FK__work_tbl__Candid__3B75D760]
ON [dbo].[work_tbl]
    ([Candidate_id]);
GO

-- Creating foreign key on [Course_id] in table 'Question_bank'
ALTER TABLE [dbo].[Question_bank]
ADD CONSTRAINT [FK__Question___Cours__31EC6D26]
    FOREIGN KEY ([Course_id])
    REFERENCES [dbo].[Course_tbl]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Question___Cours__31EC6D26'
CREATE INDEX [IX_FK__Question___Cours__31EC6D26]
ON [dbo].[Question_bank]
    ([Course_id]);
GO

-- Creating foreign key on [edu_id] in table 'edu_dtl_tbl'
ALTER TABLE [dbo].[edu_dtl_tbl]
ADD CONSTRAINT [FK__edu_dtl_t__edu_i__47DBAE45]
    FOREIGN KEY ([edu_id])
    REFERENCES [dbo].[Edu_tbl]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__edu_dtl_t__edu_i__47DBAE45'
CREATE INDEX [IX_FK__edu_dtl_t__edu_i__47DBAE45]
ON [dbo].[edu_dtl_tbl]
    ([edu_id]);
GO

-- Creating foreign key on [exam_id] in table 'User_Exam_Answer'
ALTER TABLE [dbo].[User_Exam_Answer]
ADD CONSTRAINT [FK__User_Exam__exam___35BCFE0A]
    FOREIGN KEY ([exam_id])
    REFERENCES [dbo].[Exam_Schedule]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__User_Exam__exam___35BCFE0A'
CREATE INDEX [IX_FK__User_Exam__exam___35BCFE0A]
ON [dbo].[User_Exam_Answer]
    ([exam_id]);
GO

-- Creating foreign key on [Question_id] in table 'User_Exam_Answer'
ALTER TABLE [dbo].[User_Exam_Answer]
ADD CONSTRAINT [FK__User_Exam__Quest__36B12243]
    FOREIGN KEY ([Question_id])
    REFERENCES [dbo].[Question_bank]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__User_Exam__Quest__36B12243'
CREATE INDEX [IX_FK__User_Exam__Quest__36B12243]
ON [dbo].[User_Exam_Answer]
    ([Question_id]);
GO

-- Creating foreign key on [work_id] in table 'work_dtl_tbl'
ALTER TABLE [dbo].[work_dtl_tbl]
ADD CONSTRAINT [FK__work_dtl___work___3C69FB99]
    FOREIGN KEY ([work_id])
    REFERENCES [dbo].[work_tbl]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__work_dtl___work___3C69FB99'
CREATE INDEX [IX_FK__work_dtl___work___3C69FB99]
ON [dbo].[work_dtl_tbl]
    ([work_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------