namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyComputadoraColumnsBool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Computadora", "Actualizado", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Computadora", "Check_", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Computadora", "Red", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Computadora", "Red", c => c.Boolean());
            AlterColumn("dbo.Computadora", "Check_", c => c.Boolean());
            AlterColumn("dbo.Computadora", "Actualizado", c => c.Boolean());
        }
    }
}
