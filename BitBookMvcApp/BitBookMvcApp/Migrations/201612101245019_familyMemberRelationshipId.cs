namespace BitBookMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class familyMemberRelationshipId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FamilyMember", "RelationshipId", c => c.Int());
            DropColumn("dbo.FamilyMember", "Relationship");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FamilyMember", "Relationship", c => c.String(maxLength: 50, unicode: false));
            DropColumn("dbo.FamilyMember", "RelationshipId");
        }
    }
}
