using Microsoft.EntityFrameworkCore;
using PerfectMatthew.Api.Database;
using PerfectMatthew.Api.Models;

namespace PerfectMatthew.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Ensure database is created
            context.Database.EnsureDeleted(); // Delete if exists
            context.Database.EnsureCreated(); // Recreate fresh

            // Check if database already has data
            if (context.Projects.Any())
            {
                return; // Database has been seeded
            }

            // Seed Skills
            var skills = new Skill[]
            {
                // Frontend
                new Skill { Name = "Angular", Category = SkillCategory.Frontend, Level = 3, Icon = "🅰️", Color = "#dd1b16", YearsOfExperience = 2 },
                new Skill { Name = "TypeScript", Category = SkillCategory.Frontend, Level = 4, Icon = "🔷", Color = "#3178c6", YearsOfExperience = 3 },
                new Skill { Name = "JavaScript", Category = SkillCategory.Frontend, Level = 3, Icon = "🟨", Color = "#f7df1e", YearsOfExperience = 5 },
                new Skill { Name = "HTML5", Category = SkillCategory.Frontend, Level = 5, Icon = "🌐", Color = "#e34f26", YearsOfExperience = 10 },
                new Skill { Name = "CSS3/SCSS", Category = SkillCategory.Frontend, Level = 5, Icon = "🎨", Color = "#1572b6", YearsOfExperience = 10 },
                new Skill { Name = "Tailwind CSS", Category = SkillCategory.Frontend, Level = 5, Icon = "💨", Color = "#06b6d4", YearsOfExperience = 5 },
                
                // Backend
                new Skill { Name = "C#", Category = SkillCategory.Backend, Level = 5, Icon = "#️⃣", Color = "#239120", YearsOfExperience = 6 },
                new Skill { Name = ".NET Core", Category = SkillCategory.Backend, Level = 5, Icon = "⚙️", Color = "#512bd4", YearsOfExperience = 6 },
                new Skill { Name = "ASP.NET Web API", Category = SkillCategory.Backend, Level = 5, Icon = "🔧", Color = "#512bd4", YearsOfExperience = 5 },
                new Skill { Name = "Blazor", Category = SkillCategory.Backend, Level = 4, Icon = "🔥", Color = "#512bd4", YearsOfExperience = 2 },
                new Skill { Name = "Entity Framework", Category = SkillCategory.Backend, Level = 5, Icon = "📊", Color = "#512bd4", YearsOfExperience = 5 },
                
                // Database
                new Skill { Name = "PostgreSQL", Category = SkillCategory.Database, Level = 4, Icon = "🐘", Color = "#336791", YearsOfExperience = 6 },
                new Skill { Name = "SQL Server", Category = SkillCategory.Database, Level = 5, Icon = "🗄️", Color = "#cc2927", YearsOfExperience = 7 },
                
                // Cloud & DevOps
                new Skill { Name = "Google Cloud Platform", Category = SkillCategory.Cloud, Level = 3, Icon = "☁️", Color = "#4285f4", YearsOfExperience = 2 },
                new Skill { Name = "Cloud Run", Category = SkillCategory.Cloud, Level = 2, Icon = "🏃‍♂️", Color = "#4285f4", YearsOfExperience = 2 },
                new Skill { Name = "Kubernetes", Category = SkillCategory.Cloud, Level = 2, Icon = "⚓", Color = "#326ce5", YearsOfExperience = 1 },
                new Skill { Name = "Docker", Category = SkillCategory.Cloud, Level = 5, Icon = "🐳", Color = "#2496ed", YearsOfExperience = 5 },
                new Skill { Name = "CI/CD", Category = SkillCategory.Cloud, Level = 5, Icon = "🔄", Color = "#28a745", YearsOfExperience = 4 },
                
                // Tools
                new Skill { Name = "Git", Category = SkillCategory.Tools, Level = 5, Icon = "📝", Color = "#f05032", YearsOfExperience = 8 },
                new Skill { Name = "Visual Studio", Category = SkillCategory.Tools, Level = 5, Icon = "💻", Color = "#5c2d91", YearsOfExperience = 7 },
                new Skill { Name = "VS Code", Category = SkillCategory.Tools, Level = 5, Icon = "📘", Color = "#007acc", YearsOfExperience = 5 },
                new Skill { Name = "Postman", Category = SkillCategory.Tools, Level = 4, Icon = "📮", Color = "#ff6c37", YearsOfExperience = 3 }
            };

            context.Skills.AddRange(skills);
            context.SaveChanges();

            // Seed Projects
            var projects = new Project[]
            {
                new Project
                {
                    Title = "This Portfolio Website",
                    Description = "After a long break, I finally decided to finish my portfolio. To gather old and new projects and show them to the world.",
                    LongDescription = "After a long break, I finally decided to finish my portfolio. To gather old and new projects and show them to the world. Built with the latest Angular 20 for the frontend and .NET 9 Web API for the backend, featuring server-side rendering for optimal performance and SEO.",
                    Technologies = new List<string> { "Angular 20", "TypeScript", ".NET 9", "PostgreSQL", "Docker", "Tailwind CSS" },
                    GithubUrl = "https://github.com/perfectmatthew/portfolio",
                    LiveUrl = "https://perfectmatthew.pl",
                    Category = ProjectCategory.WebApp,
                    Status = ProjectStatus.Completed,
                    StartDate = new DateTime(2025, 1, 15),
                    EndDate = new DateTime(2025, 11, 30),
                    Featured = true,
                    Achievements = new List<string>
                    {
                        "Implemented server-side rendering for improved SEO",
                        "Achieved 95+ Lighthouse performance score",
                        "Integrated with Google Analytics and contact form"
                    },
                    Challenges = new List<string>
                    {
                        "Optimizing performance for fast load times",
                        "Optimizing bundle size while maintaining rich functionality",
                        "Implementing smooth animations across different devices"
                    }
                },
                new Project
                {
                    Title = "DomekzWidokiem.pl",
                    Description = "Basic information website for a rental property in Poland.",
                    LongDescription = "Basic information website for a rental property in Poland. Written in PHP and WordPress, styled with Tailwind CSS to provide a modern and responsive design.",
                    Technologies = new List<string> { "PHP", "Tailwind CSS", "MySQL", "WordPress", "JavaScript" },
                    ImageUrl = "/assets/images/domekzwidokiem.png",
                    LiveUrl = "https://domekzwidokiem.pl",
                    Category = ProjectCategory.WebApp,
                    Status = ProjectStatus.Completed,
                    StartDate = new DateTime(2025, 10, 11),
                    EndDate = new DateTime(2025, 11, 15),
                    Featured = true,
                    Achievements = new List<string>
                    {
                        "Developed responsive design for optimal viewing on all devices",
                        "Implemented SEO best practices to enhance online visibility",
                        "Integrated with Google Analytics for traffic analysis"
                    },
                    Challenges = new List<string>
                    {
                        "Optimizing website speed on shared hosting",
                        "Implementing effective SEO strategies",
                        "Ensuring cross-browser compatibility"
                    }
                },
                new Project
                {
                    Title = "HelpDesk Web App",
                    Description = "Helpdesk application for managing tickets from different departments.",
                    LongDescription = "A helpdesk application designed to streamline ticket management across various departments, enhancing communication and resolution efficiency. This project was created for my engineering thesis.",
                    Technologies = new List<string> { "Spring Boot 2.7.0", "Java 17", "Thymeleaf", "TailwindCSS", "PostgreSQL", "JWT" },
                    GithubUrl = "https://github.com/perfectmathew/HelpDesk-App",
                    Category = ProjectCategory.WebApp,
                    Status = ProjectStatus.Completed,
                    StartDate = new DateTime(2022, 10, 22),
                    EndDate = new DateTime(2023, 4, 16),
                    Featured = false,
                    Achievements = new List<string>
                    {
                        "Successfully created ticketing system for multiple departments",
                        "Implemented role-based access control",
                        "Created comprehensive reporting dashboard"
                    },
                    Challenges = new List<string>
                    {
                        "First big project",
                        "Learning a new framework (Spring Boot)",
                        "Implementing authentication and authorization"
                    }
                },
                new Project
                {
                    Title = "Migrating Helpdesk App to GCP & AWS",
                    Description = "Automated cloud infrastructure deployment using Terraform, Jenkins, AWS and GCP",
                    LongDescription = "Complete migration project for my Master's thesis. I implemented infrastructure as code using Terraform to provision resources on GCP and AWS, set up CI/CD pipelines with Jenkins, and ensured high availability and scalability of the Helpdesk application in the cloud.",
                    Technologies = new List<string> { "Terraform", "GCP", "Cloud Run", "Cloud SQL", "Jenkins", "AWS" },
                    Category = ProjectCategory.Other,
                    Status = ProjectStatus.Completed,
                    StartDate = new DateTime(2024, 9, 1),
                    EndDate = new DateTime(2025, 1, 15),
                    Featured = false,
                    Achievements = new List<string>
                    {
                        "Automated infrastructure provisioning with Terraform",
                        "Implemented CI/CD pipelines using Jenkins",
                        "Working cross-cloud deployment strategies"
                    },
                    Challenges = new List<string>
                    {
                        "Optimizing performance for fast load times",
                        "Ensuring security and compliance across cloud providers",
                        "Managing cost efficiency in a multi-cloud environment"
                    }
                },
                new Project
                {
                    Title = "DreamMap",
                    Description = "The project allows users to create and save places they want to visit and events taking place there. It is designed for couples who have many ideas about where to spend their time together but have nowhere to write them down.",
                    LongDescription = "The project allows users to create and save places they want to visit and events taking place there. It is designed for couples who have many ideas about where to spend their time together but have nowhere to write them down. Built with Angular for the frontend and Spring Boot for the backend, featuring Google Maps integration for location selection.",
                    Technologies = new List<string> { "Angular 20", "TypeScript", "NodeJS", "Docker", "TailwindCSS", "Open Maps API" },
                    GithubUrl = "https://github.com/perfectmathew/dreammap",
                    Category = ProjectCategory.WebApp,
                    Status = ProjectStatus.InProgress,
                    StartDate = new DateTime(2025, 5, 1),
                    Featured = true,
                    Achievements = new List<string>
                    {
                        "First project for other people",
                        "Simple but useful functionality"
                    },
                    Challenges = new List<string>
                    {
                        "Integrating with mapping APIs"
                    }
                },
                new Project
                {
                    Title = "Wakmet website",
                    Description = "A WordPress-based website for my company where i work.",
                    LongDescription = "A WordPress-based website for my company where i work. The website provides information about the company's services, portfolio, and contact details. It is designed to be user-friendly and visually appealing, with a focus on showcasing the company's expertise in the industry.",
                    Technologies = new List<string> { "PHP", "WordPress", "JavaScript", "CSS", "MySQL", "WooCommerce", "Elementor" },
                    ImageUrl = "/assets/images/wakmet.png",
                    LiveUrl = "https://wakmet.com.pl",
                    Category = ProjectCategory.WebApp,
                    Status = ProjectStatus.Completed,
                    StartDate = new DateTime(2023, 6, 1),
                    EndDate = new DateTime(2023, 8, 15),
                    Featured = false,
                    Achievements = new List<string>
                    {
                        "Successfully launched the company website",
                        "Implemented e-commerce functionality with WooCommerce",
                        "Enhanced user experience with Elementor page builder"
                    },
                    Challenges = new List<string>
                    {
                        "Customizing WordPress themes to match company branding",
                        "Ensuring website security and performance optimization"
                    }
                }
            };

            context.Projects.AddRange(projects);
            context.SaveChanges();

            // Seed Experiences
            var experiences = new Experience[]
            {
                new Experience
                {
                    Company = "Tech Solutions Inc.",
                    Position = "Senior Full Stack Developer",
                    StartDate = new DateTime(2022, 6, 1),
                    Current = true,
                    Description = "Leading development of enterprise web applications using Angular and .NET Core. Responsible for architecture design, code reviews, and mentoring junior developers.",
                    Technologies = new List<string> { "Angular", ".NET Core", "PostgreSQL", "Azure", "Docker", "Kubernetes" },
                    Achievements = new List<string>
                    {
                        "Reduced application load time by 40% through optimization",
                        "Led migration from monolith to microservices architecture",
                        "Implemented CI/CD pipeline reducing deployment time by 60%",
                        "Mentored 5 junior developers"
                    },
                    Location = "Remote"
                },
                new Experience
                {
                    Company = "Digital Innovations Ltd.",
                    Position = "Full Stack Developer",
                    StartDate = new DateTime(2020, 3, 1),
                    EndDate = new DateTime(2022, 5, 31),
                    Current = false,
                    Description = "Developed and maintained multiple web applications for clients in various industries. Worked closely with UX/UI designers to implement responsive and accessible interfaces.",
                    Technologies = new List<string> { "Angular", "C#", "SQL Server", "Azure", "Git" },
                    Achievements = new List<string>
                    {
                        "Delivered 10+ successful client projects",
                        "Improved code quality through implementation of automated testing",
                        "Received 'Developer of the Year' award in 2021"
                    },
                    Location = "New York, NY"
                },
                new Experience
                {
                    Company = "StartupHub",
                    Position = "Junior Developer",
                    StartDate = new DateTime(2018, 9, 1),
                    EndDate = new DateTime(2020, 2, 28),
                    Current = false,
                    Description = "Started career as a junior developer working on various web development projects. Gained experience in full-stack development and agile methodologies.",
                    Technologies = new List<string> { "JavaScript", "Node.js", "React", "MongoDB", "Git" },
                    Achievements = new List<string>
                    {
                        "Contributed to 15+ feature releases",
                        "Completed advanced training in modern web technologies",
                        "Transitioned from frontend to full-stack development"
                    },
                    Location = "San Francisco, CA"
                }
            };

            context.Experiences.AddRange(experiences);
            context.SaveChanges();
        }
    }
}
