namespace BitBookMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigrationForBitBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentCity = c.String(maxLength: 50, unicode: false),
                        CurrentCountry = c.String(maxLength: 50, unicode: false),
                        FromCity = c.String(maxLength: 50, unicode: false),
                        FromCountry = c.String(maxLength: 50, unicode: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(maxLength: 500, unicode: false),
                        PostId = c.Int(),
                        Time = c.DateTime(),
                        WhoCommentedId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.WhoCommentedId)
                .Index(t => t.WhoCommentedId);
            
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Institute = c.String(maxLength: 50, unicode: false),
                        FromDate = c.DateTime(storeType: "date"),
                        ToDate = c.DateTime(storeType: "date"),
                        HasDegree = c.Boolean(),
                        Degree = c.String(maxLength: 50, unicode: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FamilyMember",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FamilyMemberId = c.Int(),
                        Relationship = c.String(maxLength: 50, unicode: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.FamilyMemberId)
                .Index(t => t.FamilyMemberId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FriendList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FriendId = c.Int(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FriendRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(),
                        ReceiverId = c.Int(),
                        IsAccepted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.SenderId)
                .ForeignKey("dbo.Users", t => t.ReceiverId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.Interest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InterestedIn = c.String(maxLength: 500, unicode: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(),
                        WhoLikedId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.WhoLikedId)
                .Index(t => t.WhoLikedId);
            
            CreateTable(
                "dbo.MobileNo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MobileNo = c.String(maxLength: 50, unicode: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Post = c.String(maxLength: 5000, unicode: false),
                        PicUrl = c.String(maxLength: 500, unicode: false),
                        IsText = c.Boolean(),
                        IsPic = c.Boolean(),
                        Date = c.DateTime(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProfessionalSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Skill = c.String(maxLength: 200, unicode: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50, unicode: false),
                        LastName = c.String(maxLength: 50, unicode: false),
                        FullName = c.String(maxLength: 50, unicode: false),
                        DOB = c.DateTime(storeType: "date"),
                        Gender = c.String(maxLength: 10, fixedLength: true),
                        ProPicId = c.Int(),
                        CoverPicId = c.Int(),
                        Religion = c.String(maxLength: 50, unicode: false),
                        HasRelationship = c.Boolean(),
                        Relationship = c.String(maxLength: 50, unicode: false),
                        RelationshipWithId = c.Int(),
                        About = c.String(maxLength: 50, unicode: false),
                        CreateDate = c.DateTime(storeType: "date"),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Work",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(maxLength: 50, unicode: false),
                        Position = c.String(maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 50, unicode: false),
                        City = c.String(maxLength: 50, unicode: false),
                        Country = c.String(maxLength: 50, unicode: false),
                        FromDate = c.DateTime(storeType: "date"),
                        ToDate = c.DateTime(storeType: "date"),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GetFriendRequestView",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SenderId = c.Int(),
                        ReceiverId = c.Int(),
                        FullName = c.String(maxLength: 50, unicode: false),
                        ProPic = c.String(maxLength: 50, unicode: false),
                        IsAccepted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Work", "UserId", "dbo.Users");
            DropForeignKey("dbo.Profile", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProfessionalSkills", "UserId", "dbo.Users");
            DropForeignKey("dbo.Post", "UserId", "dbo.Users");
            DropForeignKey("dbo.MobileNo", "UserId", "dbo.Users");
            DropForeignKey("dbo.Like", "WhoLikedId", "dbo.Users");
            DropForeignKey("dbo.Interest", "UserId", "dbo.Users");
            DropForeignKey("dbo.FriendRequest", "ReceiverId", "dbo.Users");
            DropForeignKey("dbo.FriendRequest", "SenderId", "dbo.Users");
            DropForeignKey("dbo.FriendList", "UserId", "dbo.Users");
            DropForeignKey("dbo.FamilyMember", "FamilyMemberId", "dbo.Users");
            DropForeignKey("dbo.FamilyMember", "UserId", "dbo.Users");
            DropForeignKey("dbo.Education", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comment", "WhoCommentedId", "dbo.Users");
            DropForeignKey("dbo.Address", "UserId", "dbo.Users");
            DropIndex("dbo.Work", new[] { "UserId" });
            DropIndex("dbo.Profile", new[] { "UserId" });
            DropIndex("dbo.ProfessionalSkills", new[] { "UserId" });
            DropIndex("dbo.Post", new[] { "UserId" });
            DropIndex("dbo.MobileNo", new[] { "UserId" });
            DropIndex("dbo.Like", new[] { "WhoLikedId" });
            DropIndex("dbo.Interest", new[] { "UserId" });
            DropIndex("dbo.FriendRequest", new[] { "ReceiverId" });
            DropIndex("dbo.FriendRequest", new[] { "SenderId" });
            DropIndex("dbo.FriendList", new[] { "UserId" });
            DropIndex("dbo.FamilyMember", new[] { "UserId" });
            DropIndex("dbo.FamilyMember", new[] { "FamilyMemberId" });
            DropIndex("dbo.Education", new[] { "UserId" });
            DropIndex("dbo.Comment", new[] { "WhoCommentedId" });
            DropIndex("dbo.Address", new[] { "UserId" });
            DropTable("dbo.GetFriendRequestView");
            DropTable("dbo.Work");
            DropTable("dbo.Profile");
            DropTable("dbo.ProfessionalSkills");
            DropTable("dbo.Post");
            DropTable("dbo.MobileNo");
            DropTable("dbo.Like");
            DropTable("dbo.Interest");
            DropTable("dbo.FriendRequest");
            DropTable("dbo.FriendList");
            DropTable("dbo.FamilyMember");
            DropTable("dbo.Education");
            DropTable("dbo.Comment");
            DropTable("dbo.Users");
            DropTable("dbo.Address");
        }
    }
}
