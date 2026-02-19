import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobApplicationsTable } from './job-applications-table';

describe('JobApplicationsTable', () => {
  let component: JobApplicationsTable;
  let fixture: ComponentFixture<JobApplicationsTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JobApplicationsTable]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JobApplicationsTable);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
