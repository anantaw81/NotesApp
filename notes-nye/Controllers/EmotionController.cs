using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using notes_nye.Data;
using notes_nye.Models;

namespace notes_nye.Controllers
{
    public class EmotionController : Controller
    {
        private readonly NotesContext dbContext;
        public EmotionController(NotesContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: EmotionController
        public ActionResult Index()
        {
            var emotionResult = dbContext.Emotions.ToList();
            ViewData["emotions"] = emotionResult;
            return View();
        }

        // GET: EmotionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmotionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmotionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var Tbl = new Emotion();
            Tbl.Name = collection["emName"];
            Tbl.Description = collection["emDesc"];

            var emotions = dbContext.Set<Emotion>();
            emotions.Add(Tbl);

            // Handle SavingData 
            int i = dbContext.SaveChanges();
            if (i > 0)
            {
                ViewBag.Msg = "Data Saved Suuceessfully.";
            }
            else
            {
                ViewBag.Msg = "Something Error at Saving Data.";
            }
            return View();
        }

        // GET: EmotionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmotionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmotionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmotionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
