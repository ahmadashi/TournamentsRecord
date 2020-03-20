import { createFeatureSelector, createSelector } from '@ngrx/store';
import { SportTypeState } from './sport-type.reducers';
import * as fromSportType from './sport-type.reducers';

export const selectSportTypeState = createFeatureSelector<SportTypeState>('sportTypeReducer');

export const selectAllSportTypes = createSelector(
  selectSportTypeState,
  fromSportType.selectAll

);

export const selectSportTypeById = (id: string) => createSelector(
  selectSportTypeState,
  state => state.entities[id]
);

export const selectSportTypeLoading = createSelector(
  selectSportTypeState,
    state => state.loading
);
