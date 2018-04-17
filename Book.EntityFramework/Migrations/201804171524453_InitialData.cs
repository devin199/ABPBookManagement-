namespace Book.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "BK.BookInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookName = c.String(nullable: false, maxLength: 50),
                        Author = c.String(maxLength: 50),
                        BookNumber = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BookInfo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "BK.BorrowBook",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookInfoId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        BorrowBookStatus = c.Int(nullable: false),
                        BorrowTime = c.DateTime(nullable: false),
                        ReturnTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BorrowBook_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("BK.BookInfo", t => t.BookInfoId, cascadeDelete: true)
                .ForeignKey("BK.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.BookInfoId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "BK.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false, maxLength: 50),
                        StudentNumber = c.String(nullable: false, maxLength: 6),
                        StudentAge = c.Int(nullable: false),
                        StudentSex = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Student_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("BK.BorrowBook", "StudentId", "BK.Student");
            DropForeignKey("BK.BorrowBook", "BookInfoId", "BK.BookInfo");
            DropIndex("BK.BorrowBook", new[] { "StudentId" });
            DropIndex("BK.BorrowBook", new[] { "BookInfoId" });
            DropTable("BK.Student",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Student_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("BK.BorrowBook",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BorrowBook_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("BK.BookInfo",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_BookInfo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
