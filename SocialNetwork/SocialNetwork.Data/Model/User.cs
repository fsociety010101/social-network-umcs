using System;
using System.Collections.Generic;

namespace SocialNetwork.Data.Model
{
    public partial class User
    {
        public User()
        {
            BlockedUserBlockedUserNavigations = new HashSet<BlockedUser>();
            BlockedUserBlockingUsers = new HashSet<BlockedUser>();
            CommentVotes = new HashSet<CommentVote>();
            Comments = new HashSet<Comment>();
            Groups = new HashSet<Group>();
            PostViews = new HashSet<PostView>();
            PostVotes = new HashSet<PostVote>();
            Posts = new HashSet<Post>();
        }

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string? TelephoneNumber { get; set; }
        public DateOnly JoinDate { get; set; }
        public DateOnly BirthdayDate { get; set; }
        public sbyte? AllowInvites { get; set; }
        public string? WorkingPlace { get; set; }
        public string? LearningPlace { get; set; }

        public virtual ICollection<BlockedUser> BlockedUserBlockedUserNavigations { get; set; }
        public virtual ICollection<BlockedUser> BlockedUserBlockingUsers { get; set; }
        public virtual ICollection<CommentVote> CommentVotes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<PostView> PostViews { get; set; }
        public virtual ICollection<PostVote> PostVotes { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
