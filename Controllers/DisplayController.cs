using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using display_list.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace display_list.Controllers
{
    public class DisplayController : Controller
    {
        list ls = new list();
        Update up = new Update();
        db objdb = new db();
        /*public IActionResult list_display()
        {
            //list ls = new list();
            List<display_entity> displays_l = list.displays_student();
            return View(displays_l);
           

            //return View();
        }*/


        public IActionResult list_display(int pg = 1)
        {
            //list ls = new list();
            List<display_entity> displays_l = list.displays_student();
            const int pageSize = 10;
            if (pg < 1)
                pg = 1;
            int recsCount = displays_l.Count();
            var pager = new pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;

            var data = displays_l.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.pager = pager;
            // return View(displays_l);

            return View(data);
        }




        public IActionResult Delete(int id = 0)
        {
            delete del = new delete();
            del.Delete_id(id);
            return RedirectToAction("list_display");


        }

        /*public IActionResult update(int id = 0)
        {
            delete del = new delete();
            del.Delete_id(id);
            return RedirectToAction("list_display");


        }*/

        //GET: Student/Edit/5

        /*public ActionResult Edit(int id ,display_entity de)
        {
            return View(ls.displays_student().Find(de=>de.id==id));
        }

        // POST: Student/Edit/
        [HttpPost]
        public IActionResult Edit(int id, [Bind]display_entity de )
        {

            Update sdb = new Update();


            try
            {
                if (ModelState.IsValid)
                {
                    string resp = sdb.UpdateDetails(de);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View(de);
        }*/

        /*public IActionResult Details(int id)
        {
            List<display_entity> displays_l = list.displays_student();
            
            return View(displays_l.Find(de=>de.id==id)); 
        }*/

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(list.displays_student().Find(de => de.id == id));
        }

        // POST: st_feedbackController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, display_entity de)
        {
            try
            {

                if (up.UpdateDetails(de))
                {
                    ViewBag.Message = "Data updated successfully";
                }
                return RedirectToAction(nameof(list_display));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(display_entity rb)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = objdb.AddFeedbackRecord(rb);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
    }

            
}
       



                

    
    

