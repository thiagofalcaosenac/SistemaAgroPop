using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class ListaVacinaFornecida : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView vacinaFornecidaGridView = new DataGridView();
        private Button adicionarVacinaFornecidaButton = new Button();
        private Button atualizarVacinaFornecidaButton = new Button();
        private Button deletarVacinaFornecidaButton = new Button();
        private Button voltarButton = new Button();

        public ListaVacinaFornecida()
        {
            this.Text = "Listagem de Vacina Fornecida";
            this.Load += new EventHandler(ListaVacinaFornecida_Load);
        }

        private void ListaVacinaFornecida_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void vacinaFornecidaGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.vacinaFornecidaGridView.Columns[e.ColumnIndex].Name == "Release Date")
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
            adicionarVacinaFornecidaButton.Text = "Adicionar";
            adicionarVacinaFornecidaButton.Location = new Point(250, 10);
            adicionarVacinaFornecidaButton.Click += new EventHandler(adicionarVacinaFornecidaButton_Click);

            atualizarVacinaFornecidaButton.Text = "Editar";
            atualizarVacinaFornecidaButton.Location = new Point(330, 10);
            atualizarVacinaFornecidaButton.Click += new EventHandler(atualizarVacinaFornecidaButton_Click);

            deletarVacinaFornecidaButton.Text = "Excluir";
            deletarVacinaFornecidaButton.Location = new Point(410, 10);
            deletarVacinaFornecidaButton.Click += new EventHandler(deletarVacinaFornecidaButton_Click);

            voltarButton.Text = "Voltar";
            voltarButton.Location = new Point(490, 10);
            voltarButton.Click += new EventHandler(voltarButton_Click);

            buttonPanel.Controls.Add(adicionarVacinaFornecidaButton);
            buttonPanel.Controls.Add(atualizarVacinaFornecidaButton);
            buttonPanel.Controls.Add(deletarVacinaFornecidaButton);
            buttonPanel.Controls.Add(voltarButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Size = new Size(600, 400);
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#d0e0e3");
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Controls.Add(this.buttonPanel);            
        }

        private void SetupDataGridView()
        {
            this.Controls.Add(vacinaFornecidaGridView);

            vacinaFornecidaGridView.ColumnCount = 8;

            vacinaFornecidaGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            vacinaFornecidaGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            vacinaFornecidaGridView.ColumnHeadersDefaultCellStyle.Font = new Font(vacinaFornecidaGridView.Font, FontStyle.Bold);

            vacinaFornecidaGridView.Name = "vacinaFornecidaGridView";
            vacinaFornecidaGridView.Location = new Point(8, 8);
            vacinaFornecidaGridView.Size = new Size(500, 250);
            vacinaFornecidaGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            vacinaFornecidaGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            vacinaFornecidaGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            vacinaFornecidaGridView.GridColor = Color.Black;
            vacinaFornecidaGridView.RowHeadersVisible = false;

            vacinaFornecidaGridView.Columns[0].Name = "Id";
            vacinaFornecidaGridView.Columns[1].Name = "Data Fabricação";
            vacinaFornecidaGridView.Columns[2].Name = "Data Validade";
            vacinaFornecidaGridView.Columns[3].Name = "Data Compra";
            vacinaFornecidaGridView.Columns[4].Name = "Quantidade";
            vacinaFornecidaGridView.Columns[5].Name = "Preço";
            vacinaFornecidaGridView.Columns[6].Name = "Fornecedor";
            vacinaFornecidaGridView.Columns[7].Name = "Vacina";

            vacinaFornecidaGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            vacinaFornecidaGridView.MultiSelect = false;
            vacinaFornecidaGridView.Dock = DockStyle.Fill;

            vacinaFornecidaGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(vacinaFornecidaGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {
            List<Model.VacinaFornecida> listaVacinaFornecidas = Controller.VacinaFornecida.ListarVacinaFornecida();

            vacinaFornecidaGridView.Rows.Clear();
            foreach (var vacinaFornecida in listaVacinaFornecidas)
            {
                Model.Fornecedor objFornecedor = Controller.Fornecedor.BuscarPorId(vacinaFornecida.fornecedorId);
                Model.Vacina objVacina = Controller.Vacina.BuscarPorId(vacinaFornecida.vacinaId);

                object[] linhaVacinaFornecida = {
                                            vacinaFornecida.Id.ToString(),
                                            vacinaFornecida.DataFabricacao,
                                            vacinaFornecida.DataValidade,
                                            vacinaFornecida.DataCompra,
                                            vacinaFornecida.Quantidade,
                                            vacinaFornecida.Preco,
                                            objFornecedor != null ? objFornecedor.razaoSocial : "",
                                            objVacina != null ? objVacina.Id : ""
                                        };
                vacinaFornecidaGridView.Rows.Add(linhaVacinaFornecida);
            }
        }

        private void adicionarVacinaFornecidaButton_Click(object sender, EventArgs e)
        {
            View.VacinaFornecida telaVacinaFornecida = new View.VacinaFornecida(null);
            telaVacinaFornecida.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
            telaVacinaFornecida.ShowDialog();
        }

        private void atualizarVacinaFornecidaButton_Click(object sender, EventArgs e)
        {
            if (this.vacinaFornecidaGridView.SelectedRows.Count > 0 &&
                this.vacinaFornecidaGridView.SelectedRows[0].Index !=
                this.vacinaFornecidaGridView.Rows.Count - 1)
            {
                string idVacinaFornecida = vacinaFornecidaGridView.Rows[this.vacinaFornecidaGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                View.VacinaFornecida telaVacinaFornecida = new View.VacinaFornecida(Int32.Parse(idVacinaFornecida));
                telaVacinaFornecida.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
                telaVacinaFornecida.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nenhum registro selecionado!");
            }
        }

        private void deletarVacinaFornecidaButton_Click(object sender, EventArgs e)
        {
            if (this.vacinaFornecidaGridView.SelectedRows.Count > 0 &&
                this.vacinaFornecidaGridView.SelectedRows[0].Index !=
                this.vacinaFornecidaGridView.Rows.Count - 1)
            {
                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir a Vacina Fornecida?", "Exclusão de Item", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string idVacinaFornecida = vacinaFornecidaGridView.Rows[this.vacinaFornecidaGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                    Controller.VacinaFornecida.ExcluirVacinaFornecida(Int32.Parse(idVacinaFornecida));
                    this.PopulateDataGridView();
                    this.vacinaFornecidaGridView.Refresh();
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
            this.vacinaFornecidaGridView.Refresh();
        }

    }

}