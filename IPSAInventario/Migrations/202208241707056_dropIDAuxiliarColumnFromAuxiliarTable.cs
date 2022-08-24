namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropIDAuxiliarColumnFromAuxiliarTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Auxiliar", "IDAuxiliar");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auxiliar", "IDAuxiliar", c => c.String(unicode: false));
        }
    }
}
