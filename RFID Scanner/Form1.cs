using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace RFID_Scaner
{
    public partial class Form1 : Form
    {

        private SerialPort SerialPort = new SerialPort();  
         
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //添加表头（列）
            resultList.Columns.Add("序号", 40, HorizontalAlignment.Center);
            resultList.Columns.Add("书名", 240, HorizontalAlignment.Center);
            resultList.Columns.Add("作者", 240, HorizontalAlignment.Center);
            resultList.Columns.Add("索书号", 240, HorizontalAlignment.Center);

            //检查是否含有串口
            string[] str = SerialPort.GetPortNames();
            if (str.Length == 0)
            {
                MessageBox.Show("本机没有串口！", "Error");
                Application.Exit();
                return;
            }

            //添加串口项目
            foreach (string s in SerialPort.GetPortNames())
            {
                //获取有多少个COM口
                cbSerial.Items.Add(s);
            }

            //串口设置默认选择项
            cbSerial.SelectedIndex = 0;         //设置cbSerial的默认选项

            //初始化SerialPort对象  
            SerialPort.NewLine = "/r/n";
            SerialPort.RtsEnable = false;
            SerialPort.DataReceived += serialDataReceived; 
        }

        void serialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int n = SerialPort.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致  
            byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据   
            SerialPort.Read(buf, 0, n);//读取缓冲数据  

            //因为要访问ui资源，所以需要使用invoke方式同步ui。  
            this.Invoke((EventHandler)(delegate
            {
                //直接按ASCII规则转换成字符串  
                string result = Encoding.ASCII.GetString(buf);
                resultList.BeginUpdate();

                ListViewItem lvi = new ListViewItem();

                lvi.Text = result;
                resultList.Items.Add(lvi);

                resultList.EndUpdate();
                //MessageBox.Show(result, "result");
            }));
        }

        private void btnSerialOpen_Click(object sender, EventArgs e)
        {
            //关闭时点击，则设置好端口，波特率后打开  
            SerialPort.PortName = cbSerial.Text;
            SerialPort.BaudRate = 115200;
            SerialPort.DataBits = 8; //数据位
            SerialPort.Parity = System.IO.Ports.Parity.None; //无奇偶校验位
            SerialPort.StopBits = System.IO.Ports.StopBits.One; //一个停止位
            SerialPort.ReadBufferSize = 1024; //接收缓冲区大小
            try
            {
                SerialPort.Open();
            }
            catch (Exception ex)
            {
                //捕获到异常信息，创建一个新的comm对象，之前的不能用了。  
                SerialPort = new SerialPort();
                //现实异常信息给客户。  
                MessageBox.Show(ex.Message);
            }
            //设置按钮的状态  
            btnSerialOpen.Enabled = false;
            btnSerialClose.Enabled = true;
            cbSerial.Enabled = false;
            
            Byte[] data = new Byte[3];
            data[0] = 0x10;
            data[1] = 0x03;
            data[2] = 0x00;
            SerialPort.Write(data, 0, 3);

        }

        private void btnSerialClose_Click(object sender, EventArgs e)
        {
            SerialPort.Close();
            btnSerialOpen.Enabled = true;
            btnSerialClose.Enabled = false;
            cbSerial.Enabled = true;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (scanTimer.Enabled)
            {
                scanTimer.Enabled = false;
                btnScan.Text = "开始扫描";
            }
            else
            {
                scanTimer.Enabled = true;
                btnScan.Text = "停止扫描";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Byte[] data = new Byte[3];
            data[0] = 0x43;
            data[1] = 0x03;
            data[2] = 0x01;
            SerialPort.Write(data, 0, 3);
        }

    }
}
