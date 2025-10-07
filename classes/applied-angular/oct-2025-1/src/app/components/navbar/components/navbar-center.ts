import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { NavbarLink } from '../types';
import { NavLink } from './navbar-link';

@Component({
  selector: 'app-navbar-center',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [NavLink],
  template: `
    <ul class="menu menu-horizontal px-1">
      @for (link of links(); track link.path) {
        <li>
          <app-navbar-link [link]="link" />
        </li>
      }
    </ul>
  `,
  styles: ``,
})
export class NavbarCenter {
  links = input.required<NavbarLink[]>();
}
