import { Routes } from '@angular/router';
import { Dashboard } from './pages/dashboard';
import { Support } from './pages/support';

export const routes: Routes = [
  {
    path: 'dashboard',
    component: Dashboard,
  },
  {
    path: 'support',
    component: Support,
  },
  {
    path: 'demos',
    loadChildren: () =>
      import('../demos/demos.routes').then((r) => r.DEMO_ROUTES),
    // This will put EVERYTHING in the demos folder into a new "chunk" - separate javascript file to be downloaded.
    // By default it is "lazy loaded" - loaded on demand. I don't really like that usually, so I'll show you how to change it.
  },
  {
    path: '**',
    redirectTo: 'dashboard',
  },
];
