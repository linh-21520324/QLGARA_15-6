using BUS;
using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class fMain : Form
    {
        DateTime now = DateTime.Now;

        public fMain()
        {
            InitializeComponent();
        }
        #region Parameters
        private bool btnHoanTatClicked = false;
        private bool textBoxTenVTPTMoi_TextChanged = false;
        private bool textBoxDonGiaNhapVTPT_TextChanged = false;
        private bool textBoxDonGiaBanVTPT_TextChanged = false;
        #endregion

        #region Methods
        void DoiDateTimePickerFormat(DateTimePicker dtp) //Ham thuc hien chuyen format DateTimePicker sang MM/yyyy.
        {
            dtp.CustomFormat = "MM/yyyy";
            dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtp.ShowUpDown = true;
        }

        string LayNgayThangNamHienTai() //Ham thuc hien lay ngay/thang/nam thoi diem hien tai.
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }
        void DatThoiDiemHienTai(TextBox tb) //Ham dat noi dung textbox la thoi diem hien tai.
        {
            tb.Text = LayNgayThangNamHienTai();
        }
        void DatLaiDateTimePicker(DateTimePicker dtp) //Dat lai gia tri DatTimePicker thanh hom nay.
        {
            dtp.Value = DateTime.Now;
        }
        void DatVisibleChoControl(Control ctrl, bool result) //Dat thuoc tinh Visible cho Control.
        {
            ctrl.Visible = result;
        }

        void NhapVTPTChoPhieuSuaChua(int DonGia)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)dataGridViewVTPTPhieuSuaChua.DataSource;
            PhieuSuaChuaBUS.Instance.ThemHangVTPT(dt, comboBoxVTPTPhieuSuaChua.Text, textBoxSoLuongVTPTPhieuSuaChua.Text, DonGia, comboBoxVTPTPhieuSuaChua.SelectedValue.ToString());
        }

        void NhapTienCongChoPhieuSuaChua(int ChiPhi)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)dataGridViewTienCongPhieuSuaChua.DataSource;
            PhieuSuaChuaBUS.Instance.ThemHangTienCong(dt, PhieuSuaChuaBUS.Instance.LayNoiDungTienCong(comboBoxTienCongPhieuSuaChua.SelectedValue.ToString()), ChiPhi, comboBoxTienCongPhieuSuaChua.SelectedValue.ToString());
        }

        int TinhTongThanhTien()
        {
            int TongThanhTien = 0;
            foreach (DataGridViewRow row in dataGridViewVTPTPhieuSuaChua.Rows)
            {
                TongThanhTien += int.Parse(row.Cells["Thành tiền"].Value.ToString());
            }
            return TongThanhTien;
        }

        int TinhTongChiPhi()
        {
            int TongChiPhi = 0;
            foreach (DataGridViewRow row in dataGridViewTienCongPhieuSuaChua.Rows)
            {
                TongChiPhi += int.Parse(row.Cells["Chi phí"].Value.ToString());
            }
            return TongChiPhi;
        }

        void KhoiTaoDataGridviewVTPT()
        {
            dataGridViewVTPTPhieuSuaChua.DataSource = PhieuSuaChuaBUS.Instance.KhoiTaoDtVTPT();
            dataGridViewVTPTPhieuSuaChua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewVTPTPhieuSuaChua.AutoResizeColumns();

            //dataGridViewVTPTPhieuSuaChua.Columns["Mã phụ tùng"].Visible = false;
        }

        void KhoiTaoDataGridviewTienCong()
        {
            dataGridViewTienCongPhieuSuaChua.DataSource = PhieuSuaChuaBUS.Instance.KhoiTaoDtTienCong();
            dataGridViewTienCongPhieuSuaChua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTienCongPhieuSuaChua.AutoResizeColumns();

            //dataGridViewVTPTPhieuSuaChua.Columns["Mã tiền công"].Visible = false;
        }

        /*void KiemTraDuLieuBaoCaoKhiLoad(DateTime a)
        {
            if (!BaoCaoTonBUS.Instance.KiemTraDuLieuBaoCao(a))
            {
                DataTable dt = new DataTable();
                BaoCaoTonBUS.Instance.NhapBaoCaoTon(BaoCaoTonBUS.Instance.TaoBaoCaoTon(a), a);
            }
        }*/
        void DatMacDinhChoComboBox(ComboBox a)//Thực hiện đặt giá trị mặc định cho comboBox để tránh lỗi.
        {
            a.SelectedItem = null;
            a.Text = "--select--";
        }

        bool QuyenHanAdmin()//Kiểm tra tài khoản hiện tại có phải là admin không
        {
            if (TaiKhoanBUS.Instance.LayQuyenHan().ToUpper()=="ADMIN")
                return true;
            return false;
        }

        void GioiHanQuyenHan()//Thực hiện giới hạn quyền hạn lên các tài khoản không phải là admin.
        {
            if (!QuyenHanAdmin())
            {
                tabControlChung.TabPages.Remove(tabControlChung.TabPages[2]);
                tabControl1.TabPages.Remove(tabControl1.TabPages[3]);
                tabControlChung.TabPages.Remove(tabControlChung.TabPages[1]);
            }
        }
        #endregion
        private void fMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyGarageDataSet.HIEUXE' table. You can move, or remove it, as needed.
            this.hIEUXETableAdapter.Fill(this.quanLyGarageDataSet.HIEUXE);
            // TODO: This line of code loads data into the 'quanLyGarageDataSet.TIENCONG' table. You can move, or remove it, as needed.
            this.tIENCONGTableAdapter.Fill(this.quanLyGarageDataSet.TIENCONG);
            // TODO: This line of code loads data into the 'quanLyGarageDataSet.VATTUPHUTUNG' table. You can move, or remove it, as needed.
            this.vATTUPHUTUNGTableAdapter.Fill(this.quanLyGarageDataSet.VATTUPHUTUNG);
            // TODO: This line of code loads data into the 'quanLyGarageDataSet.KHACHHANG' table. You can move, or remove it, as needed.
            this.kHACHHANGTableAdapter.Fill(this.quanLyGarageDataSet.KHACHHANG);
            // TODO: This line of code loads data into the 'quanLyGarageDataSet.XE' table. You can move, or remove it, as needed.
            this.xETableAdapter.Fill(this.quanLyGarageDataSet.XE);
            GioiHanQuyenHan();
            // Lấy dữ liệu các xe đã tiếp nhận
            dataGridViewXeDaTiepNhan.DataSource = XeBUS.Instance.CacXeDaTiepNhan();
            dataGridViewXeDaTiepNhan.Show();
            //Lấy dữ liệu vật tư phụ tùng
            dataGridViewVTPTDaTiepNhan.DataSource = PhieuNhapVTPTBUS.Instance.CacVTPTDaTiepNhan();
            dataGridViewVTPTDaTiepNhan.Show();
            // Lấy thông tin cho progressbar số xe đã tiếp nhận 1 ngày
            progressBarSoXeDaThem.Maximum = QuyDinhBUS.Instance.LaySoXeSuaToiDa();
            progressBarSoXeDaThem.Value = XeBUS.Instance.SoXeTiepNhanTrongNgay(now);
            //Khởi tạo 1 dt để lưu lại các mã vtpt đã nhập và kiểm tra, so sánh số lượng nhập vào.
            PhieuSuaChuaBUS.Instance.KhoiTaoDtVTPTDangNhap();
            //Khởi tạo Datagridview Phiếu sửa chữa và tiền công
            KhoiTaoDataGridviewTienCong();
            KhoiTaoDataGridviewVTPT();
            // Điển ngày thu tiền
            textBoxNgayThuTien.Text = now.ToString("dd-MM-yyyy");
            DatMacDinhChoComboBox(comboBoxBienSoXe1);
            //KiemTraDuLieuBaoCaoKhiLoad(DateTime.Now);
            dataGridViewBaoCaoTon.DataSource = BaoCaoTonBUS.Instance.KhoiTaoBaoCaoTon();
            dataGridViewBaoCaoTon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBaoCaoTon.AutoResizeColumns();
            DatThoiDiemHienTai(txtBoxNgaySuaChua);
            dateTimePickerChonThoiDiemBaoCaoTon.CustomFormat = "MM/yyyy";
            dateTimePickerChonThoiDiemBaoCaoTon.ShowUpDown = true;
            //Lấy quy định hiện hành
            dataGridViewQuyDinhHienHanh.DataSource = QuyDinhBUS.Instance.LayTatCaQuyDinh();
            dataGridViewQuyDinhHienHanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewQuyDinhHienHanh.AutoResizeColumns();

        }
        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            dataGridViewXeDaTiepNhan.DataSource = XeBUS.Instance.LamMoiDanhSachXe();
            dataGridViewXeDaTiepNhan.Show();
        }

        private void buttonThemXe_Click(object sender, EventArgs e)
        {
            if (txtBoxTenKH.Text.Length == 0)
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
            else
            {
                if (txtBoxDienThoai.Text.Length == 0)
                    MessageBox.Show("Vui lòng nhập điện thoại của khách hàng!");
                else
                {
                    if (txtBoxDiaChi.Text.Length == 0)
                        MessageBox.Show("Vui lòng nhập địa chỉ khách hàng!");
                    else
                    {
                        if (txtBoxBienSo.Text.Length == 0)
                            MessageBox.Show("Vui lòng nhập biển số xe !");
                    }
                }
            }
            int test = 0;
            test = KhachHangBUS.Instance.ThemKhachHang(txtBoxTenKH.Text, txtBoxDienThoai.Text, txtBoxDiaChi.Text);      //thuc hien them khach hang moi
            test = XeBUS.Instance.ThemXe(txtBoxBienSo.Text, comBoxHieuXe.SelectedValue.ToString(), KhachHangBUS.Instance.LayMaKH(txtBoxTenKH.Text, txtBoxDienThoai.Text), now);
            if (test != 0)
            {
                MessageBox.Show("Thêm xe thành công!");
                progressBarSoXeDaThem.Value = progressBarSoXeDaThem.Value + 1;
                this.xETableAdapter.Fill(this.quanLyGarageDataSet.XE);
            }
            if (progressBarSoXeDaThem.Value == progressBarSoXeDaThem.Maximum)
            {
                txtBoxTenKH.Clear();
                txtBoxDienThoai.Clear();
                txtBoxDiaChi.Clear();
                txtBoxBienSo.Clear();
                txtBoxTenKH.Visible = false;
                txtBoxDienThoai.Visible = false;
                txtBoxDiaChi.Visible = false;
                txtBoxBienSo.Visible = false;
                buttonThemXe.Enabled = false;
                buttonClear.Enabled = false;
            }
            else
            {
                txtBoxTenKH.Clear();
                txtBoxDienThoai.Clear();
                txtBoxDiaChi.Clear();
                txtBoxBienSo.Clear();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            txtBoxTenKH.Clear();
            txtBoxDienThoai.Clear();
            txtBoxDiaChi.Clear();
            txtBoxBienSo.Clear();
        }

        private void btnInPhieuTiepNhanXeSua_Click(object sender, EventArgs e)
        {
            printDialogPTNXS.ShowDialog();

        }

        private void txtBoxNgaySuaChua_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonNhapVTPTPhieuSuaChua_Click(object sender, EventArgs e)
        {
            if (PhieuSuaChuaBUS.Instance.KiemTraSoLuong(comboBoxVTPTPhieuSuaChua.SelectedValue.ToString(), int.Parse(textBoxSoLuongVTPTPhieuSuaChua.Text)))
            {
                NhapVTPTChoPhieuSuaChua(PhieuSuaChuaBUS.Instance.LayDonGiaVTPT(comboBoxVTPTPhieuSuaChua.SelectedValue.ToString()));
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại số lượng vật tư phụ tùng! Kho không đủ đáp ứng", "Kho không đủ đáp ứng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTongTien_Click(object sender, EventArgs e)
        {

        }

        private void buttonNhapTienCongPhieuSuaChua_Click(object sender, EventArgs e)
        {
            NhapTienCongChoPhieuSuaChua(PhieuSuaChuaBUS.Instance.LayChiPhiTienCong(comboBoxTienCongPhieuSuaChua.SelectedValue.ToString()));

        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            int TongTien;
            TongTien = TinhTongThanhTien() + TinhTongChiPhi();
            textBoxTongTienPhieuSuaChua.Text = TongTien.ToString();
            btnHoanTatClicked = true;
        }

        private void btnLuuPSC_Click(object sender, EventArgs e)
        {
            if (btnHoanTatClicked)
            {
                PhieuSuaChuaBUS.Instance.LuuPhieuSuaChua(comboBoxBienSoXe1.Text, TinhTongChiPhi(), TinhTongThanhTien(),  TinhTongChiPhi()+ TinhTongThanhTien(), (DataTable)dataGridViewTienCongPhieuSuaChua.DataSource, (DataTable)dataGridViewVTPTPhieuSuaChua.DataSource);
                PhieuSuaChuaBUS.Instance.CapNhatTienNo(comboBoxBienSoXe1.Text, int.Parse(textBoxTongTienPhieuSuaChua.Text));
                MessageBox.Show("Đã lưu phiếu sửa chữa!", "Thành công!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PhieuSuaChuaBUS.Instance.NhapVTPT((DataTable)dataGridViewVTPTPhieuSuaChua.DataSource);
                this.vATTUPHUTUNGTableAdapter.Fill(this.quanLyGarageDataSet.VATTUPHUTUNG);// update lai KHO cho phieusuachua lan sau 
            }
            else
            {
                MessageBox.Show("Xin vui lòng nhấn Hoàn tất trước khi lưu phiếu sửa chữa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnInPhieuSuaChua_Click(object sender, EventArgs e)
        {
            printDialogPSC.ShowDialog();

        }

        private void btnTaoMoiPCS_Click(object sender, EventArgs e)
        {
            comboBoxBienSoXe1.Text = "";
            comboBoxVTPTPhieuSuaChua.Text = "";
            comboBoxTienCongPhieuSuaChua.Text = "";
            textBoxSoLuongVTPTPhieuSuaChua.Text = "";
            textBoxTongTienPhieuSuaChua.Text = "";
            KhoiTaoDataGridviewVTPT();
            KhoiTaoDataGridviewTienCong();
            PhieuSuaChuaBUS.Instance.XoaDtVTPTDangNhap();
            btnHoanTatClicked = false;
            DatMacDinhChoComboBox(comboBoxBienSoXe1);
        }

        private void tabPageNhapVTPT_Click(object sender, EventArgs e)
        {

        }

        private void buttonLapPhieuNhapVTPT_Click(object sender, EventArgs e)
        {
            if (textBoxSoLuongVTPT.Text == "")
                MessageBox.Show("Vui lòng nhập số lượng vật tư trước khi thêm mới phiếu nhập !");
            else
            {
                int test = 0;
                test = PhieuNhapVTPTBUS.Instance.NhapVTPT(comboBoxTenVTPT.SelectedValue.ToString(), textBoxSoLuongVTPT.Text, now);
                if (test > 0)
                    MessageBox.Show("Nhập vật thêm tư phụ tùng thành công!");
            }
        }

        private void buttonNhapMoiVTPT_Click(object sender, EventArgs e)
        {
            if (textBoxSoLuongVTPT.Text == "")
                MessageBox.Show("Vui lòng nhập số lượng vật tư trước khi thêm mới vật tư vào kho !");
            else
            {
                int test = 0;
                test = PhieuNhapVTPTBUS.Instance.NhapMoiVTPT(textBoxTenVTPTMoi.Text, textBoxSoLuongVTPT.Text, textBoxDonGiaNhapVTPT.Text, textBoxDonGiaBanVTPT.Text, now);
                if (test > 0)
                {
                    MessageBox.Show("Nhập mới vật tư phụ tùng thành công");
                    this.vATTUPHUTUNGTableAdapter.Fill(this.quanLyGarageDataSet.VATTUPHUTUNG);
                }
            }
        }

        private void buttonPhieuNhapVTPTMoi_Click(object sender, EventArgs e)
        {
            textBoxTenVTPTMoi.Clear();
            textBoxSoLuongVTPT.Clear();
            textBoxDonGiaNhapVTPT.Clear();
            textBoxDonGiaBanVTPT.Clear();
            textBoxTenVTPTMoi_TextChanged = false;
            textBoxDonGiaNhapVTPT_TextChanged = false;
            textBoxDonGiaBanVTPT_TextChanged = false;
            textBoxTenVTPTMoi.Enabled = true;
            textBoxDonGiaNhapVTPT.Enabled = true;
            textBoxDonGiaBanVTPT.Enabled = true;
            buttonLapPhieuNhapVTPT.Visible = true;
            buttonNhapMoiVTPT.Visible = true;
        }

        private void textBoxTenVTPTMoi_TextChanged_1(object sender, EventArgs e)
        {
            if (textBoxDonGiaNhapVTPT_TextChanged|| textBoxDonGiaBanVTPT_TextChanged)
                buttonLapPhieuNhapVTPT.Visible = false;
            textBoxTenVTPTMoi_TextChanged = true;
        }

        private void textBoxDonGiaNhapVTPT_TextChanged_1(object sender, EventArgs e)
        {
            if (textBoxTenVTPTMoi_TextChanged)
                buttonLapPhieuNhapVTPT.Visible = false;
            textBoxDonGiaNhapVTPT_TextChanged = true;
        }

        private void textBoxDonGiaBanVTPT_TextChanged_1(object sender, EventArgs e)
        {
            if (textBoxTenVTPTMoi_TextChanged)
                buttonLapPhieuNhapVTPT.Visible = false;
            textBoxDonGiaBanVTPT_TextChanged = true;
        }

        private void buttonInPhieuNhapVTPT_Click(object sender, EventArgs e)
        {
            printDialogPhieuNhapVTPT.ShowDialog();

        }

        private void btnShowVTPT_Click(object sender, EventArgs e)
        {
            dataGridViewVTPTDaTiepNhan.DataSource = PhieuNhapVTPTBUS.Instance.LamMoiDanhSachVTPT();
            dataGridViewXeDaTiepNhan.Show();
        }

        private void comboBoxVTPTPhieuSuaChua_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBoxSoLuongVTPTPhieuSuaChua.Text = "";

        }

        private void buttonLapPhieuThuTienPTT_Click(object sender, EventArgs e)
        {
            if (textBoxSoTienThuPTT.Text != "")
            {
                if (PhieuThuTienBUS.Instance.LayTienNoKH(comboBienSoXe2.Text) < int.Parse(textBoxSoTienThuPTT.Text))
                    MessageBox.Show("Vui lòng nhập lại tiền thu!");
                else
                {
                    int test = 0;
                    test = PhieuThuTienBUS.Instance.ThemPhieuThuTien(comboBienSoXe2.Text, textBoxSoTienThuPTT.Text, now);
                    if (test != 0)
                        MessageBox.Show("Thêm Phiếu Thu Tiền thành công!");

                }
            }
            else
                MessageBox.Show("Vui lòng nhập số tiền thu !");
        }

        private void buttonPhieuThuTienMoiPTT_Click(object sender, EventArgs e)
        {
            textBoxDienThoaiPTT.Clear();
            textBoxDiaChiPTT.Clear();
            textBoxHoTenChuXePTT.Clear();
            textBoxSoTienThuPTT.Clear();
            DateTime now = DateTime.Now;
            textBoxNgayThuTien.Text = now.ToString("dd-MM-yyyy");
        }

        private void buttonInPhieuThuTienPTT_Click(object sender, EventArgs e)
        {
            printDialogPTT.ShowDialog();

        }

        private void comboBienSoXe2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string[] info = PhieuThuTienBUS.Instance.LayThongTinKH(comboBienSoXe2.Text);        //du lieu tra ve: { ten, dien thoai, dia chi}
            textBoxHoTenChuXePTT.Text = info[0];
            textBoxDienThoaiPTT.Text = info[1];
            textBoxDiaChiPTT.Text = info[2];
        }

        private void comboBoxTenVTPT_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBoxTenVTPTMoi.Enabled = false;
            textBoxDonGiaNhapVTPT.Enabled = false;
            textBoxDonGiaBanVTPT.Enabled = false;
            buttonNhapMoiVTPT.Visible = false;
        }

        private void radioButtonTimTuongDoi_CheckedChanged(object sender, EventArgs e)
        {
            DatVisibleChoControl(flowLayoutPanelTimChinhXac, false);
            lblTraCuuChinh.Visible = true;
            textBoxTraCuuChinh.Visible = true;
        }

        private void radioButtonTimChinhXac_CheckedChanged(object sender, EventArgs e)
        {
            DatVisibleChoControl(flowLayoutPanelTimChinhXac, true);
            lblTraCuuChinh.Visible = false;
            textBoxTraCuuChinh.Visible = false;
        }

        private void btnTimKiemTraCuu_Click(object sender, EventArgs e)
        {
            if (radioButtonTimTuongDoi.Checked == true)
            {
                if (textBoxTraCuuChinh.Text == "")
                    MessageBox.Show("Nhập từ khóa tìm kiếm !");
                else
                {
                    dataGridViewTraCuu.DataSource = XeBUS.Instance.TimKiemTuongDoi(textBoxTraCuuChinh.Text);
                    dataGridViewTraCuu.Show();
                }
            }
            else
            {
                if (txtBoxBienSoTraCuu.Text == "")
                    MessageBox.Show("Nhập từ khóa tìm kiếm !");
                else
                {
                    dataGridViewTraCuu.DataSource = XeBUS.Instance.TimKiemChinhXac(txtBoxBienSoTraCuu.Text, comboBoxHieuXeTraCuu.Text);
                    dataGridViewTraCuu.Show();
                }
            }
        }

        private void btnDatLaiTraCuu_Click(object sender, EventArgs e)
        {
            textBoxTraCuuChinh.Text = "";
            txtBoxBienSoTraCuu.Text = "";
            comboBoxHieuXeTraCuu.Text = "";
        }

        private void btnLapBaoCaoDoanhSo_Click(object sender, EventArgs e)
        {
            dataGridViewBaoCaoDoanhSo.DataSource = BaoCaoDoanhThuBUS.Instance.BaoCaoDoanhThu(textBoxThangBaoCao.Text, textBoxNamBaoCao.Text);
            dataGridViewBaoCaoDoanhSo.Show();
            textBoxTongDoanhThu.Text = BaoCaoDoanhThuBUS.Instance.TongTienDoanhThu(textBoxThangBaoCao.Text, textBoxNamBaoCao.Text);
        }

        private void btnBaoCaoDoanhSoMoi_Click(object sender, EventArgs e)
        {
            textBoxThangBaoCao.Clear();
            textBoxNamBaoCao.Clear();
            textBoxTongDoanhThu.Clear();
        }

        private void btnLapBaoCaoTon_Click(object sender, EventArgs e)
        {
            // if (BaoCaoTonDAO.Instance.KiemTraThoiDiem(dateTimePickerChonThoiDiemBaoCaoTon.Value))
            //{
            lblThangBaoCaoTon.Text = "Tháng " + dateTimePickerChonThoiDiemBaoCaoTon.Value.ToString("MM/yyyy");
            dataGridViewBaoCaoTon.DataSource = BaoCaoTonBUS.Instance.TaoBaoCaoTon(dateTimePickerChonThoiDiemBaoCaoTon.Value);
            //}
        }

        private void btnBaoCaoTonMoi_Click(object sender, EventArgs e)
        {
            DatLaiDateTimePicker(dateTimePickerChonThoiDiemBaoCaoTon);
            lblThangBaoCaoTon.Text = "Tháng";
            BaoCaoTonBUS.Instance.TaoBaoCaoMoi((DataTable)dataGridViewBaoCaoTon.DataSource);
            dateTimePickerChonThoiDiemBaoCaoTon.CustomFormat = "MM/yyyy";
            dateTimePickerChonThoiDiemBaoCaoTon.ShowUpDown = true;
        }

        private void buttonLamMoiQuyDinh_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCapNhatSoLoaiTienCong_Click_1(object sender, EventArgs e)
        {

        }

        private void txtBoxSoLoaiTienCong_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void btnCapNhatSoLoaiVatTu_Click_1(object sender, EventArgs e)
        {

        }

        private void txtBoxSoLoaiVatTu_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void btnCapNhatSoXeSuaToiDa_Click_1(object sender, EventArgs e)
        {

        }

        private void txtBoxSoXeSuaChuaToiDa_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void btnCapNhatSoHieuXe_Click_1(object sender, EventArgs e)
        {

        }

        private void txtBoxSoHieuXe_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void btnCapNhatSoXeSuaToiDa_Click(object sender, EventArgs e)
        {
            int test = BUS.QuyDinhBUS.Instance.CapNhatSoXeSuaToiDa(txtBoxSoXeSuaChuaToiDa.Text);
            if (test != 0)
            {
                MessageBox.Show("Thay đổi số xe sửa tối đa thành công !");
                txtBoxSoXeSuaChuaToiDa.Clear();
            }
        }

        private void buttonLamMoiQuyDinh_Click(object sender, EventArgs e)
        {
            dataGridViewQuyDinhHienHanh.DataSource = BUS.QuyDinhBUS.Instance.LayTatCaQuyDinh();
            dataGridViewQuyDinhHienHanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewQuyDinhHienHanh.AutoResizeColumns();
        }

        private void btnCapNhatPhanTramTiLeGiaBan_Click(object sender, EventArgs e)
        {
            int test = BUS.QuyDinhBUS.Instance.CapNhatPhanTramTiLeGiaBan(txtBoxPhanTramTiLeGiaBan.Text);
            if (test != 0)
            {
                MessageBox.Show("Thay đổi phần trăm tỉ lệ giá bán thành công !");
                txtBoxPhanTramTiLeGiaBan.Clear();
            }
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongTinTaiKhoan tttk = new fThongTinTaiKhoan();
            tttk.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void LamMoi_comboBoxTenVTPT()
        {
            DataTable tbl_tenVTPT = new DataTable();
            tbl_tenVTPT = DataProvider.Instance.ExecuteQuery("SELECT TenVTPT FROM VATTUPHUTUNG");
            comboBoxTenVTPT.DataSource = tbl_tenVTPT;
            comboBoxTenVTPT.DisplayMember = "TenVTPT";
            comboBoxTenVTPT.ValueMember = "TenVTPT";
        }

        private void LamMoi_comboBoxVTPTPhieuSuaChua()
        {
            DataTable tbl_tenVTPT = new DataTable();
            tbl_tenVTPT = DataProvider.Instance.ExecuteQuery("SELECT TenVTPT FROM VATTUPHUTUNG");
            comboBoxVTPTPhieuSuaChua.DataSource = tbl_tenVTPT;
            comboBoxVTPTPhieuSuaChua.DisplayMember = "TenVTPT";
            comboBoxVTPTPhieuSuaChua.ValueMember = "TenVTPT";
        }
        private void btnXoaVTPT_Click(object sender, EventArgs e)
        {
            if (PhieuNhapVTPTBUS.Instance.DeleteVTPT(comboBoxTenVTPT.Text))
            {
                MessageBox.Show("Xóa vật tư phụ tùng thành công!");
                LamMoi_comboBoxTenVTPT();
                comboBoxTenVTPT.Text = "";
                LamMoi_comboBoxVTPTPhieuSuaChua();
            }
            else { MessageBox.Show("Error"); }
        }
    }
}
