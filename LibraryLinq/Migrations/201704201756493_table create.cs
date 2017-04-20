namespace LibraryLinq.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablecreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        YearPublished = c.Int(nullable: false),
                        Genre = c.String(),
                        IsCheckedout = c.Boolean(nullable: false),
                        LastCheckedOutDate = c.DateTime(nullable: false),
                        DueBackDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
