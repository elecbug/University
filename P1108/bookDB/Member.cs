using System;
using System.Collections.Generic;

namespace P1108.bookDB;

public partial class Member
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<BookMember> BookMembers { get; set; } = new List<BookMember>();
}
