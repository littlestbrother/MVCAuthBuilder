using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace MyProject.Controllers
{
  [Authorize]
  public class BarsController : Controller
  {
    private readonly MyProjectContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public BarsController(UserManager<ApplicationUser> userManager, MyProjectContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userBars = _db.Bars.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userBars);
    }

    public ActionResult Create()
    {
      ViewBag.FooId = new SelectList(_db.Foos, "FooId", "Name");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Bar Bar, int FooId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      Bar.User = currentUser;
      _db.Bars.Add(Bar);
      _db.SaveChanges();
      if (FooId != 0)
      {
          _db.FooBar.Add(new FooBar() { FooId = FooId, BarId = Bar.BarId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisBar = _db.Bars
          .Include(Bar => Bar.JoinEntities)
          .ThenInclude(join => join.Foo)
          .FirstOrDefault(Bar => Bar.BarId == id);
      return View(thisBar);
    }

    public ActionResult Edit(int id)
    {
      var thisBar = _db.Bars.FirstOrDefault(Bar => Bar.BarId == id);
      ViewBag.FooId = new SelectList(_db.Foos, "FooId", "Name");
      return View(thisBar);
    }

    [HttpPost]
    public ActionResult Edit(Bar Bar, int FooId)
    {
      if (FooId != 0)
      {
        _db.FooBar.Add(new FooBar() { FooId = FooId, BarId = Bar.BarId });
      }
      _db.Entry(Bar).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddFoo(int id)
    {
      var thisBar = _db.Bars.FirstOrDefault(Bar => Bar.BarId == id);
      ViewBag.FooId = new SelectList(_db.Foos, "FooId", "Name");
      return View(thisBar);
    }

    [HttpPost]
    public ActionResult AddFoo(Bar Bar, int FooId)
    {
      if (FooId != 0)
      {
      _db.FooBar.Add(new FooBar() { FooId = FooId, BarId = Bar.BarId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisBar = _db.Bars.FirstOrDefault(Bar => Bar.BarId == id);
      return View(thisBar);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisBar = _db.Bars.FirstOrDefault(Bar => Bar.BarId == id);
      _db.Bars.Remove(thisBar);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteFoo(int joinId)
    {
      var joinEntry = _db.FooBar.FirstOrDefault(entry => entry.FooBarId == joinId);
      _db.FooBar.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}