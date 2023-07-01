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
        MonthCalendar mcDataVacinacao;
        MonthCalendar mcProximaDose;
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
            comboBoxAnimal.Location = new Point(150, 200);
            comboBoxAnimal.Size = new Size(200, 18);
            comboBoxAnimal.TabIndex = 0;
            this.setComboBoxAnimal();
            comboBoxAnimal.Text = " ";

            lblDataVacinacao = new Label();
            lblDataVacinacao.Text = "DataVacinacao:";
            lblDataVacinacao.AutoSize = true;
            lblDataVacinacao.Location = new Point(10, 100 );

            txtDataVacinacao = new TextBox();
            txtPeriodicidade.Location = new Point(150, 100);
            txtPeriodicidade.Size = new Size(200, 18);

            lblTipo = new Label();
            lblTipo.Text = "Tipo:";
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(10, 200);

            comboBoxTipo = new ComboBox();
            comboBoxTipo.Location = new Point(150, 200);
            comboBoxTipo.Size = new Size(200, 18);
            comboBoxTipo.TabIndex = 0;
            this.setComboBoxTipo();
            comboBoxTipo.Text = " ";

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

            this.Controls.Add(this.lblQtdMinima);
            this.Controls.Add(this.lblPeriodicidade);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtQtdMinima);
            this.Controls.Add(this.txtPeriodicidade);
            this.Controls.Add(this.comboBoxTipo);
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
                        (Model.CarteiraVacinacao.TipoCarteiraVacinacao) this.comboBoxTipo.SelectedItem,
                        Int32.Parse(this.txtQtdMinima.Text),
                        Int32.Parse(this.txtPeriodicidade.Text)
                        );
                    MessageBox.Show("Carteira de Vacinção atualizada com sucesso!");
                }
                else
                {
                    Controller.CarteiraVacinacao.CriarCarteiraVacinacao(
                        0,
                        (Model.CarteiraVacinacao.TipoCarteiraVacinacao) this.comboBoxTipo.SelectedItem,
                        Int32.Parse(this.txtQtdMinima.Text),
                        Int32.Parse(this.txtPeriodicidade.Text)
                        );
                    MessageBox.Show("Carteira de Vacinação cadastrada com sucesso!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

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
			this.txtQtdMinima.Text = CarteiraVacinacaoAtual.QtdMinima.ToString();
			this.txtPeriodicidade.Text = CarteiraVacinacaoAtual.Periodicidade.ToString();
			this.comboBoxTipo.SelectedItem = CarteiraVacinacaoAtual.Tipo;
        }

         private void setComboBoxTipo()
        {
            comboBoxTipo.Items.Clear();
            comboBoxTipo.Items.Add(Model.CarteiraVacinacao.TipoCarteiraVacinacao.FEBRE_AFTOSA);
            comboBoxTipo.Items.Add(Model.CarteiraVacinacao.TipoCarteiraVacinacao.BRUCELOSE);
            comboBoxTipo.Items.Add(Model.CarteiraVacinacao.TipoCarteiraVacinacao.RAIVA);
        }

    }
}