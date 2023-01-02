using System.ComponentModel.DataAnnotations.Schema;

namespace notes_nye.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        
        // Relationship
        public int WriterId { get; set; }
        [ForeignKey("WriterId")]
        public User Writer { get; set; }
        public string Tag { get; set; }
        public Emotion Emotion { get; set; }

    }
}
