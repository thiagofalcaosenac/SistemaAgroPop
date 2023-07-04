
namespace View
{
    public class VacinaFornecida : Form
    {
        Panel buttonPanel = new Panel();
        Label lblDataFabricacao;
        Label lblDataValidade;
        Label lblDataCompra;
        Label lblQuantidade;
        Label lblPreco;
        Label lblFornecedor;
        Label lblVacina;
        DateTimePicker txtDataFabricacao;
        DateTimePicker txtDataValidade;
        DateTimePicker txtDataCompra;
        TextBox txtQuantidade;
        TextBox txtPreco;
        ComboBox comboboxFornecedor;
        ComboBox comboboxVacina;

        Button btnConfirmar;
        Button btnVoltar;

        ProgressBar pbTest;

        int? idVacinaFornecidaEdicao = null;

        List<Model.Fornecedor> listaFornecedores = new List<Model.Fornecedor>();
        List<Model.Vacina> listaVacina = new List<Model.Vacina>();

        public VacinaFornecida(int? idVacinaFornecida)
        {
            this.Text = "Cadastro de Vacina Fornecida";

            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#52bf90");

            lblDataFabricacao = new Label();
            lblDataFabricacao.Text = "Data Fabricação:";
            lblDataFabricacao.AutoSize = true;
            lblDataFabricacao.Location = new Point(10, 10);
            txtDataFabricacao = new DateTimePicker();
            txtDataFabricacao.Location = new Point(150, 10);
            txtDataFabricacao.Size = new Size(200, 18);

            lblDataValidade = new Label();
            lblDataValidade.Text = "Data Validade:";
            lblDataValidade.AutoSize = true;
            lblDataValidade.Location = new Point(10, 70);
            txtDataValidade = new DateTimePicker();
            txtDataValidade.Location = new Point(150, 70);
            txtDataValidade.Size = new Size(200, 18);

            lblDataCompra = new Label();
            lblDataCompra.Text = "Data Compra:";
            lblDataCompra.AutoSize = true;
            lblDataCompra.Location = new Point(10, 130);
            txtDataCompra = new DateTimePicker();
            txtDataCompra.Location = new Point(150, 130);
            txtDataCompra.Size = new Size(200, 18);

            lblQuantidade = new Label();
            lblQuantidade.Text = "Quantidade:";
            lblQuantidade.AutoSize = true;
            lblQuantidade.Location = new Point(10, 190);
            txtQuantidade = new TextBox();
            txtQuantidade.Location = new Point(150, 190);
            txtQuantidade.Size = new Size(200, 18);

            lblPreco = new Label();
            lblPreco.Text = "Preço:";
            lblPreco.AutoSize = true;
            lblPreco.Location = new Point(10, 250);
            txtPreco = new TextBox();
            txtPreco.Location = new Point(150, 250);
            txtPreco.Size = new Size(200, 18);

            lblFornecedor = new Label();
            lblFornecedor.Text = "Fornecedor:";
            lblFornecedor.AutoSize = true;
            lblFornecedor.Location = new Point(10, 310);
            comboboxFornecedor = new ComboBox();
            comboboxFornecedor.Location = new Point(150, 310);
            comboboxFornecedor.Size = new Size(200, 18);
            this.adicionarFornecedoresCombobox();

            lblVacina = new Label();
            lblVacina.Text = "Vacina:";
            lblVacina.AutoSize = true;
            lblVacina.Location = new Point(10, 370);
            comboboxVacina = new ComboBox();
            comboboxVacina.Location = new Point(150, 370);
            comboboxVacina.Size = new Size(200, 18);
            this.adicionarVacinasCombobox();

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Location = new Point(400, 10);
            btnConfirmar.Click += new EventHandler(adicionarVacinaFornecidaButton_Click);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");

            btnVoltar = new Button();
            btnVoltar.Text = "Voltar";
            btnVoltar.Location = new Point(490, 10);
            btnVoltar.Click += new EventHandler(voltarButton_Click);
            btnVoltar.ForeColor = Color.White;
            btnVoltar.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");

            buttonPanel.Controls.Add(btnConfirmar);
            buttonPanel.Controls.Add(btnVoltar);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.lblDataFabricacao);
            this.Controls.Add(this.lblDataValidade);
            this.Controls.Add(this.lblDataCompra);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.lblVacina);
            this.Controls.Add(this.txtDataFabricacao);
            this.Controls.Add(this.txtDataValidade);
            this.Controls.Add(this.txtDataCompra);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.comboboxFornecedor);
            this.Controls.Add(this.comboboxVacina);
            this.Controls.Add(this.buttonPanel);

            if (idVacinaFornecida != null)
            {
                this.setarDadosVacinaFornecidaEdicao((int)idVacinaFornecida);
            }
        }

        private void adicionarVacinaFornecidaButton_Click(object sender, EventArgs e)
        {
            try
            {
                Model.Fornecedor fornecedorSelecionado = buscarFornecedorSelecionadoCombobox();
                Model.Vacina vacinaSelecionada = buscarVacinaSelecionadaCombobox();

                if (this.idVacinaFornecidaEdicao != null && this.idVacinaFornecidaEdicao > 0)
                {
                    Controller.VacinaFornecida.AlterarVacinaFornecida(
                        this.idVacinaFornecidaEdicao.GetValueOrDefault(),
                        this.txtDataFabricacao.Text,
                        this.txtDataValidade.Text,
                        this.txtDataCompra.Text,
                        Int32.Parse(this.txtQuantidade.Text),
                        float.Parse(this.txtPreco.Text)
                    );
                    MessageBox.Show("Vacina Fornecida atualizada com sucesso!");
                }
                else
                {
                    Controller.VacinaFornecida.CriarVacinaFornecida(
                        this.txtDataFabricacao.Text,
                        this.txtDataValidade.Text,
                        this.txtDataCompra.Text,
                        Int32.Parse(this.txtQuantidade.Text),
                        float.Parse(this.txtPreco.Text),
                        fornecedorSelecionado,
                        vacinaSelecionada
                    );
                    MessageBox.Show("Vacina Fornecida cadastrada com sucesso!");
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

        private void setarDadosVacinaFornecidaEdicao(int idVacinaFornecida)
        {
            Model.VacinaFornecida vacinaFornecidaAtual = Controller.VacinaFornecida.BuscarVacinaFornecidaPorId(idVacinaFornecida);
            Model.Vacina vacina = Controller.Vacina.BuscarPorId(vacinaFornecidaAtual.vacinaId);
            Model.Fornecedor fornecedor = Controller.Fornecedor.BuscarPorId(vacinaFornecidaAtual.fornecedorId);

			this.idVacinaFornecidaEdicao = idVacinaFornecida;
			this.txtDataFabricacao.Value = new DateTime(vacinaFornecidaAtual.DataFabricacao.Year, vacinaFornecidaAtual.DataFabricacao.Month, vacinaFornecidaAtual.DataFabricacao.Day);
			this.txtDataValidade.Value = new DateTime(vacinaFornecidaAtual.DataValidade.Year, vacinaFornecidaAtual.DataValidade.Month, vacinaFornecidaAtual.DataValidade.Day);
			this.txtDataCompra.Value = new DateTime(vacinaFornecidaAtual.DataCompra.Year, vacinaFornecidaAtual.DataCompra.Month, vacinaFornecidaAtual.DataCompra.Day);

			this.txtQuantidade.Text = vacinaFornecidaAtual.Quantidade.ToString();
			this.txtPreco.Text = vacinaFornecidaAtual.Preco.ToString();

			this.comboboxVacina.SelectedItem = vacina.Id.ToString();
			this.comboboxFornecedor.SelectedItem = fornecedor.razaoSocial;

            this.comboboxVacina.Enabled = false;
            this.comboboxFornecedor.Enabled = false;            
        }
        
        private void adicionarFornecedoresCombobox()
        {
            comboboxFornecedor.Items.Clear();
            List<Model.Fornecedor> fornecedores = Controller.Fornecedor.ListarFornecedors();

            if (fornecedores != null && fornecedores.Count() > 0)
            {
                this.listaFornecedores.AddRange(fornecedores);

                foreach (var fornecedor in fornecedores)
                {
                    comboboxFornecedor.Items.Add(fornecedor.razaoSocial);
                }

                comboboxFornecedor.SelectedIndex = 0;
            }
        }

        private Model.Fornecedor buscarFornecedorSelecionadoCombobox()
        {
            Model.Fornecedor fornecedorSelecionado = new Model.Fornecedor();

            if (comboboxFornecedor.SelectedItem != null)
            {
                String razaoSocial = comboboxFornecedor.SelectedItem.ToString();
                fornecedorSelecionado = this.listaFornecedores.Where(item => item.razaoSocial.Equals(razaoSocial)).FirstOrDefault();
            }

            return fornecedorSelecionado;
        }

        private void adicionarVacinasCombobox()
        {
            comboboxVacina.Items.Clear();
            List<Model.Vacina> vacinas = Controller.Vacina.ListarVacina();

            if (vacinas != null && vacinas.Count() > 0)
            {
                this.listaVacina.AddRange(vacinas);

                foreach (var vacina in vacinas)
                {
                    comboboxVacina.Items.Add(vacina.Id);
                }

                comboboxVacina.SelectedIndex = 0;
            }
        }

        private Model.Vacina buscarVacinaSelecionadaCombobox()
        {
            Model.Vacina vacinaSelected = new Model.Vacina();

            if (comboboxVacina.SelectedItem != null)
            {
                int idVacina = Int32.Parse(comboboxVacina.SelectedItem.ToString());
                vacinaSelected = this.listaVacina.Where(item => item.Id.Equals(idVacina)).FirstOrDefault();
            }

            return vacinaSelected;
        }

    }
}