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

        public string Binary(int oc1, int oc2, int oc3, int oc4)
        {
            string convert1 = Convert.ToString(oc1, 2);
            convert1 = convert1.PadLeft(8, '0');
            string convert2 = Convert.ToString(oc2, 2);
            convert2 = convert2.PadLeft(8, '0');
            string convert3 = Convert.ToString(oc3, 2);
            convert3 = convert3.PadLeft(8, '0');
            string convert4 = Convert.ToString(oc4, 2);
            convert4 = convert4.PadLeft(8, '0');
            string convert = $"{convert1}.{convert2}.{convert3}.{convert4}";
            return convert;
        }

        public double acharpotencia(int num)
        {
            double potencia = 0;
            int i = 0;
            while (potencia<=num)
            {
                potencia = Math.Pow(2, i);
                i++;
            }
            return potencia;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            preencher();
        }

        public void preencher()
        {
            dgv.DataSource = null;
            dgv.DataSource = redehosts;
            string bin = Binary(model.ip1, model.ip2, model.ip3, model.ip4);
            richTextBox1.AppendText("Id de rede: "+txtIpEntrada.Text + "\r\n");
            richTextBox1.AppendText("Classe: " + model.classe.ToString() + "\r\n");
            richTextBox1.AppendText("Máscara Padrão: " +model.maskpad + "\r\n");
            richTextBox1.AppendText("Endereço Binario: " + bin + "\r\n");
        }
    }
}
