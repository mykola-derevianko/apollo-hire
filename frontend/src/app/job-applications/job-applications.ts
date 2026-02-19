import { Component, inject, computed, signal } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { JobApplicationService } from './data/job-application-service';
import { JobApplicationsTable } from "./job-applications-table/job-applications-table";
import { SiFileIcon, SiPlusIcon, SiSearchIcon, SiMinusIcon } from "@semantic-icons/tabler-icons/outline";
@Component({
  selector: 'job-applications',
  imports: [JobApplicationsTable, SiFileIcon, SiPlusIcon, SiSearchIcon, SiMinusIcon],
  templateUrl: './job-applications.html',
})
export class JobApplications {

  private readonly authService = inject(AuthService);
  private readonly jobApplicationService = inject(JobApplicationService);

  applications = computed(() => this.jobApplicationService.data());
  total = computed(() => this.jobApplicationService.data()?.totalCount ?? 0);
  currentPage = computed(() => this.jobApplicationService.page());
  currentPageSize = computed(() => this.jobApplicationService.pageSize());

  loading = this.jobApplicationService.isLoading; 
  isAddModalOpen = signal(false);

  onSort($event: string) {
    throw new Error('Method not implemented.');
  }

  onSearch(query: string) {
    this.jobApplicationService.search(query);
  }

  onPageSizeChange(pageSize: number) {
    this.jobApplicationService.setPageSize(pageSize);
  }
  
  onPageChange($event: number) {
    this.jobApplicationService.setPage($event);
  }

  openAddModal() {
    this.isAddModalOpen.set(true);
  }

  closeAddModal() {
    this.isAddModalOpen.set(false);
  }

  logout() {
    this.authService.logout({ logoutParams: { returnTo: window.location.origin } });
  }
}
