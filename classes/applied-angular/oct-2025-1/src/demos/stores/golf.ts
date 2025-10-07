import { computed } from '@angular/core';
import {
  patchState,
  signalStore,
  withComputed,
  withMethods,
  withProps,
  withState,
} from '@ngrx/signals';
import { withGolfGame } from './golf-game-feature';

const GolfPars = [3, 4, 5, 6] as const;
type GolfPar = (typeof GolfPars)[number];
type GolfState = {
  par: GolfPar | null;
  strokeCount: number;
};
export const GolfStore = signalStore(
  withGolfGame(),
  withState<GolfState>({
    par: null,
    strokeCount: 0,
  }),
  withProps(() => ({
    golfPars: GolfPars,
  })),
  withComputed((state) => {
    return {
      parSet: computed(() => state.par() !== null),
      rating: computed(() => {
        const par = state.par();
        const strokes = state.strokeCount();

        return calculateRating(par, strokes);
      }),
    };
  }),
  withMethods((state) => ({
    addStroke() {
      patchState(state, { strokeCount: state.strokeCount() + 1 });
    },
    reset: () => patchState(state, { strokeCount: 0, par: null }),
    setPar: (par: GolfPar) => patchState(state, { par }),
    finishHole: () => {
      state.completeHole(state.strokeCount(), state.par()!);
      patchState(state, { par: null, strokeCount: 0 });
    },
  })),
);

function calculateRating(par: GolfPar | null, strokes: number) {
  if (par === null || strokes === 0) {
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
}
