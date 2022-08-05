namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disponibilidadSoftware : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Software", "Disponibilidad", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Software", "Disponibilidad", c => c.Boolean());
        }
    }
}
