namespace user_stories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VoyageDatas", "BusStopArrival_Id", "dbo.BusStops");
            DropForeignKey("dbo.VoyageDatas", "BusStopDeparture_Id", "dbo.BusStops");
            DropIndex("dbo.VoyageDatas", new[] { "BusStopArrival_Id" });
            DropIndex("dbo.VoyageDatas", new[] { "BusStopDeparture_Id" });
            AddColumn("dbo.VoyageDatas", "BusStopArrival_Id1", c => c.Int());
            AddColumn("dbo.VoyageDatas", "BusStopDeparture_Id1", c => c.Int());
            AlterColumn("dbo.VoyageDatas", "BusStopArrival_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.VoyageDatas", "BusStopDeparture_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.VoyageDatas", "BusStopArrival_Id1");
            CreateIndex("dbo.VoyageDatas", "BusStopDeparture_Id1");
            AddForeignKey("dbo.VoyageDatas", "BusStopArrival_Id1", "dbo.BusStops", "Id");
            AddForeignKey("dbo.VoyageDatas", "BusStopDeparture_Id1", "dbo.BusStops", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VoyageDatas", "BusStopDeparture_Id1", "dbo.BusStops");
            DropForeignKey("dbo.VoyageDatas", "BusStopArrival_Id1", "dbo.BusStops");
            DropIndex("dbo.VoyageDatas", new[] { "BusStopDeparture_Id1" });
            DropIndex("dbo.VoyageDatas", new[] { "BusStopArrival_Id1" });
            AlterColumn("dbo.VoyageDatas", "BusStopDeparture_Id", c => c.Int());
            AlterColumn("dbo.VoyageDatas", "BusStopArrival_Id", c => c.Int());
            DropColumn("dbo.VoyageDatas", "BusStopDeparture_Id1");
            DropColumn("dbo.VoyageDatas", "BusStopArrival_Id1");
            CreateIndex("dbo.VoyageDatas", "BusStopDeparture_Id");
            CreateIndex("dbo.VoyageDatas", "BusStopArrival_Id");
            AddForeignKey("dbo.VoyageDatas", "BusStopDeparture_Id", "dbo.BusStops", "Id");
            AddForeignKey("dbo.VoyageDatas", "BusStopArrival_Id", "dbo.BusStops", "Id");
        }
    }
}
