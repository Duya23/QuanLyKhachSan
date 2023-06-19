using QuanLyKhachSan.DAO;
using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyKhachSan
{
    public partial class TableManager : Form
    {
        public TableManager()
        {
            InitializeComponent();
            loadRoom();
        }
        #region Method
        void loadRoom()
        {
            
            List<Room> roomList = RoomDAO.Instance.LoadRoomList();
            foreach (Room item in roomList)
            {
                Button btn = new Button() { Width =RoomDAO.RoomWidth,Height=RoomDAO.RoomHeight};
                btn.Text = item.Tenphong + Environment.NewLine + item.Tinhtrangphong;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.Tinhtrangphong)
                {
                    case "Trống":
                        btn.BackColor = Color.YellowGreen;
                        break;
                    case "Có người":
                        btn.BackColor = Color.Red;
                        break;
                    default:
                        btn.BackColor = Color.Yellow;
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }
        void showVoucher(int maphieuthuephong)
        {
            listVoucher1.Items.Clear();
          List<VoucherInfo> listVoucherInfo = VoucherInfoDAO.Instance.GetListVoucherInfo(VoucherDAO.Instance.GetUncheckVoucherByRoom(maphieuthuephong));
            foreach (VoucherInfo item in listVoucherInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.Maphieuthuephong.ToString());
                lsvItem.SubItems.Add(item.Maloaikhach.ToString());
                lsvItem.SubItems.Add(item.Cmnd.ToString());
                lsvItem.SubItems.Add(item.Tenkhachhang.ToString());
                lsvItem.SubItems.Add(item.Diachi.ToString());
                listVoucher1.Items.Add(lsvItem);
            }
        }

        #endregion
        #region Events

        private void btn_Click(object sender, EventArgs e)
        {
            //int RoomID = ((sender as Button).Tag as Room).Maphong;
            //showVoucher(RoomID);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin f = new admin();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void danhSáchLoạiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomKind f = new RoomKind();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void danhSáchPhòngTrốngToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void phiếuThuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomRentVoucher f = new RoomRentVoucher();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        #endregion

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TableManager_Load(object sender, EventArgs e)
        {

        }

        private void datPhong_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Room selectedRoom = (Room)clickedButton.Tag;
            if (selectedRoom.Tinhtrangphong == "Có người")
            {
                MessageBox.Show("Phòng đã được có người thuê", "Thông báo", MessageBoxButtons.OK);
            }else if(selectedRoom.Tinhtrangphong == "Trống")
            {

            }
            // Kiểm tra xem phần tử được chọn có phải là một Button hay không
            //PhieuThuePhong f = new PhieuThuePhong(selectedRoom);
            this.Hide();
            //f.ShowDialog();
            this.Show();
        }

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBookRoom_Click(object sender, EventArgs e)
        {

        }
    }
}
