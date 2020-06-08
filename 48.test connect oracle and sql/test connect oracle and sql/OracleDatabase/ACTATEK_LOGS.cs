namespace test_connect_oracle_and_sql.OracleDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("APEXTA.ACTATEK_LOGS")]
    public partial class ACTATEK_LOGS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SID { get; set; }

        [Required]
        [StringLength(20)]
        public string USERID { get; set; }

        public DateTime? TIMEENTRY { get; set; }

        [StringLength(20)]
        public string EVENTID { get; set; }

        [StringLength(20)]
        public string TERMINALSN { get; set; }

        public byte[] JPEGPHOTO { get; set; }

        public DateTime? TRANSDATE { get; set; }

        public DateTime? TRANSTIME { get; set; }

        public DateTime? LASTMODIFIED { get; set; }

        public bool? MANUALTRANS { get; set; }

        public bool? UPDATED { get; set; }

        public long? FROMSID { get; set; }

        public DateTime? ACTATEKTIMEENTRY { get; set; }

        [Column(TypeName = "float")]
        public decimal? TIMEDIFFERENTABOUTGMT { get; set; }

        [StringLength(50)]
        public string TERMINALIP { get; set; }

        [StringLength(50)]
        public string REMARK { get; set; }

        [StringLength(50)]
        public string TERMINALNAME { get; set; }

        [StringLength(50)]
        public string LOGID { get; set; }

        public long? EMP_SID { get; set; }

        public int? CSC_RESULT_SID { get; set; }

        public bool ISTRANSFERED_CSC { get; set; }

        public bool? ISUPDATED_IN_OUT { get; set; }

        [StringLength(2000)]
        public string IMAGEPATH { get; set; }

        [StringLength(2000)]
        public string CONIRMDATA { get; set; }
    }
}
