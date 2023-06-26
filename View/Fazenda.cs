
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

            this.Size = new Size(1000, 900);

            lblNome = new Label();
            lblNome.Text = "Nome:";
            lblNome.AutoSize = true;
            lblNome.Location = new Point(20, 60);

            txtNome = new TextBox();
            txtNome.Location = new Point(150, 60);
            txtNome.Size = new Size(200, 18);

            lblQtdLimiteAnimal = new Label();
            lblQtdLimiteAnimal.Text = "Qtd Limite Animal:";
            lblQtdLimiteAnimal.AutoSize = true;
            lblQtdLimiteAnimal.Location = new Point(20, 120);

            txtQtdLimiteAnimal = new TextBox();
            txtQtdLimiteAnimal.Location = new Point(150, 120);
            txtQtdLimiteAnimal.Size = new Size(200, 18);

            lblTelefone = new Label();
            lblTelefone.Text = "Telefone:";
            lblTelefone.AutoSize = true;
            lblTelefone.Location = new Point(20, 180);

            txtTelefone = new TextBox();
            txtTelefone.Location = new Point(150, 180);
            txtTelefone.Size = new Size(200, 18);

            lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 240);

            txtEmail = new TextBox();
            txtEmail.Location = new Point(150, 240);
            txtEmail.Size = new Size(200, 18);

            lblBairro = new Label();
            lblBairro.Text = "Bairro:";
            lblBairro.AutoSize = true;
            lblBairro.Location = new Point(20, 300);

            txtBairro = new TextBox();
            txtBairro.Location = new Point(150, 300);
            txtBairro.Size = new Size(200, 18);

            lblRua = new Label();
            lblRua.Text = "Rua:";
            lblRua.AutoSize = true;
            lblRua.Location = new Point(20, 360);

            txtRua = new TextBox();
            txtRua.Location = new Point(150, 360);
            txtRua.Size = new Size(200, 18);

            lblNumero = new Label();
            lblNumero.Text = "Número:";
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(20, 420);

            txtNumero = new TextBox();
            txtNumero.Location = new Point(150, 420);
            txtNumero.Size = new Size(200, 18);

            lblComplemento = new Label();
            lblComplemento.Text = "Complemento:";
            lblComplemento.AutoSize = true;
            lblComplemento.Location = new Point(20, 480);

            txtComplemento = new TextBox();
            txtComplemento.Location = new Point(150, 480);
            txtComplemento.Size = new Size(200, 18);

            lblCidade = new Label();
            lblCidade.Text = "Cidade:";
            lblCidade.AutoSize = true;
            lblCidade.Location = new Point(20, 540);

            txtCidade = new TextBox();
            txtCidade.Location = new Point(150, 540);
            txtCidade.Size = new Size(200, 18);

            lblEstado = new Label();
            lblEstado.Text = "Estado:";
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(20, 600);

            txtEstado = new TextBox();
            txtEstado.Location = new Point(150, 600);
            txtEstado.Size = new Size(200, 18);

            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Location = new Point(10, 10);
            btnConfirmar.Click += new EventHandler(adicionarFazendaButton_Click);

            btnVoltar = new Button();
            btnVoltar.Text = "Voltar";
            btnVoltar.Location = new Point(400, 10);
            btnVoltar.Click += new EventHandler(voltarButton_Click);

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