import { Component, ChangeDetectionStrategy, signal } from '@angular/core';

@Component({
  selector: 'app-support-page',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: `
    <p>Support Information Coming Soon</p>
    <div>
      <span>{{ current() }}</span>
      <button (click)="increment()" class="btn btn-primary">+</button>
    </div>
  `,
  styles: ``,
})
export class Support {
  current = signal(0);
  increment() {
    this.current.update((c) => c + 1);
  }
}
