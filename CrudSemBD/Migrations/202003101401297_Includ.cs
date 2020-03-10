namespace CrudSemBD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Includ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PessoaModel",
                c => new
                    {
                        idPessoa = c.Int(nullable: false, identity: true),
                        idSexo = c.Int(nullable: false),
                        nmPessoa = c.String(),
                        dtNascimento = c.DateTime(nullable: false),
                        pessoaCPF = c.String(),
                    })
                .PrimaryKey(t => t.idPessoa)
                .ForeignKey("dbo.SexoModel", t => t.idSexo, cascadeDelete: true)
                .Index(t => t.idSexo);
            
            CreateTable(
                "dbo.SexoModel",
                c => new
                    {
                        idSexo = c.Int(nullable: false, identity: true),
                        descricaoSexo = c.String(),
                    })
                .PrimaryKey(t => t.idSexo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PessoaModel", "idSexo", "dbo.SexoModel");
            DropIndex("dbo.PessoaModel", new[] { "idSexo" });
            DropTable("dbo.SexoModel");
            DropTable("dbo.PessoaModel");
        }
    }
}
