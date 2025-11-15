import { Component, inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Skill, SkillCategory } from '../../models/Portfolio.model';
import { BackendService } from '../../services/backend';

@Component({
  selector: 'app-skills',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './skills.component.html',
  styleUrl: './skills.component.scss'
})
export class SkillsComponent implements OnInit {
  skills = signal<Skill[]>([]);
  selectedCategory = signal<SkillCategory | 'ALL'>('ALL');
  isLoading = signal(true);
  error = signal<string | null>(null);

  skillCategories = Object.values(SkillCategory);
  private backendService = inject(BackendService);

  ngOnInit() {
    this.loadSkills();
  }

  loadSkills() {
    this.isLoading.set(true);
    this.error.set(null);

    this.backendService.getSkills().subscribe({
      next: (skills) => {
        this.skills.set(skills);
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error loading skills:', err);
        this.error.set('Failed to load skills. Please try again later.');
        this.isLoading.set(false);
        // Fallback to local data if API fails
        this.loadFallbackSkills();
      }
    });
  }

  loadFallbackSkills() {
    const fallbackSkills: Skill[] = [
    // Frontend
    { id: 1, name: 'Angular', category: SkillCategory.FRONTEND, level: 3, icon: '🅰️', color: '#dd1b16', yearsOfExperience: 2 },
    { id: 2, name: 'TypeScript', category: SkillCategory.FRONTEND, level: 4, icon: '🔷', color: '#3178c6', yearsOfExperience: 3 },
    { id: 3, name: 'JavaScript', category: SkillCategory.FRONTEND, level: 3, icon: '🟨', color: '#f7df1e', yearsOfExperience: 5 },
    { id: 4, name: 'HTML5', category: SkillCategory.FRONTEND, level: 5, icon: '🌐', color: '#e34f26', yearsOfExperience: 10 },
    { id: 5, name: 'CSS3/SCSS', category: SkillCategory.FRONTEND, level: 5, icon: '🎨', color: '#1572b6', yearsOfExperience: 10 },
    { id: 6, name: 'Tailwind CSS', category: SkillCategory.FRONTEND, level: 5, icon: '💨', color: '#06b6d4', yearsOfExperience: 5 },
    
    // Backend
    { id: 7, name: 'C#', category: SkillCategory.BACKEND, level: 5, icon: '#️⃣', color: '#239120', yearsOfExperience: 6 },
    { id: 8, name: '.NET Core', category: SkillCategory.BACKEND, level: 5, icon: '⚙️', color: '#512bd4', yearsOfExperience: 6 },
    { id: 9, name: 'ASP.NET Web API', category: SkillCategory.BACKEND, level: 5, icon: '🔧', color: '#512bd4', yearsOfExperience: 5 },
    { id: 10, name: 'Blazor', category: SkillCategory.BACKEND, level: 4, icon: '🔥', color: '#512bd4', yearsOfExperience: 2 },
    { id: 11, name: 'Entity Framework', category: SkillCategory.BACKEND, level: 5, icon: '📊', color: '#512bd4', yearsOfExperience: 5 },
    
    // Database
    { id: 12, name: 'PostgreSQL', category: SkillCategory.DATABASE, level: 4, icon: '🐘', color: '#336791', yearsOfExperience: 6 },
    { id: 13, name: 'SQL Server', category: SkillCategory.DATABASE, level: 5, icon: '🗄️', color: '#cc2927', yearsOfExperience: 7 },
    
    // Cloud & DevOps
    { id: 15, name: 'Google Cloud Platform', category: SkillCategory.CLOUD, level: 3, icon: '☁️', color: '#A285f4', yearsOfExperience: 2 },
    { id: 16, name: 'Cloud Run', category: SkillCategory.CLOUD, level: 2, icon: '🏃‍♂️', color: '#4285f4', yearsOfExperience: 2 },
    { id: 17, name: 'Kubernetes', category: SkillCategory.CLOUD, level: 2, icon: '⚓', color: '#326ce5', yearsOfExperience: 1 },
    { id: 18, name: 'Docker', category: SkillCategory.CLOUD, level: 5, icon: '🐳', color: '#2496ed', yearsOfExperience: 5 },
    { id: 19, name: 'CI/CD', category: SkillCategory.CLOUD, level: 5, icon: '🔄', color: '#28a745', yearsOfExperience: 4 },
    
    // Tools
    { id: 20, name: 'Git', category: SkillCategory.TOOLS, level: 5, icon: '📝', color: '#f05032', yearsOfExperience: 8 },
    { id: 21, name: 'Visual Studio', category: SkillCategory.TOOLS, level: 5, icon: '💻', color: '#5c2d91', yearsOfExperience: 7 },
    { id: 22, name: 'VS Code', category: SkillCategory.TOOLS, level: 5, icon: '📘', color: '#007acc', yearsOfExperience: 5 },
    { id: 23, name: 'Postman', category: SkillCategory.TOOLS, level: 4, icon: '📮', color: '#ff6c37', yearsOfExperience: 3 }
    ];
    this.skills.set(fallbackSkills);
  }

  getSkillsByCategory(category: SkillCategory | 'ALL'): Skill[] {
    if (category === 'ALL') {
      return this.skills();
    }
    return this.skills().filter(skill => skill.category === category);
  }

  selectCategory(category: SkillCategory | 'ALL') {
    this.selectedCategory.set(category);
  }

  getStars(level: number): number[] {
    return Array(5).fill(0).map((x, i) => i < level ? 1 : 0);
  }

  getCategoryDisplayName(category: SkillCategory): string {
    const displayNames: Record<SkillCategory, string> = {
      [SkillCategory.FRONTEND]: 'Frontend',
      [SkillCategory.BACKEND]: 'Backend',
      [SkillCategory.DATABASE]: 'Database',
      [SkillCategory.CLOUD]: 'Cloud & DevOps',
      [SkillCategory.TOOLS]: 'Tools & Others'
    };
    return displayNames[category];
  }
}