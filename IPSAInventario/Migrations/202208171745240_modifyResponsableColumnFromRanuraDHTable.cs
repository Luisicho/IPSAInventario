namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyResponsableColumnFromRanuraDHTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ranura_Detalle_Hard", "Responsable", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ranura_Detalle_Hard", "Responsable", c => c.String(unicode: false));
        }
    }
}
