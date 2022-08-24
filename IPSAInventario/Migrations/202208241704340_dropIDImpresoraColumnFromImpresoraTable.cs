namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropIDImpresoraColumnFromImpresoraTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Impresora", "IDImpresora");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Impresora", "IDImpresora", c => c.String(unicode: false));
        }
    }
}
