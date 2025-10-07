import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { NavbarLink } from '../types';
import { NavLink } from './navbar-link';

@Component({
  selector: 'app-navbar-side',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [NavLink],
  template: `
    <ul
      tabindex="0"
      class="menu menu-sm dropdown-content bg-base-100 rounded-box z-1 mt-3 w-52 p-2 shadow"
    >
      @for (link of links(); track link.path) {
        <li>
          <app-navbar-link [link]="link" />
        </li>
      }
    </ul>
  `,
  styles: ``,
})
export class NavbarSide {
  links = input.required<NavbarLink[]>();
}
