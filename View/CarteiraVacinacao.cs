namespace Views
{
    public class CarteiraVacinacao : Form
    {
        Panel buttonPanel = new Panel();
        Label lblAnimal;
        Label lblDataVacinacao;
        Label lblProximaDose;
        Label lblNroDose;
        Label lblVacina;
        Label lblFornecedor;
        ComboBox comboBoxAnimal;
        TextBox txtDataVacinacao;
        TextBox txtProximaDose;
        TextBox txtNroDoses;
        ComboBox comboBoxVacina;
        ComboBox comboBoxFornecedor;
        Button btnConfirmar;
        Button btnVoltar;

        ProgressBar pbTest;

        int? idCarteiraVacinacaoEdicao = null;

        public CarteiraVacinacao(int? idCarteiraVacinacao)
        {
            this.Text = "Cadastro de Carteira de Vacinação";

            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblAnimal = new Label();
            lblAnimal.Text = "Animal:";
            lblAnimal.AutoSize = true;
            lblAnimal.Location = new Point(10, 10);

            comboBoxAnimal = new ComboBox();
            comboBoxAnimal.Location = new Point(150, 10);
            comboBoxAnimal.Size = new Size(200, 18);
            comboBoxAnimal.TabIndex = 0;
            this.setComboBoxAnimal();
            comboBoxAnimal.Text = " ";

            lblDataVacinacao = new Label();
            lblDataVacinacao.Text = "Data de Vacinação:";
            lblDataVacinacao.AutoSize = true;
            lblDataVacinacao.Location = new Point(10, 70);

            txtDataVacinacao = new TextBox();
            txtDataVacinacao.Location = new Point(150, 70);
            txtDataVacinacao.Size = new Size(200, 18);

            lblProximaDose = new Label();
            lblProximaDose.Text = "Data da Próxima Dose:";
            lblProximaDose.AutoSize = true;
            lblProximaDose.Location = new Point(10, 130);

            txtProximaDose = new TextBox();
            txtProximaDose.Location = new Point(150, 130);
            txtProximaDose.Size = new Size(200, 18);

            lblNroDose = new Label();
            lblNroDose.Text = "Nro de Doses:";
            lblNroDose.AutoSize = true;
            lblNroDose.Location = new Point(10, 190);

            txtNroDoses = new TextBox();
            txtNroDoses.Location = new Point(150, 190);
            txtNroDoses.Size = new Size(200, 18);

            lblVacina = new Label();
            lblVacina.Text = "Vacina:";
            lblVacina.AutoSize = true;
            lblVacina.Location = new Point(10, 250);

            comboBoxVacina = new ComboBox();
            comboBoxVacina.Location = new Point(150, 250);
            comboBoxVacina.Size = new Size(200, 18);
            comboBoxVacina.TabIndex = 0;
            this.setComboBoxVacina();
            comboBoxVacina.Text = " ";

            lblFornecedor = new Label();
            lblFornecedor.Text = "Fornecedor:";
            lblFornecedor.AutoSize = true;
            lblFornecedor.Location = new Point(10, 310);

            comboBoxFornecedor = new ComboBox();
            comboBoxFornecedor.Location = new Point(150, 310);
            comboBoxFornecedor.Size = new Size(200, 18);
            comboBoxFornecedor.TabIndex = 0;
            this.setComboBoxFornecedor();
            comboBoxFornecedor.Text = " ";

            btnVoltar = new Button();
            btnVoltar.Text = "Voltar";
            btnVoltar.Location = new Point(400, 10);
            btnVoltar.Click += new EventHandler(voltarButton_Click);

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Location = new Point(490, 10);
            btnConfirmar.Click += new EventHandler(adicionarCarteiraVacinacaoButton_Click);

            buttonPanel.Controls.Add(btnConfirmar);
            buttonPanel.Controls.Add(btnVoltar);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.lblAnimal);
            this.Controls.Add(this.lblDataVacinacao);
            this.Controls.Add(this.lblProximaDose);
            this.Controls.Add(this.lblNroDose);
            this.Controls.Add(this.lblVacina);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.comboBoxAnimal);
            this.Controls.Add(this.txtDataVacinacao);
            this.Controls.Add(this.txtProximaDose);
            this.Controls.Add(this.txtNroDoses);
            this.Controls.Add(this.comboBoxVacina);
            this.Controls.Add(this.comboBoxFornecedor);
            this.Controls.Add(this.buttonPanel);

            if (idCarteiraVacinacao != null)
            {
                this.setarDadosCarteiraVacinacaoEdicao((int)idCarteiraVacinacao);
            }
        }

        private void adicionarCarteiraVacinacaoButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.idCarteiraVacinacaoEdicao != null && this.idCarteiraVacinacaoEdicao > 0)
                {
                    Controller.CarteiraVacinacao.AlterarCarteiraVacinacao(
                        this.idCarteiraVacinacaoEdicao.Value,
                        this.txtDataVacinacao.Text,
                        this.txtProximaDose.Text,
                        Int32.Parse(this.txtNroDoses.Text)
                        );
                    MessageBox.Show("Carteira de Vacinção atualizada com sucesso!");
                }
                else
                {
                    Model.Animal animal = Controller.Animal.BuscarPorId((this.comboBoxAnimal.SelectedItem as ModelComboBox).Id);
                    Model.Vacina vacina = Controller.Vacina.BuscarPorId((this.comboBoxVacina.SelectedItem as ModelComboBox).Id);
                    Model.Fornecedor fornecedor = Controller.Fornecedor.BuscarPorId((this.comboBoxFornecedor.SelectedItem as ModelComboBox).Id);

                    Controller.CarteiraVacinacao.CriarCarteiraVacinacao(
                        0,
                        this.txtDataVacinacao.Text,
                        this.txtProximaDose.Text,
                        Int32.Parse(this.txtNroDoses.Text),
                        animal,
                        vacina,
                        fornecedor
                        );
                    MessageBox.Show("Carteira de Vacinação cadastrada com sucesso!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);

            }
        }

        private void voltarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setarDadosCarteiraVacinacaoEdicao(int idCarteiraVacinacao)
        {
            Model.CarteiraVacinacao CarteiraVacinacaoAtual = Controller.CarteiraVacinacao.BuscarPorId(idCarteiraVacinacao);
           
            this.idCarteiraVacinacaoEdicao = idCarteiraVacinacao;
            this.txtDataVacinacao.Text = CarteiraVacinacaoAtual.DataVacinacao.ToString();
            this.txtProximaDose.Text = CarteiraVacinacaoAtual.ProximaDose.ToString();
            this.txtNroDoses.Text = CarteiraVacinacaoAtual.NroDose.ToString();

            foreach (ModelComboBox animal in this.comboBoxAnimal.Items)
            {   
                if (CarteiraVacinacaoAtual.AnimalId.Equals(animal.Id))
                {
                    this.comboBoxAnimal.SelectedItem = animal;
                }
            }

            foreach (ModelComboBox comboboxVacina in this.comboBoxVacina.Items)
            {
                if (CarteiraVacinacaoAtual.VacinaId.Equals(comboboxVacina.Id))
                {
                    this.comboBoxVacina.SelectedItem = comboboxVacina;
                }
            }

            foreach (ModelComboBox comboboxFornecedor in this.comboBoxFornecedor.Items)
            {
                if (CarteiraVacinacaoAtual.FornecedorId.Equals(comboboxFornecedor.Id))
                {
                    this.comboBoxFornecedor.SelectedItem = comboboxFornecedor;
                }
            }

            this.comboBoxAnimal.Enabled = false;
            this.comboBoxVacina.Enabled = false;
            this.comboBoxFornecedor.Enabled = false;
        }

        private void setComboBoxAnimal()
        {
            List<Model.Animal> animais = Controller.Animal.ListarAnimals();
            foreach (Model.Animal animal in animais)
            {
                this.comboBoxAnimal.Items.Add(ModelComboBox.To(animal));
            }

        }

        private void setComboBoxVacina()
        {
            List<Model.Vacina> vacinas = Controller.Vacina.ListarVacina();
            foreach (Model.Vacina vacina in vacinas)
            {
                this.comboBoxVacina.Items.Add(ModelComboBox.To(vacina));
            }
        }

        private void setComboBoxFornecedor()
        {
            List<Model.Fornecedor> fornecedores = Controller.Fornecedor.ListarFornecedors();
            foreach (Model.Fornecedor fornecedor in fornecedores)
            {
                this.comboBoxFornecedor.Items.Add(ModelComboBox.To(fornecedor));
            }
        }
    }

    public class ModelComboBox
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ModelComboBox(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static ModelComboBox To(Model.Animal model)
        {
            return new ModelComboBox(model.id, model.nroRegistro.ToString());
        }

        public static ModelComboBox To(Model.Fornecedor model)
        {
            return new ModelComboBox(model.id, model.nomeFantasia);
        }

        public static ModelComboBox To(Model.Vacina model)
        {
            return new ModelComboBox(model.Id, model.Tipo.ToString());
        }

        public override string? ToString()
        {
            return Nome;
        }
    }
}