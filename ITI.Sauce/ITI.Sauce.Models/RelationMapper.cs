using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ITI.Sauce.Models
{
    public static class RelationMapper
    {
        public static void Mapper(ModelBuilder modelBuilder)
        {
            /*Recipe - Category */
            modelBuilder.Entity<Recipe>().HasOne(r=>r.Category)
                .WithMany(c=>c.Recipes).HasForeignKey(r=>r.CategoryID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            /*Recipe - Ingredient*/
            modelBuilder.Entity<RecipeIngredient>().HasOne(ri => ri.Recipe)
                .WithMany(r=>r.RecipeIngredients).HasForeignKey(ri => ri.RecipeID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RecipeIngredient>().HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients).HasForeignKey(ri => ri.IngredientID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            /*User - Fav */
            modelBuilder.Entity<Fav>()
               .HasOne(U => U.User)
               .WithMany(F => F.favs)
               .HasForeignKey(U => U.UserID)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();
            /*User - Cart*/
            modelBuilder.Entity<Cart>()
               .HasOne(U => U.User)
               .WithMany(C => C.Carts)
               .HasForeignKey(U => U.UserID)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();

            /* Vendor MemberShip*/
            modelBuilder.Entity<Vendor_MemberShip>()
                .HasOne(vm => vm.Vendor)
                .WithMany(vm => vm.Vendor_MemberShips)
                .HasForeignKey(vm => vm.Vendor_ID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vendor_MemberShip>()
               .HasOne(vm => vm.MemberShip)
               .WithMany(vm => vm.Vendor_MemberShips)
               .HasForeignKey(vm => vm.MemberShip_ID)
               .OnDelete(DeleteBehavior.Cascade);


            /* Restaurant - Vendor*/
            modelBuilder.Entity<Restaurant>()
               .HasOne(vm => vm.Vendor)
               .WithMany(vm => vm.Restaurants)
               .HasForeignKey(vm => vm.Vendor_ID)
               .OnDelete(DeleteBehavior.Cascade);

            /* Restaurant - Location*/
            modelBuilder.Entity<Location>()
               .HasOne(vm => vm.Restaurants)
               .WithMany(vm => vm.Locations)
               .HasForeignKey(vm => vm.Restaurant_ID)
               .OnDelete(DeleteBehavior.Cascade);

            /* Restaurant - Phone*/
            modelBuilder.Entity<Restaurant_Phones>()
                .HasOne(pf => pf.Restaurants)
                .WithMany(f => f.Restaurant_Phones)
                .HasForeignKey(pf => pf.Restaurant_ID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            /*Order - Order List */
            modelBuilder.Entity<OrderList>().HasOne(O => O.Order)
               .WithMany(O => O.orderLists)
               .HasForeignKey(O => O.OrderID)
               .OnDelete(DeleteBehavior.Cascade);

            /*User - Rating */
            modelBuilder.Entity<Rating>().HasOne(r => r.User)
                .WithMany(u => u.Ratings).HasForeignKey(r => r.UserID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            /*Recipe - Fav */
            modelBuilder.Entity<Fav>().HasOne(f => f.Recipe)
                .WithMany(r => r.Favs).HasForeignKey(f => f.Recipe_ID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            /*Recipe - Cart */
            modelBuilder.Entity<Cart>().HasOne(c => c.Recipe)
                .WithMany(r => r.Carts).HasForeignKey(f => f.Recipe_ID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            /*Recipe - Rating */
            modelBuilder.Entity<Rating>().HasOne(ra => ra.Recipe)
                .WithMany(r => r.Ratings).HasForeignKey(ra => ra.RecipeID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            /*user - Order*/
            modelBuilder.Entity<Order>().HasOne(o => o.User)
                .WithMany(r => r.Orders).HasForeignKey(o => o.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            //Recipe => orderList
            modelBuilder.Entity<OrderList>().HasOne(r => r.Recipe)
                .WithMany(c => c.OrderList).HasForeignKey(r => r.Recipe_ID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            /*Recipe - Resturant*/
            modelBuilder.Entity<Recipe>().HasOne(r => r.Restaurant)
                .WithMany(c => c.Recipes).HasForeignKey(r => r.ResturantID)
                .OnDelete(DeleteBehavior.Cascade);

            /*Vendoe - User*/
            modelBuilder.Entity<Vendor>().HasOne(r => r.User)
                .WithOne(c => c.Vendor).HasForeignKey<Vendor> (r => r.ID)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
