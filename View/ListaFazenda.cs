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
            this.Size = new Size(600, 500);

            adicionarFazendaButton.Text = "Adicionar";
            adicionarFazendaButton.Location = new Point(10, 10);
            adicionarFazendaButton.Click += new EventHandler(adicionarFazendaButton_Click);

            atualizarFazendaButton.Text = "Editar";
            atualizarFazendaButton.Location = new Point(100, 10);
            atualizarFazendaButton.Click += new EventHandler(atualizarFazendaButton_Click);

            deletarFazendaButton.Text = "Excluir";
            deletarFazendaButton.Location = new Point(200, 10);
            deletarFazendaButton.Click += new EventHandler(deletarFazendaButton_Click);

            voltarButton.Text = "Voltar";
            voltarButton.Location = new Point(400, 10);
            voltarButton.Click += new EventHandler(voltarButton_Click);

            buttonPanel.Controls.Add(adicionarFazendaButton);
            buttonPanel.Controls.Add(atualizarFazendaButton);
            buttonPanel.Controls.Add(deletarFazendaButton);
            buttonPanel.Controls.Add(voltarButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.ControlBox = false;
            this.Controls.Add(this.buttonPanel);
        }

        private void SetupDataGridView()
        {
            this.Controls.Add(fazendaGridView);

            fazendaGridView.ColumnCount = 2;

            fazendaGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            fazendaGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            fazendaGridView.ColumnHeadersDefaultCellStyle.Font = new Font(fazendaGridView.Font, FontStyle.Bold);

            fazendaGridView.Name = "fazendaGridView";
            fazendaGridView.Location = new Point(8, 8);
            fazendaGridView.Size = new Size(500, 250);
            fazendaGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            fazendaGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            fazendaGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            fazendaGridView.GridColor = Color.Black;
            fazendaGridView.RowHeadersVisible = false;

            fazendaGridView.Columns[0].Name = "Id";
            fazendaGridView.Columns[1].Name = "Nome";
            // fazendaGridView.Columns[2].DefaultCellStyle.Font =
            //     new Font(fazendaGridView.DefaultCellStyle.Font, FontStyle.Italic);

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
                object[] linhaFazenda = { fazenda.id.ToString(), fazenda.nome };
                fazendaGridView.Rows.Add(linhaFazenda);
            }
        }

        private void adicionarFazendaButton_Click(object sender, EventArgs e)
        {
            View.Fazenda telaFazenda = new View.Fazenda();
            telaFazenda.ShowDialog();
        }

        private void atualizarFazendaButton_Click(object sender, EventArgs e)
        {
            this.fazendaGridView.Rows.Add();
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
                    // Model.Fazenda customer = (Model.Fazenda)this.fazendaGridView.SelectedItem;
                    // MessageBox.Show(index);

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
        }

        private void voltarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}