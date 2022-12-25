using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MoMoney
{
    public partial class PayContext : DbContext
    {
        public PayContext()
            : base("name=PayContext")
        {
        }
        public static int currentId;
        public virtual DbSet<category> Categories { get; set; }
        public virtual DbSet<login> Logins { get; set; }
        public virtual DbSet<payment> Payments { get; set; }
        public virtual DbSet<income> Incomes { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .Property(e => e.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<category>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<category>()
                .HasOptional(e => e.payment)
                .WithRequired(e => e.category1);

            modelBuilder.Entity<login>()
                .Property(e => e.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<login>()
                .Property(e => e.username)
                .IsFixedLength();

            modelBuilder.Entity<login>()
                .Property(e => e.password)
                .IsFixedLength();

            modelBuilder.Entity<login>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<login>()
                .Property(e => e.balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<login>()
                .HasMany(e => e.incomes)
                .WithRequired(e => e.login)
                .HasForeignKey(e => e.uid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<login>()
                .HasMany(e => e.payments)
                .WithRequired(e => e.login)
                .HasForeignKey(e => e.uid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<payment>()
                .Property(e => e.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<payment>()
                .Property(e => e.amount)
                .HasPrecision(19, 4);

            /*modelBuilder.Entity<payment>()
                        .Property(e => e.time)
                        .HasDefaultValueSql("getdate()");*/

            modelBuilder.Entity<income>()
                .Property(e => e.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<income>()
                .Property(e => e.amount)
                .HasPrecision(19, 4);
        }
        public static void AddCategory(string categoryName)
        {

            using (var context = new PayContext())
            {
                var category = new category
                {
                    name= categoryName
                };

                context.Categories.Add(category);
                context.SaveChanges();

            }
        }
        public static void AddUser(string legalName,string username,string password)
        {

            using (var context = new PayContext())
            {
                var login = new login
                {
                    name = legalName,
                    username = username,
                    password = password,
                    balance = decimal.Zero
                };

                context.Logins.Add(login);
                context.SaveChanges();

            }
        }
        public static void AddPayment(int categoryid,decimal suma,string note)
        {
            using (var context = new PayContext())
            {
                if(context.Categories.Find(categoryid)==null)
                {
                    return;
                }
                if(suma<0)
                    suma*=-1;
                var payment = new payment
                {
                    uid = PayContext.currentId,
                    category = categoryid,
                    time = DateTime.Now,
                    amount = suma,
                    note = note
                };

                context.Payments.Add(payment);
                context.Logins.Find(PayContext.currentId).balance -= suma;
                context.SaveChanges();
            }
        }
        public static void AddIncome(decimal suma, string note)
        {

            if (suma < 0)
                suma *= -1;
            using (var context = new PayContext())
            {
                var income = new income
                {
                    uid = PayContext.currentId,
                    time = DateTime.Now,
                    amount = suma,
                    note = note
                };

                context.Incomes.Add(income);
                context.Logins.Find(PayContext.currentId).balance += suma;
                context.SaveChanges();
            }
        }

        public static ICollection<income> ShowIncome()
        {
            using (var context = new PayContext())
            {
                return context.Incomes
                    .Where(r => r.uid == PayContext.currentId)
                    .ToList();
            }
        }
        public static ICollection<payment> ShowPayment()
        {
            using (var context = new PayContext())
            {
                return context.Payments
                    .Where(r => r.uid == PayContext.currentId)
                    .ToList();
            }
        }
        public static ICollection<payment> ShowPayment(int categoryid)
        {
            using (var context = new PayContext())
            {
                return context.Payments
                    .Where(r => r.uid == PayContext.currentId)
                    .Where(m => m.category == categoryid)
                    .ToList();
            }
        }
    }
}
