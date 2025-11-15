import { inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Project, ProjectCategory, ProjectStatus, ContactMessage } from '../models/Project.model';
import { Skill, SkillCategory, Experience } from '../models/Portfolio.model';

@Injectable({
  providedIn: 'root',
})
export class BackendService {
  private http = inject(HttpClient);
  private apiUrl = 'http://localhost:8081/api';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  // Projects endpoints
  getProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(`${this.apiUrl}/projects`);
  }

  getProject(id: number): Observable<Project> {
    return this.http.get<Project>(`${this.apiUrl}/projects/${id}`);
  }

  getFeaturedProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(`${this.apiUrl}/projects/featured`);
  }

  getProjectsByCategory(category: ProjectCategory): Observable<Project[]> {
    return this.http.get<Project[]>(`${this.apiUrl}/projects/category/${category}`);
  }

  getProjectsByStatus(status: ProjectStatus): Observable<Project[]> {
    return this.http.get<Project[]>(`${this.apiUrl}/projects/status/${status}`);
  }

  // Skills endpoints
  getSkills(): Observable<Skill[]> {
    return this.http.get<Skill[]>(`${this.apiUrl}/skills`);
  }

  getSkill(id: number): Observable<Skill> {
    return this.http.get<Skill>(`${this.apiUrl}/skills/${id}`);
  }

  getSkillsByCategory(category: SkillCategory): Observable<Skill[]> {
    return this.http.get<Skill[]>(`${this.apiUrl}/skills/category/${category}`);
  }

  // Experiences endpoints
  getExperiences(): Observable<Experience[]> {
    return this.http.get<Experience[]>(`${this.apiUrl}/experiences`);
  }

  getExperience(id: number): Observable<Experience> {
    return this.http.get<Experience>(`${this.apiUrl}/experiences/${id}`);
  }

  getCurrentExperiences(): Observable<Experience[]> {
    return this.http.get<Experience[]>(`${this.apiUrl}/experiences/current`);
  }

  // Contact endpoint
  sendContactMessage(message: ContactMessage): Observable<any> {
    return this.http.post(`${this.apiUrl}/contact`, message, this.httpOptions);
  }

  getContactMessages(): Observable<ContactMessage[]> {
    return this.http.get<ContactMessage[]>(`${this.apiUrl}/contact`);
  }
}
