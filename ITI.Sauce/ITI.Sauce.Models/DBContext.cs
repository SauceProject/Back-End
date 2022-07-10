
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Models
{
    public class DBContext : IdentityDbContext<Users>
    {
        #region DbSets
        public DBContext(DbContextOptions options) : base (options)
        { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredient { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Fav> Favs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Vendor_MemberShip> Vendor_MemberShips { get; set; }
        public DbSet<MemberShip> MemberShips { get; set; }
        public DbSet<OrderList> OrderLists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Restaurant_Phones> Restaurant_Phones { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }
        #endregion


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS; Initial Catalog= Sauce; Integrated Security=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configurations
            new RecipeConfiguration().Configure(modelBuilder.Entity<Recipe>());
            new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
            new IngredientConfiguration().Configure(modelBuilder.Entity<Ingredient>());
            new RecipeIngredientConfiguration().Configure(modelBuilder.Entity<RecipeIngredient>());
            
            new CartConfiguration().Configure(modelBuilder.Entity<Cart>());
            new FavConfiguration().Configure(modelBuilder.Entity<Fav>());

            new OrderConfiguration().Configure(modelBuilder.Entity<Order>());
            new OrderListConfiguration().Configure(modelBuilder.Entity<OrderList>());
            new RatingConfiguration().Configure(modelBuilder.Entity<Rating>());
            new UserOrderConfiguration().Configure(modelBuilder.Entity<UserOrder>());

            new VendorConfiguration().Configure(modelBuilder.Entity<Vendor>());
            new MemberShipConfiguration().Configure(modelBuilder.Entity<MemberShip>());
            new Vendor_MemberShipConfiguration().Configure(modelBuilder.Entity<Vendor_MemberShip>());
            new RestaurantConfiguration().Configure(modelBuilder.Entity<Restaurant>());
            new Restaurant_PhonesConfiguration().Configure(modelBuilder.Entity<Restaurant_Phones>());
            new LocationConfiguration().Configure(modelBuilder.Entity<Location>());
            //modelBuilder.RoleData();
            #endregion
            RelationMapper.Mapper(modelBuilder);
            base.OnModelCreating(modelBuilder);
            
        }

         
    }
}
