import { httpResource } from '@angular/common/http';
import { computed, effect, Injectable, signal } from '@angular/core';
import { debounceSignal } from '../../utils/debounce-signal';
import { PagedResponseDto } from '../models/paged-response-dto';
import { environment } from '../../../environments/environment.development';
import { JobApplicationResponseDto } from '../models/job-application-response-dto';

@Injectable({
  providedIn: 'root',
})
export class JobApplicationService {

  private readonly _searchInput = signal('');
  private readonly _debouncedSearch = debounceSignal(this._searchInput, 400);

  private _query = signal({
    search: "",
    sortColumn: 'AppliedDate',
    sortDirection: 'ASC',
    pageIndex: 0,
    pageSize: 10
  });

  constructor() {
    effect(() => {
      const search = this._debouncedSearch() ?? '';
      this._query.update(query => ({ ...query, search, pageIndex: 0 }));
    });
  }

  readonly dataResource = httpResource<PagedResponseDto<JobApplicationResponseDto>>(() => ({
    url: environment.api_url + '/application',
    method: 'GET',
    params: this._query()
  }));

  data = computed(() => this.dataResource.value() ?? null);
  page = computed(() => this._query().pageIndex);
  pageSize = computed(() => this._query().pageSize);
  isLoading = this.dataResource.isLoading;

  search(searchQuery: string) {
    this._searchInput.set(searchQuery);
  }

  setPage(pageIndex: number) {
    this._query.update(query => ({ ...query, pageIndex }));
  }

  setPageSize(pageSize: number) {
    this._query.update(query => ({ ...query, pageSize, pageIndex: 0 }));
  }
}
