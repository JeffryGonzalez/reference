import { Component, ChangeDetectionStrategy, input } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { NavbarLink } from '../types';

@Component({
  selector: 'app-navbar-link',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [RouterLink, RouterLinkActive],
  template: `
    <a
      [routerLink]="link().path"
      #rla="routerLinkActive"
      [class.opacity-60]="rla.isActive === false"
      [routerLinkActive]="['underline', 'uppercase', 'font-bold']"
      >{{ link().label }}</a
    >
  `,
  styles: ``,
})
export class NavLink {
  link = input.required<NavbarLink>();
}
