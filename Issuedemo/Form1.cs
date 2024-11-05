using FastReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Issuedemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<TestInfoModel> reportList =     new List<TestInfoModel> { new TestInfoModel { Name = "Andrew Fuller1", Age = 30 }, new TestInfoModel { Name = "Nancy Davolio", Age = 25 }, new TestInfoModel { Name = "Margaret Peacock", Age = 40 } };
            List<TestItemInfo> itemList= new List<TestItemInfo> { new TestItemInfo { TestItem = "item1", TestPoint = "test11", Ct = "CT1" }, new TestItemInfo { TestItem = "item2", TestPoint = "test12", Ct = "CT2" }, new TestItemInfo { TestItem = "item3", TestPoint = "test13", Ct = "CT3" } };
            using (Report report = new Report())
            {
                report.Load(@"Reports\testDemo.frx");
                report.RegisterData(reportList, "TestInfo");
                report.SetParameterValue("MyParam", "This is a Test Title TestInfo");
                report.Prepare(false);

                report.Load(@"Reports\testDemo2.frx");
                report.RegisterData(itemList, "TestItemInfo");
                report.SetParameterValue("MyParam", "This is a Test Title TestItemInfo");
                report.Prepare(true);
                report.ShowPrepared();
            }
        }
    }
    public class TestInfoModel
    {
        public string Name { get; set; }
        public int Age { get; set; }       
    }
    public class TestItemInfo
    {
        public string TestItem { get; set; }
        public string TestPoint { get; set; }
        public string Ct { get; set; }
    }
}
