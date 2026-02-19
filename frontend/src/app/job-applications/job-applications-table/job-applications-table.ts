import { Component, input, output, computed } from '@angular/core';
import { DatePipe, NgClass} from '@angular/common';

import { SiCalendarWeekIcon, SiSquareLetterTIcon, SiBuildingEstateIcon, SiMapPinIcon, SiMenu2Icon, SiBriefcase2Icon, SiChevronRightIcon, SiChevronLeftPipeIcon, SiChevronRightPipeIcon, SiChevronLeftIcon } from '@semantic-icons/tabler-icons/outline';

import { ApplicationStatus } from '../models/application-status';
import { JobApplicationResponseDto } from '../models/job-application-response-dto';
import { PagedResponseDto } from '../models/paged-response-dto';

@Component({
  selector: 'job-applications-table',
  imports: [
    DatePipe,
    NgClass,
    SiBriefcase2Icon,
    SiMenu2Icon,
    SiCalendarWeekIcon,
    SiSquareLetterTIcon,
    SiMapPinIcon,
    SiBuildingEstateIcon,
    SiChevronRightIcon,
    SiChevronLeftPipeIcon,
    SiChevronRightPipeIcon,
    SiChevronLeftIcon
],
  templateUrl: './job-applications-table.html',
})
export class JobApplicationsTable { 
  search = output<string>();
  sort = output<string>();
  pageChange = output<number>();
  pageSize = output<number>();

  data = input<PagedResponseDto<JobApplicationResponseDto>>();
  loading = input<boolean>(false);
  total = input<number>(0);
  currentPageSize = input<number>(10);
  currentPage = input<number>(0);

  pages = computed(() => Math.ceil(this.total() / this.currentPageSize()));


  statusClasses: Record<ApplicationStatus, string> = {
    [ApplicationStatus.Applied]: 'bg-blue-100 text-blue-800',
    [ApplicationStatus.Interview]: 'bg-yellow-100 text-yellow-800',
    [ApplicationStatus.Offer]: 'bg-green-100 text-green-800',
    [ApplicationStatus.Rejected]: 'bg-red-100 text-red-800',
  };

  onSearch(event: Event) {
    this.search.emit((event.target as HTMLInputElement).value || '');
  }

  onSort(sort: string) {
    this.sort.emit(sort);
  }

  onPageChange(page: number) {
    this.pageChange.emit(page);
  }

  onPageSizeChange(pageSize: number) {
    this.pageSize.emit(Number(pageSize));
  }

}
