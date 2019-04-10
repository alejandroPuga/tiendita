using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace tiendita
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        manejo_cuenta usuario = new manejo_cuenta();

        double subtotal=0;
        double total = 0;
        int i = 0;

        private void btnsuma_Click(object sender, EventArgs e)
        {
            //     lbcuenta.Items.Add("producto: " + int.Parse(txtproducto.Text) + " cantudad: " + Convert.ToInt16(numericcant.Value) + " costo: " + int.Parse(txtcosto.Text) + "\r\n importe: " + int.Parse(txtimporte.Text));

            double temp_sub = usuario.sub_total(Convert.ToInt16(numericcant.Value), int.Parse(txtcosto.Text));
            txtimporte.Text = temp_sub.ToString();

            lbcuenta.Items.Add(usuario.ingresar_valor(txtproducto.Text, Convert.ToInt16(numericcant.Value), int.Parse(txtcosto.Text), int.Parse(txtimporte.Text)));
            txttotal.Text = usuario.total(temp_sub, usuario.iva(temp_sub)).ToString();
            total = usuario.total(temp_sub, usuario.iva(temp_sub));
            subtotal += temp_sub;
            txtiva.Text = usuario.iva(temp_sub).ToString();
            txtsubtotal.Text = subtotal.ToString();
            i++;
        }

        private void lbcuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnpagar_Click(object sender, EventArgs e)
        {
            txtcambio.Text = usuario.pagar(total,int.Parse(txtpago.Text));
            lbcuenta.Items.Add(txtcambio.Text);
        }

        private void btntiket_Click(object sender, EventArgs e)
        {

            saveFileDialog1.ShowDialog();

            string rutaarch;
            rutaarch = saveFileDialog1.FileName;
            FileStream fs = new FileStream(rutaarch, FileMode.OpenOrCreate);
            StreamWriter escritor = new StreamWriter(fs);

            for(int j=0;j<=i; j++)
            escritor.WriteLine(lbcuenta.Items[j]);

            escritor.Flush();

            escritor.Close();//siempre cerrar los archivos cuando termines uan accion
            fs.Close();
        }
    }
}
