namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterTamanoColumnFromMonitorTabla : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Monitor", "Tamano", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Monitor", "Tamano", c => c.Int());
        }
    }
}
