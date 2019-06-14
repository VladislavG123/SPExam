namespace ExamSystemProgramming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReturnedTheTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Status = c.String(),
                        DownloadInfo_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DownloadInfoes", t => t.DownloadInfo_Id)
                .Index(t => t.DownloadInfo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.States", "DownloadInfo_Id", "dbo.DownloadInfoes");
            DropIndex("dbo.States", new[] { "DownloadInfo_Id" });
            DropTable("dbo.States");
        }
    }
}
