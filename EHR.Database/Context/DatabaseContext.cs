using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EHR.Database.Entities;

namespace EHR.Database.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessLog> AccessLogs { get; set; } = null!;
        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountPermissionMap> AccountPermissionMaps { get; set; } = null!;
        public virtual DbSet<AccountProfile> AccountProfiles { get; set; } = null!;
        public virtual DbSet<AccountRoleMap> AccountRoleMaps { get; set; } = null!;
        public virtual DbSet<AutomationAuditLog> AutomationAuditLogs { get; set; } = null!;
        public virtual DbSet<AutomationLog> AutomationLogs { get; set; } = null!;
        public virtual DbSet<DrchronoIdLookup> DrchronoIdLookups { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Office> Offices { get; set; } = null!;
        public virtual DbSet<Page> Pages { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RolePermissionMap> RolePermissionMaps { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=aurora-auroradatabase5475d328-1fhhlc5ey771i.cluster-csgv9gisrp7z.us-east-2.rds.amazonaws.com:48040;Database=development;Username=cluster_root;Password=M^us{Ovk]]K+#I=LE3w(UpfeBD?0-7Rn");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum("Operation", new[] { "C", "R", "U", "D" })
                .HasPostgresEnum("status", new[] { "FAILED", "SUCCEEDED", "SKIPPED" })
                .HasPostgresEnum("type", new[] { "PROFILE", "CLINICAL_NOTE", "DOCUMENT", "SKIPPED", "PATIENT" })
                .HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<AccessLog>(entity =>
            {
                entity.ToTable("AccessLog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

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
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("statement_timestamp()");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.ModifyUserId).HasColumnName("modifyUserId");

                entity.Property(e => e.OrignData)
                    .HasColumnType("character varying")
                    .HasColumnName("orignData");

                entity.Property(e => e.UpdateData)
                    .HasColumnType("character varying")
                    .HasColumnName("updateData");

                entity.HasOne(d => d.ModifyUser)
                    .WithMany(p => p.AccessLogs)
                    .HasForeignKey(d => d.ModifyUserId)
                    .HasConstraintName("AccessLog_modifyUserId_fkey");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.ActiveToken)
                    .HasColumnType("character varying")
                    .HasColumnName("activeToken");

                entity.Property(e => e.CreateTime).HasColumnName("createTime");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Password)
                    .HasColumnType("character varying")
                    .HasColumnName("password");

                entity.Property(e => e.RefreshToken).HasColumnName("refreshToken");

                entity.Property(e => e.RefreshTokenExpiry).HasColumnName("refreshTokenExpiry");

                entity.Property(e => e.StaffAccount)
                    .HasColumnType("character varying")
                    .HasColumnName("staffAccount");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<AccountPermissionMap>(entity =>
            {
                entity.ToTable("AccountPermission_Map");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("statement_timestamp()");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsDisabled)
                    .HasColumnName("isDisabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.PermissionId).HasColumnName("permissionId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountPermissionMaps)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("AccountPermission_Map_accountId_fkey");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.AccountPermissionMaps)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("AccountPermission_Map_permissionId_fkey");
            });

            modelBuilder.Entity<AccountProfile>(entity =>
            {
                entity.ToTable("AccountProfile");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.City)
                    .HasColumnType("character varying")
                    .HasColumnName("city");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("statement_timestamp()");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasColumnType("character varying")
                    .HasColumnName("firstName");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.LastName)
                    .HasColumnType("character varying")
                    .HasColumnName("lastName");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.Phone)
                    .HasColumnType("character varying")
                    .HasColumnName("phone");

                entity.Property(e => e.State)
                    .HasColumnType("character varying")
                    .HasColumnName("state");

                entity.Property(e => e.Street)
                    .HasColumnType("character varying")
                    .HasColumnName("street");

                entity.Property(e => e.Title)
                    .HasColumnType("character varying")
                    .HasColumnName("title");

                entity.Property(e => e.ZipCode)
                    .HasColumnType("character varying")
                    .HasColumnName("zipCode");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountProfiles)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("AccountProfile_account_id_fkey");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.AccountProfiles)
                    .HasForeignKey(d => d.OfficeId)
                    .HasConstraintName("AccountProfile_office_id_fkey");
            });

            modelBuilder.Entity<AccountRoleMap>(entity =>
            {
                entity.ToTable("AccountRole_Map");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("statement_timestamp()");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Operate).HasColumnName("operate");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountRoleMaps)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("AccountRole_Map_accountId_fkey");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AccountRoleMaps)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("AccountRole_Map_roleId_fkey");
            });

            modelBuilder.Entity<AutomationAuditLog>(entity =>
            {
                entity.ToTable("automation_audit_log", "audit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApiUser)
                    .HasColumnType("character varying")
                    .HasColumnName("api_user");

                entity.Property(e => e.AppointmentId)
                    .HasColumnType("character varying")
                    .HasColumnName("appointment_id");

                entity.Property(e => e.DatabaseUser)
                    .HasColumnType("character varying")
                    .HasColumnName("database_user")
                    .HasDefaultValueSql("CURRENT_USER");

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
                    .HasColumnName("request_ip")
                    .HasComment("IP where request originated");

                entity.Property(e => e.ServerIp)
                    .HasMaxLength(15)
                    .HasColumnName("server_ip")
                    .HasDefaultValueSql("inet_client_addr()")
                    .HasComment("Server IP that processed the request");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasDefaultValueSql("statement_timestamp()");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<AutomationLog>(entity =>
            {
                entity.ToTable("automation_log");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Other)
                    .HasColumnType("jsonb")
                    .HasColumnName("other");

                entity.Property(e => e.PatientId)
                    .HasColumnType("character varying")
                    .HasColumnName("patient_id");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasDefaultValueSql("statement_timestamp()");
            });

            modelBuilder.Entity<DrchronoIdLookup>(entity =>
            {
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
                entity.ToTable("log", "audit");

                entity.HasComment("History of auditable actions on audited tables");

                entity.HasIndex(e => e.Action, "log_action_idx");

                entity.HasIndex(e => e.ActionTstampStm, "log_action_tstamp_tx_stm_idx");

                entity.HasIndex(e => e.Relid, "log_relid_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Unique identifier for each auditable event");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasComment("Action type; I = insert, D = delete, U = update, T = truncate");

                entity.Property(e => e.ActionTstampClk)
                    .HasColumnName("action_tstamp_clk")
                    .HasComment("Wall clock time at which audited event's trigger call occurred");

                entity.Property(e => e.ActionTstampStm)
                    .HasColumnName("action_tstamp_stm")
                    .HasComment("Statement start timestamp for tx in which audited event occurred");

                entity.Property(e => e.ActionTstampTx)
                    .HasColumnName("action_tstamp_tx")
                    .HasComment("Transaction start timestamp for tx in which audited event occurred");

                entity.Property(e => e.ApplicationName)
                    .HasColumnName("application_name")
                    .HasComment("Client-set session application name when this audit event occurred.");

                entity.Property(e => e.ApplicationUserName)
                    .HasColumnName("application_user_name")
                    .HasComment("Client-set session application user when this audit event occurred.");

                entity.Property(e => e.ChangedFields)
                    .HasColumnType("jsonb")
                    .HasColumnName("changed_fields")
                    .HasComment("New values of fields for INSERT or changed by UPDATE. Null for DELETE");

                entity.Property(e => e.ClientAddr)
                    .HasColumnName("client_addr")
                    .HasComment("IP address of client that issued query. Null for unix domain socket.");

                entity.Property(e => e.ClientPort)
                    .HasColumnName("client_port")
                    .HasComment("Port address of client that issued query. Undefined for unix socket.");

                entity.Property(e => e.ClientQuery)
                    .HasColumnName("client_query")
                    .HasComment("Top-level query that caused this auditable event. May be more than one.");

                entity.Property(e => e.CurrentUserName)
                    .HasColumnName("current_user_name")
                    .HasComment("Effective user that cased audited event (if authorization level changed)");

                entity.Property(e => e.Relid)
                    .HasColumnType("oid")
                    .HasColumnName("relid")
                    .HasComment("Table OID. Changes with drop/create. Get with 'tablename'::REGCLASS");

                entity.Property(e => e.RowData)
                    .HasColumnType("jsonb")
                    .HasColumnName("row_data")
                    .HasComment("Record value. Null for statement-level trigger. For INSERT this is null. For DELETE and UPDATE it is the old tuple.");

                entity.Property(e => e.SchemaName)
                    .HasColumnName("schema_name")
                    .HasComment("Database schema audited table for this event is in");

                entity.Property(e => e.SessionUserName)
                    .HasColumnName("session_user_name")
                    .HasComment("Login / session user whose statement caused the audited event");

                entity.Property(e => e.StatementOnly)
                    .HasColumnName("statement_only")
                    .HasComment("'t' if audit event is from an FOR EACH STATEMENT trigger, 'f' for FOR EACH ROW");

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name")
                    .HasComment("Non-schema-qualified table name of table event occured in");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("transaction_id")
                    .HasComment("Identifier of transaction that made the change. Unique when paired with action_tstamp_tx.");
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.ToTable("Office");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.City)
                    .HasColumnType("character varying")
                    .HasColumnName("city");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.State)
                    .HasColumnType("character varying")
                    .HasColumnName("state");

                entity.Property(e => e.Street)
                    .HasColumnType("character varying")
                    .HasColumnName("street");

                entity.Property(e => e.ZipCode)
                    .HasColumnType("character varying")
                    .HasColumnName("zipCode");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("Page");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Code)
                    .HasColumnType("character varying")
                    .HasColumnName("code");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("statement_timestamp()");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Note)
                    .HasColumnType("character varying")
                    .HasColumnName("note");

                entity.Property(e => e.PageId).HasColumnName("pageId");

                entity.Property(e => e.SortIndex).HasColumnName("sortIndex");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.PageId)
                    .HasConstraintName("Permission_pageId_fkey");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Code)
                    .HasColumnType("character varying")
                    .HasColumnName("code");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("statement_timestamp()");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.SortIndex).HasColumnName("sortIndex");
            });

            modelBuilder.Entity<RolePermissionMap>(entity =>
            {
                entity.ToTable("RolePermission_Map");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("statement_timestamp()");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.PermissionId).HasColumnName("permissionId");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermissionMaps)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("RolePermission_Map_permissionId_fkey");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermissionMaps)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("RolePermission_Map_roleId_fkey");
            });

            modelBuilder.HasSequence<int>("drchrono_id_lookup_id_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
