using System;
using System.Collections;
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

        public string retornosegundacompa;
        public string caminho,memoria;
        public int u = 0;
        public clsComum Comum = new clsComum();
        public List<ListaPasta1> ListadePasta1 = new List<ListaPasta1>();
        public List<ListaPasta2> ListadePasta2 = new List<ListaPasta2>();
        public string fontes = "$/All/Projetos/";//base de onde partir
        public List<ListaPastaS1> ListadePastaS1 = new List<ListaPastaS1>();
        public List<ListaPastaS2> ListadePastaS2 = new List<ListaPastaS2>();

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
            public string Tamanho { get; set; }
            public string Modulo { get; set; }
        }

        public class ListaPasta2
        {
            public string Diretorio { get; set; }
            public string Fonte { get; set; }
            public string Tamanho { get; set; }
            public string Modulo { get; set; }
        }
        /// <summary>
        /// ///////////////////////
        /// </summary>
        /// 
        public class ListaPastaS1
        {
            public string Diretorio { get; set; }
            public string Fonte { get; set; }
            public string Tamanho { get; set; }
            public string Modulo { get; set; }
        }

        public class ListaPastaS2
        {
            public string Diretorio { get; set; }
            public string Fonte { get; set; }
            public string Tamanho { get; set; }
            public string Modulo { get; set; }
        }
        public class ListaFontesEncontrado
        {

            public string Fonte { get; set; }
        }


        public Form1()
        {
            InitializeComponent();
        }

        public void CarregarComboProjetos()
        {
            try
            {
                clsProjetos projeto = new clsProjetos();
                dgwprojetos.DataSource = projeto.Get_ProjetosFiltro();


                dgwprojetos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgwprojetos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //cboprojetos.DataSource = projeto.Get_ProjetosFiltro();

                //cboprojetos.DisplayMember = "IDProjeto";
                //cboprojetos.ValueMember = "NomeProjeto";
                //cboprojetos.SelectedIndex = -1;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPasta1_Click(object sender, EventArgs e)
        {

            CarregarComboProjetos();
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
          //////////    listapasta1(txtPasta1.Text);
            ListadePasta1.Clear();
            ListadePasta2.Clear();
          //  testacomparatfs();
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
         // limpapastas();
            DialogResult result = this.fbd1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //'Exibe a pasta selecionada 
                txtPasta2.Text = fbd1.SelectedPath;

            }

            //--------------
        //////    listapasta2(txtPasta2.Text);

            btnPasta2.Enabled = false;
         ///// ComparaListas();
          testageral();
          //  testacomparatfs1();
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
                            where (list2Item != null )
                            select list1Item;

            var distItemsquerylistaobjetos2 = from list1Item in querylistaobjetos2
                            join list2Item in querylistaobjetos on list1Item.Name equals list2Item.Name
                            where (list2Item != null)
                            select list1Item;
            int a = distItemsquerylistaobjetos2.Count();
            ListadePasta1.Clear();
            foreach (var v in distItemsquerylistaobjetos)
            {
                string dir = Pesquisastring(v.DirectoryName.ToString(), "\\");
                ListadePasta1.Add(new ListaPasta1 { Diretorio = v.Directory.ToString(), Fonte = v.Name.ToLower(), Modulo = dir,Tamanho=v.Length.ToString() });
            }
            ListadePasta2.Clear();
            foreach (var v in distItemsquerylistaobjetos2)
            {
                string dir = Pesquisastring(v.DirectoryName.ToString(), "\\");
                ListadePasta2.Add(new ListaPasta2 { Diretorio = v.Directory.ToString(), Fonte = v.Name.ToLower() ,Modulo=dir, Tamanho = v.Length.ToString() });
            }
            //lista fontes de mesmo nome e igual modulo:
            var distItemsquerylistaobjetosT1 =from list1Item in ListadePasta1
                                               join list2Item in ListadePasta2 on list1Item.Fonte equals list2Item.Fonte
                                             where (list2Item != null && list2Item.Tamanho!= list1Item.Tamanho)
                                             select list1Item;

            foreach (var v in distItemsquerylistaobjetosT1)
            {
              // string jj = v.Modulo;
              // string dir = Pesquisastring(v.Diretorio.ToString(), "\\");
                ListadePastaS1.Add(new ListaPastaS1 { Diretorio = v.Diretorio.ToString().ToLower(), Fonte = v.Fonte.ToLower(), Modulo = v.Modulo });
            }

            var distItemsquerylistaobjetosT2 = from list2Item in ListadePasta2
                                               join list1Item in ListadePasta1 on list2Item.Fonte equals list1Item.Fonte
                                               where (list1Item != null && list1Item.Tamanho != list2Item.Tamanho)
                                               select list2Item;

            foreach (var v in distItemsquerylistaobjetosT2)
            {
                // string dir = Pesquisastring(v.Diretorio.ToString(), "\\");
                ListadePastaS2.Add(new ListaPastaS2 { Diretorio = v.Diretorio.ToString().ToLower(), Fonte = v.Fonte.ToLower(), Modulo = v.Modulo });
            }
            //
            for (int aa=0;aa<a;aa++)
            {
                string fonte= ListadePastaS1[aa].Fonte.ToString();
                string path1= ListadePastaS1[aa].Diretorio.ToString();
                string path2 = ListadePastaS2[aa].Diretorio.ToString();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarComboProjetos();
        }

        private void dgwprojetos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string IdProjeto="";
            int _linhaIndice = e.RowIndex;

            if (_linhaIndice == -1) return;

            DataGridViewRow rowData = dgwprojetos.Rows[_linhaIndice];

            int j = dgwprojetos.Rows.Count;
            if (j > 0)
            {
                
                 IdProjeto = rowData.Cells[0].Value.ToString().Substring(0, 7);
                testacomparatfs(IdProjeto);
            }
            //loop dos outros projetos
            foreach (DataGridViewRow row in dgwprojetos.Rows)
            {
                string a1 = row.Cells["IDProjeto"].Value.ToString();
                if (a1 != IdProjeto)
                { testacomparatfs1(a1); }
            }
            if (u == 0)
            {
                MessageBox.Show("Não foram encontrados conflitos!");
            }
        }

        private void dgwtfs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgwtfsreal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public string testacomparatfs(string projeto)
        {
            int itens = 0;
            int u = 0;
            string retornoerro="OK";
            //string projeto = "";
            string caminhosemfonte = "";
            string retorno = "";
            string caminhocompletocomfonte = "";
            //string fontes = "$/All/Projetos/Bradesco/Sise/17-2833/Construção/";
            string fontes = "$/All/Projetos/Bradesco/Sise/"+ projeto + "/Construção/";
            string UrlTfs = "http://tfs:8080/tfs/Sistran";
            TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(UrlTfs));
            VersionControlServer versionControlServer = teamProjectCollection.GetService<VersionControlServer>();
            TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(UrlTfs));
            
            ItemSet items = versionControlServer.GetItems(fontes, RecursionType.Full);
            dgwdirconflito.Rows.Clear();
            foreach (Item item in items.Items)
            {
                if (item.ServerItem.Contains(".cls") || item.ServerItem.Contains(".vb") || item.ServerItem.Contains(".frm") || item.ServerItem.Contains(".sql") || item.ServerItem.Contains(".asp") || item.ServerItem.Contains(".rpt") || item.ServerItem.Contains(".bas"))
                {
                    itens++;
                  string hh=  items.Items[9].ToString();
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

                    //dgwtfs.Rows.Add(fonte, datachk, tambytes, caminhocompletocomfonte);
                    //foreach (DataGridViewRow row in dgwtfs.Rows)

                        //  ListadePasta1.Clear();

                     //   if (ListadePasta1.Count == 0)
                        { ListadePasta1.Add(new ListaPasta1 { Diretorio = caminhocompletocomfonte.ToLower(), Fonte = fonte, Tamanho = tambytes, Modulo = nomemodulo }); }

                    ////  ListadePasta2.Clear();
                    //if (ListadePasta2.Count == 0)
                    //{ ListadePasta2.Add(new ListaPasta2 { Diretorio = caminhocompletocomfonte.ToLower(), Fonte = fonte }); }

                    //if (ListadePasta2.Count > 0 && ListadePasta1.Count > 0)
                    //{ var x = ListadePasta1.Select(a => a.Fonte).Except(ListadePasta2.Select(c => c.Fonte)); }

                    if (caminhocompletocomfonte.Contains(fontes))
                    {
                        retorno = caminhocompletocomfonte.Replace("$", "D:");

                        retorno = retorno.Replace(@"/", @"\"); retorno = retorno.Replace(@"D:\All\Projetos\Bradesco\Sise\", @"D:\Controle_de_Ambientes_Pastas\Projetos_Ativos\");
                    }


                }
               
            }
             if(ListadePasta1.Count==0)
                { retornoerro = "O projeto não tem fontes"; }
            return retornoerro;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tv();
            memoria = "";
          //  testa("");

        }
        public void tv()
        {
            //tfs
         
            string UrlTfs = "http://tfs:8080/tfs/Sistran";
            TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(UrlTfs));
            VersionControlServer versionControlServer = teamProjectCollection.GetService<VersionControlServer>();
            TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(UrlTfs));
            //var t = versionControlServer.GetWorkspace(fontes);
            // ItemSet items = versionControlServer.GetItems(fontes , RecursionType.Full);
            ItemSet itemsAbaixodeProjetos = versionControlServer.GetItems(fontes, RecursionType.OneLevel);

            TreeNode rootNode = tvTfs.Nodes.Add("Projetos");
            rootNode.ImageIndex = 0;
            TreeNode forms = new TreeNode("forms");
            TreeNode child = new TreeNode("forms1");

            int qtdeitensAbaixoProj = itemsAbaixodeProjetos.Items.Count();
            for (int i = 1; i < qtdeitensAbaixoProj; i++)
            {
                string fgs = itemsAbaixodeProjetos.Items[i].ServerItem.ToString();
                string ITEM = Pesquisastring(fgs, @"/");
                forms = rootNode.Nodes.Add(ITEM);
            }
            
           

            foreach (Item item in itemsAbaixodeProjetos.Items)
            {
              

                string fg = itemsAbaixodeProjetos.Items[1].ServerItem.ToString();
               
                //ItemSet itemsAh = versionControlServer.GetItems(fg, RecursionType.OneLevel);
                //string fgT = itemsAh.Items[3].ServerItem.ToString();
                //ItemSet itemsAAh = versionControlServer.GetItems(fgT, RecursionType.OneLevel);
            }

                //tfs

               
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tvTfs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string IdProjeto = "";
            string selectedNodeText = e.Node.Text;
            string parente = e.Node.Parent.Text;
            if (memoria == "" && parente!="Projetos")
            { memoria = parente; }
            string UrlTfs = "http://tfs:8080/tfs/Sistran";
            TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(UrlTfs));
            VersionControlServer versionControlServer = teamProjectCollection.GetService<VersionControlServer>();
            TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(UrlTfs));
            //var t = versionControlServer.GetWorkspace(fontes);
            // ItemSet items = versionControlServer.GetItems(fontes , RecursionType.Full);
            if (parente == "Projetos")
            {
                 caminho = fontes + selectedNodeText;
            }
            else
            {
                 caminho = fontes +  parente+"/"+selectedNodeText;
            }
            ItemSet itemsAbaixodeProjetos = versionControlServer.GetItems(caminho, RecursionType.OneLevel);

            if (e.Node.Tag != null)
            { string selectedNodeTextw = e.Node.Tag.ToString(); }

            int qtdeitensAbaixoProj = itemsAbaixodeProjetos.Items.Count();
            for (int i = 1; i < qtdeitensAbaixoProj; i++)
            {
                string fgs = itemsAbaixodeProjetos.Items[i].ServerItem.ToString();
                string ITEM = Pesquisastring(fgs, @"/");
                tvTfs.SelectedNode.Nodes.Add(ITEM);
            }

            if(selectedNodeText.Contains("-"))
            {
                // IdProjeto = "";
                IdProjeto = selectedNodeText;
               string retornoerro= testacomparatfs(IdProjeto);
                //valida se o primeiro projeto tem fontes se nao tem aborta o processo
                if (retornoerro == "OK")
                {
                    caminho = fontes + memoria + "/" + parente;// + "/" + selectedNodeText;
                    ItemSet itensoutrosproj = versionControlServer.GetItems(caminho, RecursionType.OneLevel);
                    int qtdeitensoutrosproj = itensoutrosproj.Items.Count();
                    for (int i = 1; i < qtdeitensoutrosproj; i++)
                    {
                        string fgs = itensoutrosproj.Items[i].ServerItem.ToString();
                        string ITEM = Pesquisastring(fgs, @"/");
                        if (ITEM != IdProjeto)
                        {

                            retornosegundacompa = testacomparatfs1(ITEM);
                            if(retornosegundacompa!="OK")
                            { retornosegundacompa = retornosegundacompa + ": " + ITEM; }
                            dgwretorno.Rows.Add(ITEM, IdProjeto, retornosegundacompa);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("O projeto: " + IdProjeto+" não possui fontes, comparação abortada");
                }

            }

        }

        private void btnpesq_Click(object sender, EventArgs e)
        {
            

        }

        public string testacomparatfs1(string projeto)
        {
           
            string retornoerro="ok";
            string caminhosemfonte = "";
            string retorno = "";
            string caminhocompletocomfonte = "";
            string fontes = "$/All/Projetos/Bradesco/Sise/" + projeto + "/Construção/";
            string UrlTfs = "http://tfs:8080/tfs/Sistran";
            TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(UrlTfs));
            VersionControlServer versionControlServer = teamProjectCollection.GetService<VersionControlServer>();
            TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(UrlTfs));
            ListadePasta2.Clear();
            ItemSet items = versionControlServer.GetItems("$/All/Projetos/Bradesco/Sise/" + projeto + "/Construção/", RecursionType.Full);
            dgwdirconflito.Rows.Clear();
            int yy = items.Items.Count();
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
                  
                    //dgwtfs.Rows.Add(fonte, datachk, tambytes, caminhocompletocomfonte);
                    //foreach (DataGridViewRow row in dgwtfs.Rows)

                    //  ListadePasta1.Clear();

                    //if (ListadePasta1.Count == 0)
                    //{ ListadePasta1.Add(new ListaPasta1 { Diretorio = caminhocompletocomfonte.ToLower(), Fonte = fonte }); }

                    //  ListadePasta2.Clear();
                    // if (ListadePasta2.Count == 0)
                    { ListadePasta2.Add(new ListaPasta2 { Diretorio = caminhocompletocomfonte.ToLower(), Fonte = fonte,Tamanho= tambytes,Modulo=nomemodulo }); }

                 


                    //if (ListadePasta2.Count > 0 && ListadePasta1.Count > 0)
                    //{ var x = ListadePasta1.Select(a => a.Fonte).Except(ListadePasta2.Select(c => c.Fonte)); }

                    //if (caminhocompletocomfonte.Contains(fontes))
                    //{
                    //    retorno = caminhocompletocomfonte.Replace("$", "D:");

                    //    retorno = retorno.Replace(@"/", @"\"); retorno = retorno.Replace(@"D:\All\Projetos\Bradesco\Sise\", @"D:\Controle_de_Ambientes_Pastas\Projetos_Ativos\");
                    //}


                }

            }
            //duas listas pois nesse metodo se compara as duas listas
            //pode ocorer de ListadePasta1 ou ListadePasta2 não tenham dados, nao que o projeto
            //não tenha fontes nas pastas,mas que nao tenha fontes que estejam no filtro acima
            //logo no caso de uma lista não tiver fontes gerar menssagem,no caso das duas listas
            //gerar outra menssagem

            if (ListadePasta1.Count == 0 && ListadePasta2.Count == 0)
            {
                retornoerro = "Ambos projetos não possuem fontes";
            }
            if (ListadePasta1.Count == 0 || ListadePasta2.Count == 0)
            {
                retornoerro = "Um dos projetos não possue fontes";
            }

            if (ListadePasta1.Count > 0 && ListadePasta2.Count > 0)
            {

                var distItemsquerylistaobjetos = from list1Item in ListadePasta1
                                                 join list2Item in ListadePasta2 on list1Item.Fonte equals list2Item.Fonte
                                                 where (list2Item != null)
                                                 select list1Item;

                var distItemsquerylistaobjetos2 = from list2Item in ListadePasta2
                                                  join list1Item in ListadePasta1 on list2Item.Fonte equals list1Item.Fonte
                                                  where (list1Item != null)
                                                  select list2Item;

                int e = distItemsquerylistaobjetos.Count();
                int e2 = distItemsquerylistaobjetos2.Count();
                if (e != 0 && e2 != 0)
                {
                    var distdisferenca = from list2Item in distItemsquerylistaobjetos2
                                         join list1Item in distItemsquerylistaobjetos on list2Item.Fonte equals list1Item.Fonte
                                         where (list1Item.Tamanho != list2Item.Tamanho && list1Item.Modulo == list2Item.Modulo)
                                         select list2Item;
                    u = distdisferenca.Count();
                    var distdisferenca2 = (from list1Item in distItemsquerylistaobjetos
                                           join list2Item in distItemsquerylistaobjetos2 on list1Item.Fonte equals list2Item.Fonte
                                           where (list2Item.Tamanho != list1Item.Tamanho && list1Item.Modulo == list2Item.Modulo)
                                           select list1Item).Distinct();
                    // var MyCombinedList = distdisferenca.Union(distdisferenca2);
                    //foreach (var h in distdisferenca2)
                    //{
                    //    dgwtfs.Rows.Add(projeto,h.Fonte, h.Diretorio, h.Tamanho);
                    //}
                    //distItemsquerylistaobjetos = null;
                    //distItemsquerylistaobjetos2 = null;
                    foreach (var h in distdisferenca)
                    {
                        dgwtfs2.Rows.Add(projeto, h.Fonte, h.Diretorio, h.Tamanho);
                    }

                    //distdisferenca = null;
                    //distdisferenca2 = null;
                    //  var x = ListadePasta1.Select(a => a.Fonte).Except(ListadePasta2.Select(c => c.Fonte));
                }
            }

            return retornoerro;
        }


        ///botao testa
        ///
        public void testa(string projeto)
        {
            int itens = 0;
            int u = 0;
            //string projeto = "";
            string caminhosemfonte = "";
            string retorno = "";
            string caminhocompletocomfonte = "";
            //string fontes = "$/All/Projetos/Bradesco/Sise/17-2833/Construção/";
          //  string fontes = "$/All/Projetos/Bradesco/Sise/";
            string fontes = "$/All/Projetos/";//base de onde partir
            string UrlTfs = "http://tfs:8080/tfs/Sistran";
            TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(UrlTfs));
            VersionControlServer versionControlServer = teamProjectCollection.GetService<VersionControlServer>();
            TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(UrlTfs));
            //var t = versionControlServer.GetWorkspace(fontes);
           // ItemSet items = versionControlServer.GetItems(fontes , RecursionType.Full);
            ItemSet itemsAbaixodeProjetos = versionControlServer.GetItems(fontes, RecursionType.OneLevel);
            dgwdirconflito.Rows.Clear();
            foreach (Item item in itemsAbaixodeProjetos.Items)
            {
              int qtdeitensAbaixoProj= itemsAbaixodeProjetos.Items.Count();
                string fg = itemsAbaixodeProjetos.Items[1].ServerItem.ToString();
                ItemSet itemsAh = versionControlServer.GetItems(fg, RecursionType.OneLevel);
                string fgT = itemsAh.Items[3].ServerItem.ToString();
                ItemSet itemsAAh = versionControlServer.GetItems(fgT, RecursionType.OneLevel);
                char[] charSeparators = new char[]  {'/' };

                //Using split to isolated the Project Name and the File Name

                string[] ss = item.ServerItem.Split(charSeparators, StringSplitOptions.None);
                if (item.ServerItem.Contains(".cls") || item.ServerItem.Contains(".vb") || item.ServerItem.Contains(".frm") || item.ServerItem.Contains(".sql") || item.ServerItem.Contains(".asp") || item.ServerItem.Contains(".rpt") || item.ServerItem.Contains(".bas"))
                {
                    itens++;
                  //  string hh = items.Items[9].ToString();
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

                    //dgwtfs.Rows.Add(fonte, datachk, tambytes, caminhocompletocomfonte);
                    //foreach (DataGridViewRow row in dgwtfs.Rows)

                    //  ListadePasta1.Clear();

                    //   if (ListadePasta1.Count == 0)
                    { ListadePasta1.Add(new ListaPasta1 { Diretorio = caminhocompletocomfonte.ToLower(), Fonte = fonte, Tamanho = tambytes, Modulo = nomemodulo }); }

                    ////  ListadePasta2.Clear();
                    //if (ListadePasta2.Count == 0)
                    //{ ListadePasta2.Add(new ListaPasta2 { Diretorio = caminhocompletocomfonte.ToLower(), Fonte = fonte }); }

                    //if (ListadePasta2.Count > 0 && ListadePasta1.Count > 0)
                    //{ var x = ListadePasta1.Select(a => a.Fonte).Except(ListadePasta2.Select(c => c.Fonte)); }

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
