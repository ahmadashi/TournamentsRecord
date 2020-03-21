import { createFeatureSelector, createSelector } from '@ngrx/store';
import { TournamentTypeState } from './tournament-type.reducers';
import * as fromTournamentType from './tournament-type.reducers';

export const selectTournamentTypeState = createFeatureSelector<TournamentTypeState>('tournamentTypeReducer');

export const selectAllTournamentTypes = createSelector(
  selectTournamentTypeState,
  fromTournamentType.selectAll

);

export const selectTournamentTypeById = (id: string) => createSelector(
  selectTournamentTypeState,
  state => state.entities[id]
);

export const selectTournamentTypeLoading = createSelector(
  selectTournamentTypeState,
    state => state.loading
);
