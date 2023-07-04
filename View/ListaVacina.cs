using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Views
{
    class ListaVacina : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView vacinaGridView = new DataGridView();
        private Button adicionarVacinaButton = new Button();
        private Button atualizarVacinaButton = new Button();
        private Button deletarVacinaButton = new Button();
        private Button voltarButton = new Button();

        public ListaVacina()
        {
            this.Text = "Listagem de Vacina";
            this.Load += new EventHandler(ListaVacina_Load);
        }

        private void ListaVacina_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void vacinaGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.vacinaGridView.Columns[e.ColumnIndex].Name == "Release Date")
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
            adicionarVacinaButton.Text = "Adicionar";
            adicionarVacinaButton.Location = new Point(250, 10);
            adicionarVacinaButton.Click += new EventHandler(adicionarVacinaButton_Click);
            adicionarVacinaButton.ForeColor = Color.White;
            adicionarVacinaButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            adicionarVacinaButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            atualizarVacinaButton.Text = "Editar";
            atualizarVacinaButton.Location = new Point(330, 10);
            atualizarVacinaButton.Click += new EventHandler(atualizarVacinaButton_Click);
            atualizarVacinaButton.ForeColor = Color.White;
            atualizarVacinaButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            atualizarVacinaButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            deletarVacinaButton.Text = "Excluir";
            deletarVacinaButton.Location = new Point(410, 10);
            deletarVacinaButton.Click += new EventHandler(deletarVacinaButton_Click);
            deletarVacinaButton.ForeColor = Color.White;
            deletarVacinaButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            deletarVacinaButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            voltarButton.Text = "Voltar";
            voltarButton.Location = new Point(490, 10);
            voltarButton.Click += new EventHandler(voltarButton_Click);
            voltarButton.ForeColor = Color.White;
            voltarButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            voltarButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            buttonPanel.Controls.Add(adicionarVacinaButton);
            buttonPanel.Controls.Add(atualizarVacinaButton);
            buttonPanel.Controls.Add(deletarVacinaButton);
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
            this.Controls.Add(vacinaGridView);

            vacinaGridView.ColumnCount = 4;

            vacinaGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            vacinaGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            vacinaGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            vacinaGridView.Name = "vacinaGridView";
            vacinaGridView.Location = new Point(8, 8);
            vacinaGridView.Size = new Size(500, 250);
            vacinaGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            vacinaGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            vacinaGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            vacinaGridView.Font = new Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            vacinaGridView.GridColor = Color.Black;
            vacinaGridView.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#419873");
            vacinaGridView.RowHeadersVisible = false;

            vacinaGridView.Columns[0].Name = "Id da Vacina";
            vacinaGridView.Columns[1].Name = "Tipo da Vacina";
            vacinaGridView.Columns[2].Name = "Qtd Mínima";
            vacinaGridView.Columns[3].Name = "Periocidade";

            vacinaGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            vacinaGridView.MultiSelect = false;
            vacinaGridView.Dock = DockStyle.Fill;

            vacinaGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(vacinaGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {
            List<Model.Vacina> listaVacinas = Controller.Vacina.ListarVacina();

            vacinaGridView.Rows.Clear();
            foreach (var vacina in listaVacinas)
            {
                Model.Vacina vacinas = Controller.Vacina.BuscarPorId(vacina.Id);

                object[] linhaVacina = { vacina.Id.ToString(), vacina.Tipo, vacina.QtdMinima, vacina.Periodicidade };
                vacinaGridView.Rows.Add(linhaVacina);
            }
        }

        private void adicionarVacinaButton_Click(object sender, EventArgs e)
        {
            Views.Vacina telaVacina = new Views.Vacina(null);
            telaVacina.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
            telaVacina.ShowDialog();
        }

        private void atualizarVacinaButton_Click(object sender, EventArgs e)
        {
            if (this.vacinaGridView.SelectedRows.Count > 0 &&
                this.vacinaGridView.SelectedRows[0].Index !=
                this.vacinaGridView.Rows.Count - 1)
            {
                string idVacina = vacinaGridView.Rows[this.vacinaGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                Views.Vacina telaVacina = new Views.Vacina(Int32.Parse(idVacina));
                telaVacina.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
                telaVacina.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nenhum registro selecionado!");
            }
        }

        private void deletarVacinaButton_Click(object sender, EventArgs e)
        {
            if (this.vacinaGridView.SelectedRows.Count > 0 &&
                this.vacinaGridView.SelectedRows[0].Index !=
                this.vacinaGridView.Rows.Count - 1)
            {
                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir a vacina?", "Exclusão de Item", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string idVacina = vacinaGridView.Rows[this.vacinaGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                    Controller.Vacina.ExcluirVacina(Int32.Parse(idVacina));
                    this.PopulateDataGridView();
                    this.vacinaGridView.Refresh();
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
            this.vacinaGridView.Refresh();
        }

    }

}