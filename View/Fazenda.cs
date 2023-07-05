
namespace View
{
    public class Fazenda : Form
    {
        Panel buttonPanel = new Panel();

        Label lblNome;
        Label lblQtdLimiteAnimal;
        Label lblTelefone;
        Label lblEmail;
        Label lblBairro;
        Label lblRua;
        Label lblNumero;
        Label lblComplemento;
        Label lblCidade;
        Label lblEstado;

        TextBox txtNome;
        TextBox txtQtdLimiteAnimal;
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

        int? idFazendaEdicao = null;

        public Fazenda(int? idFazenda)
        {
            this.Text = "Cadastro de Fazenda";

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

            lblQtdLimiteAnimal = new Label();
            lblQtdLimiteAnimal.Text = "Qtd Limite Animal:";
            lblQtdLimiteAnimal.AutoSize = true;
            lblQtdLimiteAnimal.Location = new Point(10, 70);
            lblQtdLimiteAnimal.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtQtdLimiteAnimal = new TextBox();
            txtQtdLimiteAnimal.Location = new Point(150, 70);
            txtQtdLimiteAnimal.Size = new Size(200, 18);
            txtQtdLimiteAnimal.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblTelefone = new Label();
            lblTelefone.Text = "Telefone:";
            lblTelefone.AutoSize = true;
            lblTelefone.Location = new Point(10, 130);
            lblTelefone.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtTelefone = new TextBox();
            txtTelefone.Location = new Point(150, 130);
            txtTelefone.Size = new Size(200, 18);
            txtTelefone.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(10, 190);
            lblEmail.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtEmail = new TextBox();
            txtEmail.Location = new Point(150, 190);
            txtEmail.Size = new Size(200, 18);
            txtEmail.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblBairro = new Label();
            lblBairro.Text = "Bairro:";
            lblBairro.AutoSize = true;
            lblBairro.Location = new Point(10, 250);
            lblBairro.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtBairro = new TextBox();
            txtBairro.Location = new Point(150, 250);
            txtBairro.Size = new Size(200, 18);
            txtBairro.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblRua = new Label();
            lblRua.Text = "Rua:";
            lblRua.AutoSize = true;
            lblRua.Location = new Point(10, 310);
            lblRua.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtRua = new TextBox();
            txtRua.Location = new Point(150, 310);
            txtRua.Size = new Size(200, 18);
            txtRua.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblNumero = new Label();
            lblNumero.Text = "Número:";
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(10, 370);
            lblNumero.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtNumero = new TextBox();
            txtNumero.Location = new Point(150, 370);
            txtNumero.Size = new Size(200, 18);
            txtNumero.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblComplemento = new Label();
            lblComplemento.Text = "Complemento:";
            lblComplemento.AutoSize = true;
            lblComplemento.Location = new Point(10, 430);
            lblComplemento.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtComplemento = new TextBox();
            txtComplemento.Location = new Point(150, 430);
            txtComplemento.Size = new Size(200, 18);
            txtComplemento.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblCidade = new Label();
            lblCidade.Text = "Cidade:";
            lblCidade.AutoSize = true;
            lblCidade.Location = new Point(10, 490);
            lblCidade.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtCidade = new TextBox();
            txtCidade.Location = new Point(150, 490);
            txtCidade.Size = new Size(200, 18);
            txtCidade.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            lblEstado = new Label();
            lblEstado.Text = "Estado:";
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(10, 550);
            lblEstado.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtEstado = new TextBox();
            txtEstado.Location = new Point(150, 550);
            txtEstado.Size = new Size(200, 18);
            txtEstado.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Location = new Point(400, 10);
            btnConfirmar.Click += new EventHandler(adicionarFazendaButton_Click);
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
            this.Controls.Add(this.lblQtdLimiteAnimal);
            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblBairro);
            this.Controls.Add(this.lblRua);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblComplemento);
            this.Controls.Add(this.lblCidade);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtQtdLimiteAnimal);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.txtRua);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtComplemento);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.buttonPanel);

            if (idFazenda != null)
            {
                this.setarDadosFazendaEdicao((int)idFazenda);
            }
        }

        private void adicionarFazendaButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.idFazendaEdicao != null && this.idFazendaEdicao > 0)
                {
                    Controller.Fazenda.AlterarFazenda(
                        this.idFazendaEdicao.ToString(),
                        this.txtNome.Text,
                        this.txtQtdLimiteAnimal.Text,
                        this.txtTelefone.Text,
                        this.txtEmail.Text,
                        this.txtBairro.Text,
                        this.txtRua.Text,
                        this.txtNumero.Text,
                        this.txtComplemento.Text,
                        this.txtCidade.Text,
                        this.txtEstado.Text
                    );
                    MessageBox.Show("Fazenda atualizada com sucesso!");
                }
                else
                {
                    Controller.Fazenda.CriarFazenda(
                        this.txtNome.Text,
                        this.txtQtdLimiteAnimal.Text,
                        this.txtTelefone.Text,
                        this.txtEmail.Text,
                        this.txtBairro.Text,
                        this.txtRua.Text,
                        this.txtNumero.Text,
                        this.txtComplemento.Text,
                        this.txtCidade.Text,
                        this.txtEstado.Text
                    );
                    MessageBox.Show("Fazenda cadastrada com sucesso!");
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

        private void setarDadosFazendaEdicao(int idFazenda)
        {
            Model.Fazenda fazendaAtual = Controller.Fazenda.BuscarPorId(idFazenda);
            Model.Endereco endereco = Controller.Endereco.BuscarPorId(fazendaAtual.enderecoId);

			this.idFazendaEdicao = idFazenda;
			this.txtNome.Text = fazendaAtual.nome;
			this.txtQtdLimiteAnimal.Text = fazendaAtual.qtdLimiteAnimal.ToString();
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