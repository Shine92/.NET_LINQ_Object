using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace test0908_LINQ_Object {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string[] datalist = new string[] { "a1", "B2", "c3", "D4" };

            //var query = from o in datalist select datalist; //Fail
            var query = from o in datalist
                        select o;

            foreach (var o in datalist) {
                listBox1.Items.Add(o);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            var dataList = new[] { "a1", "B2", "c3", "D4" };
            var query = from o in dataList
                        where o.IndexOf("c") == 0  //符合條件有c的
                        select o;
            foreach (var data in query) {
                listBox1.Items.Add(data);
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            string[] dataList = new string[] { "A11", "b12", "C13", "d14" };
            var query = from d in dataList
                        orderby d descending  //遞減
                        select d;
            foreach (string data in query) {
                listBox1.Items.Add(string.Format("{0}", data));
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            var data = new[] { "aa1", "BB2", "cc3", "DD4" };
            //Regex rx = new Regex(@"^a[0-9]*$");
            Regex rx = new Regex(@"^[\w\d]*$");  //開心地開始要錢的結束
            var query = from obj in data
                        where rx.IsMatch(obj)
                        select obj;
            foreach (var d in query) {
                listBox1.Items.Add(d);
            }
        }

        private void button5_Click(object sender, EventArgs e) {
            string[] dataList = new string[] { "John", "Simon", "Mary", "Peter" };
            var query = from objData in dataList
                        where objData == "John"
                        select objData;
            foreach (var q in query) {
                listBox1.Items.Add(q);
            }
        }

        private void button6_Click(object sender, EventArgs e) {
            var emp = new[] { new { uid = 1,UserName ="John"},
                              new { uid = 2,UserName = "Peter"}
                            };
            var query = from obj in emp
                        select new { obj.uid, obj.UserName };  //取出物件
            foreach (var q in query) {
                listBox1.Items.Add(string.Format("uid:{0},UserName:{1}", q.uid, q.UserName));
            }
        }

        private void button7_Click(object sender, EventArgs e) {
            var cust = new[] { new { Id = 1,Name = "John"},
                               new { Id = 2,Name = "Mary"},
                               new { Id = 3,Name = "Peter"}
                             };
            var query = from objCust in cust
                        orderby objCust.Id descending  //遞減
                        select new { objCust.Id, objCust.Name };
            foreach (var q in query) {
                listBox1.Items.Add(string.Format("Id = {0},Name = {1}",q.Id,q.Name));
            }
        }

        private void button8_Click(object sender, EventArgs e) {
            var cust =  new[] { new { CustId = 1,CustName = "John" },
                                new { CustId = 2,CustName = "Peter"},
                                new { CustId = 3,CustName = "Simon"}
                              };
            var query = from obj in cust
                        select obj;
            foreach(var q in query) {
                listBox1.Items.Add(q);
            }
        }

        private void button9_Click(object sender, EventArgs e) {
            string[] cust = new string[] { new { fristName = "紹銘",lastName = "黃" } };
            string[] cust = new string[] { "A123", "P21", "D132", "C213" };
        }
    }
}
