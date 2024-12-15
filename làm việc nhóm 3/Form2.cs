using làm_việc_nhóm_3.all_user_control;
using làm_việc_nhóm_3.userControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace làm_việc_nhóm_3
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            panelmoving.Left = btn_add.Left + 50;
            // hiển thị control
            uc_addroom.Visible = true;
            // ưu tiên thứ tự sẽ được đẩy lên trước 
            uc_addroom.BringToFront();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            uc_register uc = new uc_register();
            addusercontrol(uc);
        }

        private void btn_detail_Click(object sender, EventArgs e)
        {
            uc_detail uc = new uc_detail();
            addusercontrol(uc);
        }

        private void btn_staff_Click(object sender, EventArgs e)
        {
            uc_staff uc = new uc_staff();
            addusercontrol(uc);
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            uc_pay uc = new uc_pay();
            addusercontrol(uc);
        }

       
    }
}
