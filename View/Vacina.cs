namespace Views
{
    public class Vacina : Form
    {
        Panel buttonPanel = new Panel();
        Label lblQtdMinima;
        Label lblPeriodicidade;
        Label lblTipo;
        TextBox txtQtdMinima;
        TextBox txtPeriodicidade;
        ComboBox comboBoxTipo;
        Button btnConfirmar;
        Button btnVoltar;

        ProgressBar pbTest;

        int? idVacinaEdicao = null;

        public Vacina(int? idVacina)
        {
            this.Text = "Cadastro de Vacina";

            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#52bf90");

            lblQtdMinima = new Label();
            lblQtdMinima.Text = "Quantidade Mínima:";
            lblQtdMinima.AutoSize = true;
            lblQtdMinima.Location = new Point(10, 10);
            lblQtdMinima.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtQtdMinima = new TextBox();
            txtQtdMinima.Location = new Point(150, 10);
            txtQtdMinima.Size = new Size(200, 18);
            txtQtdMinima.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblPeriodicidade = new Label();
            lblPeriodicidade.Text = "Periodicidade:";
            lblPeriodicidade.AutoSize = true;
            lblPeriodicidade.Location = new Point(10, 70 );
            lblPeriodicidade.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtPeriodicidade = new TextBox();
            txtPeriodicidade.Location = new Point(150, 70);
            txtPeriodicidade.Size = new Size(200, 18);
            txtPeriodicidade.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblTipo = new Label();
            lblTipo.Text = "Tipo:";
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(10, 130);
            lblTipo.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            comboBoxTipo = new ComboBox();
            comboBoxTipo.Location = new Point(150, 130);
            comboBoxTipo.Size = new Size(200, 18);
            comboBoxTipo.TabIndex = 0;
            this.setComboBoxTipo();
            comboBoxTipo.Text = " ";
            comboBoxTipo.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Location = new Point(400, 10);
            btnConfirmar.Click += new EventHandler(adicionarVacinaButton_Click);
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

            this.Controls.Add(this.lblQtdMinima);
            this.Controls.Add(this.lblPeriodicidade);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtQtdMinima);
            this.Controls.Add(this.txtPeriodicidade);
            this.Controls.Add(this.comboBoxTipo);
            this.Controls.Add(this.buttonPanel);

            if (idVacina != null)
            {
                this.setarDadosVacinaEdicao((int)idVacina);
            }
        }

        private void adicionarVacinaButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.idVacinaEdicao != null && this.idVacinaEdicao > 0)
                {
                    Controller.Vacina.AlterarVacina(
                        this.idVacinaEdicao.Value,
                        (Model.Vacina.TipoVacina) this.comboBoxTipo.SelectedItem,
                        this.txtPeriodicidade.Text,
                        this.txtQtdMinima.Text
                        );
                    MessageBox.Show("Vacina atualizada com sucesso!");
                }
                else
                {
                    Controller.Vacina.CriarVacina(
                        0,
                        (Model.Vacina.TipoVacina) this.comboBoxTipo.SelectedItem,
                        this.txtPeriodicidade.Text,
                        this.txtQtdMinima.Text
                        );
                    MessageBox.Show("Vacina cadastrada com sucesso!");
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

        private void setarDadosVacinaEdicao(int idVacina)
        {
            Model.Vacina VacinaAtual = Controller.Vacina.BuscarPorId(idVacina);

			this.idVacinaEdicao = idVacina;
			this.txtQtdMinima.Text = VacinaAtual.QtdMinima.ToString();
			this.txtPeriodicidade.Text = VacinaAtual.Periodicidade.ToString();
			this.comboBoxTipo.SelectedItem = VacinaAtual.Tipo;
        }

         private void setComboBoxTipo()
        {
            comboBoxTipo.Items.Clear();
            comboBoxTipo.Items.Add(Model.Vacina.TipoVacina.FEBRE_AFTOSA);
            comboBoxTipo.Items.Add(Model.Vacina.TipoVacina.BRUCELOSE);
            comboBoxTipo.Items.Add(Model.Vacina.TipoVacina.RAIVA);

            comboBoxTipo.SelectedIndex = 0;
        }

    }
}