using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UHFtest
{
    public partial class FormCheckPopup : Form
    {
        private Timer closeTimer = new Timer();

        private void FormCheckPopup_Load(object sender, EventArgs e)
        {
            // このフォームがロードされた時にやりたい処理があればここに書きます
        }

        public FormCheckPopup()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;
            this.TopMost = true;

            Label label = new Label();
            label.Text = "✅ 社員証 検出";
            label.Font = new Font("Segoe UI", 72, FontStyle.Bold);
            label.ForeColor = Color.Green;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Fill;
            label.BackColor = Color.White;

            this.Controls.Add(label);

            closeTimer.Interval = 2000; //秒数
            closeTimer.Tick += (s, e) =>
            {
                closeTimer.Stop();
                this.Close();
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            closeTimer.Start();
        }
    }
}
