import { Component, OnInit, OnDestroy, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-hero',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './hero.component.html',
  styleUrl: './hero.component.scss'
})
export class HeroComponent implements OnInit, OnDestroy {
  
  currentRole = signal('');
  
  private readonly roles = [
    'Full Stack Developer',
    '.NET Developer', 
    'Angular Developer',
    'Cloud Engineer',
    'DevOps Engineer'
  ];
  
  private roleIndex = 0;
  private charIndex = 0;
  private isDeleting = false;
  private typeSpeed = 100;
  private deleteSpeed = 50;
  private delayBetweenRoles = 2000; // 2 seconds pause after completing a role
  private timeoutId?: number;

  ngOnInit() {
    this.typeRole();
  }

  ngOnDestroy() {
    if (this.timeoutId) {
      clearTimeout(this.timeoutId);
    }
  }

  private typeRole() {
    const currentRoleText = this.roles[this.roleIndex];
    
    if (!this.isDeleting) {
      // Typing forward
      this.currentRole.set(currentRoleText.substring(0, this.charIndex + 1));
      this.charIndex++;
      
      if (this.charIndex === currentRoleText.length) {
        // Finished typing, wait before deleting
        this.isDeleting = true;
        this.timeoutId = window.setTimeout(() => this.typeRole(), this.delayBetweenRoles);
        return;
      }
    } else {
      // Deleting backward
      this.currentRole.set(currentRoleText.substring(0, this.charIndex - 1));
      this.charIndex--;
      
      if (this.charIndex === 0) {
        // Finished deleting, move to next role
        this.isDeleting = false;
        this.roleIndex = (this.roleIndex + 1) % this.roles.length;
      }
    }
    
    const speed = this.isDeleting ? this.deleteSpeed : this.typeSpeed;
    this.timeoutId = window.setTimeout(() => this.typeRole(), speed);
  }

  downloadCV() {
    // Implement CV download functionality
    console.log('Downloading CV...');
  }

  scrollToProjects() {
    const element = document.querySelector('#projects');
    if (element) {
      element.scrollIntoView({ behavior: 'smooth' });
    }
  }
}