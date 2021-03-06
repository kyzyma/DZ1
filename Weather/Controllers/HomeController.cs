﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Models;
using Weather.Services;

namespace Weather.Controllers
{
    public class HomeController : Controller
    {
        GetJasonData jsData;

            public HomeController()
            {
                jsData = new GetJasonData();
            }

            // GET: /Home/

            public ActionResult Index()
            {
                var ob = jsData.OutData("london",3);
                return View(ob);
            }

            [HttpPost]
            public ActionResult Index(BaseObject City)
            {
                if (City.ChooseCityInput == null || City.ChooseCityInput.Length ==0)
                {
                    var ob = jsData.OutData(City.ChooseCityList, City.CountDays);
                    
                    return View(ob);
                }
                else
                {
                    var ob = jsData.OutData(City.ChooseCityInput, City.CountDays);
                    ob.CountDays = City.CountDays;
                    return View(ob);
                }
            }

            

            
        
    }
}
