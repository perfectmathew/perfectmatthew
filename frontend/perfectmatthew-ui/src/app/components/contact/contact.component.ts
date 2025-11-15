import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BackendService } from '../../services/backend';
import { ContactMessage } from '../../models/Project.model';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.scss'
})
export class ContactComponent {
  name = signal('');
  email = signal('');
  subject = signal('');
  message = signal('');
  
  isSubmitting = signal(false);
  submitSuccess = signal(false);
  submitError = signal('');

  constructor(private backendService: BackendService) {}

  onSubmit() {
    // Reset status
    this.submitSuccess.set(false);
    this.submitError.set('');

    // Validate
    if (!this.name() || !this.email() || !this.message()) {
      this.submitError.set('Please fill in all required fields');
      return;
    }

    // Email validation
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(this.email())) {
      this.submitError.set('Please enter a valid email address');
      return;
    }

    this.isSubmitting.set(true);

    const contactMessage: ContactMessage = {
      name: this.name(),
      email: this.email(),
      subject: this.subject() || undefined,
      message: this.message()
    };

    this.backendService.sendContactMessage(contactMessage).subscribe({
      next: (response) => {
        this.submitSuccess.set(true);
        this.isSubmitting.set(false);
        // Reset form
        this.name.set('');
        this.email.set('');
        this.subject.set('');
        this.message.set('');
        
        // Clear success message after 5 seconds
        setTimeout(() => this.submitSuccess.set(false), 5000);
      },
      error: (error) => {
        this.isSubmitting.set(false);
        this.submitError.set(error.error?.error || 'Failed to send message. Please try again.');
        console.error('Error sending contact message:', error);
      }
    });
  }
}
