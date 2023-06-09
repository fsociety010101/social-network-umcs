﻿using System;
using System.Collections.Generic;

namespace SocialNetwork.Data.Model
{
    public partial class PostView
    {
        public int PostViewId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Post Post { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
