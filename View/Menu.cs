namespace View
{
    public class Menu : Form
    {
        Button Fazenda = new Button();
        Button Raca = new Button();
        Button Animal = new Button();
        Button Fornecedor = new Button();
        Button VacinaFornecida = new Button();
        Button Vacina = new Button();
        Button CarteiraVacinacao = new Button();
        Label lblMenu = new Label();
        Button Sair = new Button();

        public void FormLayout()
        {
            lblMenu = new Label();
            lblMenu.Text = "MENU";
            lblMenu.Location = new Point(205, 50);
            this.Text = "Gestão de Fazenda";
            this.Size = new Size(450, 600);
            // this.AutoSize = true;
            // this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.StartPosition = FormStartPosition.CenterScreen;

            Fazenda.Text = "Fazenda";
            Fazenda.Name = "Fazenda";
            Fazenda.Location = new Point(75, 100);
            Fazenda.Height = 40;
            Fazenda.Width = 300;
            Fazenda.Click += new EventHandler(Fazenda_Click);

            Raca.Text = "Raça";
            Raca.Name = "Raça";
            Raca.Location = new Point(75, 150);
            Raca.Height = 40;
            Raca.Width = 300;
            Raca.Click += new EventHandler(Raca_Click);            

            Animal.Text = "Animal";
            Animal.Name = "Animal";
            Animal.Location = new Point(75, 200);
            Animal.Height = 40;
            Animal.Width = 300;
            Animal.Click += new EventHandler(Animal_Click);

            Fornecedor.Text = "Fornecedor";
            Fornecedor.Name = "Fornecedor";
            Fornecedor.Location = new Point(75, 250);
            Fornecedor.Height = 40;
            Fornecedor.Width = 300;
            Fornecedor.Click += new EventHandler(Fornecedor_Click);

            Vacina.Text = "Vacina";
            Vacina.Name = "Vacina";
            Vacina.Location = new Point(75, 300);
            Vacina.Height = 40;
            Vacina.Width = 300;
            Vacina.Click += new EventHandler(Vacina_Click);

            VacinaFornecida.Text = "Vacina Fornecida";
            VacinaFornecida.Name = "Vacina Fornecida";
            VacinaFornecida.Location = new Point(75, 350);
            VacinaFornecida.Height = 40;
            VacinaFornecida.Width = 300;
            VacinaFornecida.Click += new EventHandler(VacinaFornecida_Click);

            CarteiraVacinacao.Text = "Carteira de Vacinação";
            CarteiraVacinacao.Name = "Carteira de Vacinação";
            CarteiraVacinacao.Location = new Point(75, 400);
            CarteiraVacinacao.Height = 40;
            CarteiraVacinacao.Width = 300;
            CarteiraVacinacao.Click += new EventHandler(CarteiraVacinacao_Click);

            Sair.Text = "Sair";
            Sair.Name = "Sair";
            Sair.Location = new Point(75, 450);
            Sair.Height = 40;
            Sair.Width = 300;
            Sair.Click += new EventHandler(Sair_Click);

            Controls.Add(lblMenu);
            Controls.Add(Fazenda);
            Controls.Add(Raca);
            Controls.Add(Animal);
            Controls.Add(Fornecedor);
            Controls.Add(VacinaFornecida);
            Controls.Add(Vacina);
            Controls.Add(CarteiraVacinacao);
            Controls.Add(Sair);

        }

        public void Fazenda_Click(object sender, EventArgs e)
        {
            // using var context = new Models.Context();

            // ListaVacina listaVacina = new ListaVacina(context);
            // listaVacina.FormLayout();
            // listaVacina.Show();
        }

        public void Raca_Click(object sender, EventArgs e)
        {
            // using var context = new Models.Context();

            // ListaVacina listaVacina = new ListaVacina(context);
            // listaVacina.FormLayout();
            // listaVacina.Show();
        }

        public void Animal_Click(object sender, EventArgs e)
        {
            // using var context = new Models.Context();

            // ListaVacina listaVacina = new ListaVacina(context);
            // listaVacina.FormLayout();
            // listaVacina.Show();
        }

        public void Fornecedor_Click(object sender, EventArgs e)
        {
            // using var context = new Models.Context();

            // ListaAnimal listaAnimal = new ListaAnimal(context);
            // listaAnimal.FormLayout();
            // listaAnimal.Show();
        }

        public void Vacina_Click(object sender, EventArgs e)
        {
            // using var context = new Models.Context();

            // ListaFornecedor listaFornecedor = new ListaFornecedor(context);
            // listaFornecedor.FormLayout();
            // listaFornecedor.Show();
        }

        public void VacinaFornecida_Click(object sender, EventArgs e)
        {
            // using var context = new Models.Context();

            // ListaCarteiraVacinacao listaCarteiraVacinacao = new ListaCarteiraVacinacao(context);
            // listaCarteiraVacinacao.FormLayout();
            // listaCarteiraVacinacao.Show();
        }

        public void CarteiraVacinacao_Click(object sender, EventArgs e)
        {
            // using var context = new Models.Context();

            // ListaCarteiraVacinacao listaCarteiraVacinacao = new ListaCarteiraVacinacao(context);
            // listaCarteiraVacinacao.FormLayout();
            // listaCarteiraVacinacao.Show();
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}