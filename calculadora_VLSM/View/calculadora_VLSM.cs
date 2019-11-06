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
        List<numero> redehosts = new List<numero>();
        model model = new model();
        numero numeros = new numero();

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
                MessageBox.Show("Classe customizada, o cálculo não podera ser realizado");
            }

            return maskPad;

        }

        public void preencher()
        {
            for (int i = 0; i < redehosts.Count; i++)
            {

                dgv.Rows.Add(redehosts);
                //dgv.Rows[i].Cells[0].Value = i;
                dgv.Rows[i].Cells[0].Value = redehosts[i].numeros;
                dgv.Rows[i].Cells[1].Value = (redehosts[i].numeros + 2);
                dgv.Rows[i].Cells[2].Value = acharpotencia();
            }
        }

        //public int potenciacao(int i)
        //{
        //    Math.Pow(i, 2);
        //    return i;
        //}

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

        public class nums
        {
            public decimal Decimal { get; set; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            acharpotencia(Convert.ToInt32(nudQtdhosts.Value));
            redehosts.Add(numeros);
            redehosts.Sort();
            redehosts.Reverse();
        }
        public void acharpotencia(int num)
        {
            numeros.numeros = num;
            if (num > 2 && num <= 4)
            {
                model.potencia = 4;
            }
            else if (num > 4 && num <= 8)
            {
                model.potencia = 8;
            }
            else if (num > 8 && num <= 16)
            {
                model.potencia = 16;
            }
            else if (num > 16 && num <= 32)
            {
                model.potencia = 32;
            }
            else if (num > 32 && num <= 64)
            {
                model.potencia = 64;
            }
            else if (num > 64 && num <= 128)
            {
                model.potencia = 128;
            }
            else if (num > 128 && num <= 256)
            {
                model.potencia = 256;
            }
        }

        public decimal adicionarrede(decimal i)
        {
            //redehosts.OrderByDescending(x => x);
            return i;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            preencher();
        }
    }
}
