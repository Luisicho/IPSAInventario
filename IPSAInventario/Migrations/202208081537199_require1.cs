namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class require1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hardware", "Velocidad", c => c.Int());
            DropColumn("dbo.Hardware", "Velocidada");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hardware", "Velocidada", c => c.Int());
            DropColumn("dbo.Hardware", "Velocidad");
        }
    }
}
