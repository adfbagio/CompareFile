using ComparaArquivos.Banco;
using System.Data.Entity;

namespace ComparaArquivos
{
    public class Contexto : DbContext
    {
        public DbSet<ProjetosTfs> ProjetosTfs { get; set; }
        public DbSet<FontesProjetos> FontesProjetos { get; set; }
        public DbSet<AcessoMultiManager> AcessoMultiManager { get; set; }
        public DbSet<FormExec> FormExec { get; set; }
        public DbSet<ConBancoBs> ConBancoBs { get; set; }
        public DbSet<ProcExecProc> ProcExecProc { get; set; }
        public DbSet<RelatoriosSise> RelatoriosSise { get; set; }
        public DbSet<DictExecTabelasSise> DictExecTabelasSise { get; set; }
        public DbSet<ProcExecTabelasSise> ProcExecTabelasSise { get; set; }
        public DbSet<RelatoriosDetalhes> RelatoriosDetalhes { get; set; }
        public DbSet<RelatoriosDetCampoProcs> RelatoriosDetCampoProcs { get; set; }
      
    }
}
