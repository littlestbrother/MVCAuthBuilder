using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.Controllers {
  public class FoosController: Controller {
    private readonly MyProjectContext _db;

    public FoosController(MyProjectContext db) {
      _db = db;
    }

    public ActionResult Index() {
      List <Foo> model = _db.Foos.ToList();
      return View(model);
    }

    public ActionResult Create() {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Foo Foo) {
      _db.Foos.Add(Foo);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id) {
      var thisFoo = _db.Foos
        .Include(Foo => Foo.JoinEntities)
        .ThenInclude(join => join.Bar)
        .FirstOrDefault(Foo => Foo.FooId == id);
      return View(thisFoo);
    }
    public ActionResult Edit(int id) {
      var thisFoo = _db.Foos.FirstOrDefault(Foo => Foo.FooId == id);
      return View(thisFoo);
    }

    [HttpPost]
    public ActionResult Edit(Foo Foo) {
      _db.Entry(Foo).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id) {
      var thisFoo = _db.Foos.FirstOrDefault(Foo => Foo.FooId == id);
      return View(thisFoo);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id) {
      var thisFoo = _db.Foos.FirstOrDefault(Foo => Foo.FooId == id);
      _db.Foos.Remove(thisFoo);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}