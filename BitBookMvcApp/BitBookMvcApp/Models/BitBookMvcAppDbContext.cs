namespace BitBookMvcApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BitBookMvcAppDbContext : DbContext
    {
        public BitBookMvcAppDbContext()
            : base("name=BitBookMvcAppDbContext")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<FamilyMember> FamilyMembers { get; set; }
        public virtual DbSet<FriendList> FriendLists { get; set; }
        public virtual DbSet<FriendRequest> FriendRequests { get; set; }
        public virtual DbSet<Interest> Interests { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<MobileNo> MobileNoes { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<ProfessionalSkill> ProfessionalSkills { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Work> Works { get; set; }
        public virtual DbSet<GetFriendRequestView> GetFriendRequestViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.CurrentCity)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.CurrentCountry)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.FromCity)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.FromCountry)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Comment1)
                .IsUnicode(false);

            modelBuilder.Entity<Education>()
                .Property(e => e.Institute)
                .IsUnicode(false);

            modelBuilder.Entity<Education>()
                .Property(e => e.Degree)
                .IsUnicode(false);

            modelBuilder.Entity<FamilyMember>()
                .Property(e => e.RelationshipId);

            modelBuilder.Entity<Interest>()
                .Property(e => e.InterestedIn)
                .IsUnicode(false);

            modelBuilder.Entity<MobileNo>()
                .Property(e => e.MobileNo1)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Post1)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.PicUrl)
                .IsUnicode(false);

            modelBuilder.Entity<ProfessionalSkill>()
                .Property(e => e.Skill)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<Profile>()
                .Property(e => e.Religion)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.RelationshipId);

            modelBuilder.Entity<Profile>()
                .Property(e => e.About)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.WhoCommentedId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FamilyMembers)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FamilyMembers1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.FamilyMemberId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FriendRequests)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.SenderId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FriendRequests1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.ReceiverId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Likes)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.WhoLikedId);

            modelBuilder.Entity<Work>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Work>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<Work>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Work>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Work>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<GetFriendRequestView>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<GetFriendRequestView>()
                .Property(e => e.ProPic)
                .IsUnicode(false);
        }
    }
}
