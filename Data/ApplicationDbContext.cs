using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
  public class ApplicationDbContext : IdentityDbContext<AppUser>
  {
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
      
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      //Many to many ategory/product
      builder.Entity<ProductCategory>()
        .HasKey(pc => new { pc.CategoryId, pc.ProductId });

      builder.Entity<ProductCategory>()
        .HasOne(x => x.Product)
        .WithMany(x => x.ProductCategories)
        .HasForeignKey(p => p.ProductId);

      builder.Entity<ProductCategory>()
        .HasOne(x => x.Category)
        .WithMany(x => x.ProductCategories)
        .HasForeignKey(p => p.CategoryId);

      //Many to many cart/product
      builder.Entity<CartItem>()
        .HasKey(ci => new { ci.CartId, ci.ProductId });
      
      builder.Entity<CartItem>()
        .HasOne(x => x.Cart)
        .WithMany(x => x.CartItems)
        .HasForeignKey(x => x.CartId)
        .OnDelete(DeleteBehavior.Cascade);

      builder.Entity<CartItem>()
        .HasOne(x => x.Product)
        .WithMany()
        .HasForeignKey(x => x.ProductId)
        .OnDelete(DeleteBehavior.Restrict);

      //User roles
      var roles = new List<IdentityRole>
      {
        new IdentityRole
        {
          NormalizedName = "ADMIN",
          Name = "Admin"
        },
        new IdentityRole
        {
          NormalizedName = "USER",
          Name = "User"
        }
      };

      builder.Entity<IdentityRole>().HasData(roles);
    }
  }
}