namespace test_connect_oracle_and_sql.SqlDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ACTATEK_LOGS
    {
        [Key]
        public long SID { get; set; }

        [Required]
        [StringLength(20)]
        public string userID { get; set; }

        public DateTime? timeentry { get; set; }

        [StringLength(20)]
        public string eventID { get; set; }

        [StringLength(20)]
        public string terminalSN { get; set; }

        public byte[] jpegPhoto { get; set; }

        public DateTime? TransDate { get; set; }

        public DateTime? TransTime { get; set; }

        public DateTime? LastModified { get; set; }

        public bool? ManualTrans { get; set; }

        public bool? Updated { get; set; }

        public long? FromSID { get; set; }

        public DateTime? Actatektimeentry { get; set; }

        public double? TimeDifferentAboutGMT { get; set; }

        [StringLength(50)]
        public string terminalIP { get; set; }

        [StringLength(50)]
        public string remark { get; set; }

        [StringLength(50)]
        public string terminalName { get; set; }

        [StringLength(50)]
        public string logID { get; set; }

        public long? Emp_SID { get; set; }

        public int? CSC_Result_SID { get; set; }

        public bool IsTransfered_CSC { get; set; }

        public bool? IsUpdated_IN_OUT { get; set; }

        public string ImagePath { get; set; }

        [StringLength(2000)]
        public string ConirmData { get; set; }
    }
}
