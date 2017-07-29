namespace CodeFirstEntityPlayground.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        ParentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Knees = c.Int(),
                        Elbows = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ParentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Parents");
        }
    }
}
