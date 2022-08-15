namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyDisponibleColumnFromDisponbilidadTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Disponibilidad", "Disponible", c => c.Boolean(nullable: false));
            DropColumn("dbo.Disponibilidad", "Disponiblilidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Disponibilidad", "Disponiblilidad", c => c.Boolean());
            DropColumn("dbo.Disponibilidad", "Disponible");
        }
    }
}
