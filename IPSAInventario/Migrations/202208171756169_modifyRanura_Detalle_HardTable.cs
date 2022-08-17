namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyRanura_Detalle_HardTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Ranura_Detalle_Hard");
            AddColumn("dbo.Ranura_Detalle_Hard", "idRanura_Detalle_Hard", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Ranura_Detalle_Hard", "idRanura_Detalle_Hard");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Ranura_Detalle_Hard");
            DropColumn("dbo.Ranura_Detalle_Hard", "idRanura_Detalle_Hard");
            AddPrimaryKey("dbo.Ranura_Detalle_Hard", new[] { "IDRanura", "IDHardware" });
        }
    }
}
