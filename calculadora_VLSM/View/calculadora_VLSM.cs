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
            model.ipAcumulado = txtIpEntrada.Text;
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
            dgv.DataSource = null;
            dgv.DataSource = redehosts;
            btnCalcular.Visible = true;
        }

        public string Binary(string num)
        {
            string[] IP = num.Split('.');
            int num1 = Convert.ToInt32(IP[0]);
            int num2 = Convert.ToInt32(IP[1]);
            int num3 = Convert.ToInt32(IP[2]);
            int num4 = Convert.ToInt32(IP[3]);
            string convert1 = Convert.ToString(num1, 2);
            convert1 = convert1.PadLeft(8, '0');
            string convert2 = Convert.ToString(num2, 2);
            convert2 = convert2.PadLeft(8, '0');
            string convert3 = Convert.ToString(num3, 2);
            convert3 = convert3.PadLeft(8, '0');
            string convert4 = Convert.ToString(num4, 2);
            convert4 = convert4.PadLeft(8, '0');
            string convert = $"{convert1}.{convert2}.{convert3}.{convert4}";
            return convert;
        }

        public string BroadCast(string IP)
        {
            string[] vet = IP.Split('.');
            int num1 = Convert.ToInt32(vet[0]);
            int num2 = Convert.ToInt32(vet[1]);
            int num3 = Convert.ToInt32(vet[2]);
            int num4 = Convert.ToInt32(vet[3]);
            //double oc4Som = num4 + pot;
            IP = $"{num1}.{num2}.{num3}.{(num4 - 1)}";

            //if (model.classe == 'A')
            //{
            //    IP = $"{num1}.{num2}.{num3}.{num4}";
            //}
            //else if (model.classe == 'B')
            //{
            //    IP = $"{num1}.{num2}.{num3}.{num4}";
            //}
            //else if (model.classe == 'C')
            //{

            //        IP = $"{num1}.{num2}.{num3}.{(num4 - 1)}";

            //    //else
            //    //{
            //    //    MessageBox.Show("A classe C não comporta mais de 256 hosts");
            //    //}
            //}
            return IP;
        }

        public string AcumularHostsIP(string IP, double potencia)
        {
            string[] vet = IP.Split('.');
            int num1 = Convert.ToInt32(vet[0]);
            int num2 = Convert.ToInt32(vet[1]);
            int num3 = Convert.ToInt32(vet[2]);
            int num4 = Convert.ToInt32(vet[3]);
            int nummax = num4 + Convert.ToInt32(potencia);
            int num3maisum = num3;

            if (model.classe == 'A')
            {
                if (nummax < 256) {
                    IP = $"{num1}.{num2}.{num3}.{nummax}";
                } else {
                    while (nummax > 256) {
                        nummax = nummax - 256;
                        num3++;
                        if (num3 > 256) {
                            num2++;
                        }
                    }
                    IP = $"{num1}.{num2}.{num3}.{nummax}";
                }
            }
            else if (model.classe == 'B')
            {
                if (nummax < 256) {
                    IP = $"{num1}.{num2}.{num3}.{nummax}";
                }else {
                    while (nummax > 256) {
                        nummax = nummax - 256;
                        num3++;
                    }
                    IP = $"{num1}.{num2}.{num3}.{nummax}";
                }
            }
            else if (model.classe == 'C')
            {
                IP = $"{num1}.{num2}.{num3}.{(num4 + potencia)}";
            }
            return IP;
        }

        public double acharpotencia(int num)
        {
            double potencia = 0;
            int i = 0;
            while (potencia < num)
            {
                potencia = Math.Pow(2, i);
                i++;
            }
            return potencia;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = true;
            preencher();
        }

        public void preencher()
        {
            string bin = Binary(txtIpEntrada.Text);
            string mascBin = Binary(model.maskpad);
            richTextBox1.AppendText("Id de rede: " + txtIpEntrada.Text + "\r\n");
            richTextBox1.AppendText("Classe: " + model.classe.ToString() + "\r\n");
            richTextBox1.AppendText("Máscara Padrão: " + model.maskpad + "\r\n");
            richTextBox1.AppendText("Endereço Binario: " + bin + "\r\n");
            richTextBox1.AppendText("Máscara Binario: " + mascBin + "\r\n");


            for (int i = 0; i < redehosts.Count; i++)
            {
                
                string ip = model.ipAcumulado;
                double ptProx = redehosts[i].PotenciaProx;
                string ipSomado = model.ipAcumulado = AcumularHostsIP(model.ipAcumulado, ptProx);
                string broad = BroadCast(ipSomado);

                //richTextBox1.AppendText("\r\n");
                //richTextBox1.AppendText("\r\n");
                //richTextBox1.AppendText($"SubRede {i}: " + ipSomado + " / " + hostsAdd + "\r\n");
                //richTextBox1.AppendText("\r\n");
                //richTextBox1.AppendText($"{Binary(ipSomado)}\r\n");
                //richTextBox1.AppendText($"{Binary(hostsAdd)} \r\n");

                richTextBox1.AppendText($"\r\n \r\n Subrede {i} : {ip}  / {broad}");
                richTextBox1.AppendText($"\r\n BroadCast: {broad}");

            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            txtIpEntrada.Text = "";
            btnCalcular.Visible = false;
            label2.Visible = false;
            nudQtdhosts.Visible = false;
            btnAdd.Visible = false;
            richTextBox1.Visible = false;
            dgv.Visible = false;
            redehosts.Clear();
            model model = new model();
        }
    }
}
