using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using notes_nye.Models;

namespace notes_nye.Data
{
    public class NotesContext : DbContext
    {
        public NotesContext(DbContextOptions options) : base(options) { }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // configures one-to-many relationship
        //    modelBuilder.Entity<Note>()
        //        .HasOne(s => s.Writer)
        //        .WithMany(g => g.Note)
        //        .HasForeignKey<int>(s => s.WriterId);

        //    base.OnModelCreating(modelBuilder);
        //}
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Emotion> Emotions { get; set; }
    }
}
