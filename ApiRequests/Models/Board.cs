namespace PlaywrightTests.ApiRequests.Models;

public class Board
{
    public string? Id { get; set; }
    public string? NodeId { get; set; }
    public string? Name { get; set; }
    public string? Desc { get; set; }
    public object? DescData { get; set; }
    public bool Closed { get; set; }
    public string? DateClosed { get; set; }
    public string? IdOrganization { get; set; }
    public object? IdEnterprise { get; set; }
    public bool Pinned { get; set; }
    public bool Starred { get; set; }
    public string? Url { get; set; }
    public string?IdMemberCreator { get; set; }
    public Membership[]? Memberships { get; set; }
}

public class Membership
{
    public string? IdMember { get; set; }
    public string? MemberType { get; set; }
    public bool Unconfirmed { get; set; }
    public bool Deactivated { get; set; }
    public string? Id { get; set; }
}