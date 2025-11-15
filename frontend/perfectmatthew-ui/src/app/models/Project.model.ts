export interface Project {
  id: number;
  title: string;
  description: string;
  longDescription?: string;
  technologies: string[];
  imageUrl?: string;
  githubUrl?: string;
  liveUrl?: string;
  category: ProjectCategory;
  status: ProjectStatus;
  startDate: Date;
  endDate?: Date;
  featured: boolean;
  achievements?: string[];
  challenges?: string[];
}

export enum ProjectCategory {
  WEB_APP = 'WebApp',
  MOBILE_APP = 'MobileApp',
  API = 'Api',
  DESKTOP_APP = 'DesktopApp',
  LIBRARY = 'Library',
  OTHER = 'Other'
}

export enum ProjectStatus {
  COMPLETED = 'Completed',
  IN_PROGRESS = 'InProgress',
  ON_HOLD = 'OnHold',
  PLANNING = 'Planning'
}

export interface ContactMessage {
  name: string;
  email: string;
  subject?: string;
  message: string;
  createdAt?: Date;
}