import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HeadingComponent } from './components/heading/heading.component';
import { ButtonDirective } from './directives/button.directive';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, HeadingComponent, ButtonDirective],
  template: `
  <app-heading />
  <main class="container mx-auto">
    <p>Hello</p>
   
  </main>
  `,
  styles: [],
})
export class AppComponent {
  title = 'ngapp';
}
