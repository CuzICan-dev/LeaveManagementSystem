using LeaveManagementSystem.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.web.Controllers;

public class TestController : Controller
{
    // GET
    public IActionResult Index()
    {
        var data = new TestViewModel
        {
            Name = "Test2",
            DateOfBirth = new DateTime(1956,5, 23)
        };
        return View(data);
    }
}