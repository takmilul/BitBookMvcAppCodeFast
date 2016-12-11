namespace BitBookMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationshipIdInRelationshipName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profile", "RelationshipId", c => c.Int());
            DropColumn("dbo.Profile", "Relationship");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profile", "Relationship", c => c.String(maxLength: 50, unicode: false));
            DropColumn("dbo.Profile", "RelationshipId");
        }
    }
}
