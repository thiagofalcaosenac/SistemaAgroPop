
namespace View
{
    public class Fornecedor : Form
    {
        Panel buttonPanel = new Panel();
        Label lblNome;
        Label lblCnpj;
        Label lblRazaoSocial;
        Label lblTelefone;
        Label lblEmail;
        Label lblBairro;
        Label lblRua;
        Label lblNumero;
        Label lblComplemento;
        Label lblCidade;
        Label lblEstado;

        TextBox txtNome;
        TextBox txtCnpj;
        TextBox txtRazaoSocial;
        TextBox txtTelefone;
        TextBox txtEmail;
        TextBox txtBairro;
        TextBox txtRua;
        TextBox txtNumero;
        TextBox txtComplemento;
        TextBox txtCidade;
        TextBox txtEstado;

        Button btnConfirmar;
        Button btnVoltar;

        ProgressBar pbTest;

        int? idFornecedorEdicao = null;

        public Fornecedor(int? idFornecedor)
        {
            this.Text = "Cadastro de Fornecedor";

            this.Size = new Size(600, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#52bf90");

            lblNome = new Label();
            lblNome.Text = "Nome:";
            lblNome.AutoSize = true;
            lblNome.Location = new Point(10, 10);

            txtNome = new TextBox();
            txtNome.Location = new Point(150, 10);
            txtNome.Size = new Size(200, 18);

            lblCnpj = new Label();
            lblCnpj.Text = "Cnpj:";
            lblCnpj.AutoSize = true;
            lblCnpj.Location = new Point(10, 70);

            txtCnpj = new TextBox();
            txtCnpj.Location = new Point(150, 70);
            txtCnpj.Size = new Size(200, 18);

            lblRazaoSocial = new Label();
            lblRazaoSocial.Text = "Razao Social:";
            lblRazaoSocial.AutoSize = true;
            lblRazaoSocial.Location = new Point(10, 130);

            txtRazaoSocial = new TextBox();
            txtRazaoSocial.Location = new Point(150, 130);
            txtRazaoSocial.Size = new Size(200, 18);

            lblTelefone = new Label();
            lblTelefone.Text = "Telefone:";
            lblTelefone.AutoSize = true;
            lblTelefone.Location = new Point(10, 190);

            txtTelefone = new TextBox();
            txtTelefone.Location = new Point(150, 190);
            txtTelefone.Size = new Size(200, 18);

            lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(10, 250);

            txtEmail = new TextBox();
            txtEmail.Location = new Point(150, 250);
            txtEmail.Size = new Size(200, 18);

            lblBairro = new Label();
            lblBairro.Text = "Bairro:";
            lblBairro.AutoSize = true;
            lblBairro.Location = new Point(10, 310);

            txtBairro = new TextBox();
            txtBairro.Location = new Point(150, 310);
            txtBairro.Size = new Size(200, 18);

            lblRua = new Label();
            lblRua.Text = "Rua:";
            lblRua.AutoSize = true;
            lblRua.Location = new Point(10, 370);

            txtRua = new TextBox();
            txtRua.Location = new Point(150, 370);
            txtRua.Size = new Size(200, 18);

            lblNumero = new Label();
            lblNumero.Text = "Número:";
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(10, 430);

            txtNumero = new TextBox();
            txtNumero.Location = new Point(150, 430);
            txtNumero.Size = new Size(200, 18);

            lblComplemento = new Label();
            lblComplemento.Text = "Complemento:";
            lblComplemento.AutoSize = true;
            lblComplemento.Location = new Point(10, 490);

            txtComplemento = new TextBox();
            txtComplemento.Location = new Point(150, 490);
            txtComplemento.Size = new Size(200, 18);

            lblCidade = new Label();
            lblCidade.Text = "Cidade:";
            lblCidade.AutoSize = true;
            lblCidade.Location = new Point(10, 550);

            txtCidade = new TextBox();
            txtCidade.Location = new Point(150, 550);
            txtCidade.Size = new Size(200, 18);

            lblEstado = new Label();
            lblEstado.Text = "Estado:";
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(10, 610);

            txtEstado = new TextBox();
            txtEstado.Location = new Point(150, 610);
            txtEstado.Size = new Size(200, 18);

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Location = new Point(400, 10);
            btnConfirmar.Click += new EventHandler(adicionarFornecedorButton_Click);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");

            btnVoltar = new Button();
            btnVoltar.Text = "Voltar";
            btnVoltar.Location = new Point(500, 10);
            btnVoltar.Click += new EventHandler(voltarButton_Click);
            btnVoltar.ForeColor = Color.White;
            btnVoltar.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");

            buttonPanel.Controls.Add(btnConfirmar);
            buttonPanel.Controls.Add(btnVoltar);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblCnpj);
            this.Controls.Add(this.lblRazaoSocial);
            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblBairro);
            this.Controls.Add(this.lblRua);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblComplemento);
            this.Controls.Add(this.lblCidade);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtCnpj);
            this.Controls.Add(this.txtRazaoSocial);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.txtRua);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtComplemento);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.buttonPanel);

            if (idFornecedor != null)
            {
                this.setarDadosFornecedorEdicao((int)idFornecedor);
            }
        }

        private void adicionarFornecedorButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.idFornecedorEdicao != null && this.idFornecedorEdicao > 0)
                {
                    Controller.Fornecedor.AlterarFornecedor(
                        this.idFornecedorEdicao.ToString(),
                        this.txtCnpj.Text,
                        this.txtRazaoSocial.Text,
                         this.txtNome.Text,
                        this.txtTelefone.Text,
                        this.txtEmail.Text,
                        this.txtBairro.Text,
                        this.txtRua.Text,
                        this.txtNumero.Text,
                        this.txtComplemento.Text,
                        this.txtCidade.Text,
                        this.txtEstado.Text
                    );
                    MessageBox.Show("Fornecedor atualizada com sucesso!");
                }
                else
                {
                    Controller.Fornecedor.CriarFornecedor(
                        this.txtCnpj.Text,
                        this.txtRazaoSocial.Text,
                        this.txtNome.Text,
                        this.txtTelefone.Text,
                        this.txtEmail.Text,
                        this.txtBairro.Text,
                        this.txtRua.Text,
                        this.txtNumero.Text,
                        this.txtComplemento.Text,
                        this.txtCidade.Text,
                        this.txtEstado.Text
                    );
                    MessageBox.Show("Fornecedor cadastrada com sucesso!");
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

        private void setarDadosFornecedorEdicao(int idFornecedor)
        {
            Model.Fornecedor fornecedorAtual = Controller.Fornecedor.BuscarPorId(idFornecedor);
            Model.Endereco endereco = Controller.Endereco.BuscarPorId(fornecedorAtual.enderecoId);

			this.idFornecedorEdicao = idFornecedor;
			this.txtNome.Text = fornecedorAtual.nomeFantasia;
			this.txtCnpj.Text = fornecedorAtual.cnpj.ToString();
			this.txtRazaoSocial.Text = fornecedorAtual.razaoSocial.ToString();
			this.txtTelefone.Text = endereco.telefone;
			this.txtEmail.Text = endereco.email;
			this.txtBairro.Text = endereco.bairro;
			this.txtRua.Text = endereco.rua;
			this.txtNumero.Text = endereco.numero;
			this.txtComplemento.Text = endereco.complemento;
			this.txtCidade.Text = endereco.cidade;
			this.txtEstado.Text = endereco.estado;
        }

    }
}