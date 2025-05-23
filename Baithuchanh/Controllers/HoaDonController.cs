using Microsoft.AspNetCore.Mvc;
using Baithuchanh.Models;

public class HoaDonController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(HoaDonModel model)
    {
        if (ModelState.IsValid)
        {
            model.ThanhTien = model.SoLuong * model.DonGia;
            ViewBag.ThongBao = $"Thành tiền hóa đơn là: {model.ThanhTien.Value:C}";
        }
        return View(model);
    }
}
