using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MvcDemo3.Controllers
{
    public class MasterController : Controller
    {

        public MasterController()
        {
            db.Configuration.ValidateOnSaveEnabled = false;
            int count = db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
        public ActionResult DetailsPartialView()
        {
            List<Models.EL_MasterDataDetails> list = (from s in db.EL_MasterDataDetails select s).ToList();
            return View("~/Views/Master/DetailsPartialView.cshtml",list);
        }

        //上下文
        Models.BPMEntities3 db = new Models.BPMEntities3();
         
        //主视图、主表填信息界面显示
        public ActionResult Index()
        {
            List<Models.EL_MasterDataDetails> list = (from s in db.EL_MasterDataDetails select s).ToList();
            return View(list);

        }
        //保存按钮事件
        [HttpPost]
        public ActionResult Index(Models.EL_MasterData model)
        {
            db.EL_MasterData.Add(model);
            db.SaveChanges();
            //指定跳转到的Index方法
            return RedirectToAction("Index");
            
        }

        /*查询主表部分信息*/
        public ActionResult Details()
        {
            List<Models.EL_MasterData> list = (from s in db.EL_MasterData select s).ToList();
            return View("~/Views/Master/Details.cshtml",list);
        }

       
        //
        /*点编辑后展现的子表视图*/
        public ActionResult Edit()
        {
            List<Models.EL_MasterDataDetails> list = (from s in db.EL_MasterDataDetails select s).ToList();
            return View("~/Views/Master/DetailsPartialView.cshtml", list);
        }

       
        // GET:删除

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Models.EL_MasterDataDetails movie = db.EL_MasterDataDetails.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
                return View(movie); 
        }

        //
        // POST: 删除

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Models.EL_MasterDataDetails ID = new Models.EL_MasterDataDetails { ID = id };
                DbEntityEntry<Models.EL_MasterDataDetails> entry = db.Entry<Models.EL_MasterDataDetails>(ID);
                entry.State = System.Data.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        /*显示数据方法*/
        [HttpGet]
        public ActionResult Modify(string id)
        {
            int Id = Convert.ToInt32(id);
            Models.EL_MasterDataDetails modify =( from s in db.EL_MasterDataDetails where s.ID == Id select s).FirstOrDefault();
            DbEntityEntry entry = db.Entry<Models.EL_MasterDataDetails>(modify);
            //对每个字段进行修改
            db.Set<MvcDemo3.Models.EL_MasterDataDetails>().Attach(modify);
            entry.State = System.Data.EntityState.Modified;
            db.SaveChanges();
            return View("~/Views/Master/Modify.cshtml", modify);
        }

        /*修改数据方法*/
        [HttpPost]
        public ActionResult Modify(Models.EL_MasterDataDetails modify)
        {
            if (ModelState.IsValid)
            {
                //上下文
                DbEntityEntry entry = db.Entry<Models.EL_MasterDataDetails>(modify);
                //对每个字段进行修改
                db.Set<MvcDemo3.Models.EL_MasterDataDetails>().Attach(modify);
                entry.State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/Master/Modify.cshtml", modify);
        }

        //测试代码
        public ActionResult Check(string searchString)
        {

            var query = from r in db.EL_MasterDataDetails join s in db.EL_MasterData on r.ELID equals s.ProcessID select r;
           
            if (!String.IsNullOrEmpty(searchString))
            {
                
                query = query.Where(s => s.ELID.Contains(searchString));
            }
                return View(query);
        }

        //查询测试视图
        public ActionResult View1()
        {
            var tb = from s in db.EL_MasterData
                     join a in db.EL_MasterDataDetails
                     on s.ProcessID equals a.ELID
                     select new MvcDemo3.Models.NewSelect
                     {
                         A_ProcessID = s.ProcessID,
                         A_StaffCode = s.StaffCode,
                         A_StaffName = s.StaffName,
                         ELID = a.ELID,
                         Field1 = a.Field1,
                         Field2 = a.Field2
                     };
            return View(tb.ToList());
        }
    }
}