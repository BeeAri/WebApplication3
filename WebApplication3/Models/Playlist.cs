using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Playlist
{
    public long PlaylistId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Track> Tracks { get; } = new List<Track>();
}
