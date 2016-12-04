using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC2.ViewModels;
using MVC2.Models;

namespace MVC2.Service
{
    public class GuestbookDBService
    {
        GuestbookEntities db = new GuestbookEntities();

        public List<Guestbooks> GetDataList()
        {
            return db.Guestbooks.ToList();
        }

        public void  InsertGuestbooks (Guestbooks newData)
        {
            newData.CreateTime = DateTime.Now;
            db.Guestbooks.Add(newData);
            db.SaveChanges();
        }

        public Guestbooks GetDataById(int Id)  
        {
            return db.Guestbooks.Find(Id);
        }

        public void UpdateGuesbook(Guestbooks UpdateData)
        {
            Guestbooks oleData = db.Guestbooks.Find(UpdateData.Id);
            oleData.Name = UpdateData.Name;
            oleData.Content = UpdateData.Content;
            db.SaveChanges();
        }

        public void RelpyGuestbook(Guestbooks RelpyData)
        {
            Guestbooks oleData = db.Guestbooks.Find(RelpyData.Id);
            oleData.Reply = RelpyData.Reply;
            oleData.ReplyTime = DateTime.Now;
            db.SaveChanges();
        }

        public bool CheckUpdate(int Id)
        {
            Guestbooks Data = db.Guestbooks.Find(Id);
            return (Data != null && Data.ReplyTime == null);
        }



    }
}