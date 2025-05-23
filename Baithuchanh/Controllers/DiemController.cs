using Microsoft.AspNetCore.Mvc;
using Baithuchanh.Models;

public class DiemController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(DiemModel model)
    {
        if (ModelState.IsValid)
        {
            // Giả sử trọng số: A=30%, B=30%, C=40%
            model.DiemTongKet = model.DiemA * 0.3 + model.DiemB * 0.3 + model.DiemC * 0.4;
            ViewBag.ThongBao = $"Điểm tổng kết là: {model.DiemTongKet.Value.ToString("0.00")}";
        }

        return View(model);
    }
}
