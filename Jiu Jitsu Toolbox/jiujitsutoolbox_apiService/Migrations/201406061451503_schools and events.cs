namespace jiujitsutoolbox_apiService.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class schoolsandevents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "jiujitsutoolbox_api.Event",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Id")
                                },
                            }),
                        Name = c.String(),
                        Description = c.String(),
                        LocationId = c.String(nullable: false, maxLength: 128),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Version")
                                },
                            }),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "CreatedAt")
                                },
                            }),
                        UpdatedAt = c.DateTimeOffset(precision: 7,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "UpdatedAt")
                                },
                            }),
                        Deleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Deleted")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("jiujitsutoolbox_api.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.CreatedAt, clustered: true);
            
            CreateTable(
                "jiujitsutoolbox_api.Location",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Id")
                                },
                            }),
                        Address = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Province = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Version")
                                },
                            }),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "CreatedAt")
                                },
                            }),
                        UpdatedAt = c.DateTimeOffset(precision: 7,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "UpdatedAt")
                                },
                            }),
                        Deleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Deleted")
                                },
                            }),
                        School_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("jiujitsutoolbox_api.School", t => t.School_Id)
                .Index(t => t.CreatedAt, clustered: true)
                .Index(t => t.School_Id);
            
            AddColumn("jiujitsutoolbox_api.School", "LocationId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("jiujitsutoolbox_api.School", "LocationId");
            AddForeignKey("jiujitsutoolbox_api.School", "LocationId", "jiujitsutoolbox_api.Location", "Id", cascadeDelete: true);
            DropColumn("jiujitsutoolbox_api.School", "Address");
            DropColumn("jiujitsutoolbox_api.School", "Address2");
            DropColumn("jiujitsutoolbox_api.School", "City");
            DropColumn("jiujitsutoolbox_api.School", "State");
            DropColumn("jiujitsutoolbox_api.School", "PostalCode");
            DropColumn("jiujitsutoolbox_api.School", "Province");
            DropColumn("jiujitsutoolbox_api.School", "Country");
        }
        
        public override void Down()
        {
            AddColumn("jiujitsutoolbox_api.School", "Country", c => c.String());
            AddColumn("jiujitsutoolbox_api.School", "Province", c => c.String());
            AddColumn("jiujitsutoolbox_api.School", "PostalCode", c => c.String());
            AddColumn("jiujitsutoolbox_api.School", "State", c => c.String());
            AddColumn("jiujitsutoolbox_api.School", "City", c => c.String());
            AddColumn("jiujitsutoolbox_api.School", "Address2", c => c.String());
            AddColumn("jiujitsutoolbox_api.School", "Address", c => c.String());
            DropForeignKey("jiujitsutoolbox_api.Event", "LocationId", "jiujitsutoolbox_api.Location");
            DropForeignKey("jiujitsutoolbox_api.Location", "School_Id", "jiujitsutoolbox_api.School");
            DropForeignKey("jiujitsutoolbox_api.School", "LocationId", "jiujitsutoolbox_api.Location");
            DropIndex("jiujitsutoolbox_api.School", new[] { "LocationId" });
            DropIndex("jiujitsutoolbox_api.Location", new[] { "School_Id" });
            DropIndex("jiujitsutoolbox_api.Location", new[] { "CreatedAt" });
            DropIndex("jiujitsutoolbox_api.Event", new[] { "CreatedAt" });
            DropIndex("jiujitsutoolbox_api.Event", new[] { "LocationId" });
            DropColumn("jiujitsutoolbox_api.School", "LocationId");
            DropTable("jiujitsutoolbox_api.Location",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedAt",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "CreatedAt" },
                        }
                    },
                    {
                        "Deleted",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Deleted" },
                        }
                    },
                    {
                        "Id",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Id" },
                        }
                    },
                    {
                        "UpdatedAt",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "UpdatedAt" },
                        }
                    },
                    {
                        "Version",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Version" },
                        }
                    },
                });
            DropTable("jiujitsutoolbox_api.Event",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedAt",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "CreatedAt" },
                        }
                    },
                    {
                        "Deleted",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Deleted" },
                        }
                    },
                    {
                        "Id",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Id" },
                        }
                    },
                    {
                        "UpdatedAt",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "UpdatedAt" },
                        }
                    },
                    {
                        "Version",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Version" },
                        }
                    },
                });
        }
    }
}
