using System;

namespace wiloazure.Common.Models
{
    public class Todo
    {
        public DateTime CreatedTime { get; set; }

        public string TaskDescription { get; set; }

        public bool IsCompletd { get; set; }
    }
}
