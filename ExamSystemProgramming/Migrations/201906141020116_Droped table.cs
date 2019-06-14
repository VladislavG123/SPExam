namespace ExamSystemProgramming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dropedtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.States", "DownloadInfo_Id", "dbo.DownloadInfoes");
            DropIndex("dbo.States", new[] { "DownloadInfo_Id" });
            DropTable("dbo.States");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Status = c.String(),
                        DownloadInfo_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.States", "DownloadInfo_Id");
            AddForeignKey("dbo.States", "DownloadInfo_Id", "dbo.DownloadInfoes", "Id");
        }
    }
}
