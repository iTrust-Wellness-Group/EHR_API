using System;
using System.Collections.Generic;
using EHR.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EHR.Database.Context;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessLog> AccessLogs { get; set; }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountPermissionMap> AccountPermissionMaps { get; set; }

    public virtual DbSet<AccountRoleMap> AccountRoleMaps { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AutomationAuditLog> AutomationAuditLogs { get; set; }

    public virtual DbSet<AutomationLog> AutomationLogs { get; set; }

    public virtual DbSet<DrchronoAppointment> DrchronoAppointments { get; set; }

    public virtual DbSet<DrchronoIdLookup> DrchronoIdLookups { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Page> Pages { get; set; }

    public virtual DbSet<PatientAccount> PatientAccounts { get; set; }

    public virtual DbSet<PatientProfile> PatientProfiles { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<ReferralFormLog> ReferralFormLogs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermissionMap> RolePermissionMaps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=aurora-auroradatabase5475d328-1fhhlc5ey771i.cluster-csgv9gisrp7z.us-east-2.rds.amazonaws.com:48040;Database=development;Username=cluster_root;Password=z=oJ47hJ7PuvlTSg+^GM#vAfUf<hd8TR");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("Operation", new[] { "C", "R", "U", "D" })
            .HasPostgresEnum("status", new[] { "FAILED", "SUCCEEDED", "SKIPPED" })
            .HasPostgresEnum("type", new[] { "PROFILE", "CLINICAL_NOTE", "DOCUMENT", "SKIPPED", "PATIENT" })
            .HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<AccessLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AccessLog_pkey");

            entity.ToTable("AccessLog");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Action)
                .HasColumnType("character varying")
                .HasColumnName("action");
            entity.Property(e => e.ActionName)
                .HasColumnType("character varying")
                .HasColumnName("actionName");
            entity.Property(e => e.ControllerName)
                .HasColumnType("character varying")
                .HasColumnName("controllerName");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("statement_timestamp()")
                .HasColumnName("createTime");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("false")
                .HasColumnName("isDelete");
            entity.Property(e => e.ModifyUserId).HasColumnName("modifyUserId");
            entity.Property(e => e.OrignData)
                .HasColumnType("character varying")
                .HasColumnName("orignData");
            entity.Property(e => e.UpdateData)
                .HasColumnType("character varying")
                .HasColumnName("updateData");
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Account_pkey");

            entity.ToTable("Account");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Account1)
                .HasColumnType("character varying")
                .HasColumnName("account");
            entity.Property(e => e.ActiveToken)
                .HasColumnType("character varying")
                .HasColumnName("activeToken");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("statement_timestamp()")
                .HasColumnName("createTime");
            entity.Property(e => e.DrchonoId)
                .HasColumnType("character varying")
                .HasColumnName("drchonoId");
            entity.Property(e => e.IsDelete).HasColumnName("isDelete");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.RefreshToken)
                .HasColumnType("character varying")
                .HasColumnName("refreshToken");
            entity.Property(e => e.RefreshTokenExpiryTime)
                .HasColumnType("character varying")
                .HasColumnName("refreshTokenExpiryTime");
            entity.Property(e => e.Salt)
                .HasColumnType("character varying")
                .HasColumnName("salt");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<AccountPermissionMap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AccountPermission_Map_pkey");

            entity.ToTable("AccountPermission_Map");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("statement_timestamp()")
                .HasColumnName("createTime");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("false")
                .HasColumnName("isDelete");
            entity.Property(e => e.IsDisabled)
                .HasDefaultValueSql("false")
                .HasColumnName("isDisabled");
            entity.Property(e => e.PermissionId).HasColumnName("permissionId");

            entity.HasOne(d => d.Permission).WithMany(p => p.AccountPermissionMaps)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("AccountPermission_Map_permissionId_fkey");
        });

        modelBuilder.Entity<AccountRoleMap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AccountRole_Map_pkey");

            entity.ToTable("AccountRole_Map");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("statement_timestamp()")
                .HasColumnName("createTime");
            entity.Property(e => e.IsDelete).HasColumnName("isDelete");
            entity.Property(e => e.Operate)
                .HasColumnType("character varying")
                .HasColumnName("operate");
            entity.Property(e => e.RoleId).HasColumnName("roleId");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountRoleMaps)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("AccountRole_Map_accountId_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.AccountRoleMaps)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("AccountRole_Map_roleId_fkey");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Appointment_pkey");

            entity.ToTable("Appointment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("statement_timestamp()")
                .HasColumnName("createTime");
            entity.Property(e => e.IsDelete).HasColumnName("isDelete");
            entity.Property(e => e.Note)
                .HasColumnType("character varying")
                .HasColumnName("note");
            entity.Property(e => e.OfficeId).HasColumnName("officeId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.PlatformType)
                .HasColumnType("character varying")
                .HasColumnName("platformType");
            entity.Property(e => e.ScheduledTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("scheduledTime");
            entity.Property(e => e.ServiceType).HasColumnName("serviceType");
            entity.Property(e => e.Status)
                .HasColumnType("character varying")
                .HasColumnName("status");

            entity.HasOne(d => d.Account).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("Appointment_accountId_fkey");

            entity.HasOne(d => d.DrchronoAppointment).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DrchronoAppointmentId)
                .HasConstraintName("Appointment_DrchronoAppointmentId_fkey");

            entity.HasOne(d => d.Office).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.OfficeId)
                .HasConstraintName("Appointment_officeId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("Appointment_patientId_fkey");
        });

        modelBuilder.Entity<AutomationAuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("automation_audit_log_pkey");

            entity.ToTable("automation_audit_log", "audit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiUser)
                .HasColumnType("character varying")
                .HasColumnName("api_user");
            entity.Property(e => e.AppointmentId)
                .HasColumnType("character varying")
                .HasColumnName("appointment_id");
            entity.Property(e => e.DatabaseUser)
                .HasDefaultValueSql("CURRENT_USER")
                .HasColumnType("character varying")
                .HasColumnName("database_user");
            entity.Property(e => e.Event)
                .HasColumnType("jsonb")
                .HasColumnName("event");
            entity.Property(e => e.NewData)
                .HasColumnType("jsonb")
                .HasColumnName("new_data");
            entity.Property(e => e.OriginalData)
                .HasColumnType("jsonb")
                .HasColumnName("original_data");
            entity.Property(e => e.PatientId)
                .HasColumnType("character varying")
                .HasColumnName("patient_id");
            entity.Property(e => e.RequestIp)
                .HasMaxLength(15)
                .HasComment("IP where request originated")
                .HasColumnName("request_ip");
            entity.Property(e => e.ServerIp)
                .HasMaxLength(15)
                .HasDefaultValueSql("inet_client_addr()")
                .HasComment("Server IP that processed the request")
                .HasColumnName("server_ip");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("statement_timestamp()")
                .HasColumnName("timestamp");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<AutomationLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("automation_log_pkey");

            entity.ToTable("automation_log");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Other)
                .HasColumnType("jsonb")
                .HasColumnName("other");
            entity.Property(e => e.PatientId)
                .HasColumnType("character varying")
                .HasColumnName("patient_id");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("statement_timestamp()")
                .HasColumnName("timestamp");
        });

        modelBuilder.Entity<DrchronoAppointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("DrchronoAppointment_pkey");

            entity.ToTable("DrchronoAppointment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DrchronoId)
                .HasColumnType("character varying")
                .HasColumnName("drchronoId");
        });

        modelBuilder.Entity<DrchronoIdLookup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("drchrono_id_lookup_pkey");

            entity.ToTable("drchrono_id_lookup");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DrchronoId)
                .HasColumnType("character varying")
                .HasColumnName("drchrono_id");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("log_pkey");

            entity.ToTable("log", "audit", tb => tb.HasComment("History of auditable actions on audited tables"));

            entity.HasIndex(e => e.Action, "log_action_idx");

            entity.HasIndex(e => e.ActionTstampStm, "log_action_tstamp_tx_stm_idx");

            entity.HasIndex(e => e.Relid, "log_relid_idx");

            entity.Property(e => e.Id)
                .HasComment("Unique identifier for each auditable event")
                .HasColumnName("id");
            entity.Property(e => e.Action)
                .HasComment("Action type; I = insert, D = delete, U = update, T = truncate")
                .HasColumnName("action");
            entity.Property(e => e.ActionTstampClk)
                .HasComment("Wall clock time at which audited event's trigger call occurred")
                .HasColumnName("action_tstamp_clk");
            entity.Property(e => e.ActionTstampStm)
                .HasComment("Statement start timestamp for tx in which audited event occurred")
                .HasColumnName("action_tstamp_stm");
            entity.Property(e => e.ActionTstampTx)
                .HasComment("Transaction start timestamp for tx in which audited event occurred")
                .HasColumnName("action_tstamp_tx");
            entity.Property(e => e.ApplicationName)
                .HasComment("Client-set session application name when this audit event occurred.")
                .HasColumnName("application_name");
            entity.Property(e => e.ApplicationUserName)
                .HasComment("Client-set session application user when this audit event occurred.")
                .HasColumnName("application_user_name");
            entity.Property(e => e.ChangedFields)
                .HasComment("New values of fields for INSERT or changed by UPDATE. Null for DELETE")
                .HasColumnType("jsonb")
                .HasColumnName("changed_fields");
            entity.Property(e => e.ClientAddr)
                .HasComment("IP address of client that issued query. Null for unix domain socket.")
                .HasColumnName("client_addr");
            entity.Property(e => e.ClientPort)
                .HasComment("Port address of client that issued query. Undefined for unix socket.")
                .HasColumnName("client_port");
            entity.Property(e => e.ClientQuery)
                .HasComment("Top-level query that caused this auditable event. May be more than one.")
                .HasColumnName("client_query");
            entity.Property(e => e.CurrentUserName)
                .HasComment("Effective user that cased audited event (if authorization level changed)")
                .HasColumnName("current_user_name");
            entity.Property(e => e.Relid)
                .HasComment("Table OID. Changes with drop/create. Get with 'tablename'::REGCLASS")
                .HasColumnType("oid")
                .HasColumnName("relid");
            entity.Property(e => e.RowData)
                .HasComment("Record value. Null for statement-level trigger. For INSERT this is null. For DELETE and UPDATE it is the old tuple.")
                .HasColumnType("jsonb")
                .HasColumnName("row_data");
            entity.Property(e => e.SchemaName)
                .HasComment("Database schema audited table for this event is in")
                .HasColumnName("schema_name");
            entity.Property(e => e.SessionUserName)
                .HasComment("Login / session user whose statement caused the audited event")
                .HasColumnName("session_user_name");
            entity.Property(e => e.StatementOnly)
                .HasComment("'t' if audit event is from an FOR EACH STATEMENT trigger, 'f' for FOR EACH ROW")
                .HasColumnName("statement_only");
            entity.Property(e => e.TableName)
                .HasComment("Non-schema-qualified table name of table event occured in")
                .HasColumnName("table_name");
            entity.Property(e => e.TransactionId)
                .HasComment("Identifier of transaction that made the change. Unique when paired with action_tstamp_tx.")
                .HasColumnName("transaction_id");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Office_pkey");

            entity.ToTable("Office");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.City)
                .HasColumnType("character varying")
                .HasColumnName("city");
            entity.Property(e => e.DrchronoId)
                .HasColumnType("character varying")
                .HasColumnName("drchronoId");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.State)
                .HasColumnType("character varying")
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasColumnType("character varying")
                .HasColumnName("street");
            entity.Property(e => e.Zip)
                .HasColumnType("character varying")
                .HasColumnName("zip");
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Page_pkey");

            entity.ToTable("Page");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<PatientAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PatientAccount_pkey");

            entity.ToTable("PatientAccount");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Account)
                .HasColumnType("character varying")
                .HasColumnName("account");
            entity.Property(e => e.ActiveToken)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("activeToken");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("statement_timestamp()")
                .HasColumnName("createTime");
            entity.Property(e => e.DrchronoId)
                .HasColumnType("character varying")
                .HasColumnName("drchronoId");
            entity.Property(e => e.IsDelete).HasColumnName("isDelete");
            entity.Property(e => e.LeadsquaredId)
                .HasColumnType("character varying")
                .HasColumnName("leadsquaredId");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.RefreshToken)
                .HasColumnType("character varying")
                .HasColumnName("refreshToken");
            entity.Property(e => e.RefreshTokenExpiryTime)
                .HasColumnType("character varying")
                .HasColumnName("refreshTokenExpiryTime");
            entity.Property(e => e.Salt)
                .HasColumnType("character varying")
                .HasColumnName("salt");
            entity.Property(e => e.Status)
                .HasColumnType("character varying")
                .HasColumnName("status");
        });

        modelBuilder.Entity<PatientProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PatientProfile_pkey");

            entity.ToTable("PatientProfile");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasColumnType("character varying")
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasColumnType("character varying")
                .HasColumnName("country");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("statement_timestamp()")
                .HasColumnName("createTime");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasColumnType("character varying")
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasColumnType("character varying")
                .HasColumnName("lastName");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.Phone)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("phone");
            entity.Property(e => e.Result)
                .HasColumnType("character varying")
                .HasColumnName("result");
            entity.Property(e => e.State)
                .HasColumnType("character varying")
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasColumnType("character varying")
                .HasColumnName("street");
            entity.Property(e => e.ZipCode)
                .HasColumnType("character varying")
                .HasColumnName("zipCode");

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientProfiles)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("PatientProfile_patientId_fkey");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Permission_pkey");

            entity.ToTable("Permission");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("statement_timestamp()")
                .HasColumnName("createTime");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("false")
                .HasColumnName("isDelete");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .HasColumnType("character varying")
                .HasColumnName("note");
            entity.Property(e => e.PageId).HasColumnName("pageId");
            entity.Property(e => e.SortIndex).HasColumnName("sortIndex");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Page).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.PageId)
                .HasConstraintName("Permission_pageId_fkey");
        });

        modelBuilder.Entity<ReferralFormLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ReferralFormLog_pkey");

            entity.ToTable("ReferralFormLog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("statement_timestamp()")
                .HasColumnName("createTime");
            entity.Property(e => e.FormId)
                .HasMaxLength(36)
                .HasColumnName("formId");
            entity.Property(e => e.MethodName)
                .HasColumnType("character varying")
                .HasColumnName("methodName");
            entity.Property(e => e.QueryString)
                .HasColumnType("character varying")
                .HasColumnName("queryString");
            entity.Property(e => e.RequestId)
                .HasColumnType("character varying")
                .HasColumnName("requestId");
            entity.Property(e => e.Section)
                .HasColumnType("character varying")
                .HasColumnName("section");
            entity.Property(e => e.SharepointId)
                .HasColumnType("character varying")
                .HasColumnName("sharepointId");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Role_pkey");

            entity.ToTable("Role");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("statement_timestamp()")
                .HasColumnName("createTime");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsDelete).HasColumnName("isDelete");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.SortIndex).HasColumnName("sortIndex");
        });

        modelBuilder.Entity<RolePermissionMap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("RolePermission_Map_pkey");

            entity.ToTable("RolePermission_Map");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("statement_timestamp()")
                .HasColumnName("createTime");
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("false")
                .HasColumnName("isDelete");
            entity.Property(e => e.PermissionId).HasColumnName("permissionId");
            entity.Property(e => e.RoleId).HasColumnName("roleId");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissionMaps)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("RolePermission_Map_permissionId_fkey");
        });
        modelBuilder.HasSequence<int>("drchrono_id_lookup_id_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
