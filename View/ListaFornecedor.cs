using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class ListaFornecedor : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView fornecedorGridView = new DataGridView();
        private Button adicionarFornecedorButton = new Button();
        private Button atualizarFornecedorButton = new Button();
        private Button deletarFornecedorButton = new Button();
        private Button voltarButton = new Button();

        public ListaFornecedor()
        {
            this.Text = "Listagem de Fornecedor";
            this.Load += new EventHandler(ListaFornecedor_Load);
        }

        private void ListaFornecedor_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void fornecedorGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.fornecedorGridView.Columns[e.ColumnIndex].Name == "Release Date")
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
            adicionarFornecedorButton.Text = "Adicionar";
            adicionarFornecedorButton.Location = new Point(250, 10);
            adicionarFornecedorButton.Click += new EventHandler(adicionarFornecedorButton_Click);
            adicionarFornecedorButton.ForeColor = Color.White;
            adicionarFornecedorButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            adicionarFornecedorButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            atualizarFornecedorButton.Text = "Editar";
            atualizarFornecedorButton.Location = new Point(330, 10);
            atualizarFornecedorButton.Click += new EventHandler(atualizarFornecedorButton_Click);
            atualizarFornecedorButton.ForeColor = Color.White;
            atualizarFornecedorButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            atualizarFornecedorButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            deletarFornecedorButton.Text = "Excluir";
            deletarFornecedorButton.Location = new Point(410, 10);
            deletarFornecedorButton.Click += new EventHandler(deletarFornecedorButton_Click);
            deletarFornecedorButton.ForeColor = Color.White;
            deletarFornecedorButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            deletarFornecedorButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            voltarButton.Text = "Voltar";
            voltarButton.Location = new Point(490, 10);
            voltarButton.Click += new EventHandler(voltarButton_Click);
            voltarButton.ForeColor = Color.White;
            voltarButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            voltarButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            buttonPanel.Controls.Add(adicionarFornecedorButton);
            buttonPanel.Controls.Add(atualizarFornecedorButton);
            buttonPanel.Controls.Add(deletarFornecedorButton);
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
            this.Controls.Add(fornecedorGridView);

            fornecedorGridView.ColumnCount = 12;

            fornecedorGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            fornecedorGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            fornecedorGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            fornecedorGridView.Name = "fornecedorGridView";
            fornecedorGridView.Location = new Point(8, 8);
            fornecedorGridView.Size = new Size(500, 250);
            fornecedorGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            fornecedorGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            fornecedorGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            fornecedorGridView.Font = new Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fornecedorGridView.GridColor = Color.Black;
            fornecedorGridView.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#419873");
            fornecedorGridView.RowHeadersVisible = false;

            fornecedorGridView.Columns[0].Name = "Id";
            fornecedorGridView.Columns[1].Name = "Nome";
            fornecedorGridView.Columns[2].Name = "Cnpj";
            fornecedorGridView.Columns[3].Name = "Razao Social";
            fornecedorGridView.Columns[4].Name = "Telefone";
            fornecedorGridView.Columns[5].Name = "Email";
            fornecedorGridView.Columns[6].Name = "Bairro";
            fornecedorGridView.Columns[7].Name = "Rua";
            fornecedorGridView.Columns[8].Name = "Numero";
            fornecedorGridView.Columns[9].Name = "Complemento";
            fornecedorGridView.Columns[10].Name = "Cidade";
            fornecedorGridView.Columns[11].Name = "Estado";

            fornecedorGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            fornecedorGridView.MultiSelect = false;
            fornecedorGridView.Dock = DockStyle.Fill;

            fornecedorGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(fornecedorGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {
            List<Model.Fornecedor> listaFornecedors = Controller.Fornecedor.ListarFornecedors();

            fornecedorGridView.Rows.Clear();
            foreach (var fornecedor in listaFornecedors)
            {
                Model.Endereco endereco = Controller.Endereco.BuscarPorId(fornecedor.enderecoId);

                object[] linhaFornecedor = {
                    fornecedor.id.ToString(),
                    fornecedor.nomeFantasia,
                    fornecedor.cnpj,
                    fornecedor.razaoSocial,
                    endereco.telefone,
                    endereco.email,
                    endereco.bairro,
                    endereco.rua,
                    endereco.numero,
                    endereco.complemento,
                    endereco.cidade,
                    endereco.estado
                };
                fornecedorGridView.Rows.Add(linhaFornecedor);
            }
        }

        private void adicionarFornecedorButton_Click(object sender, EventArgs e)
        {
            View.Fornecedor telaFornecedor = new View.Fornecedor(null);
            telaFornecedor.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
            telaFornecedor.ShowDialog();
        }

        private void atualizarFornecedorButton_Click(object sender, EventArgs e)
        {
            if (this.fornecedorGridView.SelectedRows.Count > 0 &&
                this.fornecedorGridView.SelectedRows[0].Index !=
                this.fornecedorGridView.Rows.Count - 1)
            {
                string idFornecedor = fornecedorGridView.Rows[this.fornecedorGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                View.Fornecedor telaFornecedor = new View.Fornecedor(Int32.Parse(idFornecedor));
                telaFornecedor.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
                telaFornecedor.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nenhum registro selecionado!");
            }
        }

        private void deletarFornecedorButton_Click(object sender, EventArgs e)
        {
            if (this.fornecedorGridView.SelectedRows.Count > 0 &&
                this.fornecedorGridView.SelectedRows[0].Index !=
                this.fornecedorGridView.Rows.Count - 1)
            {
                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir a fornecedor?", "Exclusão de Item", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string idFornecedor = fornecedorGridView.Rows[this.fornecedorGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                    Controller.Fornecedor.ExcluirFornecedor(idFornecedor);
                    this.PopulateDataGridView();
                    this.fornecedorGridView.Refresh();
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
            this.fornecedorGridView.Refresh();
        }

    }

}