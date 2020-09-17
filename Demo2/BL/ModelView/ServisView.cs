﻿using Demo2.DB;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2.BL.ModelView
{
    public  class ServisView
    {
        public string Title { get; set; }

        public string RealCost { get; set; }
               
        public string DiscountCost { get; set; }
        public string DurationInSeconds { get; set; }
        public string Discount { get; set; }

        public string MainImagePath { get; set; }

        public ServisView(DB.Service service)
        {
            Title = service.Title;
            RealCost = GetRealcost(service);
            DiscountCost = GetDiscountCost(service);
            DurationInSeconds = GetDurationInSeconds(service);
            Discount = GetDiscount(service);
            MainImagePath = service.MainImagePath;
        }

        private string GetDiscount(Service service)
        {
            if (service.Discount != null && service.Discount > 0)
            {
                return (service.Discount * 100).ToString() + "%";
            }
            return null;
        }

        private string GetDurationInSeconds(Service service)
        {
            return " руб. за " + (service.DurationInSeconds / 60).ToString() + " минут";
        }

        private string GetDiscountCost(Service service)
        {
            if (service.Discount != null && service.Discount > 0)
            {
                decimal s = service.Cost - service.Cost * Convert.ToDecimal(service.Discount);
                return  Math.Round(s, 0).ToString();
            }
            return Math.Round(service.Cost,0).ToString();
        }

        private string GetRealcost(Service service)
        {
            if (service.Discount != null && service.Discount > 0)
                return Math.Round( service.Cost , 0).ToString();

            return null;
        }
    }
}