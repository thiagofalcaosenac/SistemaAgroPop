using Model;
namespace View
{
    public class Animal : Form
    {
        Panel buttonPanel = new Panel();
        DateTimePicker dataNascimentoTime;

        Label lbldataNascimento;
        Label lblnroRegistro;
        Label lblOrigem;
        Label lblCor;
        Label lblPeso;
        Label lblRaca;
        Label lblFazenda;

        TextBox txtdataNascimento;
        TextBox txtnroRegistro;
        ComboBox cmbOrigem;
        TextBox txtCor;
        TextBox txtPeso;
        ComboBox cmbRaca;
        List<Model.Raca> listRaca = new List<Model.Raca>();
        ComboBox cmbFazenda;
        List<Model.Fazenda> listFazenda = new List<Model.Fazenda>();
        Button btnConfirmar;
        Button btnVoltar;

        ProgressBar pbTest;

        int? idAnimalEdicao = null;

        public Animal(int? idAnimal)
        {
            this.Text = "Cadastro de Animal";

            this.Size = new Size(1000, 900);

            lbldataNascimento = new Label();
            lbldataNascimento.Text = "Data de Nascimento:";
            lbldataNascimento.AutoSize = true;
            lbldataNascimento.Location = new Point(20, 60);
        
            // Criar o DateTimePicker
            dataNascimentoTime = new DateTimePicker();
            dataNascimentoTime.Location = new Point(150, 60);
            dataNascimentoTime.Size = new Size(200, 18);

            lblnroRegistro = new Label();
            lblnroRegistro.Text = "Número do Registro:";
            lblnroRegistro.AutoSize = true;
            lblnroRegistro.Location = new Point(20, 120);

            txtnroRegistro = new TextBox();
            txtnroRegistro.Location = new Point(150, 120);
            txtnroRegistro.Size = new Size(200, 18);

            lblOrigem = new Label();
            lblOrigem.Text = "Origem:";
            lblOrigem.AutoSize = true;
            lblOrigem.Location = new Point(20, 180);

            cmbOrigem = new ComboBox();
            cmbOrigem.Location = new Point(150, 180);
            cmbOrigem.Size = new Size(200, 18);
            cmbOrigem.DropDownStyle = ComboBoxStyle.DropDownList; // Impedir que o usuário digite valores

            lblCor= new Label();
            lblCor.Text = "Cor:";
            lblCor.AutoSize = true;
            lblCor.Location = new Point(20, 240);

            txtCor = new TextBox();
            txtCor.Location = new Point(150, 240);
            txtCor.Size = new Size(200, 18);

            lblPeso = new Label();
            lblPeso.Text = "Peso:";
            lblPeso.AutoSize = true;
            lblPeso.Location = new Point(20, 300);

            txtPeso = new TextBox();
            txtPeso.Location = new Point(150, 300);
            txtPeso.Size = new Size(200, 18);

            lblRaca = new Label();
            lblRaca.Text = "Raça:";
            lblRaca.AutoSize = true;
            lblRaca.Location = new Point(20, 360);
           
            cmbRaca = new ComboBox();
            cmbRaca.Location = new Point(150, 360);
            cmbRaca.Size = new Size(200, 18);
            cmbRaca.DropDownStyle = ComboBoxStyle.DropDownList; // Impedir que o usuário digite valores
            this.adicionarRacaCombobox();
            lblFazenda = new Label();
            lblFazenda.Text = "Fazenda:";
            lblFazenda.AutoSize = true;
            lblFazenda.Location = new Point(20, 420);

            cmbFazenda = new ComboBox();
            cmbFazenda.Location = new Point(150, 420);
            cmbFazenda.Size = new Size(200, 18);
            cmbFazenda.DropDownStyle = ComboBoxStyle.DropDownList; // Impedir que o usuário digite valores
            this.adicionarFazendaCombobox();

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Location = new Point(800, 10);
            btnConfirmar.Click += new EventHandler(adicionarAnimalButton_Click);

            btnVoltar = new Button();
            btnVoltar.Text = "Voltar";
            btnVoltar.Location = new Point(900, 10);
            btnVoltar.Click += new EventHandler(voltarButton_Click);

            buttonPanel.Controls.Add(btnConfirmar);
            buttonPanel.Controls.Add(btnVoltar);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.lbldataNascimento);
            this.Controls.Add(this.lblnroRegistro);
            this.Controls.Add(this.lblOrigem);
            this.Controls.Add(this.lblCor);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.lblRaca);
            this.Controls.Add(this.lblFazenda);
            this.Controls.Add(this.dataNascimentoTime);
            this.Controls.Add(this.txtnroRegistro);
            this.Controls.Add(this.cmbOrigem); 
            this.Controls.Add(this.txtCor);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.cmbRaca);
            this.Controls.Add(this.cmbFazenda);
            this.Controls.Add(this.buttonPanel);
            this.PopulateComboBox();

            if (idAnimal != null)
            {
                this.setarDadosAnimalEdicao((int)idAnimal);
            }
        }

        private void adicionarAnimalButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.idAnimalEdicao != null && this.idAnimalEdicao > 0)
                {
                    Model.Raca racaSelecionada = this.buscarRacaSelecionadaCombobox();
                    Model.Fazenda fazendaSelecionada = this.buscarFazendaSelecionadaCombobox();
                    int origemSelecionada = this.buscarOrigemSelecionadaCombobox();
                    Controller.Animal.AlterarAnimal(
                        this.idAnimalEdicao.ToString(),
                        this.dataNascimentoTime.Text,
                        this.txtnroRegistro.Text,
                        this.cmbOrigem.Text,
                        this.txtCor.Text,
                        this.txtPeso.Text,
                        racaSelecionada.id.ToString(),
                        fazendaSelecionada.id.ToString()
                    );
                    MessageBox.Show("Animal atualizada com sucesso!");
                }
                else
                {
                    Model.Raca racaSelecionada = this.buscarRacaSelecionadaCombobox();
                    Model.Fazenda fazendaSelecionada = this.buscarFazendaSelecionadaCombobox();
                    int origemSelecionada = this.buscarOrigemSelecionadaCombobox();
                    Controller.Animal.CriarAnimal(
                        this.dataNascimentoTime.Text,
                        this.txtnroRegistro.Text,
                        this.cmbOrigem.Text,
                        this.txtCor.Text,
                        this.txtPeso.Text,
                        racaSelecionada.id.ToString(),
                        fazendaSelecionada.id.ToString()
                    );
                    MessageBox.Show("Animal cadastrada com sucesso!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private Model.Raca buscarRacaSelecionadaCombobox()
        {
            Model.Raca racaSelecionada = new Model.Raca();

            if (cmbRaca.SelectedItem != null)
            {
                String nomeRaca = cmbRaca.SelectedItem.ToString();

                racaSelecionada = this.listRaca.Where(item => item.nome.Equals(nomeRaca)).FirstOrDefault();
            }

            return racaSelecionada;
        }
         private Model.Fazenda buscarFazendaSelecionadaCombobox()
        {
            Model.Fazenda fazendaSelecionada = new Model.Fazenda();

            if (cmbFazenda.SelectedItem != null)
            {
                String nomeFazenda = cmbFazenda.SelectedItem.ToString();

                fazendaSelecionada = this.listFazenda.Where(item => item.nome.Equals(nomeFazenda)).FirstOrDefault();
            }

            return fazendaSelecionada;
        }

          private int buscarOrigemSelecionadaCombobox()
        {
            int indice = 0;
            if (cmbOrigem.SelectedItem != null)
            {
                String nome = cmbOrigem.SelectedItem.ToString();
                // Obter os valores do enum EnumEspecie
                EnumOrigem[] enumOrigem = (EnumOrigem[])Enum.GetValues(typeof(EnumOrigem));
                // Converter os valores para um array de objetos
                object[] enumOrigemObjects = enumOrigem.Cast<object>().ToArray();
                indice = Array.IndexOf(enumOrigemObjects, nome);
            }

            return indice;
        }
        private void PopulateComboBox()
    {
            // Obter os valores do enum EnumEspecie
            EnumOrigem[] enumOrigem = (EnumOrigem[])Enum.GetValues(typeof(EnumOrigem));

            // Converter os valores para um array de objetos
            object[] enumOrigemObjects = enumOrigem.Cast<object>().ToArray();

            // Adicionar os valores ao ComboBox
            cmbOrigem.Items.AddRange(enumOrigemObjects);

    }

        private void voltarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setarDadosAnimalEdicao(int idAnimal)
        {
            Model.Animal animalAtual = Controller.Animal.BuscarPorId(idAnimal);
            Model.Raca raca = Controller.Raca.BuscarPorId(animalAtual.racaid);
            Model.Fazenda fazenda = Controller.Fazenda.BuscarPorId(animalAtual.fazendaid);
           
			this.idAnimalEdicao = idAnimal;
			this.dataNascimentoTime.Text = animalAtual.dataNascimento.ToString(); //dataPiker
			this.txtnroRegistro.Text = animalAtual.nroRegistro.ToString();
			this.cmbOrigem.Text = animalAtual.origem.ToString();
			this.txtCor.Text = animalAtual.cor;
			this.txtPeso.Text = animalAtual.peso.ToString();
			//this.cmbRaca.Text = animalAtual.raca.ToString();
            
            this.cmbRaca.SelectedItem = raca.nome;
             this.cmbFazenda.SelectedItem = fazenda.nome;
        }

      private void adicionarRacaCombobox()
        {
           cmbRaca.Items.Clear();
            IEnumerable<Model.Raca> collectionRaca = Controller.Raca.ListarRacas();

            if (collectionRaca != null && collectionRaca.Count() > 0)
            {
                this.listRaca.AddRange(collectionRaca.ToList());

                foreach (var raca in collectionRaca)
                {
                    cmbRaca.Items.Add(raca.nome);
                }

                cmbRaca.SelectedIndex = 0;
            }
        }
        private void adicionarFazendaCombobox()
        {
           cmbFazenda.Items.Clear();
            IEnumerable<Model.Fazenda> collectionFazenda = Controller.Fazenda.ListarFazendas();

            if (collectionFazenda != null && collectionFazenda.Count() > 0)
            {
                this.listFazenda.AddRange(collectionFazenda.ToList());

                foreach (var fazenda in collectionFazenda)
                {
                    cmbFazenda.Items.Add(fazenda.nome);
                }

                cmbFazenda.SelectedIndex = 0;
            }

        }
    }   
}