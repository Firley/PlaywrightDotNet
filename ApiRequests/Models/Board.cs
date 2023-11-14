namespace PlaywrightTests.ApiRequests.Models;

public class Board
{
    public string Id { get; set; } = null!;

    public string NodeId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Desc { get; set; } = null!;

    public object DescData { get; set; } = null!;

    public bool Closed { get; set; }

    public string DateClosed { get; set; } = null!;

    public string IdOrganization { get; set; } = null!;

    public object IdEnterprise { get; set; } = null!;

    public bool Pinned { get; set; }

    public bool Starred { get; set; }

    public string Url { get; set; } = null!;

    public string IdMemberCreator { get; set; } = null!;

    public Membership[] Memberships { get; set; } = null!;
}

public class Membership
{
    public string? IdMember { get; set; }

    public string? MemberType { get; set; }

    public bool Unconfirmed { get; set; }

    public bool Deactivated { get; set; }

    public string? Id { get; set; }
}