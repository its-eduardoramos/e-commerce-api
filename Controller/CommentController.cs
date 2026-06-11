using api.Dtos;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [Route("api/comment")]
  [ApiController]
  [Authorize]
  public class CommentController : ControllerBase
  {
    private readonly ICommentRepository _commentRepo;
    public CommentController(ICommentRepository commentRepo)
    {
      _commentRepo = commentRepo;
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var comment = await _commentRepo.GetByIdAsync(id);
      if (comment is null) return NotFound();
      return Ok(comment.ToResponse());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCommentRequest commentDto)
    {
      var comment = commentDto.ToEntity();
      var createdComment = await _commentRepo.CreateAsync(comment);

      return CreatedAtAction(
        nameof(GetById),
        new { id = createdComment.Id },
        createdComment.ToResponse()
      );
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequest updateDto)
    {
      var updatedComment = await _commentRepo.UpdateAsync(id, updateDto);
      if(updatedComment is null) return NotFound();
      return Ok(updatedComment.ToResponse());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var deletedComment = await _commentRepo.DeleteAsync(id);
      if(deletedComment is null) return NotFound();
      return NoContent();
    }
  }
}