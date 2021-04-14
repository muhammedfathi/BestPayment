using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NaqdiDAL.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bank_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeesPercent = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "cases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartValue = table.Column<double>(type: "float", nullable: false),
                    EndValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cases", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GlobalConfigration",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorConfig = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalConfigration", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PayMent_Cards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phoneno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bill_value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    paid_value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Residual_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Cards_Count = table.Column<int>(type: "int", nullable: true),
                    Pay_Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayMent_Cards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Center_id = table.Column<int>(type: "int", nullable: true),
                    Servisversion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MType = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UPUser = table.Column<int>(type: "int", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: true),
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUser", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_TUser_Role_Role_ID",
                        column: x => x.Role_ID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TUser_TUser_UPUser",
                        column: x => x.UPUser,
                        principalTable: "TUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CasesCPS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comapny_id = table.Column<int>(type: "int", nullable: false),
                    Provider_id = table.Column<int>(type: "int", nullable: false),
                    Service_id = table.Column<int>(type: "int", nullable: false),
                    Cases_id = table.Column<int>(type: "int", nullable: false),
                    FeesType = table.Column<bool>(type: "bit", nullable: true),
                    FeesValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CommissionType = table.Column<bool>(type: "bit", nullable: true),
                    CommissionValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QueryState = table.Column<bool>(type: "bit", nullable: false),
                    PaymentState = table.Column<bool>(type: "bit", nullable: false),
                    ISEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasesCPS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CasesCPS_cases_Cases_id",
                        column: x => x.Cases_id,
                        principalTable: "cases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasesCPS_Company_Comapny_id",
                        column: x => x.Comapny_id,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasesCPS_Provider_Provider_id",
                        column: x => x.Provider_id,
                        principalTable: "Provider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasesCPS_Service_Service_id",
                        column: x => x.Service_id,
                        principalTable: "Service",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "privilage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    service_id = table.Column<int>(type: "int", nullable: true),
                    company_id = table.Column<int>(type: "int", nullable: true),
                    upServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_privilage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_privilage_Company_company_id",
                        column: x => x.company_id,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_privilage_Service_service_id",
                        column: x => x.service_id,
                        principalTable: "Service",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgentCommissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Service_ID = table.Column<int>(type: "int", nullable: true),
                    Company_ID = table.Column<int>(type: "int", nullable: true),
                    Provider_ID = table.Column<int>(type: "int", nullable: true),
                    Case_ID = table.Column<int>(type: "int", nullable: true),
                    Commission_Type = table.Column<bool>(type: "bit", nullable: true),
                    Commission_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fees_Type = table.Column<bool>(type: "bit", nullable: true),
                    Fees_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentState = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentCommissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AgentCommissions_cases_Case_ID",
                        column: x => x.Case_ID,
                        principalTable: "cases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgentCommissions_Company_Company_ID",
                        column: x => x.Company_ID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgentCommissions_Provider_Provider_ID",
                        column: x => x.Provider_ID,
                        principalTable: "Provider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgentCommissions_Service_Service_ID",
                        column: x => x.Service_ID,
                        principalTable: "Service",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgentCommissions_TUser_UserID",
                        column: x => x.UserID,
                        principalTable: "TUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintUserOwnerIDFK = table.Column<int>(type: "int", nullable: false),
                    cdate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Complaint_TUser_ComplaintUserOwnerIDFK",
                        column: x => x.ComplaintUserOwnerIDFK,
                        principalTable: "TUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Excute",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    service_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    company_id = table.Column<int>(type: "int", nullable: true),
                    provider_id = table.Column<int>(type: "int", nullable: true),
                    DiscValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DateOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeOut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalUser = table.Column<int>(type: "int", nullable: false),
                    CardID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excute", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Excute_Company_company_id",
                        column: x => x.company_id,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Excute_Provider_provider_id",
                        column: x => x.provider_id,
                        principalTable: "Provider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Excute_Service_service_id",
                        column: x => x.service_id,
                        principalTable: "Service",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Excute_TUser_user_id",
                        column: x => x.user_id,
                        principalTable: "TUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    providerid = table.Column<int>(type: "int", nullable: true),
                    companyid = table.Column<int>(type: "int", nullable: true),
                    serviceid = table.Column<int>(type: "int", nullable: true),
                    userid = table.Column<int>(type: "int", nullable: true),
                    ldate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    accountno = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Log_Company_companyid",
                        column: x => x.companyid,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Log_Provider_providerid",
                        column: x => x.providerid,
                        principalTable: "Provider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Log_Service_serviceid",
                        column: x => x.serviceid,
                        principalTable: "Service",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Log_TUser_userid",
                        column: x => x.userid,
                        principalTable: "TUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Login_Information",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mac_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    latitude = table.Column<double>(type: "float", nullable: true),
                    longitude = table.Column<double>(type: "float", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    action_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    action_time = table.Column<TimeSpan>(type: "time", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login_Information", x => x.id);
                    table.ForeignKey(
                        name: "FK_Login_Information_TUser_user_id",
                        column: x => x.user_id,
                        principalTable: "TUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProvidersDeposit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderID = table.Column<int>(type: "int", nullable: true),
                    BankID = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidersDeposit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProvidersDeposit_Banks_BankID",
                        column: x => x.BankID,
                        principalTable: "Banks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProvidersDeposit_Provider_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Provider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProvidersDeposit_TUser_UserID",
                        column: x => x.UserID,
                        principalTable: "TUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersDeposit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BankID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeesType = table.Column<bool>(type: "bit", nullable: false),
                    FeesValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResposibleID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    image_Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image_Bytes = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    MoveType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToUser = table.Column<int>(type: "int", nullable: false),
                    BanksID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDeposit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsersDeposit_Banks_BanksID",
                        column: x => x.BanksID,
                        principalTable: "Banks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersDeposit_TUser_ResposibleID",
                        column: x => x.ResposibleID,
                        principalTable: "TUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersDeposit_TUser_ToUser",
                        column: x => x.ToUser,
                        principalTable: "TUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersDeposit_TUser_UserId",
                        column: x => x.UserId,
                        principalTable: "TUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CasesCPSField_Provs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CasesCPS_ID = table.Column<int>(type: "int", nullable: false),
                    fieldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fieldValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasesCPSField_Provs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CasesCPSField_Provs_CasesCPS_CasesCPS_ID",
                        column: x => x.CasesCPS_ID,
                        principalTable: "CasesCPS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    serial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duration = table.Column<int>(type: "int", nullable: false),
                    CaseCPS_ID = table.Column<int>(type: "int", nullable: false),
                    PinNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    card_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    ProviderID = table.Column<int>(type: "int", nullable: true),
                    ServiceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Store_CasesCPS_CaseCPS_ID",
                        column: x => x.CaseCPS_ID,
                        principalTable: "CasesCPS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Store_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Store_Provider_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Provider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Store_Service_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rol_PrivFT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol_id = table.Column<int>(type: "int", nullable: false),
                    Priv_id = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol_PrivFT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rol_PrivFT_privilage_Priv_id",
                        column: x => x.Priv_id,
                        principalTable: "privilage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rol_PrivFT_Role_Rol_id",
                        column: x => x.Rol_id,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rol_PrivFT_TUser_UserID",
                        column: x => x.UserID,
                        principalTable: "TUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reply",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reply1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompliaintID = table.Column<int>(type: "int", nullable: false),
                    ReplyedByIDFK = table.Column<int>(type: "int", nullable: false),
                    ReplyedON = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reply_Complaint_CompliaintID",
                        column: x => x.CompliaintID,
                        principalTable: "Complaint",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reply_TUser_ReplyedByIDFK",
                        column: x => x.ReplyedByIDFK,
                        principalTable: "TUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ChargeOperations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    OperatioDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OperatioTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    responseMSG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperationID = table.Column<int>(type: "int", nullable: false),
                    OperationState = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargeOperations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChargeOperations_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChargeOperations_Excute_OperationID",
                        column: x => x.OperationID,
                        principalTable: "Excute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChargeOperations_TUser_UserID",
                        column: x => x.UserID,
                        principalTable: "TUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Execution_Responses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExecutionID = table.Column<int>(type: "int", nullable: false),
                    fieldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fieldValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Execution_Responses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Execution_Responses_Excute_ExecutionID",
                        column: x => x.ExecutionID,
                        principalTable: "Excute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentCommissions_Case_ID",
                table: "AgentCommissions",
                column: "Case_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AgentCommissions_Company_ID",
                table: "AgentCommissions",
                column: "Company_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AgentCommissions_Provider_ID",
                table: "AgentCommissions",
                column: "Provider_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AgentCommissions_Service_ID",
                table: "AgentCommissions",
                column: "Service_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AgentCommissions_UserID",
                table: "AgentCommissions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CasesCPS_Cases_id",
                table: "CasesCPS",
                column: "Cases_id");

            migrationBuilder.CreateIndex(
                name: "IX_CasesCPS_Comapny_id",
                table: "CasesCPS",
                column: "Comapny_id");

            migrationBuilder.CreateIndex(
                name: "IX_CasesCPS_Provider_id",
                table: "CasesCPS",
                column: "Provider_id");

            migrationBuilder.CreateIndex(
                name: "IX_CasesCPS_Service_id",
                table: "CasesCPS",
                column: "Service_id");

            migrationBuilder.CreateIndex(
                name: "IX_CasesCPSField_Provs_CasesCPS_ID",
                table: "CasesCPSField_Provs",
                column: "CasesCPS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeOperations_CompanyID",
                table: "ChargeOperations",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeOperations_OperationID",
                table: "ChargeOperations",
                column: "OperationID");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeOperations_UserID",
                table: "ChargeOperations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_ComplaintUserOwnerIDFK",
                table: "Complaint",
                column: "ComplaintUserOwnerIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_Excute_company_id",
                table: "Excute",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Excute_provider_id",
                table: "Excute",
                column: "provider_id");

            migrationBuilder.CreateIndex(
                name: "IX_Excute_service_id",
                table: "Excute",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_Excute_user_id",
                table: "Excute",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Execution_Responses_ExecutionID",
                table: "Execution_Responses",
                column: "ExecutionID");

            migrationBuilder.CreateIndex(
                name: "IX_Log_companyid",
                table: "Log",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_Log_providerid",
                table: "Log",
                column: "providerid");

            migrationBuilder.CreateIndex(
                name: "IX_Log_serviceid",
                table: "Log",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "IX_Log_userid",
                table: "Log",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Login_Information_user_id",
                table: "Login_Information",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_privilage_company_id",
                table: "privilage",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_privilage_service_id",
                table: "privilage",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidersDeposit_BankID",
                table: "ProvidersDeposit",
                column: "BankID");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidersDeposit_ProviderID",
                table: "ProvidersDeposit",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidersDeposit_UserID",
                table: "ProvidersDeposit",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_CompliaintID",
                table: "Reply",
                column: "CompliaintID");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_ReplyedByIDFK",
                table: "Reply",
                column: "ReplyedByIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_PrivFT_Priv_id",
                table: "Rol_PrivFT",
                column: "Priv_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_PrivFT_Rol_id",
                table: "Rol_PrivFT",
                column: "Rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_PrivFT_UserID",
                table: "Rol_PrivFT",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_CaseCPS_ID",
                table: "Store",
                column: "CaseCPS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_CompanyID",
                table: "Store",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ProviderID",
                table: "Store",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ServiceID",
                table: "Store",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_TUser_Role_ID",
                table: "TUser",
                column: "Role_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TUser_UPUser",
                table: "TUser",
                column: "UPUser");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDeposit_BanksID",
                table: "UsersDeposit",
                column: "BanksID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDeposit_ResposibleID",
                table: "UsersDeposit",
                column: "ResposibleID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDeposit_ToUser",
                table: "UsersDeposit",
                column: "ToUser");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDeposit_UserId",
                table: "UsersDeposit",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentCommissions");

            migrationBuilder.DropTable(
                name: "CasesCPSField_Provs");

            migrationBuilder.DropTable(
                name: "ChargeOperations");

            migrationBuilder.DropTable(
                name: "Execution_Responses");

            migrationBuilder.DropTable(
                name: "GlobalConfigration");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Login_Information");

            migrationBuilder.DropTable(
                name: "PayMent_Cards");

            migrationBuilder.DropTable(
                name: "ProvidersDeposit");

            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.DropTable(
                name: "Rol_PrivFT");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "UsersDeposit");

            migrationBuilder.DropTable(
                name: "Excute");

            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "privilage");

            migrationBuilder.DropTable(
                name: "CasesCPS");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "TUser");

            migrationBuilder.DropTable(
                name: "cases");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
