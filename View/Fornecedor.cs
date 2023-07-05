
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
            lblNome.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtNome = new TextBox();
            txtNome.Location = new Point(150, 10);
            txtNome.Size = new Size(200, 18);
            txtNome.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblCnpj = new Label();
            lblCnpj.Text = "Cnpj:";
            lblCnpj.AutoSize = true;
            lblCnpj.Location = new Point(10, 70);
            lblCnpj.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtCnpj = new TextBox();
            txtCnpj.Location = new Point(150, 70);
            txtCnpj.Size = new Size(200, 18);
            lblCnpj.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblRazaoSocial = new Label();
            lblRazaoSocial.Text = "Razao Social:";
            lblRazaoSocial.AutoSize = true;
            lblRazaoSocial.Location = new Point(10, 130);
            lblRazaoSocial.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtRazaoSocial = new TextBox();
            txtRazaoSocial.Location = new Point(150, 130);
            txtRazaoSocial.Size = new Size(200, 18);
            txtRazaoSocial.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblTelefone = new Label();
            lblTelefone.Text = "Telefone:";
            lblTelefone.AutoSize = true;
            lblTelefone.Location = new Point(10, 190);
            lblTelefone.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtTelefone = new TextBox();
            txtTelefone.Location = new Point(150, 190);
            txtTelefone.Size = new Size(200, 18);

            lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(10, 250);
            lblEmail.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtEmail = new TextBox();
            txtEmail.Location = new Point(150, 250);
            txtEmail.Size = new Size(200, 18);
            txtEmail.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblBairro = new Label();
            lblBairro.Text = "Bairro:";
            lblBairro.AutoSize = true;
            lblBairro.Location = new Point(10, 310);
            lblBairro.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtBairro = new TextBox();
            txtBairro.Location = new Point(150, 310);
            txtBairro.Size = new Size(200, 18);
            txtBairro.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblRua = new Label();
            lblRua.Text = "Rua:";
            lblRua.AutoSize = true;
            lblRua.Location = new Point(10, 370);
            lblRua.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtRua = new TextBox();
            txtRua.Location = new Point(150, 370);
            txtRua.Size = new Size(200, 18);
            txtRua.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblNumero = new Label();
            lblNumero.Text = "Número:";
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(10, 430);
            lblNumero.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtNumero = new TextBox();
            txtNumero.Location = new Point(150, 430);
            txtNumero.Size = new Size(200, 18);
            txtNumero.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblComplemento = new Label();
            lblComplemento.Text = "Complemento:";
            lblComplemento.AutoSize = true;
            lblComplemento.Location = new Point(10, 490);
            lblComplemento.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtComplemento = new TextBox();
            txtComplemento.Location = new Point(150, 490);
            txtComplemento.Size = new Size(200, 18);
            txtComplemento.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblCidade = new Label();
            lblCidade.Text = "Cidade:";
            lblCidade.AutoSize = true;
            lblCidade.Location = new Point(10, 550);
            lblCidade.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtCidade = new TextBox();
            txtCidade.Location = new Point(150, 550);
            txtCidade.Size = new Size(200, 18);
            txtCidade.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblEstado = new Label();
            lblEstado.Text = "Estado:";
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(10, 610);
            lblEstado.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtEstado = new TextBox();
            txtEstado.Location = new Point(150, 610);
            txtEstado.Size = new Size(200, 18);
            txtEstado.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Location = new Point(400, 10);
            btnConfirmar.Click += new EventHandler(adicionarFornecedorButton_Click);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            btnConfirmar.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnVoltar = new Button();
            btnVoltar.Text = "Voltar";
            btnVoltar.Location = new Point(500, 10);
            btnVoltar.Click += new EventHandler(voltarButton_Click);
            btnVoltar.ForeColor = Color.White;
            btnVoltar.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            btnVoltar.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

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