using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Geodatabase;


namespace MemorialDescritivo2
{
    public partial class frmMemorial : Form
    {
        public frmMemorial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string resultado = string.Empty;
            IFeatureClass klass = Dialog.AbrirObjetos(0);

            if (!Feicao.Valida(klass))
            {
                return;
            }

            textEntrada.Text = klass.FeatureDataset.Workspace.PathName;
            lblFeature.Text = klass.AliasName;
            resultado = Feicao.calculaGeral(klass);
            textMemorial.Text = resultado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.ShowDialog();

            textDestino.Text = saveFileDialog1.FileName.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter vGravador = new System.IO.StreamWriter(textDestino.Text);
            vGravador.WriteLine(System.DateTime.Now.Date);
            vGravador.WriteLine(textMemorial.Text);
            vGravador.Close();
            MessageBox.Show("Arquivo gravado com sucesso!");
            Close();

        }
    }
}
