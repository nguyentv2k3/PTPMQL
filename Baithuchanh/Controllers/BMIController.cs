using Microsoft.AspNetCore.Mvc;
using Baithuchanh.Models;

public class BMIController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(BMIModel model)
    {
        if (ModelState.IsValid)
        {
            // Tính BMI = cân nặng / (chiều cao)^2
            model.BMI = model.CanNang / (model.ChieuCao * model.ChieuCao);

            string thongbao = "";

            if (model.BMI < 18.5)
                thongbao = "Bạn bị thiếu cân";
            else if (model.BMI < 24.9)
                thongbao = "Bạn có cân nặng bình thường";
            else if (model.BMI < 29.9)
                thongbao = "Bạn bị thừa cân";
            else
                thongbao = "Bạn bị béo phì";

            ViewBag.ThongBao = thongbao;
        }

        return View(model);
    }
}
