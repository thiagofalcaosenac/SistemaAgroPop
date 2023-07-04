using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class ListaAnimal : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView animalGridView = new DataGridView();
        private Button adicionarAnimalButton = new Button();
        private Button atualizarAnimalButton = new Button();
        private Button deletarAnimalButton = new Button();
        private Button voltarButton = new Button();

        public ListaAnimal()
        {
            this.Text = "Listagem de Animal";
            this.Load += new EventHandler(ListaAnimal_Load);
        }

        private void ListaAnimal_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void animalGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.animalGridView.Columns[e.ColumnIndex].Name == "Release Date")
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
            adicionarAnimalButton.Text = "Adicionar";
            adicionarAnimalButton.Location = new Point(250, 10);
            adicionarAnimalButton.Click += new EventHandler(adicionarAnimalButton_Click);
            adicionarAnimalButton.ForeColor = Color.White;
            adicionarAnimalButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            adicionarAnimalButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            atualizarAnimalButton.Text = "Editar";
            atualizarAnimalButton.Location = new Point(330, 10);
            atualizarAnimalButton.Click += new EventHandler(atualizarAnimalButton_Click);
            atualizarAnimalButton.ForeColor = Color.White;
            atualizarAnimalButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            adicionarAnimalButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            deletarAnimalButton.Text = "Excluir";
            deletarAnimalButton.Location = new Point(410, 10);
            deletarAnimalButton.Click += new EventHandler(deletarAnimalButton_Click);
            deletarAnimalButton.ForeColor = Color.White;
            deletarAnimalButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            adicionarAnimalButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            voltarButton.Text = "Voltar";
            voltarButton.Location = new Point(490, 10);
            voltarButton.Click += new EventHandler(voltarButton_Click);
            voltarButton.ForeColor = Color.White;
            voltarButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            voltarButton.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            buttonPanel.Controls.Add(adicionarAnimalButton);
            buttonPanel.Controls.Add(atualizarAnimalButton);
            buttonPanel.Controls.Add(deletarAnimalButton);
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
            this.Controls.Add(animalGridView);

            animalGridView.ColumnCount = 8;

            animalGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#317256");
            animalGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            animalGridView.Font = new Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            animalGridView.Name = "animalGridView";
            animalGridView.Location = new Point(8, 8);
            animalGridView.Size = new Size(500, 250);
            animalGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            animalGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            animalGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            animalGridView.Font = new Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            animalGridView.GridColor = Color.Black;
            animalGridView.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#419873");
            animalGridView.RowHeadersVisible = false;

            animalGridView.Columns[0].Name = "Id";
            animalGridView.Columns[1].Name = "DataNascimento";
            animalGridView.Columns[2].Name = "NroRegistro";
            animalGridView.Columns[3].Name = "Origem";
            animalGridView.Columns[4].Name = "Cor";
            animalGridView.Columns[5].Name = "Peso";
            animalGridView.Columns[6].Name = "Raca";
            animalGridView.Columns[7].Name = "Fazenda";
        

            animalGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            animalGridView.MultiSelect = false;
            animalGridView.Dock = DockStyle.Fill;

            animalGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(animalGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {
            List<Model.Animal> listaAnimals = Controller.Animal.ListarAnimals();

            animalGridView.Rows.Clear();
            foreach (var animal in listaAnimals)
            {
               Model.Raca raca = Controller.Raca.BuscarPorId(animal.racaid);
               Model.Fazenda fazenda = Controller.Fazenda.BuscarPorId(animal.fazendaid);
                   

                object[] linhaAnimal = {
                        animal.id.ToString(),
                        animal.dataNascimento,
                        animal.nroRegistro,
                        animal.origem,
                        animal.cor,
                        animal.peso,
                        raca.nome,
                        fazenda.nome
                                           
                    };
                animalGridView.Rows.Add(linhaAnimal);
            }
        }

        private void adicionarAnimalButton_Click(object sender, EventArgs e)
        {
            View.Animal telaAnimal = new View.Animal(null);
            telaAnimal.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
            telaAnimal.ShowDialog();
        }

        private void atualizarAnimalButton_Click(object sender, EventArgs e)
        {
            if (this.animalGridView.SelectedRows.Count > 0 &&
                this.animalGridView.SelectedRows[0].Index !=
                this.animalGridView.Rows.Count - 1)
            {
                string idAnimal = animalGridView.Rows[this.animalGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                View.Animal telaAnimal = new View.Animal(Int32.Parse(idAnimal));
                telaAnimal.FormClosed += new FormClosedEventHandler(recarregarDadosGrid);
                telaAnimal.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ops...Nenhum registro selecionado!");
            }
        }

        private void deletarAnimalButton_Click(object sender, EventArgs e)
        {
            if (this.animalGridView.SelectedRows.Count > 0 &&
                this.animalGridView.SelectedRows[0].Index !=
                this.animalGridView.Rows.Count - 1)
            {
                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir a animal?", "Exclusão de Item", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string idAnimal = animalGridView.Rows[this.animalGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                    Controller.Animal.ExcluirAnimal(idAnimal);
                    this.PopulateDataGridView();
                    this.animalGridView.Refresh();
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
            this.animalGridView.Refresh();
        }

    }

}