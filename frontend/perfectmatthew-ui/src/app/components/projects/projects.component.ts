import { Component, inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Project, ProjectCategory, ProjectStatus } from '../../models/Project.model';
import { BackendService } from '../../services/backend';

@Component({
  selector: 'app-projects',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './projects.component.html',
  styleUrl: './projects.component.scss'
})
export class ProjectsComponent implements OnInit {
  projects = signal<Project[]>([]);
  filteredProjects = signal<Project[]>([]);
  selectedCategory = signal<ProjectCategory | 'ALL'>('ALL');
  isLoading = signal(true);
  error = signal<string | null>(null);

  projectCategories = Object.values(ProjectCategory);
  private backendService = inject(BackendService);

  ngOnInit() {
    this.loadProjects();
  }

  loadProjects() {
    this.isLoading.set(true);
    this.error.set(null);

    this.backendService.getProjects().subscribe({
      next: (projects) => {
        this.projects.set(projects);
        this.filteredProjects.set(projects);
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error loading projects:', err);
        this.error.set('Failed to load projects. Please try again later.');
        this.isLoading.set(false);
        // Fallback to local data if API fails
        this.loadFallbackProjects();
      }
    });
  }

  loadFallbackProjects() {
    const fallbackProjects: Project[] = [
    {
      id: 1,
      title: 'This Portfolio Website',
      description: 'After a long break, I finally decided to finish my portfolio. To gather old and new projects and show them to the world.',
      longDescription: 'After a long break, I finally decided to finish my portfolio. To gather old and new projects and show them to the world. Built with the latest Angular 20 for the frontend and .NET 9 Web API for the backend, featuring server-side rendering for optimal performance and SEO.',
      technologies: ['Angular 20', 'TypeScript', '.NET 9', 'PostgreSQL', 'Docker', 'Tailwind CSS'],
      githubUrl: 'https://github.com/perfectmatthew/portfolio',
      liveUrl: 'https://perfectmatthew.pl',
      category: ProjectCategory.WEB_APP,
      status: ProjectStatus.COMPLETED,
      startDate: new Date('2025-01-15'),
      endDate: new Date('2025-11-30'),
      featured: true,
      achievements: [
        'Implemented server-side rendering for improved SEO',
        'Achieved 95+ Lighthouse performance score',
        'Integrated with Google Analytics and contact form'
      ],
      challenges: [
        'Optimizing performance for fast load times',
        'Optimizing bundle size while maintaining rich functionality',
        'Implementing smooth animations across different devices'
      ]
    },
    {
      id: 2,
      title: 'DomekzWidokiem.pl',
      description: 'Basic information website for a rental property in Poland.',
      longDescription: 'Basic information website for a rental property in Poland. Written in PHP and WordPress, styled with Tailwind CSS to provide a modern and responsive design.',
      technologies: ['PHP', 'Tailwind CSS', 'MySQL', 'WordPress', 'JavaScript'],
      imageUrl: '/assets/images/domekzwidokiem.png',
      liveUrl: 'https://domekzwidokiem.pl',
      category: ProjectCategory.WEB_APP,
      status: ProjectStatus.COMPLETED,
      startDate: new Date('2025-10-11'),
      endDate: new Date('2025-11-15'),
      featured: true,
      achievements: [
        'Developed responsive design for optimal viewing on all devices',
        'Implemented SEO best practices to enhance online visibility',
        'Integrated with Google Analytics for traffic analysis'
      ],
      challenges: [
        'Optimizing website speed on shared hosting',
        'Implementing effective SEO strategies',
        'Ensuring cross-browser compatibility'
      ]
    },
    {
      id: 3,
      title: 'HelpDesk Web App',
      description: 'Helpdesk application for managing tickets from different departments.',
      longDescription: 'A helpdesk application designed to streamline ticket management across various departments, enhancing communication and resolution efficiency. This project was created for my engineering thesis.',
      technologies: ['Spring Boot 2.7.0', 'Java 17', 'Thymeleaf', 'TailwindCSS', 'PostgreSQL', 'JWT'],
      githubUrl: 'https://github.com/perfectmathew/HelpDesk-App',
      category: ProjectCategory.WEB_APP,
      status: ProjectStatus.COMPLETED,
      startDate: new Date('2022-10-22'),
      endDate: new Date('2023-04-16'),
      featured: false,
      achievements: [
        '',
        '',
        ''
      ],
        challenges: [
            'First big project',
            'learning a new framework (Spring Boot)',
            'implementing authentication and authorization'
      ]
    },
    {
      id: 4,
      title: 'Migrating Helpdesk App to GPC & AWS',
      description: 'Automated cloud infrastructure deployment using Terraform, Jenkins, AWS and GCP',
      longDescription: 'Complete migration project for my Master\'s thesis. I implemented infrastructure as code using Terraform to provision resources on GCP and AWS, set up CI/CD pipelines with Jenkins, and ensured high availability and scalability of the Helpdesk application in the cloud.',
      technologies: ['Terraform', 'GCP', 'Cloud Run', 'Cloud SQL', 'Jenkins', 'AWS'],
      category: ProjectCategory.OTHER,
      status: ProjectStatus.COMPLETED,
      startDate: new Date('2024-09-01'),
      endDate: new Date('2025-01-15'),
      featured: false,
      achievements: [
        'Automated infrastructure provisioning with Terraform',
        'Implemented CI/CD pipelines using Jenkins',
        'Working cross-cloud deployment strategies'
      ],
      challenges: [
            'Optimizing performance for fast load times',
            'Ensuring security and compliance across cloud providers',
            'Managing cost efficiency in a multi-cloud environment'
      ]
    },
    {
      id: 5,
      title: 'DreamMap',
      description: 'The project allows users to create and save places they want to visit and events taking place there. It is designed for couples who have many ideas about where to spend their time together but have nowhere to write them down.',
      longDescription: 'The project allows users to create and save places they want to visit and events taking place there. It is designed for couples who have many ideas about where to spend their time together but have nowhere to write them down. Built with Angular for the frontend and Spring Boot for the backend, featuring Google Maps integration for location selection.',
      technologies: ['Angular 20', 'TypeScript', 'NodeJS', 'Docker', 'TailwindCSS', 'Open Maps API'],
      githubUrl: 'https://github.com/perfectmathew/dreammap',
      category: ProjectCategory.WEB_APP,
      status: ProjectStatus.IN_PROGRESS,
      startDate: new Date('2025-05-01'),
      featured: true,
      achievements: [
        'First project for other people',
        'Simple but useful functionality',
      ],
      challenges: [
        'Integrating with mapping APIs'
      ]
    },
    {
      id: 6,
      title: 'Wakmet website',
      description: 'A WordPress-based website for my company where i work.',
      longDescription: 'A WordPress-based website for my company where i work. The website provides information about the company\'s services, portfolio, and contact details. It is designed to be user-friendly and visually appealing, with a focus on showcasing the company\'s expertise in the industry.',
      technologies: ['PHP', 'WordPress', 'JavaScript', 'CSS', 'MySQL', 'WooCommerce', 'Elementor'],
      imageUrl: '/assets/images/wakmet.png',
      liveUrl: 'https://wakmet.com.pl',
      category: ProjectCategory.WEB_APP,
      status: ProjectStatus.COMPLETED,
      startDate: new Date('2023-06-01'),
      endDate: new Date('2023-08-15'),
      featured: false,
      achievements: [
        'Successfully launched the company website',
        'Implemented e-commerce functionality with WooCommerce',
        'Enhanced user experience with Elementor page builder'
      ],
      challenges: [
        'Customizing WordPress themes to match company branding',
        'Ensuring website security and performance optimization'
      ]
    }
    ];
    this.projects.set(fallbackProjects);
    this.filteredProjects.set(fallbackProjects);
  }

  filterProjects(category: ProjectCategory | 'ALL') {
    this.selectedCategory.set(category);
    if (category === 'ALL') {
      this.filteredProjects.set(this.projects());
    } else {
      this.filteredProjects.set(this.projects().filter(project => project.category === category));
    }
  }

  getFeaturedProjects(): Project[] {
    return this.projects().filter(project => project.featured);
  }

  openProject(url: string) {
    if (url) {
      window.open(url, '_blank');
    }
  }

  getCategoryDisplayName(category: ProjectCategory): string {
    const displayNames: Record<ProjectCategory, string> = {
      [ProjectCategory.WEB_APP]: 'Web Application',
      [ProjectCategory.MOBILE_APP]: 'Mobile Application',
      [ProjectCategory.API]: 'API/Backend',
      [ProjectCategory.DESKTOP_APP]: 'Desktop Application',
      [ProjectCategory.LIBRARY]: 'Library/Framework',
      [ProjectCategory.OTHER]: 'Other'
    };
    return displayNames[category];
  }

  getStatusDisplayName(status: ProjectStatus): string {
    const displayNames: Record<ProjectStatus, string> = {
      [ProjectStatus.COMPLETED]: 'Completed',
      [ProjectStatus.IN_PROGRESS]: 'In Progress',
      [ProjectStatus.ON_HOLD]: 'On Hold',
      [ProjectStatus.PLANNING]: 'Planning'
    };
    return displayNames[status];
  }
}