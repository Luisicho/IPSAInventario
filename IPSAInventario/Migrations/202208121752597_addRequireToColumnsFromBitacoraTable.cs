namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequireToColumnsFromBitacoraTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bitacora", "Falla_Reportada", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Bitacora", "Que_Presenta", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Bitacora", "Reporto", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Bitacora", "Ubicacion", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bitacora", "Ubicacion", c => c.String(unicode: false));
            AlterColumn("dbo.Bitacora", "Reporto", c => c.String(unicode: false));
            AlterColumn("dbo.Bitacora", "Que_Presenta", c => c.String(unicode: false));
            AlterColumn("dbo.Bitacora", "Falla_Reportada", c => c.String(unicode: false));
        }
    }
}
