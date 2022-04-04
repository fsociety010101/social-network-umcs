using System;
using System.Collections.Generic;

namespace SocialNetwork.Data.Model
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int ConversationId { get; set; }
        public int ConversationParticipantId { get; set; }
        public sbyte? WasRemoved { get; set; }
        public DateTime DateTime { get; set; }
        public string? Content { get; set; }
        public sbyte? WasEdited { get; set; }
        public DateTime? LastEditTime { get; set; }
    }
}
