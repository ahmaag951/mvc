namespace mvc_template.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "Type");
        }
    }
}
