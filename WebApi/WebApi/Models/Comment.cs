using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public int UserId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();

    public virtual User User { get; set; } = null!;
}
