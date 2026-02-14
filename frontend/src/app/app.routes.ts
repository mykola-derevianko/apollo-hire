import { Routes } from '@angular/router';
import { Dashboard } from './dashboard/dashboard';
import { authGuardFn } from '@auth0/auth0-angular';
import { PageWLogin } from './page-w-login/page-w-login';

export const routes: Routes = [
    {
        path: 'dashboard',
        component: Dashboard,
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
