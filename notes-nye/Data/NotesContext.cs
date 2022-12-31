using Microsoft.EntityFrameworkCore;
using notes_nye.Models;

namespace notes_nye.Data
{
    public class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public NotesContext(DbContextOptions options) : base(options) { }
    }
}
