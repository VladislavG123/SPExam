namespace ExamSystemProgramming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimeToState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.States", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.States", "DateTime");
        }
    }
}
