namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropIDMonitorColumnFromMonitorTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Monitor", "IDMonitor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Monitor", "IDMonitor", c => c.String(unicode: false));
        }
    }
}
