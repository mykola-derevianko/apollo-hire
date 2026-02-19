import { ApplicationStatus } from "./application-status";
import { WorkType } from "./work-type";

export interface JobApplicationResponseDto {
  id: string;
  userId: string;
  companyName: string;
  jobTitle: string;
  location: string;
  workType: WorkType;
  status: ApplicationStatus;
  source: string;
  sourceUrl?: string | null;
  appliedDate?: string | null;
  notes?: string | null;
  isArchived: boolean;
  createdAt: string;
  updatedAt: string;
  eventCount: number;
}
