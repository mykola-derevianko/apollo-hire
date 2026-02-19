import { Routes } from '@angular/router';
import { JobApplications } from './job-applications/job-applications';
import { authGuardFn } from '@auth0/auth0-angular';
import { PageWLogin } from './page-w-login/page-w-login';

export const routes: Routes = [
    {
        path: 'dashboard',
        component: JobApplications,
        canActivate: [authGuardFn]
    },
    {
        path: '',
        pathMatch: 'full',
        redirectTo: 'dashboard'
    },
    {
        path: 'login',
        component: PageWLogin,
    },
];
