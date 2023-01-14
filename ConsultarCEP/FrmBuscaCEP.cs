using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSCorreios;

namespace ConsultarCEP
{
    public partial class FrmBuscaCEP : Form
    {
        public FrmBuscaCEP()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtCep.Text))
            {
                using(var ws = new WSCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var endereco = ws.consultaCEPAsync(txtCep.Text.Trim()).Result;

                        txtEstado.Text = endereco.@return.uf;
                        txtCidade.Text = endereco.@return.cidade;
                        txtBairro.Text = endereco.@return.bairro;
                        txtRua.Text = endereco.@return.end;
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text,MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe CEP Válido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtEstado.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtRua.Text = string.Empty;
            txtCep.Text = string.Empty;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
