using Microsoft.AspNetCore.Mvc;
using Notes_API.Models;
using Notes_API.Interfaces;

namespace Notes_API.Controllers;

public class NotesController(INoteService noteService) : Controller
{
    private int UserId => 1;

    public async Task<IActionResult> List()
    {
        var notes = await noteService.GetNotesByUserIdAsync(UserId);

        return View(notes.Select(note => new NoteViewModel(note)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRequestModel model)
    {
        await noteService.CreateNote(UserId, model.Title, model.Content);

        return RedirectToAction(nameof(List));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await noteService.DeleteNote(id, UserId);

        return RedirectToAction(nameof(List));
    }

    [HttpPost]
    public async Task<IActionResult> Toggle(int id)
    {
        await noteService.ToggleNote(id, UserId);

        return RedirectToAction(nameof(List));
    }
}