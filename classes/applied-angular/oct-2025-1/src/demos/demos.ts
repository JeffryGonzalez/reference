import { Component, ChangeDetectionStrategy } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-demos',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [RouterOutlet, RouterLink],
  template: `
    <p>Demos Coming Soon</p>
    <div class="flex flex-row gap-4 p-8">
      <a class="link" routerLink="signals">Signals</a>
    </div>

    <router-outlet />
  `,
  styles: ``,
})
export class Demos {}
