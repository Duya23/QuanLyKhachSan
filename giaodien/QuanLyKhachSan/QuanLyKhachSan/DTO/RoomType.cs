using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class RoomType
    {
        private string maLoaiPhong;
        private int tenLoaiPhong;
        private int donGia;
        public RoomType(DataRow row)
        {
            this.MaLoaiPhong = row["maLoaiPhong"].ToString();
            this.TenLoaiPhong = (int)row["tenLoaiPhong"];
            this.DonGia = (int)row["donGia"];
        }

        public string MaLoaiPhong { get { return this.maLoaiPhong; } set { this.maLoaiPhong = value; } }
        public int TenLoaiPhong { get { return this.tenLoaiPhong; } set { this.tenLoaiPhong = value; } }
        public int DonGia { get { return this.donGia; } set { this.donGia = value; } }
    }
}
