namespace IPSAInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropTriggersTGR_INST_HARDWARE_TGR_INST_PERIFERICO : DbMigration
    {
        public override void Up()
        {
            Sql("DROP TRIGGER TGR_INST_HARDWARE");
            Sql("DROP TRIGGER TGR_INST_PERIFERICO");
        }
        
        public override void Down()
        {
        }
    }
}
