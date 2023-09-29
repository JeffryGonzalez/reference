import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-heading',
  standalone: true,
  imports: [CommonModule],
  template: `
       <header class="prose-xl bg-slate-500  border-black border-2 p-4 mb-8">
      <h1 class="text-center font-black uppercase">Super Angular App</h1>
    </header>
  `,
  styles: [
  ]
})
export class HeadingComponent {

}
