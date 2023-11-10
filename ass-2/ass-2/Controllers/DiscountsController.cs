using ass_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

public class DiscountsController : Controller
{
    // 创建一个Discount的列表
    private List<Discount> discounts = new List<Discount>
    {
        new Discount { Name = "R9000p", OriginalPrice = 1099, CurrentPrice = 999, ImageUrl = "Content/images/copt1.jpg" },
        new Discount { Name = "R7000P", OriginalPrice = 899, CurrentPrice = 809, ImageUrl = "url2" },
        // 添加更多的Discount对象...
    };

    // GET: Discounts
    public ActionResult Index()
    {
        // 使用创建的Discount列表
        return View(discounts);
    }

    // GET: Discounts/Details/5
    public ActionResult Details(string id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        // 在Discount列表中查找对应的Discount对象
        Discount discount = discounts.FirstOrDefault(d => d.Name == id);
        if (discount == null)
        {
            return HttpNotFound();
        }

        if (id == "Double 11 Special Discount")
        {
            // Add your logic for Double 11 Special Discount here
        }

        return View(discount);
    }
    // GET: Discounts/Edit/5
    public ActionResult Edit()
    {
        
        return View();
    }
    // 其他的方法...

    // 注意：因为你不再使用数据库，所以不需要Dispose方法
}