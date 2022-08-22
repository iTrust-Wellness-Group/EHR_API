using System;
using System.Collections.Generic;
using System.Net;

namespace EHR.Database.Entities
{
    /// <summary>
    /// History of auditable actions on audited tables
    /// </summary>
    public partial class Log
    {
        /// <summary>
        /// Unique identifier for each auditable event
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Database schema audited table for this event is in
        /// </summary>
        public string SchemaName { get; set; } = null!;
        /// <summary>
        /// Non-schema-qualified table name of table event occured in
        /// </summary>
        public string TableName { get; set; } = null!;
        /// <summary>
        /// Table OID. Changes with drop/create. Get with &apos;tablename&apos;::REGCLASS
        /// </summary>
        public uint Relid { get; set; }
        /// <summary>
        /// Login / session user whose statement caused the audited event
        /// </summary>
        public string SessionUserName { get; set; } = null!;
        /// <summary>
        /// Effective user that cased audited event (if authorization level changed)
        /// </summary>
        public string CurrentUserName { get; set; } = null!;
        /// <summary>
        /// Transaction start timestamp for tx in which audited event occurred
        /// </summary>
        public DateTime ActionTstampTx { get; set; }
        /// <summary>
        /// Statement start timestamp for tx in which audited event occurred
        /// </summary>
        public DateTime ActionTstampStm { get; set; }
        /// <summary>
        /// Wall clock time at which audited event&apos;s trigger call occurred
        /// </summary>
        public DateTime ActionTstampClk { get; set; }
        /// <summary>
        /// Identifier of transaction that made the change. Unique when paired with action_tstamp_tx.
        /// </summary>
        public long TransactionId { get; set; }
        /// <summary>
        /// Client-set session application name when this audit event occurred.
        /// </summary>
        public string? ApplicationName { get; set; }
        /// <summary>
        /// Client-set session application user when this audit event occurred.
        /// </summary>
        public string? ApplicationUserName { get; set; }
        /// <summary>
        /// IP address of client that issued query. Null for unix domain socket.
        /// </summary>
        public IPAddress? ClientAddr { get; set; }
        /// <summary>
        /// Port address of client that issued query. Undefined for unix socket.
        /// </summary>
        public int? ClientPort { get; set; }
        /// <summary>
        /// Top-level query that caused this auditable event. May be more than one.
        /// </summary>
        public string? ClientQuery { get; set; }
        /// <summary>
        /// Action type; I = insert, D = delete, U = update, T = truncate
        /// </summary>
        public string Action { get; set; } = null!;
        /// <summary>
        /// Record value. Null for statement-level trigger. For INSERT this is null. For DELETE and UPDATE it is the old tuple.
        /// </summary>
        public string? RowData { get; set; }
        /// <summary>
        /// New values of fields for INSERT or changed by UPDATE. Null for DELETE
        /// </summary>
        public string? ChangedFields { get; set; }
        /// <summary>
        /// &apos;t&apos; if audit event is from an FOR EACH STATEMENT trigger, &apos;f&apos; for FOR EACH ROW
        /// </summary>
        public bool StatementOnly { get; set; }
    }
}
