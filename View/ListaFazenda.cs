using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class ListaFazenda : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView fazendaGridView = new DataGridView();
        private Button adicionarFazendaButton = new Button();
        private Button atualizarFazendaButton = new Button();
        private Button deletarFazendaButton = new Button();
        private Button voltarButton = new Button();

        public ListaFazenda()
        {
            this.Text = "Listagem de Fazenda";
            this.Load += new EventHandler(ListaFazenda_Load);
        }

        private void ListaFazenda_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void fazendaGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.fazendaGridView.Columns[e.ColumnIndex].Name == "Release Date")
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
            adicionarFazendaButton.Text = "Adicionar";
            adicionarFazendaButton.Location = new Point(250, 10);
            adicionarFazendaButton.Click += new EventHandler(adicionarFazendaButton_Click);
            adicionarFazendaButton.ForeColor = Color.White;
            adicionarFazendaButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            adicionarFazendaButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            atualizarFazendaButton.Text = "Editar";
            atualizarFazendaButton.Location = new Point(330, 10);
            atualizarFazendaButton.Click += new EventHandler(atualizarFazendaButton_Click);
            atualizarFazendaButton.ForeColor = Color.White;
            atualizarFazendaButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            atualizarFazendaButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            deletarFazendaButton.Text = "Excluir";
            deletarFazendaButton.Location = new Point(410, 10);
            deletarFazendaButton.Click += new EventHandler(deletarFazendaButton_Click);
            deletarFazendaButton.ForeColor = Color.White;
            deletarFazendaButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            deletarFazendaButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            voltarButton.Text = "Voltar";
            voltarButton.Location = new Point(490, 10);
            voltarButton.Click += new EventHandler(voltarButton_Click);
            voltarButton.ForeColor = Color.White;
            voltarButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            voltarButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            buttonPanel.Controls.Add(adicionarFazendaButton);
            buttonPanel.Controls.Add(atualizarFazendaButton);
            buttonPanel.Controls.Add(deletarFazendaButton);
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
            this.Controls.Add(fazendaGridView);

            fazendaGridView.ColumnCount = 12;

            fazendaGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            fazendaGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            fazendaGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            fazendaGridView.Name = "fazendaGridView";
            fazendaGridView.Location = new Point(8, 8);
            fazendaGridView.Size = new Size(500, 250);
            fazendaGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            fazendaGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            fazendaGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            fazendaGridView.Font = new Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fazendaGridView.GridColor = Color.Black;
            fazendaGridView.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#419873");
            fazendaGridView.RowHeadersVisible = false;

            fazendaGridView.Columns[0].Name = "Id";
            fazendaGridView.Columns[1].Name = "Nome";
            fazendaGridView.Columns[2].Name = "Limite Animal";
            fazendaGridView.Columns[3].Name = "Qtd Animais";
            fazendaGridView.Columns[4].Name = "Telefone";
            fazendaGridView.Columns[5].Name = "Email";
            fazendaGridView.Columns[6].Name = "Bairro";
            fazendaGridView.Columns[7].Name = "Rua";
            fazendaGridView.Columns[8].Name = "Numero";
            fazendaGridView.Columns[9].Name = "Complemento";
            fazendaGridView.Columns[10].Name = "Cidade";
            fazendaGridView.Columns[11].Name = "Estado";

            fazendaGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            fazendaGridView.MultiSelect = false;
            fazendaGridView.Dock = DockStyle.Fill;
            
            fazendaGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(fazendaGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {
            List<Model.Fazenda> listaFazendas = Controller.Fazenda.ListarFazendas();

            fazendaGridView.Rows.Clear();
            foreach (var fazenda in listaFazendas)
            {
                Model.Endereco endereco = Controller.Endereco.BuscarPorId(fazenda.enderecoId);

                object[] linhaFazenda = {
                                            fazenda.id.ToString(),
                                            fazenda.nome,
                                            fazenda.qtdLimiteAnimal,
                                            fazenda.qtdAtualAnimal,
                                            endereco.telefone,
                                            endereco.email,
                                            endereco.bairro,
                                            endereco.rua,
                                            endereco.numero,
                                            endereco.complemento,
                                            endereco.cidade,
                                            endereco.estado
                                        };
                fazendaGridView.Rows.Add(linhaFazenda);
            }
        }

        private void adicionarFazendaButton_Click(object sender, EventArgs e)
        {
            View.Fazenda telaFazenda = new View.Fazenda(null);
            telaFazenda.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
            telaFazenda.ShowDialog();
        }

        private void atualizarFazendaButton_Click(object sender, EventArgs e)
        {
            if (this.fazendaGridView.SelectedRows.Count > 0 &&
                this.fazendaGridView.SelectedRows[0].Index !=
                this.fazendaGridView.Rows.Count - 1)
            {
                string idFazenda = fazendaGridView.Rows[this.fazendaGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                View.Fazenda telaFazenda = new View.Fazenda(Int32.Parse(idFazenda));
                telaFazenda.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
                telaFazenda.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nenhum registro selecionado!");
            }
        }

        private void deletarFazendaButton_Click(object sender, EventArgs e)
        {
            if (this.fazendaGridView.SelectedRows.Count > 0 &&
                this.fazendaGridView.SelectedRows[0].Index !=
                this.fazendaGridView.Rows.Count - 1)
            {
                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir a fazenda?", "Exclusão de Item", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string idFazenda = fazendaGridView.Rows[this.fazendaGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                    Controller.Fazenda.ExcluirFazenda(idFazenda);
                    this.PopulateDataGridView();
                    this.fazendaGridView.Refresh();
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
            this.fazendaGridView.Refresh();
        }

    }

}