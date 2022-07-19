USE[GYM]
GO
/****** Object:  Table [dbo].[admission_form]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[admission_form] (
	[Id][int] IDENTITY(1, 1) NOT NULL,
	[first_name] [varchar] (150) NULL,
	[middle_name][varchar] (150) NULL,
	[last_name][varchar] (150) NULL,
	[cnic][varchar] (20) NULL,
	[is_resident][bit] NULL,
	[address][nvarchar] (max)NULL,
	[email][varchar] (150) NULL,
	[DOB][varchar] (12) NULL,
	[Age][int] NULL,
	[purpose_of_joining][varchar] (max)NULL,
	[Height][decimal] (18, 2) NULL,
	[Weight][decimal] (18, 2) NULL,
	[BMI][decimal] (18, 2) NULL,
	[company_id][int] NULL,
	[created_by][int] NULL,
	[updated_by][int] NULL,
	[created_on][datetime] NULL,
	[updated_on][datetime] NULL,
	[is_active][bit] NULL,
	[is_deleted][bit] NULL,
	[gender][varchar] (12) NULL,
	[contact_number][varchar] (20) NULL,
 CONSTRAINT[PK_admission_form] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[apps]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[apps] (
	[app_sk][int] NOT NULL,
	[app_desc] [varchar] (150) NULL,
	[company_name][nvarchar] (500) NULL,
	[company_key][nvarchar] (150) NULL,
 CONSTRAINT[PK_apps] PRIMARY KEY CLUSTERED 
(
	[app_sk] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[audit_log]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[audit_log] (
	[id][int] IDENTITY(1, 1) NOT NULL,
	[form_post_data] [nvarchar] (max)NULL,
	[form_ref][nvarchar] (50) NULL,
	[record_pk][int] NULL,
	[user_id][int] NULL,
	[created_on][datetime] NULL,
	[action][varchar] (50) NULL,
	[is_email_sent][int] NULL,
	[sent_datetime][datetime] NULL,
	[rec_st_code][varchar] (50) NULL,
 CONSTRAINT[PK_audit_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dept]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dept] (
	[dept_sk][int] IDENTITY(1, 1) NOT NULL,
	[dept_desc] [varchar] (50) NOT NULL,
	[dept_type_sk] [int] NOT NULL,
	[dept_name] [varchar] (150) NULL,
 CONSTRAINT[PK_dept] PRIMARY KEY CLUSTERED 
(
	[dept_sk] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dept_type]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dept_type] (
	[dept_type_sk][int] NOT NULL,
	[dept_type_name] [varchar] (50) NULL
) ON[PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[employee]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[employee] (
	[Id][int] IDENTITY(1, 1) NOT NULL,
	[Name] [varchar] (150) NULL,
	[contact_no][varchar] (21) NULL,
	[date_of_joining][varchar] (12) NULL,
	[job_title][varchar] (150) NULL,
	[email_id][varchar] (500) NULL,
	[from_time][varchar] (5) NULL,
	[to_time][varchar] (5) NULL,
	[reporting_id][int] NULL,
	[address][varchar] (max)NULL,
	[salary][decimal] (18, 2) NULL,
	[guardian_name][varchar] (150) NULL,
	[guardian_no][varchar] (21) NULL,
	[sick_leave][decimal] (18, 2) NULL,
	[annual_leave][decimal] (18, 2) NULL,
	[use_sick_leave][decimal] (18, 2) NULL,
	[use_annual_leave][decimal] (18, 2) NULL,
	[unuse_annual_leave][decimal] (18, 2) NULL,
	[unuse_sick_leave][decimal] (18, 2) NULL,
	[company_id][int] NULL,
	[created_by][int] NULL,
	[updated_by][int] NULL,
	[created_on][datetime] NULL,
	[updated_on][datetime] NULL,
	[is_active][bit] NULL,
	[is_deleted][bit] NULL,
	[is_trainer][bit] NULL,
 CONSTRAINT[PK_employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[login_history]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[login_history] (
	[id][int] IDENTITY(1, 1) NOT NULL,
	[app_sk] [int] NULL,
	[usr_sk][int] NULL,
	[type_sk][int] NULL,
	[usr_ip][varchar] (50) NULL,
	[created_on][datetime] NULL,
 CONSTRAINT[PK_login_history] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mnus]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mnus] (
	[mnu_sk][int] IDENTITY(1, 1) NOT NULL,
	[app_sk] [int] NOT NULL,
	[mnu_desc] [nvarchar] (150) NOT NULL,
	[mnu_url] [nvarchar] (150) NULL,
	[mnu_icon][nvarchar] (50) NOT NULL,
	[parent_mnu_sk] [int] NOT NULL,
	[created_by] [int] NULL,
	[created_on][datetime] NULL,
	[is_active][bit] NOT NULL,
	[Seq_No] [int] NULL,
 CONSTRAINT[PK_mnus] PRIMARY KEY CLUSTERED 
(
	[mnu_sk] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY]

GO
/****** Object:  Table [dbo].[Package]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Package] (
	[Id][int] IDENTITY(1, 1) NOT NULL,
	[package_name] [varchar] (250) NULL,
	[package_fee][decimal] (18, 2) NULL,
	[session_adj][decimal] (18, 2) NULL,
	[expiry_date][varchar] (12) NULL,
	[company_id][int] NULL,
	[created_by][int] NULL,
	[updated_by][int] NULL,
	[created_on][datetime] NULL,
	[updated_on][datetime] NULL,
	[is_active][bit] NULL,
	[is_deleted][bit] NULL,
	[registration_fee][decimal] (18, 2) NULL,
 CONSTRAINT[PK_Package] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[package_assignment]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[package_assignment] (
	[Id][int] IDENTITY(1, 1) NOT NULL,
	[registration_fee_discount] [decimal] (18, 2) NULL,
	[package_fee_discount][decimal] (18, 2) NULL,
	[special_discount][decimal] (18, 2) NULL,
	[joining_date][varchar] (12) NULL,
	[effective_date][varchar] (12) NULL,
	[company_id][int] NULL,
	[created_by][int] NULL,
	[updated_by][int] NULL,
	[created_on][datetime] NULL,
	[updated_on][datetime] NULL,
	[is_active][bit] NULL,
	[is_deleted][bit] NULL,
	[addmission_id][int] NULL,
	[package_id][int] NULL,
 CONSTRAINT[PK_package_assignment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[role_mnus]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role_mnus] (
	[role_mnu_sk][int] IDENTITY(1, 1) NOT NULL,
	[role_sk] [int] NOT NULL,
	[mnu_sk] [int] NOT NULL,
	[can_slct] [bit] NOT NULL,
	[can_insrt] [bit] NOT NULL,
	[can_updt] [bit] NOT NULL,
	[can_del] [bit] NOT NULL,
	[is_active] [bit] NOT NULL,
	[created_on] [datetime] NULL,
	[created_by][int] NULL,
 CONSTRAINT[PK_role_mnus] PRIMARY KEY CLUSTERED 
(
	[role_mnu_sk] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY]

GO
/****** Object:  Table [dbo].[usr_apps]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usr_apps] (
	[usr_apps_sk][int] IDENTITY(1, 1) NOT NULL,
	[usr_sk] [int] NOT NULL,
	[app_sk] [int] NOT NULL,
	[is_active] [bit] NOT NULL,
	[created_on] [datetime] NULL,
	[created_by][int] NULL,
 CONSTRAINT[PK_usr_apps] PRIMARY KEY CLUSTERED 
(
	[usr_apps_sk] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY]

GO
/****** Object:  Table [dbo].[usr_auth_roles]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usr_auth_roles] (
	[usr_role_sk][int] IDENTITY(1, 1) NOT NULL,
	[usr_sk] [int] NOT NULL,
	[role_sk] [int] NOT NULL,
	[is_active] [bit] NOT NULL,
	[created_on] [datetime] NULL,
	[created_by][int] NULL,
 CONSTRAINT[PK_usr_auth_roles] PRIMARY KEY CLUSTERED 
(
	[usr_role_sk] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY]

GO
/****** Object:  Table [dbo].[usr_mnus]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usr_mnus] (
	[usr_mnu_sk][int] IDENTITY(1, 1) NOT NULL,
	[usr_sk] [int] NULL,
	[mnu_sk][int] NULL,
	[can_slct][bit] NULL,
	[can_insrt][bit] NULL,
	[can_updt][bit] NULL,
	[can_del][bit] NULL,
	[is_active][bit] NULL,
	[created_on][datetime] NULL,
	[created_by][int] NULL,
 CONSTRAINT[PK_usr_mnus] PRIMARY KEY CLUSTERED 
(
	[usr_mnu_sk] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY]

GO
/****** Object:  Table [dbo].[usr_role]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usr_role] (
	[role_sk][int] IDENTITY(1, 1) NOT NULL,
	[role_desc] [nvarchar] (150) NOT NULL,
 CONSTRAINT[PK_usr_role] PRIMARY KEY CLUSTERED 
(
	[role_sk] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY]

GO
/****** Object:  Table [dbo].[usrs]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usrs] (
	[usr_sk][int] IDENTITY(1, 1) NOT NULL,
	[usr_nme] [nvarchar] (max)NULL,
	[usr_full_nme][varchar] (150) NOT NULL,
	[dept_sk] [int] NOT NULL,
	[is_active] [bit] NOT NULL,
	[created_on] [datetime] NULL,
	[created_by][int] NULL,
	[branch_code][int] NULL,
	[mgr_id][int] NULL,
	[password][nvarchar] (max)NULL,
 CONSTRAINT[PK_usrs] PRIMARY KEY CLUSTERED 
(
	[usr_sk] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[admission_form] ON

INSERT[dbo].[admission_form] ([Id], [first_name], [middle_name], [last_name], [cnic], [is_resident], [address], [email], [DOB], [Age], [purpose_of_joining], [Height], [Weight], [BMI], [company_id], [created_by], [updated_by], [created_on], [updated_on], [is_active], [is_deleted], [gender], [contact_number]) VALUES(4, N'Syed', N'faiz', N'Ali', N'4220121415833', 1, NULL, N'syedfaizishtiaque@gmail.com', N'07/21/1994', 27, N'Dont Know', CAST(6.00 AS Decimal(18, 2)), CAST(61.00 AS Decimal(18, 2)), CAST(18.24 AS Decimal(18, 2)), 1, 1, 1, CAST(N'2022-07-08 21:18:56.650' AS DateTime), CAST(N'2022-07-09 23:45:21.263' AS DateTime), 1, 0, N'Male', N'03200248812')
INSERT[dbo].[admission_form]([Id], [first_name], [middle_name], [last_name], [cnic], [is_resident], [address], [email], [DOB], [Age], [purpose_of_joining], [Height], [Weight], [BMI], [company_id], [created_by], [updated_by], [created_on], [updated_on], [is_active], [is_deleted], [gender], [contact_number]) VALUES(5, N'Syed', N'Sheraz', N'Ali', N'4220121415833', 1, NULL, N'syedsherazishtiaque@gmail.com', N'11/14/1995', 26, N'Dont Know', CAST(5.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), CAST(2.58 AS Decimal(18, 2)), 1, 1, 1, CAST(N'2022-07-08 21:24:48.327' AS DateTime), CAST(N'2022-07-09 23:47:51.527' AS DateTime), 1, 0, N'Male', NULL)
SET IDENTITY_INSERT[dbo].[admission_form] OFF
INSERT[dbo].[apps] ([app_sk], [app_desc], [company_name], [company_key]) VALUES(1, N'GYM', N'MINI GYM', N'MINI-GYM-001')
SET IDENTITY_INSERT[dbo].[audit_log] ON

INSERT[dbo].[audit_log] ([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(1, N'{"Id":5,"enc_id":null,"first_name":"Syed","middle_name":"faiz 123","last_name":"Ali","gender":"Male","CNIC":"4220121415833","is_resident":true,"address":null,"email":"syedfaizishtiaque@gmail.com","DOB":"07/31/1994","Age":27,"purpose_of_joining":"Dont Know","Height":"5''11''''","Weight":"61 kg","BMI":"SFSLFKSJ;LF","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-08T21:24:48.3269833+05:00","updated_on":"2022-07-08T21:24:48.3280288+05:00","is_active":true,"is_deleted":false}', N'AdmissionForm/Create', 5, 1, CAST(N'2022-07-08 21:24:48.333' AS DateTime), N'Insert', 0, NULL, N'INS')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(2, N'{"Id":5,"enc_id":null,"first_name":"Syed","middle_name":"faiz 123456","last_name":"Ali","gender":"Male","CNIC":"4220121415833","is_resident":true,"address":null,"email":"syedfaizishtiaque@gmail.com","DOB":"07/31/1994","Age":27,"purpose_of_joining":"Dont Know","Height":"5''11''''","Weight":"61 kg","BMI":"SFSLFKSJ;LF","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-08T21:38:42.194135+05:00","updated_on":"2022-07-08T21:38:42.1951319+05:00","is_active":true,"is_deleted":false}', N'AdmissionForm/Update', 5, 1, CAST(N'2022-07-08 21:38:42.333' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(3, N'{"Id":5,"enc_id":null,"first_name":"Syed","middle_name":"Sheraz","last_name":"Ali","gender":"Male","CNIC":"4220121415833","is_resident":true,"address":null,"email":"syedsherazishtiaque@gmail.com","DOB":"11/14/1995","Age":26,"purpose_of_joining":"Dont Know","Height":"5''11''''","Weight":"55 kg","BMI":"BMI","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-08T21:40:03.0259033+05:00","updated_on":"2022-07-08T21:40:03.0269035+05:00","is_active":true,"is_deleted":false}', N'AdmissionForm/Update', 5, 1, CAST(N'2022-07-08 21:40:03.040' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(4, N'{"Id":1,"enc_id":null,"package_name":"Fitness Pro 12345","package_fee":12000.0,"session_adj":2000.0,"expiry_date":"Jul  8 2022 ","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-08T23:05:50.613613+05:00","updated_on":"2022-07-08T23:05:50.613613+05:00","is_active":true,"is_deleted":false}', N'Package/UpdatePackage', 1, 1, CAST(N'2022-07-08 23:05:50.673' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(5, N'{"Id":5,"enc_id":null,"package_name":"Fitness Pro 00111","package_fee":12000.0,"session_adj":2000.0,"expiry_date":"07/08/2022","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-08T23:07:10.0847693+05:00","updated_on":"2022-07-08T23:07:10.0855718+05:00","is_active":true,"is_deleted":false}', N'Package/UpdatePackage', 5, 1, CAST(N'2022-07-08 23:07:10.117' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(6, N'{"Id":2,"enc_id":null,"package_name":"Fitness Pro 987","package_fee":1000.0,"session_adj":1000.0,"expiry_date":"07/06/2022","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-08T23:07:31.7569848+05:00","updated_on":"2022-07-08T23:07:31.7579485+05:00","is_active":true,"is_deleted":false}', N'Package/UpdatePackage', 2, 1, CAST(N'2022-07-08 23:07:31.760' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(7, N'{"Id":1,"enc_id":null,"package_name":"Fitness Pro 12345","package_fee":12000.0,"session_adj":2000.0,"expiry_date":"Jul  8 2022 ","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-08T23:07:42.4124342+05:00","updated_on":"2022-07-08T23:07:42.4134443+05:00","is_active":true,"is_deleted":false}', N'Package/UpdatePackage', 1, 1, CAST(N'2022-07-08 23:07:42.417' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(8, N'{"Id":1,"enc_id":null,"package_name":"Fitness Pro 12345","package_fee":12000.0,"session_adj":2000.0,"expiry_date":"08/19/2022","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-08T23:10:51.9453992+05:00","updated_on":"2022-07-08T23:10:51.946396+05:00","is_active":true,"is_deleted":false}', N'Package/UpdatePackage', 1, 1, CAST(N'2022-07-08 23:10:51.950' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(9, N'{"Id":4,"enc_id":null,"first_name":"Syed","middle_name":"faiz","last_name":"Ali","gender":"Male","CNIC":"4220121415833","contact_number":"03200248812","is_resident":true,"address":null,"email":"syedfaizishtiaque@gmail.com","DOB":"07/31/1994","Age":27,"purpose_of_joining":"Dont Know","Height":"5''11''''","Weight":"61 kg","BMI":"SFSLFKSJ;LF","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-09T00:52:25.2677752+05:00","updated_on":"2022-07-09T00:52:25.2687391+05:00","is_active":true,"is_deleted":false}', N'AdmissionForm/Update', 4, 1, CAST(N'2022-07-09 00:52:25.417' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(10, N'{"Id":4,"enc_id":null,"first_name":"Syed","middle_name":"faiz","last_name":"Ali","gender":"Male","CNIC":"4220121415833","contact_number":"03200248812","is_resident":true,"address":null,"email":"syedfaizishtiaque@gmail.com","DOB":"07/31/1994","Age":27,"purpose_of_joining":"Dont Know","Height":"5","Weight":"6","BMI":"2","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-09T22:59:00.2836361+05:00","updated_on":"2022-07-09T22:59:00.2846593+05:00","is_active":true,"is_deleted":false}', N'AdmissionForm/Update', 4, 1, CAST(N'2022-07-09 22:59:01.470' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(11, N'{"Id":4,"enc_id":null,"first_name":"Syed","middle_name":"faiz","last_name":"Ali","gender":"Male","CNIC":"4220121415833","contact_number":"03200248812","is_resident":true,"address":null,"email":"syedfaizishtiaque@gmail.com","DOB":"07/21/1994","Age":27,"purpose_of_joining":"Dont Know","Height":"6","Weight":"61","BMI":"5.559201111111111","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-09T23:25:59.3795225+05:00","updated_on":"2022-07-09T23:25:59.3795225+05:00","is_active":true,"is_deleted":false}', N'AdmissionForm/Update', 4, 1, CAST(N'2022-07-09 23:25:59.387' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(12, N'{"Id":4,"enc_id":null,"first_name":"Syed","middle_name":"faiz","last_name":"Ali","gender":"Male","CNIC":"4220121415833","contact_number":"03200248812","is_resident":true,"address":null,"email":"syedfaizishtiaque@gmail.com","DOB":"07/21/1994","Age":27,"purpose_of_joining":"Dont Know","Height":"6","Weight":"61","BMI":"5.559201111111111","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-09T23:27:29.655727+05:00","updated_on":"2022-07-09T23:27:29.6567265+05:00","is_active":true,"is_deleted":false}', N'AdmissionForm/Update', 4, 1, CAST(N'2022-07-09 23:27:29.667' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(13, N'{"Id":4,"enc_id":null,"first_name":"Syed","middle_name":"faiz","last_name":"Ali","gender":"Male","CNIC":"4220121415833","contact_number":"03200248812","is_resident":true,"address":null,"email":"syedfaizishtiaque@gmail.com","DOB":"07/21/1994","Age":27,"purpose_of_joining":"Dont Know","Height":"6","Weight":"61","BMI":"18.238849373377775","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-09T23:28:11.839952+05:00","updated_on":"2022-07-09T23:28:11.8409481+05:00","is_active":true,"is_deleted":false}', N'AdmissionForm/Update', 4, 1, CAST(N'2022-07-09 23:28:11.850' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(14, N'{"Id":4,"enc_id":null,"first_name":"Syed","middle_name":"faiz","last_name":"Ali","gender":"Male","CNIC":"4220121415833","contact_number":"03200248812","is_resident":true,"address":null,"email":"syedfaizishtiaque@gmail.com","DOB":"07/21/1994","Age":27,"purpose_of_joining":"Dont Know","Height":"6","Weight":"61","BMI":"18.24","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-09T23:45:21.263792+05:00","updated_on":"2022-07-09T23:45:21.263792+05:00","is_active":true,"is_deleted":false}', N'AdmissionForm/Update', 4, 1, CAST(N'2022-07-09 23:45:21.320' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(15, N'{"Id":5,"enc_id":null,"first_name":"Syed","middle_name":"Sheraz","last_name":"Ali","gender":"Male","CNIC":"4220121415833","contact_number":null,"is_resident":true,"address":null,"email":"syedsherazishtiaque@gmail.com","DOB":"11/14/1995","Age":26,"purpose_of_joining":"Dont Know","Height":"5","Weight":"6","BMI":"2.58","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-09T23:47:51.5241779+05:00","updated_on":"2022-07-09T23:47:51.5252109+05:00","is_active":true,"is_deleted":false}', N'AdmissionForm/Update', 5, 1, CAST(N'2022-07-09 23:47:51.557' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(16, N'{"Id":4,"enc_id":null,"package_name":"Fitness Pro","package_fee":12000.0,"registration_fee":5000.0,"session_adj":2000.0,"expiry_date":"07/08/2022","company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-10T00:17:58.5701112+05:00","updated_on":"2022-07-10T00:17:58.5720575+05:00","is_active":true,"is_deleted":false}', N'Package/UpdatePackage', 4, 1, CAST(N'2022-07-10 00:17:58.677' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(17, N'{"Id":1,"enc_id":null,"name":"Syed Faraz Ali","contact_no":"032002","date_of_joining":"07/10/2022","job_title":null,"email_id":"syedfarazali@gmail.com","from_time":"08:00","to_time":"06:00","reporting_id":0,"working_hours":null,"reporting_name":null,"address":"House no 5 block 77 Area 1-C Landhi no 2 karachi","salary":10000.0,"guardian_name":null,"guardian_no":null,"sick_leave":32,"annual_leave":18,"use_sick_leave":0,"unuse_annual_leave":0,"unuse_sick_leave":0,"use_annual_leave":0,"is_trainer":true,"company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-10T02:29:44.6951825+05:00","updated_on":"2022-07-10T02:29:44.6981738+05:00","is_active":true,"is_deleted":false}', N'Employee/Create', 1, 1, CAST(N'2022-07-10 02:29:44.853' AS DateTime), N'Insert', 0, NULL, N'INS')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(18, N'{"Id":1,"enc_id":null,"name":"Syed Faraz Ali","contact_no":"032002","date_of_joining":"07/10/2022","job_title":null,"email_id":"syedfarazali@gmail.com","from_time":"08:00","to_time":"06:00","reporting_id":1,"working_hours":null,"reporting_name":null,"address":"House no 5 block 77 Area 1-C Landhi no 2 karachi","salary":10000.00,"guardian_name":"syed ishtiaque ali","guardian_no":"03007067950","sick_leave":32,"annual_leave":18,"use_sick_leave":0,"unuse_annual_leave":0,"unuse_sick_leave":0,"use_annual_leave":0,"is_trainer":false,"company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-10T02:41:12.8783047+05:00","updated_on":"2022-07-10T02:41:12.8792999+05:00","is_active":true,"is_deleted":false}', N'Employee/Update', 1, 1, CAST(N'2022-07-10 02:41:12.977' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(19, N'{"Id":1,"enc_id":null,"name":"Syed Faraz Ali","contact_no":"032002","date_of_joining":"07/10/2022","job_title":null,"email_id":"syedfarazali@gmail.com","from_time":"08:00","to_time":"09:00","reporting_id":1,"working_hours":null,"reporting_name":null,"address":"House no 5 block 77 Area 1-C Landhi no 2 karachi","salary":10000.00,"guardian_name":"syed ishtiaque ali","guardian_no":"03007067950","sick_leave":32,"annual_leave":18,"use_sick_leave":0,"unuse_annual_leave":0,"unuse_sick_leave":0,"use_annual_leave":0,"is_trainer":false,"company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-10T02:42:36.3683191+05:00","updated_on":"2022-07-10T02:42:36.3683191+05:00","is_active":true,"is_deleted":false}', N'Employee/Update', 1, 1, CAST(N'2022-07-10 02:42:36.493' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(20, N'{"Id":1,"enc_id":null,"name":"Syed Faraz Ali","contact_no":"032002","date_of_joining":"07/10/2022","job_title":null,"email_id":"syedfarazali@gmail.com","from_time":"0800","to_time":null,"reporting_id":1,"working_hours":null,"reporting_name":null,"address":"House no 5 block 77 Area 1-C Landhi no 2 karachi","salary":10000.00,"guardian_name":"syed ishtiaque ali","guardian_no":"03007067950","sick_leave":32,"annual_leave":18,"use_sick_leave":0,"unuse_annual_leave":0,"unuse_sick_leave":0,"use_annual_leave":0,"is_trainer":true,"company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-10T18:42:04.4434641+05:00","updated_on":"2022-07-10T18:42:04.444467+05:00","is_active":true,"is_deleted":false}', N'Employee/Update', 1, 1, CAST(N'2022-07-10 18:42:04.490' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(21, N'{"Id":1,"enc_id":null,"name":"Syed Faraz Ali","contact_no":"032002","date_of_joining":"07/10/2022","job_title":null,"email_id":"syedfarazali@gmail.com","from_time":"08:00","to_time":"09:00","reporting_id":0,"working_hours":null,"reporting_name":null,"address":"House no 5 block 77 Area 1-C Landhi no 2 karachi","salary":10000.00,"guardian_name":"syed ishtiaque ali","guardian_no":"03007067950","sick_leave":32,"annual_leave":18,"use_sick_leave":0,"unuse_annual_leave":0,"unuse_sick_leave":0,"use_annual_leave":0,"is_trainer":true,"company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-10T18:43:30.279947+05:00","updated_on":"2022-07-10T18:43:30.280946+05:00","is_active":true,"is_deleted":false}', N'Employee/Update', 1, 1, CAST(N'2022-07-10 18:43:30.290' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(22, N'{"Id":1,"enc_id":null,"name":"Syed Faraz Ali","contact_no":"032002","date_of_joining":"07/10/2022","job_title":null,"email_id":"syedfarazali@gmail.com","from_time":"14:48","to_time":"21:00","reporting_id":1,"working_hours":null,"reporting_name":null,"address":"House no 5 block 77 Area 1-C Landhi no 2 karachi","salary":10000.00,"guardian_name":"syed ishtiaque ali","guardian_no":"03007067950","sick_leave":32,"annual_leave":18,"use_sick_leave":0,"unuse_annual_leave":0,"unuse_sick_leave":0,"use_annual_leave":0,"is_trainer":false,"company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-18T14:48:18.8702518+05:00","updated_on":"2022-07-18T14:48:18.8712476+05:00","is_active":true,"is_deleted":false}', N'Employee/Update', 1, 1, CAST(N'2022-07-18 14:48:18.983' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(23, N'{"Id":1,"enc_id":null,"name":"Syed Faraz Ali","contact_no":"032002","date_of_joining":"07/10/2022","job_title":null,"email_id":"syedfarazali@gmail.com","from_time":"20:00","to_time":"18:00","reporting_id":1,"working_hours":null,"reporting_name":null,"address":"House no 5 block 77 Area 1-C Landhi no 2 karachi","salary":10000.00,"guardian_name":"syed ishtiaque ali","guardian_no":"03007067950","sick_leave":32,"annual_leave":18,"use_sick_leave":0,"unuse_annual_leave":0,"unuse_sick_leave":0,"use_annual_leave":0,"is_trainer":false,"company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-18T14:56:21.5911615+05:00","updated_on":"2022-07-18T14:56:21.593162+05:00","is_active":true,"is_deleted":false}', N'Employee/Update', 1, 1, CAST(N'2022-07-18 14:56:21.683' AS DateTime), N'update', 0, NULL, N'UPD')
INSERT[dbo].[audit_log]([id], [form_post_data], [form_ref], [record_pk], [user_id], [created_on], [action], [is_email_sent], [sent_datetime], [rec_st_code]) VALUES(24, N'{"Id":1,"enc_id":null,"name":"Syed Faraz Ali","contact_no":"032002","date_of_joining":"07/10/2022","job_title":null,"email_id":"syedfarazali@gmail.com","from_time":"08:00","to_time":"18:00","reporting_id":1,"working_hours":null,"reporting_name":null,"address":"House no 5 block 77 Area 1-C Landhi no 2 karachi","salary":10000.00,"guardian_name":"syed ishtiaque ali","guardian_no":"03007067950","sick_leave":32,"annual_leave":18,"use_sick_leave":0,"unuse_annual_leave":0,"unuse_sick_leave":0,"use_annual_leave":0,"is_trainer":false,"company_id":1,"created_by":1,"updated_by":1,"created_on":"2022-07-18T14:59:43.5669675+05:00","updated_on":"2022-07-18T14:59:43.5689786+05:00","is_active":true,"is_deleted":false}', N'Employee/Update', 1, 1, CAST(N'2022-07-18 14:59:43.573' AS DateTime), N'update', 0, NULL, N'UPD')
SET IDENTITY_INSERT[dbo].[audit_log] OFF
SET IDENTITY_INSERT [dbo].[dept] ON

INSERT[dbo].[dept] ([dept_sk], [dept_desc], [dept_type_sk], [dept_name]) VALUES(1, N'Islamabad', 1, N'ISLAMABAD BRANCH')
SET IDENTITY_INSERT[dbo].[dept] OFF
INSERT[dbo].[dept_type] ([dept_type_sk], [dept_type_name]) VALUES(1, N'Business')
SET IDENTITY_INSERT[dbo].[employee] ON

INSERT[dbo].[employee] ([Id], [Name], [contact_no], [date_of_joining], [job_title], [email_id], [from_time], [to_time], [reporting_id], [address], [salary], [guardian_name], [guardian_no], [sick_leave], [annual_leave], [use_sick_leave], [use_annual_leave], [unuse_annual_leave], [unuse_sick_leave], [company_id], [created_by], [updated_by], [created_on], [updated_on], [is_active], [is_deleted], [is_trainer]) VALUES(1, N'Syed Faraz Ali', N'032002', N'07/10/2022', NULL, N'syedfarazali@gmail.com', N'08:00', N'18:00', 1, N'House no 5 block 77 Area 1-C Landhi no 2 karachi', CAST(10000.00 AS Decimal(18, 2)), N'syed ishtiaque ali', N'03007067950', CAST(32.00 AS Decimal(18, 2)), CAST(18.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 1, 1, CAST(N'2022-07-10 02:29:44.697' AS DateTime), CAST(N'2022-07-18 14:59:43.570' AS DateTime), 1, 0, 0)
SET IDENTITY_INSERT[dbo].[employee] OFF
SET IDENTITY_INSERT [dbo].[login_history] ON

INSERT[dbo].[login_history] ([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(1, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 14:32:14.297' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(2, 9, 1, 0, N'Visited LocalHost', CAST(N'2022-07-08 14:34:09.420' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(3, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 14:37:42.460' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(4, 9, 1, 0, N'Visited LocalHost', CAST(N'2022-07-08 14:39:16.327' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(5, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 14:39:36.383' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(6, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 14:50:48.080' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(7, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 14:54:56.530' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(8, 9, 1, 0, N'Visited LocalHost', CAST(N'2022-07-08 14:55:11.587' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(9, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 16:42:53.710' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(10, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 16:44:03.230' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(11, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 17:26:25.313' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(12, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 17:27:46.930' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(13, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 17:30:42.473' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(14, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 17:35:28.927' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(15, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 17:36:49.860' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(16, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 17:45:57.123' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(17, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 20:03:24.443' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(18, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 20:23:09.287' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(19, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 20:24:46.643' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(20, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 20:37:13.260' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(21, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 20:45:41.253' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(22, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 21:03:01.893' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(23, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 21:27:55.120' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(24, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 21:38:31.763' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(25, 9, 1, 0, N'Visited LocalHost', CAST(N'2022-07-08 21:41:18.697' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(26, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 21:41:32.287' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(27, 9, 1, 0, N'Visited LocalHost', CAST(N'2022-07-08 21:41:41.290' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(28, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 21:48:16.260' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(29, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 23:05:16.483' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(30, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 23:06:53.200' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(31, 9, 1, 0, N'Visited LocalHost', CAST(N'2022-07-08 23:24:05.387' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(32, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 23:24:19.473' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(33, 9, 1, 0, N'Visited LocalHost', CAST(N'2022-07-08 23:28:04.167' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(34, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 23:28:16.410' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(35, 9, 1, 0, N'Visited LocalHost', CAST(N'2022-07-08 23:29:36.677' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(36, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 23:29:54.670' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(37, 9, 1, 0, N'Visited LocalHost', CAST(N'2022-07-08 23:36:01.253' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(38, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-08 23:36:16.030' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(39, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 00:34:12.673' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(40, 9, 1, 0, N'Visited LocalHost', CAST(N'2022-07-09 00:35:03.543' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(41, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 00:35:18.043' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(42, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 00:43:30.307' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(43, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 12:25:32.330' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(44, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 12:28:24.087' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(45, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 12:29:29.270' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(46, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 19:03:52.210' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(47, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 19:12:01.490' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(48, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 19:14:52.853' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(49, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 19:18:49.243' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(50, 9, 1, 0, N'Visited LocalHost', CAST(N'2022-07-09 19:24:09.563' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(51, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 19:24:40.547' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(52, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 21:09:59.087' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(53, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 21:31:21.207' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(54, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 22:05:31.437' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(55, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 23:29:09.420' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(56, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-09 23:50:00.363' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(57, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-10 00:01:12.277' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(58, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-10 00:16:40.807' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(59, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-10 01:44:05.630' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(60, 9, 1, 0, N'Visited LocalHost', CAST(N'2022-07-10 01:45:17.180' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(61, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-10 01:45:25.727' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(62, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-10 01:53:04.160' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(63, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-10 02:21:15.090' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(64, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-10 02:40:37.463' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(65, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-10 02:42:15.380' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(66, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-10 18:19:47.117' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(67, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-18 14:34:34.943' AS DateTime))
INSERT[dbo].[login_history]([id], [app_sk], [usr_sk], [type_sk], [usr_ip], [created_on]) VALUES(68, 9, 1, 1, N'Visited LocalHost', CAST(N'2022-07-18 15:48:41.963' AS DateTime))
SET IDENTITY_INSERT[dbo].[login_history] OFF
SET IDENTITY_INSERT [dbo].[mnus] ON

INSERT[dbo].[mnus] ([mnu_sk], [app_sk], [mnu_desc], [mnu_url], [mnu_icon], [parent_mnu_sk], [created_by], [created_on], [is_active], [Seq_No]) VALUES(2, 1, N'  Dashboard', N'/Home', N'fas fa-eye', 0, 1, CAST(N'2022-07-07 00:00:00.000' AS DateTime), 1, 1)
INSERT[dbo].[mnus]([mnu_sk], [app_sk], [mnu_desc], [mnu_url], [mnu_icon], [parent_mnu_sk], [created_by], [created_on], [is_active], [Seq_No]) VALUES(3, 1, N'  Packages', N'/Package', N'fas fa-list', 0, 1, CAST(N'2022-07-08 00:00:00.000' AS DateTime), 1, 4)
INSERT[dbo].[mnus]([mnu_sk], [app_sk], [mnu_desc], [mnu_url], [mnu_icon], [parent_mnu_sk], [created_by], [created_on], [is_active], [Seq_No]) VALUES(4, 1, N'  Admissions', N'/Admission', N'fas fa-university', 0, 1, CAST(N'2022-07-08 00:00:00.000' AS DateTime), 1, 3)
INSERT[dbo].[mnus]([mnu_sk], [app_sk], [mnu_desc], [mnu_url], [mnu_icon], [parent_mnu_sk], [created_by], [created_on], [is_active], [Seq_No]) VALUES(5, 1, N'  Admission Form', N'/Admission/create', N'fas fa-file', 0, 1, CAST(N'2022-07-08 00:00:00.000' AS DateTime), 1, 2)
INSERT[dbo].[mnus]([mnu_sk], [app_sk], [mnu_desc], [mnu_url], [mnu_icon], [parent_mnu_sk], [created_by], [created_on], [is_active], [Seq_No]) VALUES(6, 1, N'Employees', N'/Employee', N'fas fa-user', 0, 1, CAST(N'2022-07-08 00:00:00.000' AS DateTime), 1, 2)
SET IDENTITY_INSERT[dbo].[mnus] OFF
SET IDENTITY_INSERT [dbo].[Package] ON

INSERT[dbo].[Package] ([Id], [package_name], [package_fee], [session_adj], [expiry_date], [company_id], [created_by], [updated_by], [created_on], [updated_on], [is_active], [is_deleted], [registration_fee]) VALUES(1, N'Fitness Pro 12345', CAST(12000.00 AS Decimal(18, 2)), CAST(2000.00 AS Decimal(18, 2)), N'08/19/2022', 1, 1, 1, CAST(N'2022-07-08 17:28:34.057' AS DateTime), CAST(N'2022-07-08 23:10:51.947' AS DateTime), 1, 0, NULL)
INSERT[dbo].[Package]([Id], [package_name], [package_fee], [session_adj], [expiry_date], [company_id], [created_by], [updated_by], [created_on], [updated_on], [is_active], [is_deleted], [registration_fee]) VALUES(2, N'Fitness Pro 987', CAST(1000.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), N'07/06/2022', 1, 1, 1, CAST(N'2022-07-08 17:35:49.507' AS DateTime), CAST(N'2022-07-08 23:07:31.757' AS DateTime), 1, 0, NULL)
INSERT[dbo].[Package]([Id], [package_name], [package_fee], [session_adj], [expiry_date], [company_id], [created_by], [updated_by], [created_on], [updated_on], [is_active], [is_deleted], [registration_fee]) VALUES(3, N'Fitness Pro 5', CAST(44.00 AS Decimal(18, 2)), CAST(444.00 AS Decimal(18, 2)), N'07/06/2022', 1, 1, 1, CAST(N'2022-07-08 17:37:12.787' AS DateTime), CAST(N'2022-07-08 17:37:12.790' AS DateTime), 1, 0, NULL)
INSERT[dbo].[Package]([Id], [package_name], [package_fee], [session_adj], [expiry_date], [company_id], [created_by], [updated_by], [created_on], [updated_on], [is_active], [is_deleted], [registration_fee]) VALUES(4, N'Fitness Pro', CAST(12000.00 AS Decimal(18, 2)), CAST(2000.00 AS Decimal(18, 2)), N'07/08/2022', 1, 1, 1, CAST(N'2022-07-08 17:47:11.830' AS DateTime), CAST(N'2022-07-10 00:17:58.573' AS DateTime), 1, 0, CAST(5000.00 AS Decimal(18, 2)))
INSERT[dbo].[Package]([Id], [package_name], [package_fee], [session_adj], [expiry_date], [company_id], [created_by], [updated_by], [created_on], [updated_on], [is_active], [is_deleted], [registration_fee]) VALUES(5, N'Fitness Pro 00111', CAST(12000.00 AS Decimal(18, 2)), CAST(2000.00 AS Decimal(18, 2)), N'07/08/2022', 1, 1, 1, CAST(N'2022-07-08 17:47:24.220' AS DateTime), CAST(N'2022-07-08 23:07:10.087' AS DateTime), 1, 0, NULL)
SET IDENTITY_INSERT[dbo].[Package] OFF
SET IDENTITY_INSERT [dbo].[role_mnus] ON

INSERT[dbo].[role_mnus] ([role_mnu_sk], [role_sk], [mnu_sk], [can_slct], [can_insrt], [can_updt], [can_del], [is_active], [created_on], [created_by]) VALUES(1, 1, 2, 1, 1, 1, 1, 1, CAST(N'2022-07-07 00:00:00.000' AS DateTime), 1)
INSERT[dbo].[role_mnus]([role_mnu_sk], [role_sk], [mnu_sk], [can_slct], [can_insrt], [can_updt], [can_del], [is_active], [created_on], [created_by]) VALUES(2, 1, 3, 1, 1, 1, 1, 1, CAST(N'2022-07-07 00:00:00.000' AS DateTime), 1)
INSERT[dbo].[role_mnus]([role_mnu_sk], [role_sk], [mnu_sk], [can_slct], [can_insrt], [can_updt], [can_del], [is_active], [created_on], [created_by]) VALUES(3, 1, 4, 1, 1, 1, 1, 1, CAST(N'2022-07-07 00:00:00.000' AS DateTime), 1)
INSERT[dbo].[role_mnus]([role_mnu_sk], [role_sk], [mnu_sk], [can_slct], [can_insrt], [can_updt], [can_del], [is_active], [created_on], [created_by]) VALUES(4, 1, 5, 1, 1, 1, 1, 1, CAST(N'2022-07-07 00:00:00.000' AS DateTime), 1)
INSERT[dbo].[role_mnus]([role_mnu_sk], [role_sk], [mnu_sk], [can_slct], [can_insrt], [can_updt], [can_del], [is_active], [created_on], [created_by]) VALUES(5, 1, 6, 1, 1, 1, 1, 1, CAST(N'2022-07-07 00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT[dbo].[role_mnus] OFF
SET IDENTITY_INSERT [dbo].[usr_apps] ON

INSERT[dbo].[usr_apps] ([usr_apps_sk], [usr_sk], [app_sk], [is_active], [created_on], [created_by]) VALUES(1, 1, 1, 1, CAST(N'2022-07-07 00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT[dbo].[usr_apps] OFF
SET IDENTITY_INSERT [dbo].[usr_auth_roles] ON

INSERT[dbo].[usr_auth_roles] ([usr_role_sk], [usr_sk], [role_sk], [is_active], [created_on], [created_by]) VALUES(1, 1, 1, 1, CAST(N'2022-07-07 00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT[dbo].[usr_auth_roles] OFF
SET IDENTITY_INSERT [dbo].[usr_role] ON

INSERT[dbo].[usr_role] ([role_sk], [role_desc]) VALUES(1, N'System Engineer')
INSERT[dbo].[usr_role]([role_sk], [role_desc]) VALUES(2, N'Orgranization Owner')
SET IDENTITY_INSERT[dbo].[usr_role] OFF
SET IDENTITY_INSERT [dbo].[usrs] ON

INSERT[dbo].[usrs] ([usr_sk], [usr_nme], [usr_full_nme], [dept_sk], [is_active], [created_on], [created_by], [branch_code], [mgr_id], [password]) VALUES(1, N'1mPfARK2pMhbr6OczDWnPg==', N'Syed Faiz Ali', 1, 1, CAST(N'2022-07-07 00:00:00.000' AS DateTime), 1, 1, 1, N'SLKk%2BA6olQY=')
SET IDENTITY_INSERT[dbo].[usrs] OFF
/****** Object:  StoredProcedure [dbo].[sp_Logindata]    Script Date: 7/20/2022 12:21:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





	CREATE proc [dbo].[sp_Logindata]
@username nvarchar(100),
	@key nvarchar(100)
	as
	begin



 select dpt.dept_sk , dpt.dept_name , usr.usr_sk , usr.usr_nme , usr.usr_full_nme , app.app_sk , app.app_desc  , rol.role_sk, rol.role_desc

								 , mnu.mnu_sk , mnu.mnu_desc , mnu.mnu_url , mnu.mnu_icon  , mnu.parent_mnu_sk , mnu.seq_no

								 , rolmnu.can_slct , rolmnu.can_insrt , rolmnu.can_updt , rolmnu.can_del,
								 deptyp.dept_type_sk , deptyp.dept_type_name
								from usrs usr

							   left join usr_apps usrapp on usrapp.usr_sk = usr.usr_sk
					  --left join tblBranch br on br.Branch_code = usr.branch_code
							   left join dept dpt on dpt.dept_sk = usr.dept_sk
							   inner join dept_type deptyp on deptyp.dept_type_sk = dpt.dept_type_sk

							   left join apps app on app.app_sk = usrapp.app_sk

							   left join usr_auth_roles usrauthrol on usrauthrol.usr_sk = usr.usr_sk

							   left join usr_role rol on rol.role_sk = usrauthrol.role_sk

							   left join role_mnus rolmnu on rolmnu.role_sk = usrauthrol.role_sk

							   left join mnus mnu on mnu.mnu_sk = rolmnu.mnu_sk  and mnu.app_sk = app.app_sk

							 where rolmnu.is_active= 1 and lower(usr.usr_nme)= lower(@username) and usr.is_active= 1
							 and app.company_key = @key
						union all
						select dpt.dept_sk , dpt.dept_name , usr.usr_sk , usr.usr_nme , usr.usr_full_nme , app.app_sk , app.app_desc  , rol.role_sk, rol.role_desc

								 , mnu.mnu_sk , mnu.mnu_desc , mnu.mnu_url , mnu.mnu_icon  , mnu.parent_mnu_sk , mnu.seq_no

								 , usrmnu.can_slct , usrmnu.can_insrt , usrmnu.can_updt , usrmnu.can_del,
								 deptyp.dept_type_sk , deptyp.dept_type_name
								from usrs usr

							   left join usr_apps usrapp on usrapp.usr_sk = usr.usr_sk


							   left join dept dpt on dpt.dept_sk = usr.dept_sk
							   inner join dept_type deptyp on deptyp.dept_type_sk = dpt.dept_type_sk

							   left join apps app on app.app_sk = usrapp.app_sk

							   left join usr_auth_roles usrauthrol on usrauthrol.usr_sk = usr.usr_sk

							   left join usr_role rol on rol.role_sk = usrauthrol.role_sk

							   left join usr_mnus usrmnu on usrmnu.usr_sk = usrauthrol.usr_sk

							   left join mnus mnu on mnu.mnu_sk = usrmnu.mnu_sk  and mnu.app_sk = app.app_sk

							 where usrmnu.is_active= 1 and lower(usr.usr_nme)= lower(@username)
							 and app.company_key = @key and mnu.mnu_sk not in (select mnu_sk from role_mnus where role_sk = usrauthrol.role_sk) and usr.is_active=1
							 order by  mnu.seq_no
	end


GO
