using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Views
{
    class ListaCarteiraVacinacao : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView carteiraVacinacaoGridView = new DataGridView();
        private Button adicionarCarteiraVacinacaoButton = new Button();
        private Button atualizarCarteiraVacinacaoButton = new Button();
        private Button deletarCarteiraVacinacaoButton = new Button();
        private Button voltarButton = new Button();

        public ListaCarteiraVacinacao()
        {
            this.Text = "Listagem de Carteira de Vacinação";
            this.Load += new EventHandler(ListaCarteiraVacinacao_Load);

            // List<Model.CarteiraVacinacao> carteirasVacinacao = Controller.CarteiraVacinacao.VerificarCarteirasProximaDose();

            //  foreach (Model.CarteiraVacinacao carteiraVacinacao in carteirasVacinacao)
            // {
            //     Console.WriteLine($"A carteira de vacinação de ID {carteiraVacinacao.Id} está com a próxima dose agendada para daqui a 30 dias.");
            // }
        }

        private void ListaCarteiraVacinacao_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void carteiraVacinacaoGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.carteiraVacinacaoGridView.Columns[e.ColumnIndex].Name == "Release Date")
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = DateTime.Parse(e.Value.ToString())
                                .ToLongDateString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                        }
                    }
                }
            }
        }

        private void SetupLayout()
        {
            adicionarCarteiraVacinacaoButton.Text = "Adicionar";
            adicionarCarteiraVacinacaoButton.Location = new Point(250, 10);
            adicionarCarteiraVacinacaoButton.Click += new EventHandler(adicionarCarteiraVacinacaoButton_Click);
            adicionarCarteiraVacinacaoButton.ForeColor = Color.White;
            adicionarCarteiraVacinacaoButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            adicionarCarteiraVacinacaoButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            atualizarCarteiraVacinacaoButton.Text = "Editar";
            atualizarCarteiraVacinacaoButton.Location = new Point(330, 10);
            atualizarCarteiraVacinacaoButton.Click += new EventHandler(atualizarCarteiraVacinacaoButton_Click);
            atualizarCarteiraVacinacaoButton.ForeColor = Color.White;
            atualizarCarteiraVacinacaoButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            adicionarCarteiraVacinacaoButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            deletarCarteiraVacinacaoButton.Text = "Excluir";
            deletarCarteiraVacinacaoButton.Location = new Point(410, 10);
            deletarCarteiraVacinacaoButton.Click += new EventHandler(deletarCarteiraVacinacaoButton_Click);
            deletarCarteiraVacinacaoButton.ForeColor = Color.White;
            deletarCarteiraVacinacaoButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            deletarCarteiraVacinacaoButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            voltarButton.Text = "Voltar";
            voltarButton.Location = new Point(490, 10);
            voltarButton.Click += new EventHandler(voltarButton_Click);
            voltarButton.ForeColor = Color.White;
            voltarButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            voltarButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            buttonPanel.Controls.Add(adicionarCarteiraVacinacaoButton);
            buttonPanel.Controls.Add(atualizarCarteiraVacinacaoButton);
            buttonPanel.Controls.Add(deletarCarteiraVacinacaoButton);
            buttonPanel.Controls.Add(voltarButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Size = new Size(600, 400);
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#49ab81");
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Controls.Add(this.buttonPanel);            
        }

        private void SetupDataGridView()
        {
            this.Controls.Add(carteiraVacinacaoGridView);

            carteiraVacinacaoGridView.ColumnCount = 7;

            carteiraVacinacaoGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            carteiraVacinacaoGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            carteiraVacinacaoGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            carteiraVacinacaoGridView.Name = "CarteiraVacinacaoGridView";
            carteiraVacinacaoGridView.Location = new Point(8, 8);
            carteiraVacinacaoGridView.Size = new Size(500, 250);
            carteiraVacinacaoGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            carteiraVacinacaoGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            carteiraVacinacaoGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            carteiraVacinacaoGridView.Font = new Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            carteiraVacinacaoGridView.GridColor = Color.Black;
            carteiraVacinacaoGridView.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#419873");
            carteiraVacinacaoGridView.RowHeadersVisible = false;

            carteiraVacinacaoGridView.Columns[0].Name = "Id";
            carteiraVacinacaoGridView.Columns[1].Name = "Animal";
            carteiraVacinacaoGridView.Columns[2].Name = "Aplicação";
            carteiraVacinacaoGridView.Columns[3].Name = "Próxima Dose";
            carteiraVacinacaoGridView.Columns[4].Name = "Nro Doses";
            carteiraVacinacaoGridView.Columns[5].Name = "Vacina";
            carteiraVacinacaoGridView.Columns[6].Name = "Fornecedor";

            carteiraVacinacaoGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            carteiraVacinacaoGridView.MultiSelect = false;
            carteiraVacinacaoGridView.Dock = DockStyle.Fill;

            carteiraVacinacaoGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(carteiraVacinacaoGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {
            List<Model.CarteiraVacinacao> listaCarteiraVacinacoes = Controller.CarteiraVacinacao.ListarCarteiraVacinacao();

            carteiraVacinacaoGridView.Rows.Clear();
            foreach (var carteiraVacinacao in listaCarteiraVacinacoes)
            {
                Model.CarteiraVacinacao carteiraVacinacoes = Controller.CarteiraVacinacao.BuscarPorId(carteiraVacinacao.Id);
                Model.Vacina vacina = Controller.Vacina.BuscarPorId(carteiraVacinacao.VacinaId);
                Model.Animal animal = Controller.Animal.BuscarPorId(carteiraVacinacao.AnimalId);
                Model.Fornecedor fornecedor = Controller.Fornecedor.BuscarPorId(carteiraVacinacao.FornecedorId);

                object[] linhaCarteiraVacinacao = { carteiraVacinacao.Id.ToString(), animal.nroRegistro, carteiraVacinacao.DataVacinacao, carteiraVacinacao.ProximaDose, carteiraVacinacao.NroDose,  vacina.Tipo, fornecedor.nomeFantasia };
                carteiraVacinacaoGridView.Rows.Add(linhaCarteiraVacinacao);
            }
        }

        private void adicionarCarteiraVacinacaoButton_Click(object sender, EventArgs e)
        {
            Views.CarteiraVacinacao telaCarteiraVacinacao = new Views.CarteiraVacinacao(null);
            telaCarteiraVacinacao.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
            telaCarteiraVacinacao.ShowDialog();
        }

        private void atualizarCarteiraVacinacaoButton_Click(object sender, EventArgs e)
        {
            if (this.carteiraVacinacaoGridView.SelectedRows.Count > 0 &&
                this.carteiraVacinacaoGridView.SelectedRows[0].Index !=
                this.carteiraVacinacaoGridView.Rows.Count - 1)
            {
                string idCarteiraVacinacao = carteiraVacinacaoGridView.Rows[this.carteiraVacinacaoGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                Views.CarteiraVacinacao telaCarteiraVacinacao = new Views.CarteiraVacinacao(Int32.Parse(idCarteiraVacinacao));
                telaCarteiraVacinacao.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
                telaCarteiraVacinacao.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nenhum registro selecionado!");
            }
        }

        private void deletarCarteiraVacinacaoButton_Click(object sender, EventArgs e)
        {
            if (this.carteiraVacinacaoGridView.SelectedRows.Count > 0 &&
                this.carteiraVacinacaoGridView.SelectedRows[0].Index !=
                this.carteiraVacinacaoGridView.Rows.Count - 1)
            {
                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir a Carteira de Vacinação?", "Exclusão de Item", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string idCarteiraVacinacao = carteiraVacinacaoGridView.Rows[this.carteiraVacinacaoGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                    Controller.CarteiraVacinacao.ExcluirVacinaCarteiraVacinacao(Int32.Parse(idCarteiraVacinacao));
                    this.PopulateDataGridView();
                    this.carteiraVacinacaoGridView.Refresh();
                }
                else
                {
                    MessageBox.Show("Operação cancelada");
                }
            }
            else
            {
                MessageBox.Show("Nenhum registro selecionado!");
            }
        }

        private void voltarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void recarregarDadosGrid(object sender, FormClosedEventArgs e)
        {
            PopulateDataGridView();
            this.carteiraVacinacaoGridView.Refresh();
        }

    }

}