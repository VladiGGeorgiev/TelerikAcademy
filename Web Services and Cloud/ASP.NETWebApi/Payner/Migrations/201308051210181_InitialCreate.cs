namespace Payner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Album_AlbumId = c.Int(),
                    })
                .PrimaryKey(t => t.ArtistId)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId)
                .Index(t => t.Album_AlbumId);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.DateTime(nullable: false),
                        Producer = c.String(),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.DateTime(nullable: false),
                        Genre = c.String(),
                        Artist_ArtistId = c.Int(),
                        Album_AlbumId = c.Int(),
                    })
                .PrimaryKey(t => t.SongId)
                .ForeignKey("dbo.Artists", t => t.Artist_ArtistId)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId)
                .Index(t => t.Artist_ArtistId)
                .Index(t => t.Album_AlbumId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Songs", new[] { "Album_AlbumId" });
            DropIndex("dbo.Songs", new[] { "Artist_ArtistId" });
            DropIndex("dbo.Artists", new[] { "Album_AlbumId" });
            DropForeignKey("dbo.Songs", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Songs", "Artist_ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Artists", "Album_AlbumId", "dbo.Albums");
            DropTable("dbo.Songs");
            DropTable("dbo.Albums");
            DropTable("dbo.Artists");
        }
    }
}
