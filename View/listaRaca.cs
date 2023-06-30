using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class ListaRaca : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView racaGridView = new DataGridView();
        private Button adicionarRacaButton = new Button();
        private Button atualizarRacaButton = new Button();
        private Button deletarRacaButton = new Button();
        private Button voltarButton = new Button();

        public ListaRaca()
        {
            this.Text = "Listagem de Raca";
            this.Load += new EventHandler(ListaRaca_Load);
        }

        private void ListaRaca_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void racaGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.racaGridView.Columns[e.ColumnIndex].Name == "Release Date")
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
            this.Size = new Size(1000, 900);

            adicionarRacaButton.Text = "Adicionar";
            adicionarRacaButton.Location = new Point(600, 10);
            adicionarRacaButton.Click += new EventHandler(adicionarRacaButton_Click);

            atualizarRacaButton.Text = "Editar";
            atualizarRacaButton.Location = new Point(700, 10);
            atualizarRacaButton.Click += new EventHandler(atualizarRacaButton_Click);

            deletarRacaButton.Text = "Excluir";
            deletarRacaButton.Location = new Point(800, 10);
            deletarRacaButton.Click += new EventHandler(deletarRacaButton_Click);

            voltarButton.Text = "Voltar";
            voltarButton.Location = new Point(900, 10);
            voltarButton.Click += new EventHandler(voltarButton_Click);

            buttonPanel.Controls.Add(adicionarRacaButton);
            buttonPanel.Controls.Add(atualizarRacaButton);
            buttonPanel.Controls.Add(deletarRacaButton);
            buttonPanel.Controls.Add(voltarButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.ControlBox = false;
            this.Controls.Add(this.buttonPanel);
        }

        private void SetupDataGridView()
        {
            this.Controls.Add(racaGridView);

            racaGridView.ColumnCount =4;

            racaGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            racaGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            racaGridView.ColumnHeadersDefaultCellStyle.Font = new Font(racaGridView.Font, FontStyle.Bold);

            racaGridView.Name = "racaGridView";
            racaGridView.Location = new Point(8, 8);
            racaGridView.Size = new Size(500, 250);
            racaGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            racaGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            racaGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            racaGridView.GridColor = Color.Black;
            racaGridView.RowHeadersVisible = false;

            racaGridView.Columns[0].Name = "Id";
            racaGridView.Columns[1].Name = "Especie";
            racaGridView.Columns[2].Name = "Nome";
            racaGridView.Columns[3].Name = "Porte";

            racaGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            racaGridView.MultiSelect = false;
            racaGridView.Dock = DockStyle.Fill;

            racaGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(racaGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {
            List<Model.Raca> listaRacas = Controller.Raca.ListarRacas();

            racaGridView.Rows.Clear();
            foreach (var raca in listaRacas)
            {
                object[] linhaRaca = {
                            raca.id.ToString(),
                            raca.especie,
                            raca.nome,
                            raca.porte
                };
                racaGridView.Rows.Add(linhaRaca);
            }
        }

        private void adicionarRacaButton_Click(object sender, EventArgs e)
        {
            View.Raca telaRaca = new View.Raca(null);
            telaRaca.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
            telaRaca.ShowDialog();
        }

        private void atualizarRacaButton_Click(object sender, EventArgs e)
        {
            if (this.racaGridView.SelectedRows.Count > 0 &&
                this.racaGridView.SelectedRows[0].Index !=
                this.racaGridView.Rows.Count - 1)
            {
                string idRaca = racaGridView.Rows[this.racaGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                View.Raca telaRaca = new View.Raca(Int32.Parse(idRaca));
                telaRaca.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
                telaRaca.ShowDialog();
            }
            else
            {
                MessageBox.Show("Erro...Nenhum registro selecionado!");
            }
        }

        private void deletarRacaButton_Click(object sender, EventArgs e)
        {
            if (this.racaGridView.SelectedRows.Count > 0 &&
                this.racaGridView.SelectedRows[0].Index !=
                this.racaGridView.Rows.Count - 1)
            {
                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir a raca?", "Exclusão de Item", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string idRaca = racaGridView.Rows[this.racaGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                    Controller.Raca.ExcluirRaca(idRaca);
                    this.PopulateDataGridView();
                    this.racaGridView.Refresh();
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
            this.racaGridView.Refresh();
        }

    }

}