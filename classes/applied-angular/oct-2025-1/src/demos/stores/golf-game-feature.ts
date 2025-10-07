import { computed } from '@angular/core';
import {
  patchState,
  signalStoreFeature,
  withComputed,
  withMethods,
  withState,
} from '@ngrx/signals';
import { addEntity, withEntities } from '@ngrx/signals/entities';
type GolfHole = {
  id: number;
  par: number;
  strokes: number;
};
type GolfGameState = {
  _currentHoleId: number;
};
export function withGolfGame() {
  return signalStoreFeature(
    withState<GolfGameState>({
      _currentHoleId: 1,
    }),
    withEntities<GolfHole>(),
    withComputed((state) => {
      return {
        total: computed(() => {
          return state.entities().reduce((sum, hole) => sum + hole.strokes, 0);
        }),
      };
    }),
    withMethods((state) => ({
      completeHole: (strokes: number, par: number) =>
        patchState(
          state,
          addEntity({
            id: state._currentHoleId(),
            par,
            strokes,
          }),
          { _currentHoleId: state._currentHoleId() + 1 },
        ),
    })),
  );
}
