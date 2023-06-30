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
        TextBox txtRaca;
        TextBox txtFazenda;

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

            txtRaca = new TextBox();
            txtRaca.Location = new Point(150, 360);
            txtRaca.Size = new Size(200, 18);

            lblFazenda = new Label();
            lblFazenda.Text = "Fazenda:";
            lblFazenda.AutoSize = true;
            lblFazenda.Location = new Point(20, 420);

            txtFazenda = new TextBox();
            txtFazenda.Location = new Point(150, 420);
            txtFazenda.Size = new Size(200, 18);


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
            this.Controls.Add(this.txtdataNascimento);
            this.Controls.Add(this.txtnroRegistro);
            this.Controls.Add(this.cmbOrigem); 
            this.Controls.Add(this.txtCor);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.txtRaca);
            this.Controls.Add(this.txtFazenda);
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
                    Controller.Animal.AlterarAnimal(
                        this.idAnimalEdicao.ToString(),
                        this.txtdataNascimento.Text,
                        this.txtnroRegistro.Text,
                        this.cmbOrigem.Text,
                        this.txtCor.Text,
                        this.txtPeso.Text,
                        this.txtRaca.Text,
                        this.txtFazenda.Text
                    );
                    MessageBox.Show("Animal atualizada com sucesso!");
                }
                else
                {
                    Controller.Animal.CriarAnimal(
                        this.txtdataNascimento.Text,
                        this.txtnroRegistro.Text,
                        this.cmbOrigem.Text,
                        this.txtCor.Text,
                        this.txtPeso.Text,
                        this.txtRaca.Text,
                        this.txtFazenda.Text
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

			this.idAnimalEdicao = idAnimal;
			this.dataNascimentoTime.Text = animalAtual.dataNascimento.ToString(); //dataPiker
			this.txtnroRegistro.Text = animalAtual.nroRegistro.ToString();
			this.cmbOrigem.Text = animalAtual.origem.ToString();//combobox enum
			this.txtCor.Text = animalAtual.cor;
			this.txtPeso.Text = animalAtual.peso.ToString();
			//this.txtRaca.Text = animalAtual.raca; //combobox
			//this.txtFazenda.Text = animalAtual.fazenda; //combobox
        }

    }
}