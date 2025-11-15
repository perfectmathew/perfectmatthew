namespace PerfectMatthew.Api.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? LongDescription { get; set; }
        public List<string> Technologies { get; set; } = new();
        public string? ImageUrl { get; set; }
        public string? GithubUrl { get; set; }
        public string? LiveUrl { get; set; }
        public ProjectCategory Category { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Featured { get; set; }
        public List<string> Achievements { get; set; } = new();
        public List<string> Challenges { get; set; } = new();
    }

    public enum ProjectCategory
    {
        WebApp,
        MobileApp,
        Api,
        DesktopApp,
        Library,
        Other
    }

    public enum ProjectStatus
    {
        Completed,
        InProgress,
        OnHold,
        Planning
    }
}