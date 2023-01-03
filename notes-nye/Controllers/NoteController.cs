using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var notesList = dbContext.Notes.Include(s => s.Emotion).Include(s => s.Writer).ToList();
            ViewData["notes"] = notesList;
            return View(notesList);
        }

        // GET: NoteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NoteController/Create
        public ActionResult Create()
        {
            var writerResult = dbContext.Users.OrderBy(u => u.Id).ToList();
            var emotionResult = dbContext.Emotions.OrderBy(e => e.Id).ToList();
            ViewBag.Writer= new SelectList(writerResult, "Id", "Name") ;
            ViewBag.Emotion = new SelectList(emotionResult, "Id", "Name");
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
            Tbl.WriterId = Int32.Parse(collection["noteWriter"]);
            Tbl.Tag = collection["noteTag"];
            Tbl.EmotionId = Int32.Parse(collection["noteEmotion"]);

            var notes = dbContext.Set<Note>();
            notes.Add(Tbl);

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
            var notesResult = dbContext.Notes.SingleOrDefault(x => x.Id == id);
            if(notesResult != null)
            {
                notesResult.Id = id;
                notesResult.Title = collection["noteTitle"];
                notesResult.Content = collection["noteContent"];
                //notesResult.Writer = collection["noteWriter"];
                notesResult.Tag = collection["noteTag"];
                //notesResult.Emotion = collection["noteEmotion"];
                dbContext.SaveChanges();
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // POST: NoteController/Delete/5
        [HttpGet]
        /*[ValidateAntiForgeryToken]*/
        public ActionResult Delete(int id)
        {
            var notesResult = dbContext.Notes.Find(id);
            dbContext.Notes.Remove(notesResult);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        /*[HttpPost("{id}")]
        public async Task<ActionResult<Note>> Delete(int id)
        {
            var notesResult = await dbContext.Notes.FindAsync(id);
            if (notesResult == null)
            {
                return NotFound();
            }
            dbContext.Notes.Remove(notesResult);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }*/

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var notesResult = await dbContext.Notes.Where(s => s.Id == id).Include(s => s.Emotion).Include(s => s.Writer).FirstOrDefaultAsync();
            //var notesResult = await dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id);
            if(notesResult != null)
            {
                return await Task.Run(() => View("View", notesResult));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> View(Note model)
        {
            var notesResult = await dbContext.Notes.FindAsync();
            //var notesResult = await dbContext.Notes.Where(s => s.Id == model.Id ).Include(s => s.Emotion).Include(s => s.Writer).FirstOrDefaultAsync();
            if (notesResult != null)
            {
                notesResult.Title = model.Title;
                notesResult.Content = model.Content;
                notesResult.Writer = model.Writer;
                notesResult.Tag = model.Tag;
                notesResult.Emotion = model.Emotion;
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Note model)
        {
            var notesResult = await dbContext.Notes.FindAsync(model.Id);
            if(notesResult != null)
            {
                dbContext.Notes.Remove(notesResult);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
