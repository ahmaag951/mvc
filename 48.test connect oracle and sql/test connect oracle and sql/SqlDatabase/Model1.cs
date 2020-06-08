namespace test_connect_oracle_and_sql.SqlDatabase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model12")
        {
        }

        public virtual DbSet<ACTATEK_LOGS> ACTATEK_LOGS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACTATEK_LOGS>()
                .Property(e => e.userID)
                .IsUnicode(false);

            modelBuilder.Entity<ACTATEK_LOGS>()
                .Property(e => e.eventID)
                .IsUnicode(false);

            modelBuilder.Entity<ACTATEK_LOGS>()
                .Property(e => e.terminalSN)
                .IsUnicode(false);
        }
    }
}
