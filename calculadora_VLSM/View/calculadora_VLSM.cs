using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using calculadora_VLSM.Model;

namespace calculadora_VLSM
{
    public partial class calculadora_VLSM : Form
    {
        List<decimal> redehosts = new List<decimal>();

        public calculadora_VLSM()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        public void identificarClassMasc()
        {
            model model = new model();
            string[] classeMascara = txtIpEntrada.Text.Split('.');
            model.ip1 = int.Parse(classeMascara[0]);
            model.ip2 = int.Parse(classeMascara[1]);
            model.ip3 = int.Parse(classeMascara[2]);
            model.ip4 = int.Parse(classeMascara[3]);
            model.maskpad = Convert.ToString(definirClasse(model.ip1));

        }
        public string definirClasse(int num)
        {
            string maskPad = "";

            if (num <= 127)
            {
                maskPad = "255.0.0.0";
            }
            else if (num >= 128 && num <= 191)
            {
                maskPad = "255.255.0.0";
            }
            else if (num >= 192 && num <= 223)
            {
                maskPad = "255.255.255.0";
            }

            else
            {
                MessageBox.Show("Classe customizada");
            }

            return maskPad;

        }

        public void preencher()
        {
            dgv.DataSource = null;
            dgv.DataSource = redehosts;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            identificarClassMasc();
            dgv.Visible = true;
            label2.Visible = true;
            nudQtdhosts.Visible = true;
            btnAdd.Visible = true;
            btnCalcular.Visible = true;
            richTextBox1.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            adicionarrede();
        }
        public void adicionarrede()
        {
            redehosts.Add(nudQtdhosts.Value);
            
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            preencher();
        }
    }
}
