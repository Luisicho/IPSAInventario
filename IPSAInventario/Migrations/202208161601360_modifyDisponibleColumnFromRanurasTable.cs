namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyDisponibleColumnFromRanurasTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ranuras", "Disponible", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ranuras", "Disponible", c => c.Boolean());
        }
    }
}
