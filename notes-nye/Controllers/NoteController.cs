using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using notes_nye.Data;
using notes_nye.Models;

namespace notes_nye.Controllers
{
    public class NoteController : Controller
    {
        private static int idnya = 0;
        private readonly NotesContext dbContext;
        public NoteController(NotesContext dbContext) { 
            this.dbContext = dbContext;
        }
        
        
        // GET: NoteController
        public ActionResult Index()
        {
            var notesList = dbContext.Notes.ToList();
            ViewData["notes"] = notesList;
            return View();
        }

        // GET: NoteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NoteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NoteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            //ViewBag.noteTitle = collection["noteTitle"];

            var Tbl = new Note();
            Tbl.Id = idnya++;
            Tbl.Title = collection["noteTitle"];
            Tbl.Content = collection["noteContent"];
            Tbl.Writer = collection["noteWriter"];
            Tbl.Tag = collection["noteTag"];
            Tbl.Emotion = collection["noteEmotion"];

            var notes = dbContext.Set<Note>();
            notes.Add(Tbl);
            int i = dbContext.SaveChanges();
            if (i > 0)
            {
                ViewBag.Msg = "Data Saved Suuceessfully.";
            }
            try
            {
                return View();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NoteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NoteController/Edit/5
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

        // GET: NoteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NoteController/Delete/5
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
