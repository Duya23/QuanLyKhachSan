
using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAO
{
    public class RoomDAO
    {
        private static RoomDAO instance;

        public static RoomDAO Instance
        {
            get
            {
                if (instance == null) instance = new RoomDAO(); return RoomDAO.instance;
            }
            private set
            {
                RoomDAO.instance = value;
            }
        }
        public static int RoomWidth = 100;
        public static int RoomHeight = 100;
        private RoomDAO() { }
        public List<Room> LoadRoomList()
        {
            List<Room> roomList = new List<Room>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetRoomList");
            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                roomList.Add(room);

            }

            return roomList;
        }
        public float GetDonGiaTheoLoaiPhong(string maLoaiPhong)
        {
            string query = "SELECT DonGia FROM LOAIPHONG WHERE MaLoaiPhong = '" + maLoaiPhong + "'";
            float gia = DataProvider.Instance.ExecuteScalarFloat(query);
            return gia;
        }
        public float GetDonGiaTheoPhong(int maPhong)
        {
            string query = "SELECT DonGia FROM LOAIPHONG lp, DANHMUCPHONG p WHERE lp.MaLoaiPhong = p.MaLoaiPhong AND p.MaPhong = " + maPhong;
            float gia = DataProvider.Instance.ExecuteScalarFloat(query);
            return gia;
        }
        public Boolean CapNhatTinhTrangPhong(int maPhong,string trangThai)
        {
            string query = "UPDATE DANHMUCPHONG SET TinhTrangPhong = N'" + trangThai  + "' WHERE MaPhong = " + maPhong;
            Boolean update = DataProvider.Instance.ExecuteUpdate(query);
            return update;
        }
    }
}
