﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EzTechReview.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EztechreviewEntities : DbContext
    {
        public EztechreviewEntities()
                : base("name=EztechreviewEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Follower> Followers { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<Pending> Pendings { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }
    }
}
