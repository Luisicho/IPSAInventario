namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyAuxiliarTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Auxiliar", "Funcionando", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Auxiliar", "Funcionando", c => c.Boolean());
        }
    }
}
