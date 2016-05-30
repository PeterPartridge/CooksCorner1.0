﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CooksCorner1._0.Models;
using Antlr.Runtime.Misc;
using System.Net;
using System.Data.Entity;
using System.Data;
using System.IO;
using PagedList;
using System.Collections;

namespace CooksCorner1._0.Controllers
{
    public class HomeController : Controller
    {
        CooksCornerDBset _db = new CooksCornerDBset();

        public ActionResult Index()
        {
            
            return View();

            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult _RecipeFrontPage()
        {
            var recipeList = _db.RecipeDB.ToList();

            int recipeMax = recipeList.Count;

            int ran = new Random().Next(1, recipeMax);

            if (ran == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            RecipeModel recipe = _db.RecipeDB.Include(i => i.Images).SingleOrDefault(s => s.RecipeId == ran);

            return PartialView(recipe);

        }


    }
}