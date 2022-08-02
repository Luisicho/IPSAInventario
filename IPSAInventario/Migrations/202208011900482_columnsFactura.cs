namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnsFactura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Factura", "Nombre_Factura", c => c.String());
            AddColumn("dbo.Factura", "Nombre_Requisicion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Factura", "Nombre_Requisicion");
            DropColumn("dbo.Factura", "Nombre_Factura");
        }
    }
}
