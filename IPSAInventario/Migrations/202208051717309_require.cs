namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class require : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Factura_Detalle_Soft", "Responsable", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Factura_Detalle_Soft", "Responsable", c => c.String(unicode: false));
        }
    }
}
