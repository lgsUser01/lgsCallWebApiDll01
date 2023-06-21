using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lgsCallWebApiDll01
{
    public partial class Form1 : Form
    {
       
        ClgsCallWebApi01.ClgsWebKiroTeiKyori01 ClgsWebKiroTei = new ClgsCallWebApi01.ClgsWebKiroTeiKyori01();

        public Form1()
        {
            InitializeComponent();
            this.textBoxWebApiUrl.Text = "https://haruka01.logistica.jp/lgsWebKiro01/api/K/";
            this.textBoxWebApiKey.Text = "ここにWebApiKey値をセットする"; // ここにWebApiKey値をセットする


            ClgsWebKiroTei.WebApiUrl = this.textBoxWebApiUrl.Text;
            ClgsWebKiroTei.WebApiKey = this.textBoxWebApiKey.Text;

            // プロキシ認証なし
            ClgsWebKiroTei.ProxyServer = "";
            ClgsWebKiroTei.ProxyUserName = "";
            ClgsWebKiroTei.ProxyPassword = "";

            this.textBox起点.Text = "13102";
            this.textBox終点.Text = "27127";
        }

        private async void webApi呼び出しToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClgsWebKiroTei.Kiten = this.textBox起点.Text;
            ClgsWebKiroTei.Shuuten = this.textBox終点.Text;
     
            await ClgsWebKiroTei.lgsKyoriKmKeisan();
            int intIppanKm = ClgsWebKiroTei.SaitanKyoriKm;
            int intShuyouKm = ClgsWebKiroTei.ShuyouKyoriKm;
            string strError = ClgsWebKiroTei.Error;

            this.textBox主要距離Km.Text = intShuyouKm.ToString();
            this.textBox最短距離Km.Text = intIppanKm.ToString();
            this.textBoxError.Text = strError;
        }
    }
}
