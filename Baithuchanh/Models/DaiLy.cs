using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Baithuchanh.Models
{
    public class DaiLy
    {
        public string MaDaiLy { get; set; }

        public string TenDaiLy { get; set; }

        public string DiaChi { get; set; }

        public string NguoiDaiDien { get; set; }

        public string DienThoai { get; set; }
     // Foreign Key - mã hệ thống phân phối mà đại lý này thuộc về
        public string MaHTPP { get; set; }

        // Navigation property - tham chiếu đến hệ thống phân phối
        public HeThongPhanPhoi HeThongPhanPhoi { get; set; }
    }
}