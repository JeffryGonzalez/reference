import { Component, ChangeDetectionStrategy, inject } from '@angular/core';
import { GolfStore } from '../stores/golf';

@Component({
  selector: 'app-demos-signals2',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  providers: [GolfStore],
  template: `
    <p>Golf Score</p>

    @if (store.parSet() === false) {
      <div class="join">
        @for (par of store.golfPars; track par) {
          <button (click)="store.setPar(par)" class="join-item btn btn-sm ">
            {{ par }}
          </button>
        }
      </div>
    } @else {
      <div>
        <div>
          Strokes: <span>{{ store.strokeCount() }}</span> (Par
          {{ store.par() }})
        </div>

        <button (click)="store.addStroke()" class="btn btn-primary btn-circle">
          +
        </button>
      </div>
      <div>
        @switch (store.rating()) {
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
        <button (click)="store.reset()" class="btn btn-warning">Reset</button>
        @if (store.strokeCount() > 0) {
          <button (click)="store.finishHole()" class="btn btn-secondary ml-2">
            Finish Hole
          </button>
        }
      </div>
    }
    <div>
      <p>Total Strokes: {{ store.total() }}</p>
      @for (hole of store.entities(); track hole.id) {
        <div>
          Hole {{ hole.id }}: {{ hole.strokes }} strokes (Par {{ hole.par }})
        </div>
      }
    </div>
  `,
  styles: ``,
})
export class Signals2 {
  readonly store = inject(GolfStore);
}
