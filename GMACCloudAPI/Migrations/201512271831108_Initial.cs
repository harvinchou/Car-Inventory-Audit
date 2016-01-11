namespace GMACCloudAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetCheckItems",
                c => new
                    {
                        TaskCode = c.String(nullable: false, maxLength: 30),
                        VIN = c.String(nullable: false, maxLength: 30),
                        RFIDCode = c.String(),
                        GPS = c.String(),
                        ScannedOn = c.String(),
                        ResultStatus = c.String(),
                        ResultComment = c.String(),
                    })
                .PrimaryKey(t => new { t.TaskCode, t.VIN });
            
            CreateTable(
                "dbo.AssetCheckJobs",
                c => new
                    {
                        TaskCode = c.String(nullable: false, maxLength: 30),
                        Dealer = c.String(),
                        OperatorLoginAccount = c.String(),
                        TaskStatus = c.String(),
                        CreatedOn = c.String(),
                        CompletedOn = c.String(),
                        ResultStatus = c.String(),
                        ResultComment = c.String(),
                    })
                .PrimaryKey(t => t.TaskCode);
            
            CreateTable(
                "dbo.AssetRegistrations",
                c => new
                    {
                        VIN = c.String(nullable: false, maxLength: 30),
                        RFIDCode = c.String(),
                        Dealer = c.String(),
                        Status = c.String(),
                        OperatorLoginAccount = c.String(),
                        CreatedOn = c.String(),
                    })
                .PrimaryKey(t => t.VIN);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        LoginAccount = c.String(nullable: false, maxLength: 30),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.LoginAccount);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.AssetRegistrations");
            DropTable("dbo.AssetCheckJobs");
            DropTable("dbo.AssetCheckItems");
        }
    }
}
