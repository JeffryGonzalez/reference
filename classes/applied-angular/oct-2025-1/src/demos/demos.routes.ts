import { Routes } from '@angular/router';
import { Demos } from './demos';
import { Signals } from './pages/signals';
export const DEMO_ROUTES: Routes = [
  {
    path: '',
    component: Demos,
    children: [
      {
        path: 'signals',
        component: Signals,
      },
    ],
  },
];
