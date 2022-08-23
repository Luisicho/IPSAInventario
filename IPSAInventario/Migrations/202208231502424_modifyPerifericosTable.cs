namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyPerifericosTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Perifericos", "Revisado", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Perifericos", "Disponibilidad", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Perifericos", "Check_", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Perifericos", "Check_", c => c.Boolean());
            AlterColumn("dbo.Perifericos", "Disponibilidad", c => c.Boolean());
            AlterColumn("dbo.Perifericos", "Revisado", c => c.Boolean());
        }
    }
}
