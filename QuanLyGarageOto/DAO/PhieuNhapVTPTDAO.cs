using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PhieuNhapVTPTDAO
    {
        private static PhieuNhapVTPTDAO instance;
        private PhieuNhapVTPTDAO() { }
        public static PhieuNhapVTPTDAO Instance
        {
            get { if (instance == null) instance = new PhieuNhapVTPTDAO(); return instance; }
            private set { PhieuNhapVTPTDAO.instance = value; }
        }
        public int NhapVTPT(string ten, int soluong, DateTime now)
        {
            string query = "NhapVTPT @MaPhuTung , @SoLuong , @ThoiDiem";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ten, soluong, now });
        }

        public int NhapMoiVTPT(string ten, int soluong, int dongianhap, int dongiaban, DateTime now)
        {
            string query = "NhapMoiVTPT @TenPhuTung , @SoLuong , @DonGiaNhap , @DonGiaBan , @ThoiDiem";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ten, soluong, dongianhap, dongiaban, now });
        }

        public DataTable CacVTPTDaTiepNhan()
        {
            string query = "SELECT MaVTPT as 'Mã VTPT', TenVTPT as 'Tên VTPT', DonGiaNhap as 'Đơn giá nhập', DonGiaBan as 'Đơn giá bán', SoLuong as 'Số Lượng' FROM VATTUPHUTUNG";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable LamMoiDanhSachVTPT()
        {
            string query = "SELECT MaVTPT as 'Mã VTPT', TenVTPT as 'Tên VTPT', DonGiaNhap as 'Đơn giá nhập', DonGiaBan as 'Đơn giá bán', SoLuong as 'Số Lượng' FROM VATTUPHUTUNG";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool DeleteVTPT(string tenVTPT)
        {
            string query = "XoaVTPT @TenVTPT";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tenVTPT });
            return result > 0;
        }
    }
}
