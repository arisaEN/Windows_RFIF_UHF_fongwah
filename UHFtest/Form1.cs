using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace UHFtest
{
    public partial class Form1 : Form
    {
        [DllImport("E7umf.DLL", EntryPoint = "uhf_connect")]
        public static extern Int32 uhf_connect(Int16 port, Int32 baud);
        [DllImport("E7umf.DLL", EntryPoint = "uhf_disconnect")]
        public static extern Int32 uhf_disconnect(Int32 icdev);
        [DllImport("E7umf.DLL", EntryPoint = "uhf_read")]
        public static extern Int32 uhf_read(Int32 icdev, byte infoType, Int32 address, Int32 rlen, byte[] pDataR);
        [DllImport("E7umf.DLL", EntryPoint = "uhf_write")]
        public static extern Int32 uhf_write(Int32 icdev, byte infoType, Int32 address, Int32 wlen, byte[] pDataW);
        [DllImport("E7umf.DLL", EntryPoint = "uhf_action")]
        public static extern Int32 uhf_action(Int32 icdev, byte action, byte time);
        [DllImport("E7umf.DLL", EntryPoint = "uhf_inventory")]
        public static extern Int32 uhf_inventory(Int32 icdev, Int32[] tagCount, Int32[] datalen, byte[] pDataR);


        public Form1()
        {
            InitializeComponent();
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            Int32 deviceHandle = -1;
            Int32 st;
            byte infoType;
            Int32 address, length;
            byte[] bufDataR = new byte[1024];

            //data to write: 11223344556677889900AABBCCDDEEFF
            byte[] bufDataW = { 0x31, 0x31, 0x32, 0x32, 0x33, 0x33, 0x34, 0x34, 0x35, 0x35, 0x36, 0x36, 0x37, 0x37, 0x38, 0x38, 0x39, 0x39, 0x30, 0x30, 0x41, 0x41, 0x42, 0x42, 0x43, 0x43, 0x44, 0x44, 0x45, 0x45, 0x46, 0x46 };

            //connect reader
            deviceHandle = uhf_connect(100, 115200);//100->USB port, other value serial port; 115200->serial port baud rate
            if (-1 == deviceHandle)
            {
                lB_test.Items.Add("Connect reader failed！");
                return;
            }
            lB_test.Items.Add("Connect reader ok！");


            //read EPC
            infoType = 1; //1：EPC，2：TIP，3：USER，0：reserved
            address = 0;
            length = 8;  //will get 32 bytes data
            st = uhf_read(deviceHandle, infoType, address, length, bufDataR);
            if (st != 0) lB_test.Items.Add("read EPC Error!");
            else
            {
                lB_test.Items.Add("Read EPC OK:");
                lB_test.Items.Add(System.Text.Encoding.Default.GetString(bufDataR));
            }


            //read TID
            infoType = 2; //1：EPC，2：TIP，3：USER，0：reserved
            address = 0;
            length = 8;  //will get 32 bytes data
            st = uhf_read(deviceHandle, infoType, address, length, bufDataR);
            if (st != 0) lB_test.Items.Add("read TID Error!");
            else
            {
                lB_test.Items.Add("Read TID OK:");
                lB_test.Items.Add(System.Text.Encoding.Default.GetString(bufDataR));
            }


            //read USER
            infoType = 3; //1：EPC，2：TIP，3：USER，0：reserved
            address = 0;
            length = 8;  //will get 32 bytes data
            st = uhf_read(deviceHandle, infoType, address, length, bufDataR);
            if (st != 0) lB_test.Items.Add("read USER Error!");
            else
            {
                lB_test.Items.Add("Read USER OK:");
                lB_test.Items.Add(System.Text.Encoding.Default.GetString(bufDataR));
            }


            //read reserved
            infoType = 0; //1：EPC，2：TIP，3：USER，0：reserved
            address = 0;
            length = 4;  //will get 16 bytes data
            st = uhf_read(deviceHandle, infoType, address, length, bufDataR);
            if (st != 0) lB_test.Items.Add("read reserved Error!");
            else
            {
                lB_test.Items.Add("Read reserved OK:");
                lB_test.Items.Add(System.Text.Encoding.Default.GetString(bufDataR));
            }

            /*
                        //write EPC
                        infoType = 1; //1：EPC，2：TIP，3：USER，0：reserved
                        address = 2;
                        length = 6;  //will write 24 bytes data
                        st = uhf_write(deviceHandle, infoType, address, length, bufDataW);
                        if (st != 0) listBox1.Items.Add("Write EPC Error!");
                        else
                        {
                            listBox1.Items.Add("Write EPC OK:");
                            bufDataW[24] = 0;
                            listBox1.Items.Add(System.Text.Encoding.Default.GetString(bufDataW));
                        }


                        //write USER
                        infoType = 3; //1：EPC，2：TIP，3：USER，0：reserved
                        address = 0;
                        length = 4;  //will write 16 bytes data
                        st = uhf_write(deviceHandle, infoType, address, length, bufDataW);
                        if (st != 0) listBox1.Items.Add("Write USER Error!");
                        else
                        {
                            listBox1.Items.Add("Write USER OK:");
                            bufDataW[16] = 0;
                            listBox1.Items.Add(System.Text.Encoding.Default.GetString(bufDataW));
                        }


                        //write reserved
                        infoType = 0; //1：EPC，2：TIP，3：USER，0：reserved
                        address = 0;
                        length = 4;  //will write 16 bytes data
                        st = uhf_write(deviceHandle, infoType, address, length, bufDataW);
                        if (st != 0) listBox1.Items.Add("Write reserved Error!");
                        else
                        {
                            listBox1.Items.Add("Write reserved OK:");
                            bufDataW[16] = 0;
                            listBox1.Items.Add(System.Text.Encoding.Default.GetString(bufDataW));
                        }
            */

            //reader action
            //action:  beep:0x01, red led on:0x02, green led on:0x04, yellow led on:0x08
            //time: Unit:10ms
            st = uhf_action(deviceHandle, (0x01 | 0x04), 50);  //beep and green led on 500ms
            if (st != 0) lB_test.Items.Add("Reader action Error!");
            else
            {
                lB_test.Items.Add("Reader action OK!");
            }


            uhf_disconnect(deviceHandle); //disconnect reader
            lB_test.Items.Add("Disconnect reader！");

        }

        private void btn_ReadMultipleEPC_Click(object sender, EventArgs e)
        {
            Int32 deviceHandle = -1;
            Int32 st, i;
            Int32 offset = 0;
            Int32 EPCcount;
            Int32[] tagCount = new Int32[2];
            Int32[] length = new Int32[2];
            byte[] bufDataR = new byte[2056];
            byte[] bufEPC = new byte[256];
            string str;

            //connect reader
            deviceHandle = uhf_connect(100, 115200);//100->USB port, other value serial port; 115200->serial port baud rate
            if (-1 == deviceHandle)
            {
                lB_test.Items.Add("Connect reader failed！");
                return;
            }
            lB_test.Items.Add("Connect reader ok！");

            //read multiple EPC
            //bufDataR: Data1 length(1 byte) + EPC1Read count(1byte) + EPC1(length=Data1 length-1), Data2 length(1 byte) + EPC2Read count(1byte) + EPC2(length=Data1 length-1)...
            st = uhf_inventory(deviceHandle, tagCount, length, bufDataR);
            if (st != 0) lB_test.Items.Add("Read Multiple EPC Error!");
            else
            {
                lB_test.Items.Add("Read Multiple EPC OK!");
                lB_test.Items.Add("Tag count::");
                lB_test.Items.Add(tagCount[0].ToString());

                EPCcount = tagCount[0];
                while (EPCcount > 0)
                {
                    for (i = 0; i < bufDataR[offset] - 1; i++)
                        bufEPC[i] = bufDataR[offset + 2 + i];
                    str = String.Concat("read count:", bufDataR[offset + 1].ToString(), ", EPC: ", System.Text.Encoding.Default.GetString(bufEPC));
                    lB_test.Items.Add(str);
                    EPCcount--;
                    offset += bufDataR[offset] + 1;
                }
            }

            uhf_disconnect(deviceHandle); //disconnect reader
            lB_test.Items.Add("Disconnect reader！");

        }

        //2025/6/14追加分


        // 連続スキャン用のタイマーと接続ハンドル
        private System.Windows.Forms.Timer scanTimer = new System.Windows.Forms.Timer();
        private Int32 persistentDeviceHandle = -1;
        private Dictionary<string, DateTime> epcLastSeen = new Dictionary<string, DateTime>();

        // フォームロード時にタイマー設定とListView初期化
        private void Form1_Load(object sender, EventArgs e)
        {
            scanTimer.Interval = 500; // 0.5秒ごとにスキャン
            scanTimer.Tick += ScanTimer_Tick;

            // ListView列の定義（2列：時刻, ラベル）
            lV_Continuous.View = View.Details;
            lV_Continuous.FullRowSelect = true;
            lV_Continuous.GridLines = true;

            
            lV_Continuous.Columns.Add("タグ", 120);
            lV_Continuous.Columns.Add("時刻 (JST)", 200);
        }

        // スキャン開始ボタン
        private void btn_StartScan_Click(object sender, EventArgs e)
        {
            if (persistentDeviceHandle == -1)
            {
                persistentDeviceHandle = uhf_connect(100, 115200);
                if (persistentDeviceHandle == -1)
                {
                    MessageBox.Show("リーダー接続失敗！");
                    return;
                }
            }

            scanTimer.Start();
        }

        // スキャン停止ボタン
        private void btn_StopScan_Click(object sender, EventArgs e)
        {
            scanTimer.Stop();

            if (persistentDeviceHandle != -1)
            {
                uhf_disconnect(persistentDeviceHandle);
                persistentDeviceHandle = -1;
            }
        }

        // タイマーごとの読み取り処理
        private void ScanTimer_Tick(object sender, EventArgs e)
        {
            Int32[] tagCount = new Int32[2];
            Int32[] length = new Int32[2];
            byte[] bufDataR = new byte[2056];
            byte[] bufEPC = new byte[256];
            int offset = 0;

            int st = uhf_inventory(persistentDeviceHandle, tagCount, length, bufDataR);
            if (st != 0)
            {
                return;
            }

            int EPCcount = tagCount[0];

            while (EPCcount > 0)
            {
                for (int i = 0; i < bufDataR[offset] - 1; i++)
                    bufEPC[i] = bufDataR[offset + 2 + i];

                string epc = BitConverter.ToString(bufEPC, 0, bufDataR[offset] - 1).Replace("-", "");
                string label = GetTagLabel_StaffIdentityCard(epc);
                bool allowDisplay = true;

                if (!cb_AllowDuplicates.Checked)
                {
                    if (epcLastSeen.ContainsKey(epc))
                    {
                        DateTime lastSeen = epcLastSeen[epc];
                        if ((DateTime.Now - lastSeen).TotalMinutes < 10)
                        {
                            allowDisplay = false; // ✋ 10分以内 → 表示しない
                        }
                    }

                    // 最終検出時刻を更新（検出された時点で記録）
                    epcLastSeen[epc] = DateTime.Now;
                }

                ///社員証検出した場合の処理 ポップアップ表示
                if (allowDisplay)
                {
                    // ✅ チェックポップアップ条件：「連続検出OFF」かつ「社員証」
                    if (!cb_AllowDuplicates.Checked && label == "社員証")
                    {
                        var popup = new FormCheckPopup(); // ※別途作成必要
                        popup.Show(); // 非同期で表示
                    }

                    // ✅ 音＋LED（表示されたときだけ鳴らす）
                    uhf_action(persistentDeviceHandle, 0x01 | 0x04, 30);

                    // ✅ ListViewに記録
                    string timestamp = DateTime.Now.ToString("HH:mm:ss");
                    var item = new ListViewItem(timestamp);
                    item.SubItems.Add(label);
                    lV_Continuous.Items.Add(item);
                    lV_Continuous.EnsureVisible(lV_Continuous.Items.Count - 1);
                }

                EPCcount--;
                offset += bufDataR[offset] + 1;
            }
        }



        // EPCをラベルに変換（必要なら複数パターン追加可）
        private string GetTagLabel_StaffIdentityCard(string epc)
        {
            if (epc == "303042303741313530383046373441463845303430383141")
                return "社員証";
            return epc;
        }
    }
}