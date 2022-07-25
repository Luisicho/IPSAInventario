namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoblandoProveedores : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Proveedores VALUES ('Juan')");
            Sql("INSERT INTO Proveedores VALUES ('Pepe')");
            Sql("INSERT INTO Proveedores VALUES ('Felipe')");
        }
        
        public override void Down()
        {
        }
    }
}
