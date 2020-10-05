using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2.BL
{
    public  class ServisController
    {
        private DB.DETLT2020Entities entities;
        public List<BL.ModelView.ServisView> ServisViews { get; } 
        public DB.Service Service { get; set; }


        public ServisController ()
        {

            ServisViews = new List<ModelView.ServisView>();
            try
            {
                entities =  new DB.DETLT2020Entities();

                var serv = entities.Services.ToList();
                foreach (var l in serv)
                {
                    ServisViews.Add(new ModelView.ServisView(l));
                }
            }
            catch
            {
                throw new Exception("Eror  db  ");
            }
        }

        public ServisController ( BL.ModelView.ServisView view )
        {
            try
            {
                entities = new DB.DETLT2020Entities();
                Service = entities.Services.Where(x => x.Title == view.Title).First(); ;
            }
            catch
            {
                throw new Exception("Ошибка БД");
            }
        }

        public  ServisController (DB.Service service)
        {
            entities = new DB.DETLT2020Entities();
            Service = service;
        }

        public  void  AddServis ()
        {
            try
            {
                entities.Services.AddOrUpdate(Service);
                entities.SaveChanges();
            }
            catch
            {
                throw new Exception("Ошибка сохранения в бд");
            }
        }

        public  void  Dellete ( )
        {
            try
            {
                entities.Services.Remove(Service);
                entities.SaveChanges();
            }
            catch
            {
                throw new Exception("Ошибка  удаления из бд");
            }
        }
    }
}
