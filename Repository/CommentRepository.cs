using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class CommentRepository : ICommentRepository
  {
    private readonly ApplicationDbContext _context;
    public CommentRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<List<Comment>> GetAllAsync()
    {
      return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
      return await _context.Comments.FindAsync(id);
    }

    public async Task<Comment> CreateAsync(Comment commentModel)
    {
      await _context.AddAsync(commentModel);
      await _context.SaveChangesAsync();
      return commentModel;
    }

    public async Task<Comment?> UpdateAsync(int id, UpdateCommentRequest updateDto)
    {
      var existingComment = await GetByIdAsync(id);
      if(existingComment is null) return null;

      existingComment.Title = updateDto.Title;
      existingComment.Content = updateDto.Content;
      existingComment.Rating = updateDto.Rating;
      existingComment.UpdatedAt = DateTime.UtcNow;

      await _context.SaveChangesAsync();
      return existingComment;
    }

    public async Task<Comment?> DeleteAsync(int id)
    {
      var existingComment = await _context.Comments.FindAsync(id);
      if (existingComment is null) return null;
      
      _context.Remove(existingComment);
      await _context.SaveChangesAsync();
      return existingComment;
    }
  }
}