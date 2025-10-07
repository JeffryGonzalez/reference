import { ChangeDetectionStrategy, Component, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { NavbarCenter } from './components/navbar-center';
import { NavbarSide } from './components/navbar-side';
import { NavbarLink } from './types';
import { NavbarHamburger } from './components/navbar-hamburger';

@Component({
  selector: 'app-nav-bar',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [RouterLink, NavbarCenter, NavbarSide, NavbarHamburger],
  template: `
    <div class="navbar bg-base-100 shadow-sm">
      <div class="navbar-start">
        <div class="dropdown">
          <div tabindex="0" role="button" class="btn btn-ghost lg:hidden">
            <app-navbar-hamburger-menu />
          </div>
          <app-navbar-side [links]="links()" />
        </div>
        <a routerLink="/" class="btn btn-ghost text-xl">Applied Angular</a>
      </div>
      <div class="navbar-center hidden lg:flex">
        <app-navbar-center [links]="links()" />
      </div>
      <div class="navbar-end">
        <a class="btn">Button</a>
      </div>
    </div>
  `,
  styles: ``,
})
export class Navbar {
  links = signal<NavbarLink[]>([
    {
      label: 'Dashboard',
      path: '/dashboard',
    },
    {
      label: 'Demos',
      path: '/demos',
    },
    {
      label: 'Support',
      path: '/support',
    },
  ]);
}
