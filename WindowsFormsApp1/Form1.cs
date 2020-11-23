using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //全域
        //要使用BindingList 是WinfromBug https://www.cnblogs.com/seasons1987/archive/2012/06/28/2568408.html

        public BindingList<MenuModel> listmenu;
        public BindingList<OrderModel> result;

        public Form1()
        {
            InitializeComponent();
        }

        //第一次初始執行
        private void Form1_Load(object sender, EventArgs e)
        {
            //品項資料
            listmenu = new BindingList<MenuModel>()
            {
               new MenuModel { item="紅茶", price=100  },
               new MenuModel { item="綠茶", price=200  }
            };
            //初始化Menu
            dataGridView1.DataSource = listmenu;
            //初始化 Order
            result = new BindingList<OrderModel>();
        }



        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //確定點選的事件綁定"Column_Choose"
            if (e.ColumnIndex == dataGridView1.Columns["Column_Choose"].Index && e.RowIndex >= 0)
            {
                //點選變色                
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                
                //抓取品項和價錢
                string user_item = dataGridView1.Rows[e.RowIndex].Cells["Column_Item"].Value.ToString();
                int user_price = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Column_Price"].Value.ToString());

                //先去檢查 result 有無我點選的品項
                bool check = false;
                foreach (var x in result)
                { 
                    if (x.item == user_item)
                    {
                        check = true;
                        break;
                    }
                }
                //如果我有這個品項 ok
                if (check == true)
                {
                    foreach (var order in result)
                    {
                        if (order.item == user_item)
                        {
                            //加數量
                            order.count += 1;
                        }
                    }
                }
                else//如果沒有加品項
                {
                     result.Add
                     (
                         new OrderModel
                         {
                             item = user_item,
                             price = user_price * 1,
                             count = 1
                         }
                     );
                }
                dataGridView2.Refresh();
                dataGridView2.DataSource = result;

                //1.
                //搞懂 List Array 差別
                //請你用一個Array 裡面寫 1-10 分別用for 和 foreach 列出


                //2.
                //成績單
                //Grid_View
                //請你建一個 StudentData 的Class
                //可以讓使用者輸入 姓名 國文 英文 數學
                //之後把結果用在GridView


            }

        }

    }
}
