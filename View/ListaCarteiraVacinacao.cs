using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Views
{
    class ListaCarteiraVacinacao : Form
        {
        private Panel buttonPanel = new Panel();
        private DataGridView CarteiraVacinacaocaoGridView = new DataGridView();
        private Button adicionarCarteiraVacinacaoButton = new Button();
        private Button atualizarCarteiraVacinacaoButton = new Button();
        private Button deletarCarteiraVacinacaoButton = new Button();
        private Button voltarButton = new Button();

        public ListaCarteiraVacinacao()
        {
            this.Text = "Listagem de Carteira de Vacinação";
            this.Load += new EventHandler(ListaCarteiraVacinacao_Load);
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
            this.Size = new Size(600, 600);

            adicionarCarteiraVacinacaoButton.Text = "Adicionar";
            adicionarCarteiraVacinacaoButton.Location = new Point(200, 10);
            adicionarCarteiraVacinacaoButton.Click += new EventHandler(adicionarCarteiraVacinacaoButton_Click);

            atualizarCarteiraVacinacaoButton.Text = "Editar";
            atualizarCarteiraVacinacaoButton.Location = new Point(300, 10);
            atualizarCarteiraVacinacaoButton.Click += new EventHandler(atualizarCarteiraVacinacaoButton_Click);

            deletarCarteiraVacinacaoButton.Text = "Excluir";
            deletarCarteiraVacinacaoButton.Location = new Point(400, 10);
            deletarCarteiraVacinacaoButton.Click += new EventHandler(deletarCarteiraVacinacaoButton_Click);

            voltarButton.Text = "Voltar";
            voltarButton.Location = new Point(500, 10);
            voltarButton.Click += new EventHandler(voltarButton_Click);

            buttonPanel.Controls.Add(adicionarCarteiraVacinacaoButton);
            buttonPanel.Controls.Add(atualizarCarteiraVacinacaoButton);
            buttonPanel.Controls.Add(deletarCarteiraVacinacaoButton);
            buttonPanel.Controls.Add(voltarButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.ControlBox = false;
            this.Controls.Add(this.buttonPanel);
        }

        private void SetupDataGridView()
        {
            this.Controls.Add(carteiraVacinacaoGridView);

            carteiraVacinacaoGridView.ColumnCount = 7;

            carteiraVacinacaoGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            carteiraVacinacaoGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            carteiraVacinacaoGridView.ColumnHeadersDefaultCellStyle.Font = new Font(CarteiraVacinacaoGridView.Font, FontStyle.Bold);

            carteiraVacinacaoGridView.Name = "CarteiraVacinacaoGridView";
            carteiraVacinacaoGridView.Location = new Point(8, 8);
            carteiraVacinacaoGridView.Size = new Size(500, 250);
            carteiraVacinacaoGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            carteiraVacinacaoGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            carteiraVacinacaoGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            carteiraVacinacaoGridView.GridColor = Color.Black;
            carteiraVacinacaoGridView.RowHeadersVisible = false;

            carteiraVacinacaoGridView.Columns[0].Name = "Id da Carteira de Vacinação";
            carteiraVacinacaoGridView.Columns[1].Name = "Animal";
            carteiraVacinacaoGridView.Columns[2].Name = "Data de Aplicação";
            carteiraVacinacaoGridView.Columns[3].Name = "Data da Proxima Dose";
            carteiraVacinacaoGridView.Columns[4].Name = "Numero de Doses";
            carteiraVacinacaoGridView.Columns[5].Name = "Vacina";
            carteiraVacinacaoGridView.Columns[6].Name = "Fornecedor";

            carteiraVacinacaoGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            carteiraVacinacaoGridView.MultiSelect = false;
            carteiraVacinacaoGridView.Dock = DockStyle.Fill;

            carteiraVacinacaoGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(CarteiraVacinacaoGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {
            List<Model.CarteiraVacinacao> listaCarteiraVacinacaos = Controller.CarteiraVacinacao.ListarCarteiraVacinacao();

            carteiraVacinacaoGridView.Rows.Clear();
            foreach (var carteiraVacinacao in listaCarteiraVacinacoes)
            {
                Model.CarteiraVacinacao carteiraVacinacoes = Controller.CarteiraVacinacao.BuscarPorId(carteiraVacinacao.Id);

                object[] linhaCarteiraVacinacao = {carteiraVacinacao.Id.ToString(), carteiraVacinacao.Tipo, carteiraVacinacao.Periodicidade, carteiraVacinacao.QtdMinima};
                CarteiraVacinacaoGridView.Rows.Add(linhaCarteiraVacinacao);
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
                    Controller.CarteiraVacinacao.ExcluirCarteiraVacinacao(Int32.Parse(idCarteiraVacinacao));
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