using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC2.Service;
using MVC2.ViewModels;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class GuestbookController : Controller
    {

        GuestbookDBService guestbookService = new GuestbookDBService();

        // GET: Guestbook
        public ActionResult Index()
        {
            GuestbooksView Data = new GuestbooksView();
            Data.DataList = guestbookService.GetDataList();
            return View(Data);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Add([Bind(Include ="Name,Content")] Guestbooks Data)
        {
            guestbookService.InsertGuestbooks(Data);            
            return RedirectToAction("Index");
        }

        public ActionResult Edit (int Id)
        {
            Guestbooks Data = guestbookService.GetDataById(Id);
            return View(Data);
        }

        [HttpPost]
        public ActionResult Edit(int Id, [Bind(Include = "Name,Contetn")] Guestbooks UpdateData)
        {
            if (guestbookService.CheckUpdate(Id))
            {
                UpdateData.Id = Id;
                guestbookService.UpdateGuesbook(UpdateData);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Reply(int Id)
        {
            Guestbooks Data = guestbookService.GetDataById(Id);
            return View(Data);
        }

        [HttpPost]
        public ActionResult Reply (int Id,[Bind(Include ="Reply,ReplyTime")] Guestbooks ReplyData)
        {
            if(guestbookService.CheckUpdate(Id))
            {
                ReplyData.Id = Id;
                guestbookService.RelpyGuestbook(ReplyData);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}