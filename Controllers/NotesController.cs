using Microsoft.AspNetCore.Mvc;
using Notes_API.Interfaces;
using Notes_API.Models;
using Notes_API.Models.Request;
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

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var notes = await noteService.GetNotesByUserIdAsync(UserId);
        var note = notes.FirstOrDefault(n => n.Id == id);

        if (note is null)
            return NotFound();

        var model = new EditRequestModel
        {
            Title = note.Title,
            Content = note.Content
        };

        ViewBag.NoteId = note.Id;
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit( int id, EditRequestModel model )
    {
        if (!ModelState.IsValid)
            return View(model);

        await noteService.EditNote(
            id,
            UserId,
            model.Title,
            model.Content
        );

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