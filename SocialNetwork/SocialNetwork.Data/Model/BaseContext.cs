using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SocialNetwork.Data.Model
{
    public partial class BaseContext : DbContext
    {
        public BaseContext()
        {
        }

        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlockedUser> BlockedUsers { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<CommentVote> CommentVotes { get; set; } = null!;
        public virtual DbSet<Friend> Friends { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<GroupParticipant> GroupParticipants { get; set; } = null!;
        public virtual DbSet<Invite> Invites { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostView> PostViews { get; set; } = null!;
        public virtual DbSet<PostVote> PostVotes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=db;port=3306;database=social-network;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_polish_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<BlockedUser>(entity =>
            {
                entity.ToTable("blocked users");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => new { e.BlockingUserId, e.BlockedUserId }, "ID constraint")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.BlockingUserId, "User1ID_idx");

                entity.HasIndex(e => e.BlockedUserId, "User2ID_idx");

                entity.Property(e => e.BlockedUserId).HasColumnName("BlockedUserID");

                entity.Property(e => e.BlockingUserId).HasColumnName("BlockingUserID");

                entity.HasOne(d => d.BlockedUserNavigation)
                    .WithMany(p => p.BlockedUserBlockedUserNavigations)
                    .HasForeignKey(d => d.BlockedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User2ID0");

                entity.HasOne(d => d.BlockingUser)
                    .WithMany(p => p.BlockedUserBlockingUsers)
                    .HasForeignKey(d => d.BlockingUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User1ID0");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.CommentId, "CommentID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.PostId, "fk_comments_posts1_idx");

                entity.HasIndex(e => e.SenderId, "fk_comments_users1_idx");

                entity.Property(e => e.CommentId)
                    .ValueGeneratedNever()
                    .HasColumnName("CommentID");

                entity.Property(e => e.Content).HasColumnType("mediumtext");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comments_posts1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comments_users1");
            });

            modelBuilder.Entity<CommentVote>(entity =>
            {
                entity.ToTable("comment votes");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.CommentVoteId, "CommentVoteID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CommentId, "fk_comment votes_comments1");

                entity.HasIndex(e => e.VotingUserId, "fk_comment votes_users1_idx");

                entity.Property(e => e.CommentVoteId)
                    .ValueGeneratedNever()
                    .HasColumnName("CommentVoteID");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.VotingUserId).HasColumnName("VotingUserID");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentVotes)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comment votes_comments1");

                entity.HasOne(d => d.VotingUser)
                    .WithMany(p => p.CommentVotes)
                    .HasForeignKey(d => d.VotingUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comment votes_users1");
            });

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("friends");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => new { e.User1Id, e.User2Id }, "ID constraint")
                    .IsUnique();

                entity.HasIndex(e => e.User1Id, "User1ID_idx");

                entity.HasIndex(e => e.User2Id, "User2ID_idx");

                entity.Property(e => e.User1Id).HasColumnName("User1ID");

                entity.Property(e => e.User2Id).HasColumnName("User2ID");

                entity.HasOne(d => d.User1)
                    .WithMany()
                    .HasForeignKey(d => d.User1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User1ID");

                entity.HasOne(d => d.User2)
                    .WithMany()
                    .HasForeignKey(d => d.User2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User2ID");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("group");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.CreatorId, "fk_group_users1_idx");

                entity.Property(e => e.GroupId)
                    .ValueGeneratedNever()
                    .HasColumnName("GroupID");

                entity.Property(e => e.ConversationId).HasColumnName("ConversationID");

                entity.Property(e => e.CreatorId).HasColumnName("CreatorID");

                entity.Property(e => e.Description).HasMaxLength(45);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_group_users1");
            });

            modelBuilder.Entity<GroupParticipant>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("group participant");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => new { e.UserId, e.GroupId }, "ID constraint")
                    .IsUnique();

                entity.HasIndex(e => e.GroupId, "fk_group participant_group1");

                entity.HasIndex(e => e.UserId, "fk_group participant_users1_idx");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Nick).HasMaxLength(20);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Group)
                    .WithMany()
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_group participant_group1");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_group participant_users1");
            });

            modelBuilder.Entity<Invite>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("invites");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => new { e.InvitingUserId, e.InvitedUserId }, "ID constraint")
                    .IsUnique();

                entity.HasIndex(e => e.InvitingUserId, "User1ID_idx");

                entity.HasIndex(e => e.InvitedUserId, "User2ID_idx");

                entity.Property(e => e.InvitedUserId).HasColumnName("InvitedUserID");

                entity.Property(e => e.InvitingUserId).HasColumnName("InvitingUserID");

                entity.HasOne(d => d.InvitedUser)
                    .WithMany()
                    .HasForeignKey(d => d.InvitedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User2ID00");

                entity.HasOne(d => d.InvitingUser)
                    .WithMany()
                    .HasForeignKey(d => d.InvitingUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User1ID00");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("messages");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.DateTime, "DateTime_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.ConversationParticipantId, "fk_messages_conversation participant1_idx");

                entity.HasIndex(e => e.ConversationId, "fk_messages_conversations1_idx");

                entity.Property(e => e.MessageId)
                    .ValueGeneratedNever()
                    .HasColumnName("MessageID");

                entity.Property(e => e.Content).HasColumnType("mediumtext");

                entity.Property(e => e.ConversationId).HasColumnName("ConversationID");

                entity.Property(e => e.ConversationParticipantId).HasColumnName("ConversationParticipantID");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.LastEditTime).HasColumnType("timestamp");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.GroupId, "fk_posts_group1_idx");

                entity.HasIndex(e => e.SenderId, "fk_posts_users_idx");

                entity.Property(e => e.PostId)
                    .ValueGeneratedNever()
                    .HasColumnName("PostID");

                entity.Property(e => e.Content).HasColumnType("mediumtext");

                entity.Property(e => e.DataTime).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Messagescol)
                    .HasMaxLength(45)
                    .HasColumnName("messagescol");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_posts_group1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_posts_users");
            });

            modelBuilder.Entity<PostView>(entity =>
            {
                entity.ToTable("post view");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.PostViewId, "PostViewID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.PostId, "fk_post view_posts1");

                entity.HasIndex(e => e.UserId, "fk_senderid_idx");

                entity.Property(e => e.PostViewId)
                    .ValueGeneratedNever()
                    .HasColumnName("PostViewID");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostViews)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_post view_posts1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PostViews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_senderid");
            });

            modelBuilder.Entity<PostVote>(entity =>
            {
                entity.ToTable("post votes");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.PostId, "fk_post votes_posts1");

                entity.HasIndex(e => e.VotingUserId, "fk_post votes_users1_idx");

                entity.Property(e => e.PostVoteId)
                    .ValueGeneratedNever()
                    .HasColumnName("PostVoteID");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.VotingUserId).HasColumnName("VotingUserID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostVotes)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_post votes_posts1");

                entity.HasOne(d => d.VotingUser)
                    .WithMany(p => p.PostVotes)
                    .HasForeignKey(d => d.VotingUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_post votes_users1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.EmailAddress, "EmailAddress_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.TelephoneNumber, "TelephoneNumber_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "UserID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AllowInvites).HasDefaultValueSql("'1'");

                entity.Property(e => e.EmailAddress).HasMaxLength(35);

                entity.Property(e => e.LearningPlace).HasMaxLength(45);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.PasswordHash).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(20);

                entity.Property(e => e.TelephoneNumber).HasMaxLength(15);

                entity.Property(e => e.WorkingPlace).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
