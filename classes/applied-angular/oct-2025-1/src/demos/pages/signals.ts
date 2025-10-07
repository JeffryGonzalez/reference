import {
  Component,
  ChangeDetectionStrategy,
  signal,
  computed,
} from '@angular/core';

@Component({
  selector: 'app-demos-signals',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: `
    <p>Golf Score</p>

    @if (parSet() === false) {
      <div class="join">
        <button (click)="par.set(3)" class="join-item btn btn-sm ">3</button>
        <button (click)="par.set(4)" class="join-item btn btn-sm ">4</button>
        <button (click)="par.set(5)" class="join-item btn btn-sm ">5</button>
      </div>
    } @else {
      <div>
        <div>
          Strokes: <span>{{ strokeCount() }}</span> (Par {{ par() }})
        </div>

        <button (click)="addStroke()" class="btn btn-primary btn-circle">
          +
        </button>
      </div>
      <div>
        @switch (rating()) {
          @case ('') {
            <span>No rating</span>
          }
          @case ('Par') {
            <span class="badge badge-lg badge-primary">Par</span>
          }
          @case ('Birdie') {
            <span class="badge badge-lg badge-secondary">Birdie</span>
          }
          @case ('Eagle') {
            <span class="badge badge-lg badge-accent">Eagle</span>
          }
          @case ('Bogey') {
            <span class="badge badge-lg badge-info">Bogey</span>
          }
          @case ('Double Bogey') {
            <span class="badge badge-lg badge-success">Double Bogey</span>
          }
          @case ('Albatross') {
            <span class="badge badge-lg badge-warning">Albatross</span>
          }
          @case ('Ouch') {
            <span class="badge badge-lg badge-error"
              >Head To the Clubhouse.
            </span>
          }
        }
      </div>
      <div>
        <button (click)="reset()" class="btn btn-warning">Reset</button>
      </div>
    }
  `,
  styles: ``,
})
export class Signals {
  par = signal<3 | 4 | 5 | null>(null);

  parSet = computed(() => this.par() !== null);

  strokeCount = signal(0);

  atZero = computed(() => {
    return this.strokeCount() === 0;
  });
  addStroke() {
    // this.strokeCount.set(this.strokeCount() + 1);
    this.strokeCount.update((oldCount) => oldCount + 1);
  }
  reset() {
    this.strokeCount.set(0);
    this.par.set(null);
  }
  rating = computed(() => {
    const par = this.par();
    const strokes = this.strokeCount();

    if (par === null) {
      return '';
    }

    const diff = strokes - par;

    if (diff === 0) {
      return 'Par';
    } else if (diff === -1) {
      return 'Birdie';
    } else if (diff === -2) {
      return 'Eagle';
    } else if (diff === 1) {
      return 'Bogey';
    } else if (diff === 2) {
      return 'Double Bogey';
    } else if (diff < -2) {
      return 'Albatross';
    } else {
      return 'Ouch';
    }
  });
}
