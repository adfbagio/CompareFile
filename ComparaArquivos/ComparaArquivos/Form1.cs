using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
//using TeamFoundationServer.ExtendedClient;
using Microsoft.TeamFoundation.Client.ProjectSettings;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace ComparaArquivos
{
    

    public partial class Form1 : Form
    {
        public clsComum Comum = new clsComum();
        public List<ListaPasta1> ListadePasta1 = new List<ListaPasta1>();
        public List<ListaPasta2> ListadePasta2 = new List<ListaPasta2>();
        public List<ListaFontesEncontrado> ListaFontesEncontrados = new List<ListaFontesEncontrado>();
        public bool arquivossaoiguais;

        public string caminhopastaraiz = @"d:\CDBFolder\";
        public string caminhopasta = @"d:\CDBFolder\Pasta\";
        public string caminhobanco = @"d:\CDBFolder\PastaBanco\";
        public string caminhoprojetos = @"d:\CDBFolder\ProjetosAtivos\";
        public string caminholog = @"d:\CDBFolder\t.htm";
        public string caminhoTFS = @"D:\CDBFolder\Sustentacao\";
        public int Posguardar;
        public Boolean Usouunderline, Retornoacao;
        public string Strretorno, Idprojretorno;

        public class ListaPasta1
        {
            public string Diretorio { get; set; }
            public string Fonte { get; set; }
        }

        public class ListaPasta2
        {
            public string Diretorio { get; set; }
            public string Fonte { get; set; }
        }

        public class ListaFontesEncontrado
        {

            public string Fonte { get; set; }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void btnPasta1_Click(object sender, EventArgs e)
        {
            //btncon.Enabled = true;
            //btncon.BackColor = Color.Silver;
            fbd1.Description = @"Selecione uma pasta para localizar os objetos";
            fbd1.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd1.ShowNewFolderButton = true;

            //var a = Global.GlobalVarLink1;
            //lblcon.Text = Global.GlobalVar1;
            //Exibe a caixa de diálogo
            //  limpapastas();
            DialogResult result = this.fbd1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //'Exibe a pasta selecionada 
                txtPasta1.Text = fbd1.SelectedPath;

            }

            //--------------
            //  listapasta1(txtPasta1.Text);
            ListadePasta1.Clear();
            ListadePasta2.Clear();
            testacomparatfs();
            btnPasta1.Enabled = false;
            
        }

        private void btnPasta2_Click(object sender, EventArgs e)
        {
            //btncon.Enabled = true;
            //btncon.BackColor = Color.Silver;
            fbd1.Description = @"Selecione uma pasta para localizar os objetos";
            fbd1.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd1.ShowNewFolderButton = true;

            //var a = Global.GlobalVarLink1;
            //lblcon.Text = Global.GlobalVar1;
            //Exibe a caixa de diálogo
            //  limpapastas();
            DialogResult result = this.fbd1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //'Exibe a pasta selecionada 
                txtPasta2.Text = fbd1.SelectedPath;

            }

            //--------------
            listapasta2(txtPasta2.Text);

            btnPasta2.Enabled = false;
         ///////   ComparaListas();
           // testageral();
            testacomparatfs1();
        }

        public void listapasta2(string caminho)
        {
            //le a pasta aonde estao as procedures


            System.IO.DirectoryInfo dir1 = new System.IO.DirectoryInfo(txtPasta2.Text);//st
            string[] fileExtensions = new string[] { ".sql", ".SQL", ".frm", ".cls", ".Cls", };
            IEnumerable<System.IO.FileInfo> listObjetos = dir1.GetFiles("*.*", System.IO.SearchOption.AllDirectories).Where(s => fileExtensions.Contains(s.Extension));
            var querylistaobjetos = (from file in listObjetos
                                     select file);

            foreach (var v in querylistaobjetos)
            {
                ListadePasta2.Add(new ListaPasta2 { Diretorio = v.DirectoryName.ToString().ToLower(), Fonte = v.Name.ToLower() });
            }

        }

        public void listapasta1(string caminho)
        {
            //le a pasta aonde estao as procedures


            System.IO.DirectoryInfo dir1 = new System.IO.DirectoryInfo(txtPasta1.Text);//st
            string[] fileExtensions = new string[] { ".sql", ".SQL", ".frm", ".cls", ".Cls", };
            IEnumerable<System.IO.FileInfo> listObjetos = dir1.GetFiles("*.*", System.IO.SearchOption.AllDirectories).Where(s => fileExtensions.Contains(s.Extension));
            var querylistaobjetos = (from file in listObjetos
                                     select file);

            foreach (var v in querylistaobjetos)
            {
                ListadePasta1.Add(new ListaPasta1 { Diretorio = v.DirectoryName.ToString().ToLower(), Fonte = v.Name.ToLower() });
            }


        }
        public void ComparaListas()
        {
            int y = 0;



            //Apaga pasta

            Comum.DeleteDirectory(caminhopastaraiz + "Pasta1\\");
            Comum.DeleteDirectory(caminhopastaraiz + "Pasta2\\");
            //Compara diretorio e fonte da lista 1 com diretorio e fonte da lista 2
            foreach (var v1 in ListadePasta1)
            {
                string fonte = v1.Fonte;
                string dir = Pesquisastring(v1.Diretorio, "\\");

                foreach (var v2 in ListadePasta2)
                {
                    string dir1 = Pesquisastring(v2.Diretorio, "\\");
                    // if (v2.Diretorio.Contains(dir))
                    if (dir == dir1)
                    {
                        //if (v2.Fonte.Contains(fonte))
                        if (v2.Fonte == fonte)
                        {

                            //Quem entrar aki copia cada fonte para as pasta de trabalho 1 e 2 e compara
                            //quando encontrar diferenca grava numa temp diferencas e quando for igual grava na temp iguais
                            //que serao fonte de dois datagrid no final de tudo e clicaveis
                            //salva essas lista em 2 tables para posterior conferencia do analista
                            FileInfo fi1 = new FileInfo(v1.Diretorio + "\\" + v1.Fonte);
                            FileInfo fi2 = new FileInfo(v2.Diretorio + "\\" + v2.Fonte);

                            if (!System.IO.Directory.Exists(caminhopastaraiz + "Pasta1\\" + dir))
                            { System.IO.Directory.CreateDirectory(caminhopastaraiz + "Pasta1\\" + dir); }

                            if (!System.IO.Directory.Exists(caminhopastaraiz + "Pasta2\\" + dir))
                            { System.IO.Directory.CreateDirectory(caminhopastaraiz + "Pasta2\\" + dir); }

                            fi1.CopyTo(caminhopastaraiz + "Pasta1\\" + dir + "\\" + v1.Fonte);
                            fi2.CopyTo(caminhopastaraiz + "Pasta2\\" + dir + "\\" + v2.Fonte);
                            comparateit2dir(caminhopastaraiz + "Pasta1\\" + dir + "\\" + v1.Fonte, caminhopastaraiz + "Pasta2\\" + dir + "\\" + v2.Fonte, v2.Fonte);
                            y = y + 1;
                        }
                    }
                }
                //if (ListadePasta2.Exists(x => x.Diretorio == dir && x.Fonte==fonte) )
                //{
                //    bool a = true;
                //}
            }

            var notMatchedpets = ListadePasta1.Where(p2 => ListadePasta2
  .Any(p1 => p1.Diretorio == p2.Diretorio && p1.Fonte == p2.Fonte))
  .ToList();
            var caminhoprojb1 = ListadePasta1.Select(s1 => s1.Fonte).ToList().Intersect(ListadePasta2.Select(s2 => s2.Fonte).ToList()).ToList();
            if (caminhoprojb1.Count() > 0)
                caminhoprojb1.ToList().ForEach(t => ListaFontesEncontrados.Add(new ListaFontesEncontrado { Fonte = t }));


            foreach (var v1 in ListaFontesEncontrados)
            {
                //aqui
                var query_where3 = from c in ListadePasta1
                                   where c.Fonte == v1.Fonte
                                   select new
                                   {
                                       account_name = c.Diretorio,
                                       contact_name = c.Fonte
                                   };
                //aqui
                //aqui
                var query_where4 = from c in ListadePasta2
                                   where c.Fonte == v1.Fonte
                                   select new
                                   {
                                       account_name = c.Diretorio,
                                       contact_name = c.Fonte
                                   };
                //aqui


            }


        }


        public int  tamfiltro;
        public int Pesquisastring2(string pathpesq, string filtro)
        //public string Pesquisastring(string pathpesq, string filtro)
        //***********************************************************
        //Pesquisa dentro de uma string de diretório pelo pasta raiz
        //***********************************************************
        {
            try
            {


                //busca se tem espaco em branco
                tamfiltro = Convert.ToInt32(filtro.Length);
                int posicaoini = 0;
                int posicaoespaco = pathpesq.IndexOf(" ", posicaoini, StringComparison.Ordinal);//procura a string "\\" na string StrPath
                int tamanhostring = Convert.ToInt32(pathpesq.Length);
                int limite = tamanhostring - 1;


                if (posicaoespaco == 0 || posicaoespaco == -1)
                {
                    do
                    {
                        posicaoespaco = pathpesq.IndexOf(filtro, posicaoini, StringComparison.Ordinal);//procura a string "\\" na string StrPath
                        if (posicaoespaco != -1)
                        {
                            if (posicaoespaco < limite)
                            {
                                Posguardar = posicaoespaco;
                            }
                        }
                        posicaoini = (posicaoini + 1);
                    } while (posicaoespaco != -1);
                }
                else
                {
                    pathpesq = pathpesq.Replace(" ", "_");
                    Usouunderline = true;
                    Pesquisastring(pathpesq, filtro);
                }
                tamanhostring = tamanhostring - (Posguardar + tamfiltro);

                string strPath = pathpesq.Substring((Posguardar + tamfiltro), tamanhostring);
                strPath = strPath.Replace("\\", "");
                if (Usouunderline == true)
                {
                    Strretorno = strPath.Replace("_", "");
                }
                else
                {
                    Strretorno = strPath;
                }
            }
            catch (Exception e)
            {
                //  Comum.Geralog("Erro: " + "Pesquisastring " + DateTime.Now.ToString() + " OperacaodeDiretorioTfs1.Pesquisastring ", e.Message.ToString() + " ", e.Source.ToString());
            }
            return Posguardar + tamfiltro;
        }
        public string Pesquisastring(string pathpesq, string filtro)
        //***********************************************************
        //Pesquisa dentro de uma string de diretório pelo pasta raiz
        //***********************************************************
        {
            try
            {


                //busca se tem espaco em branco
                int tamfiltro = Convert.ToInt32(filtro.Length);
                int posicaoini = 0;
                int posicaoespaco = pathpesq.IndexOf(" ", posicaoini, StringComparison.Ordinal);//procura a string "\\" na string StrPath
                int tamanhostring = Convert.ToInt32(pathpesq.Length);
                int limite = tamanhostring - 1;


                if (posicaoespaco == 0 || posicaoespaco == -1)
                {
                    do
                    {
                        posicaoespaco = pathpesq.IndexOf(filtro, posicaoini, StringComparison.Ordinal);//procura a string "\\" na string StrPath
                        if (posicaoespaco != -1)
                        {
                            if (posicaoespaco < limite)
                            {
                                Posguardar = posicaoespaco;
                            }
                        }
                        posicaoini = (posicaoini + 1);
                    } while (posicaoespaco != -1);
                }
                else
                {
                    pathpesq = pathpesq.Replace(" ", "_");
                    Usouunderline = true;
                    Pesquisastring(pathpesq, filtro);
                }
                tamanhostring = tamanhostring - (Posguardar + tamfiltro);

                string strPath = pathpesq.Substring((Posguardar + tamfiltro), tamanhostring);
                strPath = strPath.Replace("\\", "");
                if (Usouunderline == true)
                {
                    Strretorno = strPath.Replace("_", "");
                }
                else
                {
                    Strretorno = strPath;
                }
            }
            catch (Exception e)
            {
                //Comum.Geralog("Erro: " + "Pesquisastring " + DateTime.Now.ToString() + " OperacaodeDiretorioTfs1.Pesquisastring ", e.Message.ToString() + " ", e.Source.ToString());
            }
            return Strretorno;
        }

        public void comparateit2dir(string caminho1, string caminho2, string nome)
        {
         
            arquivossaoiguais = false;
            string caminhopastap = caminho1;
            string caminhobancop = caminho2;
       
            File.Create(caminholog).Close();

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //  startInfo.FileName = "C:\\Program Files\\Compare It!\\wincmp3.exe";
            startInfo.FileName = @"C:\\Program Files (x86)\\Compare It!\\wincmp3.exe";
            startInfo.Arguments = caminhopastap + " " + caminhobancop + " /min /G " + caminholog;
            process.StartInfo = startInfo;

            var a = process.Start();
            process.WaitForExit(100000);
            // bool retorno = learquivo(caminholog);
            string[] lines = System.IO.File.ReadAllLines(caminholog.Trim());
            //while ((line = file.ReadLine()) != null)
            foreach (string linha in lines)
            {
                string h = linha;
                if (h.Contains("Files are identical!"))
                { arquivossaoiguais = true; }


                // Console.WriteLine(line);

            }
            //===============
            if (!arquivossaoiguais)
            { dgwdirconflito.Rows.Add(nome, caminho1, caminho2);
                foreach (DataGridViewRow row in dgwdirconflito.Rows)
                    if (row.Cells[0].Value.ToString()== nome)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                        
            }
            dgwdirconflito.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgwdirconflito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            limpapastas();
          //  lblprocerr.Text = dgwdirconflito.Rows.Count.ToString();

            if (arquivossaoiguais)
            {
                dgwdirconflito.Rows.Add(nome);
                foreach (DataGridViewRow row in dgwdirconflito.Rows)
                    if (row.Cells[0].Value.ToString() == nome)
                    {
                        row.DefaultCellStyle.BackColor = Color.Green;
                    }
            }
            //dgwdirsemconflito.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //dgwdirsemconflito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
           

        }

        private void limpapastas()
        {
            //apaga diretorios
            // string caminhopasta = @"d:\CDBFolder\Pasta\";
            //string caminhobanco = @"d:\CDBFolder\PastaBanco\";
            //  string caminholog = @"d:\CDBFolder\";
            clearFolder(caminhopasta);
            clearFolder(caminhobanco);
            File.Delete(caminholog);
            //  clearFolder(caminholog);
        }

        private void clearFolder(string FolderName)
        {

            foreach (string file in Directory.GetFiles(FolderName))
            {
                var di = new DirectoryInfo(FolderName);
                di.Attributes &= ~FileAttributes.ReadOnly;
                var di1 = new DirectoryInfo(file);
                di1.Attributes &= ~FileAttributes.ReadOnly;
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }



        }

        public void testageral()
        {
            FileCompareNomeTamanhoIgual1 myFileCompareNomeTamIgual1 = new FileCompareNomeTamanhoIgual1();

            System.IO.DirectoryInfo dir1 = new System.IO.DirectoryInfo(txtPasta1.Text);//st
            string[] fileExtensions = new string[] { ".sql", ".SQL", ".frm", ".cls", ".Cls", };
            IEnumerable<System.IO.FileInfo> listObjetos = dir1.GetFiles("*.*", System.IO.SearchOption.AllDirectories).Where(s => fileExtensions.Contains(s.Extension));
            var querylistaobjetos = (from file in listObjetos
                                     select file);


            System.IO.DirectoryInfo dir2 = new System.IO.DirectoryInfo(txtPasta2.Text);//st
            string[] fileExtensions2 = new string[] { ".sql", ".SQL", ".frm", ".cls", ".Cls", };
            IEnumerable<System.IO.FileInfo> listObjetos2 = dir2.GetFiles("*.*", System.IO.SearchOption.AllDirectories).Where(s => fileExtensions.Contains(s.Extension));
            var querylistaobjetos2 = (from file in listObjetos2
                                     select file);

            var distItemsquerylistaobjetos = from list1Item in querylistaobjetos
                            join list2Item in querylistaobjetos2 on list1Item.Name equals list2Item.Name
                            where (list2Item != null)
                            select list1Item;

            var distItemsquerylistaobjetos2 = from list1Item in querylistaobjetos2
                            join list2Item in querylistaobjetos on list1Item.Name equals list2Item.Name
                            where (list2Item != null)
                            select list1Item;
            int a = distItemsquerylistaobjetos2.Count();
            ListadePasta1.Clear();
            foreach (var v in distItemsquerylistaobjetos)
            {
                
                ListadePasta1.Add(new ListaPasta1 { Diretorio = v.DirectoryName.ToString().ToLower(), Fonte = v.Name.ToLower() });
            }
            ListadePasta2.Clear();
            foreach (var v in distItemsquerylistaobjetos2)
            {
                ListadePasta2.Add(new ListaPasta2 { Diretorio = v.DirectoryName.ToString().ToLower(), Fonte = v.Name.ToLower() });
            }
            //


            //
            for (int aa=0;aa<a;aa++)
            {
                string fonte=ListadePasta1[aa].Fonte.ToString();
                string path1= ListadePasta1[aa].Diretorio.ToString();
                string path2 = ListadePasta2[aa].Diretorio.ToString();
                comparateit2dir(path1 + "\\" + fonte, path2 + "\\" + fonte, fonte);
            }
            var queryDesenvenaoSt = (from file in querylistaobjetos2
                                     select file).Except(querylistaobjetos, myFileCompareNomeTamIgual1);
        }

        class FileCompareNomeTamanhoIgual1 :
      System.Collections.Generic.IEqualityComparer<System.IO.FileInfo>
        {

            public FileCompareNomeTamanhoIgual1() { }

            public bool Equals(System.IO.FileInfo f1, System.IO.FileInfo f2)
            {
                return (f1.Name == f2.Name &&
                        f1.Length == f2.Length);
            }


            public int GetHashCode(System.IO.FileInfo fi)
            {
                string s = String.Format("{0}{1}", fi.Name, fi.Length);
                return s.GetHashCode();
            }
        }

        public void testacomparatfs()
        {
            string caminhosemfonte = "";
            string retorno = "";
            string caminhocompletocomfonte = "";
            string fontes = "$/All/Projetos/Bradesco/Sise/17-2833/Construção/";
            string UrlTfs = "http://tfs:8080/tfs/Sistran";
            TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(UrlTfs));
            VersionControlServer versionControlServer = teamProjectCollection.GetService<VersionControlServer>();
            TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(UrlTfs));
            
            ItemSet items = versionControlServer.GetItems("$/All/Projetos/Bradesco/Sise/17-2833/Construção/", RecursionType.Full);
            dgwdirconflito.Rows.Clear();
            foreach (Item item in items.Items)
            {
                if (item.ServerItem.Contains(".cls") || item.ServerItem.Contains(".vb") || item.ServerItem.Contains(".frm") || item.ServerItem.Contains(".sql") || item.ServerItem.Contains(".asp") || item.ServerItem.Contains(".rpt") || item.ServerItem.Contains(".bas"))
                {
                    string tambytes = (item.ContentLength.ToString());
                   int versao = item.ChangesetId;
                    string datachk = item.CheckinDate.ToString();
                    datachk = datachk.Substring(0, 10);
                    caminhocompletocomfonte = item.ServerItem;
                    int tam = Pesquisastring2(item.ServerItem, @"/");
                   // int t = Convert.ToInt32(tam);
                    caminhosemfonte = caminhocompletocomfonte.Remove(tam);
                    string fonte = caminhocompletocomfonte.Replace(caminhosemfonte, "");
                    string modulofonte = caminhocompletocomfonte.Replace(caminhosemfonte, "");
                    int tammodulo = Pesquisastring2(caminhosemfonte, "/");//da o nome da pasta
                    string caminhosemmodulo = caminhocompletocomfonte.Substring(0, tammodulo);
                    string y = caminhocompletocomfonte.Replace(caminhosemmodulo, "");
                    string nomemodulo = y.Replace(fonte, "");
                    nomemodulo = nomemodulo.Replace("/", "");

                    dgwtfs.Rows.Add(fonte, datachk, tambytes, caminhocompletocomfonte);
                    foreach (DataGridViewRow row in dgwtfs.Rows)

                        //  ListadePasta1.Clear();

                        if (ListadePasta1.Count == 0)
                        { ListadePasta1.Add(new ListaPasta1 { Diretorio = caminhocompletocomfonte.ToLower(), Fonte = fonte }); }

                    //  ListadePasta2.Clear();
                    if (ListadePasta2.Count == 0)
                    { ListadePasta2.Add(new ListaPasta2 { Diretorio = caminhocompletocomfonte.ToLower(), Fonte = fonte }); }

                    if (ListadePasta2.Count > 0 && ListadePasta1.Count > 0)
                    { var x = ListadePasta1.Select(a => a.Fonte).Except(ListadePasta2.Select(c => c.Fonte)); }

                    if (caminhocompletocomfonte.Contains(fontes))
                    {
                        retorno = caminhocompletocomfonte.Replace("$", "D:");

                        retorno = retorno.Replace(@"/", @"\"); retorno = retorno.Replace(@"D:\All\Projetos\Bradesco\Sise\", @"D:\Controle_de_Ambientes_Pastas\Projetos_Ativos\");
                    }


                }
            }
        }

        public void testacomparatfs1()
        {
            string caminhosemfonte = "";
            string retorno = "";
            string caminhocompletocomfonte = "";
            string fontes = "$/All/Projetos/Bradesco/Sise/17-2833/Construção/";
            string UrlTfs = "http://tfs:8080/tfs/Sistran";
            TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(UrlTfs));
            VersionControlServer versionControlServer = teamProjectCollection.GetService<VersionControlServer>();
            TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(UrlTfs));

            ItemSet items = versionControlServer.GetItems("$/All/Projetos/Bradesco/Sise/17-2833/Construção/", RecursionType.Full);
            dgwdirconflito.Rows.Clear();
            foreach (Item item in items.Items)
            {
                if (item.ServerItem.Contains(".cls") || item.ServerItem.Contains(".vb") || item.ServerItem.Contains(".frm") || item.ServerItem.Contains(".sql") || item.ServerItem.Contains(".asp") || item.ServerItem.Contains(".rpt") || item.ServerItem.Contains(".bas"))
                {
                    string tambytes = (item.ContentLength.ToString());
                    int versao = item.ChangesetId;
                    string datachk = item.CheckinDate.ToString();
                    datachk = datachk.Substring(0, 10);
                    caminhocompletocomfonte = item.ServerItem;
                    int tam = Pesquisastring2(item.ServerItem, @"/");
                    // int t = Convert.ToInt32(tam);
                    caminhosemfonte = caminhocompletocomfonte.Remove(tam);
                    string fonte = caminhocompletocomfonte.Replace(caminhosemfonte, "");
                    string modulofonte = caminhocompletocomfonte.Replace(caminhosemfonte, "");
                    int tammodulo = Pesquisastring2(caminhosemfonte, "/");//da o nome da pasta
                    string caminhosemmodulo = caminhocompletocomfonte.Substring(0, tammodulo);
                    string y = caminhocompletocomfonte.Replace(caminhosemmodulo, "");
                    string nomemodulo = y.Replace(fonte, "");
                    nomemodulo = nomemodulo.Replace("/", "");

                    dgwtfs.Rows.Add(fonte, datachk, tambytes, caminhocompletocomfonte);
                    foreach (DataGridViewRow row in dgwtfs.Rows)

                        //  ListadePasta1.Clear();

                        //if (ListadePasta1.Count == 0)
                        //{ ListadePasta1.Add(new ListaPasta1 { Diretorio = caminhocompletocomfonte.ToLower(), Fonte = fonte }); }

                    //  ListadePasta2.Clear();
                    if (ListadePasta2.Count == 0)
                    { ListadePasta2.Add(new ListaPasta2 { Diretorio = caminhocompletocomfonte.ToLower(), Fonte = fonte }); }

                    if (ListadePasta2.Count > 0 && ListadePasta1.Count > 0)
                    { var x = ListadePasta1.Select(a => a.Fonte).Except(ListadePasta2.Select(c => c.Fonte)); }

                    if (caminhocompletocomfonte.Contains(fontes))
                    {
                        retorno = caminhocompletocomfonte.Replace("$", "D:");

                        retorno = retorno.Replace(@"/", @"\"); retorno = retorno.Replace(@"D:\All\Projetos\Bradesco\Sise\", @"D:\Controle_de_Ambientes_Pastas\Projetos_Ativos\");
                    }


                }
            }
        }
    }
}
