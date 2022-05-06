using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjAcademiaTB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Academia ItapevaCity;

        private void Form1_Load(object sender, EventArgs e)
        {
            ItapevaCity = new Academia(new BindingList<Aluno>());
            ItapevaCity.Matricular(new Aluno(1, "JOAO", 20, 67, 1.73));
            ItapevaCity.Matricular(new Aluno(2, "MARIA", 22, 97, 1.80));
            ItapevaCity.Matricular(new Aluno(3, "JOSE", 28, 78, 1.56));
            ItapevaCity.Matricular(new Aluno(4, "ANA", 25, 80, 1.82));
            bs.DataSource = ItapevaCity.Alunos;
            dgvAlunos.DataSource = bs;
            dgvAlunos.AutoResizeColumns();
        }

        private void btnMatricular_Click(object sender, EventArgs e)
        {
            FormFichaAluno ficha = new FormFichaAluno();
            ficha.Registro = null;
            ficha.ShowDialog();
            if (ficha.Registro != null)
            {
                ItapevaCity.Matricular(ficha.Registro);
                bs.MoveLast();
                bs.ResetBindings(false);
                dgvAlunos.AutoResizeColumns();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormFichaAluno ficha = new FormFichaAluno();
            ficha.Registro = (Aluno)bs.Current;
            ficha.ShowDialog();
            if (ficha.Registro != null)
            {
                ItapevaCity.Editar(ficha.Registro);
                bs.ResetBindings(false);
                dgvAlunos.AutoResizeColumns();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Aluno atual = (Aluno)bs.Current;
            DialogResult op;
            op = MessageBox.Show("Deseja excluir:" + atual.Nome, "ALERTA!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (op == DialogResult.Yes)
            {
                ItapevaCity.Excluir(atual);
                bs.ResetBindings(false);
                dgvAlunos.AutoResizeColumns();
            }
        }
    }
}
