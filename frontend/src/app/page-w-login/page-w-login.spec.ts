import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageWLogin } from './page-w-login';

describe('PageWLogin', () => {
  let component: PageWLogin;
  let fixture: ComponentFixture<PageWLogin>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PageWLogin]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageWLogin);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
