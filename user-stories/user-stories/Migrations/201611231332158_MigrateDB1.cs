namespace user_stories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VoyageDatas", "BusStopArrival_Id1", "dbo.BusStops");
            DropForeignKey("dbo.VoyageDatas", "BusStopDeparture_Id1", "dbo.BusStops");
            DropIndex("dbo.VoyageDatas", new[] { "BusStopArrival_Id1" });
            DropIndex("dbo.VoyageDatas", new[] { "BusStopDeparture_Id1" });
            RenameColumn(table: "dbo.VoyageDatas", name: "BusStopArrival_Id1", newName: "BusStopArrivalId");
            RenameColumn(table: "dbo.VoyageDatas", name: "BusStopDeparture_Id1", newName: "BusStopDepartureId");
            AlterColumn("dbo.VoyageDatas", "BusStopArrivalId", c => c.Int(nullable: false));
            AlterColumn("dbo.VoyageDatas", "BusStopDepartureId", c => c.Int(nullable: false));
            CreateIndex("dbo.VoyageDatas", "BusStopDepartureId");
            CreateIndex("dbo.VoyageDatas", "BusStopArrivalId");
            AddForeignKey("dbo.VoyageDatas", "BusStopArrivalId", "dbo.BusStops", "Id", cascadeDelete: false);
            AddForeignKey("dbo.VoyageDatas", "BusStopDepartureId", "dbo.BusStops", "Id", cascadeDelete: false);
            DropColumn("dbo.VoyageDatas", "BusStopDeparture_Id");
            DropColumn("dbo.VoyageDatas", "BusStopArrival_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VoyageDatas", "BusStopArrival_Id", c => c.Int(nullable: false));
            AddColumn("dbo.VoyageDatas", "BusStopDeparture_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.VoyageDatas", "BusStopDepartureId", "dbo.BusStops");
            DropForeignKey("dbo.VoyageDatas", "BusStopArrivalId", "dbo.BusStops");
            DropIndex("dbo.VoyageDatas", new[] { "BusStopArrivalId" });
            DropIndex("dbo.VoyageDatas", new[] { "BusStopDepartureId" });
            AlterColumn("dbo.VoyageDatas", "BusStopDepartureId", c => c.Int());
            AlterColumn("dbo.VoyageDatas", "BusStopArrivalId", c => c.Int());
            RenameColumn(table: "dbo.VoyageDatas", name: "BusStopDepartureId", newName: "BusStopDeparture_Id1");
            RenameColumn(table: "dbo.VoyageDatas", name: "BusStopArrivalId", newName: "BusStopArrival_Id1");
            CreateIndex("dbo.VoyageDatas", "BusStopDeparture_Id1");
            CreateIndex("dbo.VoyageDatas", "BusStopArrival_Id1");
            AddForeignKey("dbo.VoyageDatas", "BusStopDeparture_Id1", "dbo.BusStops", "Id");
            AddForeignKey("dbo.VoyageDatas", "BusStopArrival_Id1", "dbo.BusStops", "Id");
        }
    }
}
