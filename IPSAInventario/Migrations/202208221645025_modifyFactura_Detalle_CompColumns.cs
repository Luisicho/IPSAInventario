namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyFactura_Detalle_CompColumns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Factura_Detalle_Comp", "Responsable", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Factura_Detalle_Comp", "Responsable", c => c.String(unicode: false));
        }
    }
}
