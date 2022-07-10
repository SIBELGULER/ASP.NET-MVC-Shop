using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrnekProje.Data;
using OrnekProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OrnekProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
       
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public OrderDetailsVM OrderVM { get; set; }
        public OrderController(ApplicationDbContext db)
        {
            _db = db; 
        }
        [HttpPost]
        [Authorize(Roles =Diger.Role_Admin)]
        public IActionResult Onaylandi()
        {
            OrderHeader orderHeader = _db.OrderHeader.FirstOrDefault(i => i.Id == OrderVM.OrderHeader.Id);
            orderHeader.OrderStatus = Diger.Durum_Onaylandı;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = Diger.Role_Admin)]
        public IActionResult KargoyaVer()
        {
            OrderHeader orderHeader = _db.OrderHeader.FirstOrDefault(i => i.Id == OrderVM.OrderHeader.Id);
            orderHeader.OrderStatus = Diger.Durum_Kargoda;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            OrderVM = new OrderDetailsVM
            {
                OrderHeader = _db.OrderHeader.FirstOrDefault(i => i.Id == id),
                OrderDetails = _db.OrderDetails.Where(x => x.OrderId == id).Include(x => x.Product)
            };
            return View(OrderVM);
        }
        public IActionResult Index()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<OrderHeader> orderHeadersList;
            if (User.IsInRole(Diger.Role_Admin))
            {
                orderHeadersList = _db.OrderHeader.ToList();
            }
            else
            {
                orderHeadersList = _db.OrderHeader.Where(i => i.ApplicationUserId == claim.Value).Include(i => i.ApplicationUser);
            }
            return View(orderHeadersList);
        }
        public IActionResult Beklenen()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<OrderHeader> orderHeadersList;
            if (User.IsInRole(Diger.Role_Admin))
            {
                orderHeadersList = _db.OrderHeader.Where(İ=>İ.OrderStatus==Diger.Durum_Beklemede);
            }
            else
            {
                orderHeadersList = _db.OrderHeader.Where(i => i.ApplicationUserId == claim.Value&&i.OrderStatus==Diger.Durum_Beklemede).Include(i => i.ApplicationUser);
            }
            return View(orderHeadersList);
        }
        public IActionResult Onaylanan()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<OrderHeader> orderHeadersList;
            if (User.IsInRole(Diger.Role_Admin))
            {
                orderHeadersList = _db.OrderHeader.Where(İ => İ.OrderStatus == Diger.Durum_Onaylandı);
            }
            else
            { //Bu sayfaya da sipariş durumu onayalanan siparişler gelecektir.
                orderHeadersList = _db.OrderHeader.Where(i => i.ApplicationUserId == claim.Value && i.OrderStatus == Diger.Durum_Onaylandı).Include(i => i.ApplicationUser);
            }
            return View(orderHeadersList);
        }
        public IActionResult Kargolanan()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<OrderHeader> orderHeadersList;
            if (User.IsInRole(Diger.Role_Admin))
            {
                orderHeadersList = _db.OrderHeader.Where(İ => İ.OrderStatus == Diger.Durum_Kargoda);
            }
            else
            { //Bu sayfaya da kargolanan siparişler gelecek.
                orderHeadersList = _db.OrderHeader.Where(i => i.ApplicationUserId == claim.Value && i.OrderStatus == Diger.Durum_Kargoda).Include(i => i.ApplicationUser);
            }
            return View(orderHeadersList);
        }
    }
}
