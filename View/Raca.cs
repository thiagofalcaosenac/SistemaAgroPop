
using Model;
namespace View
{
    public class Raca : Form
    {
        Panel buttonPanel = new Panel();

        Label lblEspecie;
        Label lblNome;
        Label lblPorte;
       

        ComboBox cmbEspecie;
        TextBox txtNome;
        ComboBox cmbPorte;
       

        Button btnConfirmar;
        Button btnVoltar;

        ProgressBar pbTest;

        int? idRacaEdicao = null;

        public Raca(int? idRaca)
        {
            this.Text = "Cadastro de Raca";

            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#52bf90");

            lblEspecie = new Label();
            lblEspecie.Text = "Especie:";
            lblEspecie.AutoSize = true;
            lblEspecie.Location = new Point(10, 10);
            // Criar o ComboBox
            cmbEspecie = new ComboBox();
            cmbEspecie.Location = new Point(150, 10);
            cmbEspecie.Size = new Size(200, 18);
            cmbEspecie.DropDownStyle = ComboBoxStyle.DropDownList; // Impedir que o usuário digite valores
            
            lblNome = new Label();
            lblNome.Text = "Nome da raça:";
            lblNome.AutoSize = true;
            lblNome.Location = new Point(10, 70);

            txtNome = new TextBox();
            txtNome.Location = new Point(150, 70);
            txtNome.Size = new Size(200, 18);

            lblPorte = new Label();
            lblPorte.Text = "Porte:";
            lblPorte.AutoSize = true;
            lblPorte.Location = new Point(10, 130);

            cmbPorte = new ComboBox();
            cmbPorte.Location = new Point(150, 130);
            cmbPorte.Size = new Size(200, 18);
            cmbPorte.DropDownStyle = ComboBoxStyle.DropDownList; // Impedir que o usuário digite valores


            btnConfirmar = new Button();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Location = new Point(400, 10);
            btnConfirmar.Click += new EventHandler(adicionarRacaButton_Click);
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

            this.Controls.Add(this.lblEspecie);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblPorte);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.buttonPanel);
            // Adicionar o ComboBox ao formulário
            this.Controls.Add(this.cmbEspecie); 
            this.Controls.Add(this.cmbPorte); 
            this.PopulateComboBox();
            if (idRaca != null)
            {
                this.setarDadosRacaEdicao((int)idRaca);
            }
        }

        private void adicionarRacaButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.idRacaEdicao != null && this.idRacaEdicao > 0)
                {
                    Controller.Raca.AlterarRaca(
                        this.idRacaEdicao.ToString(),
                        this.txtNome.Text,
                        this.cmbEspecie.Text,
                        this.cmbPorte.Text
                    );
                    MessageBox.Show("Raca atualizada com sucesso!");
                }
                else
                {
                    Controller.Raca.CriarRaca(
                        this.txtNome.Text,
                        this.cmbEspecie.Text,
                        this.cmbPorte.Text
                    );
                    MessageBox.Show("Raca cadastrada com sucesso!");
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
            EnumEspecie[] enumEspecie = (EnumEspecie[])Enum.GetValues(typeof(EnumEspecie));

            // Converter os valores para um array de objetos
            object[] enumEspecieObjects = enumEspecie.Cast<object>().ToArray();

            // Adicionar os valores ao ComboBox
            cmbEspecie.Items.AddRange(enumEspecieObjects);

            // Obter os valores do enum EnumEspecie
            EnumPorte[] enumPortes= (EnumPorte[])Enum.GetValues(typeof(EnumPorte));

            // Converter os valores para um array de objetos
            object[] enumPortesObjetos = enumPortes.Cast<object>().ToArray();

            // Adicionar os valores ao ComboBox
            cmbPorte.Items.AddRange(enumPortesObjetos);

    }
        private void voltarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setarDadosRacaEdicao(int idRaca)
        {
            Model.Raca racaAtual = Controller.Raca.BuscarPorId(idRaca);

			this.idRacaEdicao = idRaca;
			this.cmbEspecie.Text = racaAtual.especie.ToString();
			this.txtNome.Text = racaAtual.nome;
            this.cmbPorte.Text = racaAtual.porte.ToString();
	
        }
    }
}