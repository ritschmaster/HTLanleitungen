namespace MusicDataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MusicDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duration = c.Int(nullable: false),
                        InterpreterId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SongId)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Interpreters", t => t.InterpreterId, cascadeDelete: true)
                .Index(t => t.InterpreterId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Interpreters",
                c => new
                    {
                        InterpreterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.InterpreterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "InterpreterId", "dbo.Interpreters");
            DropForeignKey("dbo.Songs", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Songs", new[] { "AlbumId" });
            DropIndex("dbo.Songs", new[] { "InterpreterId" });
            DropTable("dbo.Interpreters");
            DropTable("dbo.Songs");
            DropTable("dbo.Albums");
        }
    }
}
