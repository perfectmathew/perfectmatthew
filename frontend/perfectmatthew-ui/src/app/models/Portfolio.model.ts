export interface Skill {
  id: number;
  name: string;
  category: SkillCategory;
  level: number; // 1-5 scale
  icon: string;
  color: string;
  yearsOfExperience: number;
}

export enum SkillCategory {
  FRONTEND = 'Frontend',
  BACKEND = 'Backend',
  DATABASE = 'Database',
  CLOUD = 'Cloud',
  TOOLS = 'Tools'
}

export interface Experience {
  id: number;
  company: string;
  position: string;
  startDate: Date;
  endDate?: Date;
  current: boolean;
  description: string;
  technologies: string[];
  achievements: string[];
  location: string;
  companyLogo?: string;
}

export interface Education {
  id: number;
  institution: string;
  degree: string;
  field: string;
  startDate: Date;
  endDate: Date;
  gpa?: number;
  description?: string;
  achievements?: string[];
}

export interface Certificate {
  id: number;
  name: string;
  issuer: string;
  dateIssued: Date;
  expiryDate?: Date;
  credentialId?: string;
  credentialUrl?: string;
  logoUrl?: string;
}