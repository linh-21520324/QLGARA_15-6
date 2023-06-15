using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PhieuNhapVTPTBUS
    {
        private static PhieuNhapVTPTBUS instance;
        private PhieuNhapVTPTBUS() { }
        public static PhieuNhapVTPTBUS Instance
        {
            get { if (instance == null) instance = new PhieuNhapVTPTBUS(); return instance; }
            private set { PhieuNhapVTPTBUS.instance = value; }
        }
        public int NhapVTPT(string ten, string soluong, DateTime now)
        {
            return PhieuNhapVTPTDAO.Instance.NhapVTPT(ten, int.Parse(soluong), now);
        }
        public int NhapMoiVTPT(string ten, string soluong, string dongianhap, string dongiaban, DateTime now)
        {
            return PhieuNhapVTPTDAO.Instance.NhapMoiVTPT(ten, int.Parse(soluong), int.Parse(dongianhap), int.Parse(dongiaban), now);
        }

        public DataTable CacVTPTDaTiepNhan()
        {
            return PhieuNhapVTPTDAO.Instance.CacVTPTDaTiepNhan();
        }

        public DataTable LamMoiDanhSachVTPT()
        {
            return PhieuNhapVTPTDAO.Instance.LamMoiDanhSachVTPT();
        }

        public bool DeleteVTPT(string TenVTPT)
        {
            return PhieuNhapVTPTDAO.Instance.DeleteVTPT(TenVTPT);

        }
    }
}
