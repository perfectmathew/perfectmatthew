namespace PerfectMatthew.Api.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public SkillCategory Category { get; set; }
        public int Level { get; set; } // 1-5 scale
        public string Icon { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; }
    }

    public enum SkillCategory
    {
        Frontend,
        Backend,
        Database,
        Cloud,
        Tools
    }

    public class Experience
    {
        public int Id { get; set; }
        public string Company { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Current { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<string> Technologies { get; set; } = new();
        public List<string> Achievements { get; set; } = new();
        public string Location { get; set; } = string.Empty;
        public string? CompanyLogo { get; set; }
    }

    public class ContactMessage
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Subject { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}