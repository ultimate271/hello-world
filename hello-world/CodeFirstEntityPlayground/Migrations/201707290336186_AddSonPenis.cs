namespace CodeFirstEntityPlayground.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSonPenis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parents", "Penis", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parents", "Penis");
        }
    }
}
