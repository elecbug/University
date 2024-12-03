using System;
using System.Collections.Generic;

namespace P1108.bookDB;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Company { get; set; } = null!;

    public virtual ICollection<BookMember> BookMembers { get; set; } = new List<BookMember>();
}
