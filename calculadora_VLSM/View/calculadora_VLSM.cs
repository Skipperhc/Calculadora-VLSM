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

        public calculadora_VLSM()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void identificarClassMasc()
        {
            string[] classeMascara = txtIpEntrada.Text.Split('.');
            model.ip1 = int.Parse(classeMascara[0]);
            model.ip2 = int.Parse(classeMascara[1]);
            model.ip3 = int.Parse(classeMascara[2]);
            model.ip4 = int.Parse(classeMascara[3]);
            definirClasse(model.ip1);
        }
        public void definirClasse(int num)
        {
            if (num <= 127)
            {
                model.maskpad = "255.0.0.0";
                model.classe = 'A';

            }
            else if (num >= 128 && num <= 191)
            {
                model.maskpad = "255.255.0.0";
                model.classe = 'B';
            }
            else if (num >= 192 && num <= 223)
            {
                model.maskpad = "255.255.255.0";
                model.classe = 'C';
            }
            else
            {
                MessageBox.Show("Classe customizada, o cálculo não podera ser realizado");
            }
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

        public class nums
        {
            public decimal Decimal { get; set; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            numero numeros = new numero();
            numeros.Hosts = Convert.ToInt32(nudQtdhosts.Value);
            numeros.Mais2 = Convert.ToInt32(nudQtdhosts.Value + 2);
            numeros.PotenciaProx = acharpotencia(numeros.Mais2);
            redehosts.Add(numeros);
            numeros = null;
            redehosts = redehosts.OrderByDescending(x => x.PotenciaProx).ToList();
            nudQtdhosts.Focus();
            nudQtdhosts.Value = 0;
        }

        public int acharpotencia(int num)
        {
            if (num >= 0 && num <= 2)
            {
                model.potencia = 2;
            }
            if (num > 2 && num <= 4)
            {
                model.potencia = 4;
            }
            if (num > 4 && num <= 8)
            {
                model.potencia = 8;
            }
            if (num > 8 && num <= 16)
            {
                model.potencia = 16;
            }
            if (num > 16 && num <= 32)
            {
                model.potencia = 32;
            }
            if (num > 32 && num <= 64)
            {
                model.potencia = 64;
            }
            if (num > 64 && num <= 128)
            {
                model.potencia = 128;
            }
            if (num > 128 && num <= 256)
            {
                model.potencia = 256;
            }
            return model.potencia;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            preencher();
        }

        public void preencher()
        {
            dgv.DataSource = null;
            dgv.DataSource = redehosts;

            richTextBox1.AppendText("Id de rede: "+txtIpEntrada.Text + "\r\n");
            richTextBox1.AppendText("Classe: " + model.classe.ToString() + "\r\n");
            richTextBox1.AppendText("Máscara Padrão: " +model.maskpad + "\r\n");
        }
    }
}
