namespace test_connect_oracle_and_sql.OracleDatabase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<ACTATEK_LOGS> ACTATEK_LOGS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACTATEK_LOGS>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<ACTATEK_LOGS>()
                .Property(e => e.EVENTID)
                .IsUnicode(false);

            modelBuilder.Entity<ACTATEK_LOGS>()
                .Property(e => e.TERMINALSN)
                .IsUnicode(false);

            modelBuilder.Entity<ACTATEK_LOGS>()
                .Property(e => e.TIMEDIFFERENTABOUTGMT)
                .HasPrecision(16, 0);
        }
    }
}
