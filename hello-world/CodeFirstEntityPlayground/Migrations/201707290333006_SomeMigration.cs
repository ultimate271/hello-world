namespace CodeFirstEntityPlayground.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parents", "Legs", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parents", "Legs");
        }
    }
}
