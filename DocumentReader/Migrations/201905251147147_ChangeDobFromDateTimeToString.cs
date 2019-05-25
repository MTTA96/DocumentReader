namespace DocumentReader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDobFromDateTimeToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Soldiers", "Dob", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Soldiers", "Dob", c => c.DateTime(nullable: false));
        }
    }
}
