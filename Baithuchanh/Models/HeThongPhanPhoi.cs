using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Baithuchanh.Models
{
    [Table("HeThongPhanPhoi")]
    public class HeThongPhanPhoi
    {
        [Key]
        public string MaHTTP { get; set; }
        public string TenHTPP { get; set; }
        public ICollection<DaiLy> DaiLys { get; set; }
    }
}