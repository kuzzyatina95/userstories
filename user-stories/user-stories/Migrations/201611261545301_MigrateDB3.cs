namespace user_stories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "PassengerFirstAndLastName", c => c.String(nullable: false));
            AlterColumn("dbo.Tickets", "PassengerDocumentNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "PassengerDocumentNumber", c => c.String());
            AlterColumn("dbo.Tickets", "PassengerFirstAndLastName", c => c.String());
        }
    }
}
