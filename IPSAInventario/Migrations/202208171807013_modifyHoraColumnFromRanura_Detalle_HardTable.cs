namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyHoraColumnFromRanura_Detalle_HardTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ranura_Detalle_Hard", "FechaHora", c => c.Int(nullable: false));
            DropColumn("dbo.Ranura_Detalle_Hard", "Hora");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ranura_Detalle_Hard", "Hora", c => c.Time(precision: 7));
            DropColumn("dbo.Ranura_Detalle_Hard", "FechaHora");
        }
    }
}
