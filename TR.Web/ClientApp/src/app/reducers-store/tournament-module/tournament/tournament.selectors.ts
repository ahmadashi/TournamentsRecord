import { createFeatureSelector, createSelector } from '@ngrx/store';
import { TournamentState } from './tournament.reducers';
import * as fromTournament from './tournament.reducers';

export const selectTournamentState = createFeatureSelector<TournamentState>('tournamentReducer');

export const selectAllTournaments = createSelector(
  selectTournamentState,
  fromTournament.selectAll

);

export const selectTournamentById = (id: number) => createSelector(
  selectTournamentState,
  state => state.entities[id]
);

export const selectTournamentLoading = createSelector(
  selectTournamentState,
    state => state.loading
);

export const selectTournamentError = createSelector(
  selectTournamentState,
  state => state.error
);

export const selectTournamentsByUserId = (userId: number) => createSelector(
  selectAllTournaments,
  allTournaments => {
    return allTournaments
      .filter(tourn => tourn.userId == userId);
  }
);
