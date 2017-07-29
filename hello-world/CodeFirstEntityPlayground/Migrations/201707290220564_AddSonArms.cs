namespace CodeFirstEntityPlayground.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSonArms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parents", "Arms", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parents", "Arms");
        }
    }
}
