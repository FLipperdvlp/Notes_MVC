using Notes_API.Entities;

namespace Notes_API.Models;

public class NoteViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsPinned { get; set; }
    public int UserId { get; set; }

    public NoteViewModel(Note note)
    {
        Id = note.Id;
        Title = note.Title;
        Content = note.Content;
        CreatedAt = note.CreatedAt;
        UpdatedAt = note.UpdatedAt;
        IsPinned = note.IsPinned;
        UserId = note.UserId;
    }
}