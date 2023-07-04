using View;
using Views;

namespace SistemaAgroPop
{

    public class MenuPrincipal : Form
    {
        Label lblMenu;
        PictureBox pictureBox;

        Button btnFazenda;
        Button btnRaca;
        Button btnAnimal;
        Button btnFornecedor;
        Button btnVacinaFornecida;
        Button btnVacina;
        Button btnCarteiraVacinacao;

        Button btnSair;
        Panel contentPanel;

        public MenuPrincipal()
        {
            this.Text = "Gestão de Fazenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            pictureBox = new PictureBox();
            pictureBox.Location = new Point(20, 20);
            pictureBox.Size = new Size(120, 30);
            pictureBox.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "/agroehtudo.jpg");

            btnFazenda = new Button();
            btnFazenda.Text = "Fazenda";
            btnFazenda.Size = new Size(120, 30);
            btnFazenda.Location = new Point(20, 100);
            btnFazenda.Click += new EventHandler(this.Fazenda_Click);
            btnFazenda.ForeColor = Color.White;
            btnFazenda.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");

            btnRaca = new Button();
            btnRaca.Text = "Raça";
            btnRaca.Size = new Size(120, 30);
            btnRaca.Location = new Point(20, 140);
            btnRaca.Click += new EventHandler(this.Raca_Click);
            btnRaca.ForeColor = Color.White;
            btnRaca.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");

            btnAnimal = new Button();
            btnAnimal.Text = "Animal";
            btnAnimal.Size = new Size(120, 30);
            btnAnimal.Location = new Point(20, 180);
            btnAnimal.Click += new EventHandler(this.Animal_Click);
            btnAnimal.ForeColor = Color.White;
            btnAnimal.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");

            btnFornecedor = new Button();
            btnFornecedor.Text = "Fornecedor";
            btnFornecedor.Size = new Size(120, 30);
            btnFornecedor.Location = new Point(20, 220);
            btnFornecedor.Click += new EventHandler(this.Fornecedor_Click);
            btnFornecedor.ForeColor = Color.White;
            btnFornecedor.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");

            btnVacinaFornecida = new Button();
            btnVacinaFornecida.Text = "Vacina Fornecida";
            btnVacinaFornecida.Size = new Size(120, 30);
            btnVacinaFornecida.Location = new Point(20, 260);
            btnVacinaFornecida.Click += new EventHandler(this.VacinaFornecida_Click);
            btnVacinaFornecida.ForeColor = Color.White;
            btnVacinaFornecida.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");

            btnVacina = new Button();
            btnVacina.Text = "Vacina";
            btnVacina.Size = new Size(120, 30);
            btnVacina.Location = new Point(20, 300);
            btnVacina.Click += new EventHandler(this.Vacina_Click);
            btnVacina.ForeColor = Color.White;
            btnVacina.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");

            btnCarteiraVacinacao = new Button();
            btnCarteiraVacinacao.Text = "Carteira Vacinação";
            btnCarteiraVacinacao.Size = new Size(120, 30);
            btnCarteiraVacinacao.Location = new Point(20, 340);
            btnCarteiraVacinacao.Click += new EventHandler(this.CarteiraVacinacao_Click); 
            btnCarteiraVacinacao.ForeColor = Color.White;
            btnCarteiraVacinacao.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");           

            btnSair = new Button();
            btnSair.Text = "Sair";
            btnSair.Size = new Size(120, 30);
            btnSair.Location = new Point(20, 460);
            btnSair.Click += new EventHandler(this.btnSairClick);
            btnSair.ForeColor = Color.White;
            btnSair.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");

            contentPanel = new Panel();
            contentPanel.AutoSize = true; 
            contentPanel.Location = new Point(160, 60);
            contentPanel.BorderStyle = BorderStyle.Fixed3D;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#49ab81");

            this.Controls.Add(lblMenu);
            this.Controls.Add(pictureBox);
            this.Controls.Add(btnFazenda);
            this.Controls.Add(btnRaca);
            this.Controls.Add(btnAnimal);
            this.Controls.Add(btnFornecedor);
            this.Controls.Add(btnVacinaFornecida);
            this.Controls.Add(btnVacina);
            this.Controls.Add(btnCarteiraVacinacao);            
            this.Controls.Add(btnSair);
            this.Controls.Add(contentPanel);
            this.Size = new Size(800, 600);
        }

        public void Fazenda_Click(object sender, EventArgs e)
        {

            this.contentPanel.Controls.Clear();

            ListaFazenda listaFazendaForm = new ListaFazenda();
            listaFazendaForm.TopLevel = false;
            listaFazendaForm.AutoScroll = true;
            this.contentPanel.Controls.Add(listaFazendaForm);            
            listaFazendaForm.Show();
        }

        public void Raca_Click(object sender, EventArgs e)
        {

            this.contentPanel.Controls.Clear();

            ListaRaca listaRacaForm = new ListaRaca();
            listaRacaForm.TopLevel = false;
            listaRacaForm.AutoScroll = true;
            this.contentPanel.Controls.Add(listaRacaForm);            
            listaRacaForm.Show();
        }

        public void Animal_Click(object sender, EventArgs e)
        {

            this.contentPanel.Controls.Clear();
                        
            ListaAnimal listaAnimalForm = new ListaAnimal();
            listaAnimalForm.TopLevel = false;
            listaAnimalForm.AutoScroll = true;
            this.contentPanel.Controls.Add(listaAnimalForm);            
            listaAnimalForm.Show();
        }

        public void Fornecedor_Click(object sender, EventArgs e)
        {

            this.contentPanel.Controls.Clear();

            ListaFornecedor listaFornecedorForm = new ListaFornecedor();
            listaFornecedorForm.TopLevel = false;
            listaFornecedorForm.AutoScroll = true;
            this.contentPanel.Controls.Add(listaFornecedorForm);            
            listaFornecedorForm.Show();
        }

        public void Vacina_Click(object sender, EventArgs e)
        {

            this.contentPanel.Controls.Clear();
                        
            ListaVacina listaVacinaForm = new ListaVacina();
            listaVacinaForm.TopLevel = false;
            listaVacinaForm.AutoScroll = true;
            this.contentPanel.Controls.Add(listaVacinaForm);            
            listaVacinaForm.Show();
        }

        public void VacinaFornecida_Click(object sender, EventArgs e)
        {

            this.contentPanel.Controls.Clear();
                        
            ListaVacinaFornecida listaVacinaFornecidaForm = new ListaVacinaFornecida();
            listaVacinaFornecidaForm.TopLevel = false;
            listaVacinaFornecidaForm.AutoScroll = true;
            this.contentPanel.Controls.Add(listaVacinaFornecidaForm);
            listaVacinaFornecidaForm.Show();
        }

        public void CarteiraVacinacao_Click(object sender, EventArgs e)
        {

            this.contentPanel.Controls.Clear();
                        
            ListaCarteiraVacinacao listaCarteiraVacinacaoForm = new ListaCarteiraVacinacao();
            listaCarteiraVacinacaoForm.TopLevel = false;
            listaCarteiraVacinacaoForm.AutoScroll = true;
            this.contentPanel.Controls.Add(listaCarteiraVacinacaoForm);            
            listaCarteiraVacinacaoForm.Show();
        }

        private void btnSairClick(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}