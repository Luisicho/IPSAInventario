namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Computadora_SoftwareTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Software", "Product_Key", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Software", "Product_Key", c => c.String(unicode: false));
        }
    }
}
