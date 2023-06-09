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

            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#52bf90");

            lbldataNascimento = new Label();
            lbldataNascimento.Text = "Data de Nascimento:";
            lbldataNascimento.AutoSize = true;
            lbldataNascimento.Location = new Point(10, 10);
            lbldataNascimento.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            dataNascimentoTime = new DateTimePicker();
            dataNascimentoTime.Location = new Point(150, 10);
            dataNascimentoTime.Size = new Size(200, 18);

            lblnroRegistro = new Label();
            lblnroRegistro.Text = "Número do Registro:";
            lblnroRegistro.AutoSize = true;
            lblnroRegistro.Location = new Point(10, 70);
            lblnroRegistro.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtnroRegistro = new TextBox();
            txtnroRegistro.Location = new Point(150, 70);
            txtnroRegistro.Size = new Size(200, 18);
            txtnroRegistro.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblOrigem = new Label();
            lblOrigem.Text = "Origem:";
            lblOrigem.AutoSize = true;
            lblOrigem.Location = new Point(10, 130);
            lblOrigem.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            cmbOrigem = new ComboBox();
            cmbOrigem.Location = new Point(150, 130);
            cmbOrigem.Size = new Size(200, 18);
            cmbOrigem.DropDownStyle = ComboBoxStyle.DropDownList; // Impedir que o usuário digite valores
            cmbOrigem.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblCor= new Label();
            lblCor.Text = "Cor:";
            lblCor.AutoSize = true;
            lblCor.Location = new Point(10, 190);
            lblCor.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtCor = new TextBox();
            txtCor.Location = new Point(150, 190);
            txtCor.Size = new Size(200, 18);
            txtCor.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblPeso = new Label();
            lblPeso.Text = "Peso:";
            lblPeso.AutoSize = true;
            lblPeso.Location = new Point(10, 250);
            lblPeso.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtPeso = new TextBox();
            txtPeso.Location = new Point(150, 250);
            txtPeso.Size = new Size(200, 18);
            txtPeso.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblRaca = new Label();
            lblRaca.Text = "Raça:";
            lblRaca.AutoSize = true;
            lblRaca.Location = new Point(10, 310);
            lblRaca.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            cmbRaca = new ComboBox();
            cmbRaca.Location = new Point(150, 310);
            cmbRaca.Size = new Size(200, 18);
            cmbRaca.DropDownStyle = ComboBoxStyle.DropDownList; // Impedir que o usuário digite valores
            this.adicionarRacaCombobox();
            cmbRaca.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblFazenda = new Label();
            lblFazenda.Text = "Fazenda:";
            lblFazenda.AutoSize = true;
            lblFazenda.Location = new Point(10, 370);
            lblFazenda.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            cmbFazenda = new ComboBox();
            cmbFazenda.Location = new Point(150, 370);
            cmbFazenda.Size = new Size(200, 18);
            cmbFazenda.DropDownStyle = ComboBoxStyle.DropDownList; // Impedir que o usuário digite valores
            this.adicionarFazendaCombobox();
            cmbFazenda.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Location = new Point(400, 10);
            btnConfirmar.Click += new EventHandler(adicionarAnimalButton_Click);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            btnConfirmar.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnVoltar = new Button();
            btnVoltar.Text = "Voltar";
            btnVoltar.Location = new Point(490, 10);
            btnVoltar.Click += new EventHandler(voltarButton_Click);
            btnVoltar.ForeColor = Color.White;
            btnVoltar.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            btnVoltar.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

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
            cmbOrigem.SelectedIndex = 0;
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
			this.dataNascimentoTime.Value = new DateTime(animalAtual.dataNascimento.Year, animalAtual.dataNascimento.Month, animalAtual.dataNascimento.Day); //dataPiker
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