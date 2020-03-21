import { createEntityAdapter, EntityAdapter, EntityState } from '@ngrx/entity';
import { TournamentTypeActions, TournamentTypeActionTypes } from './tournament-type.actions';
import { TrTournamentTypeModel } from '../../../models/tr-tournament-type-model';


export interface TournamentTypeState extends EntityState<TrTournamentTypeModel> {
  loading: boolean;  
}

export const adapter: EntityAdapter<TrTournamentTypeModel> = createEntityAdapter<TrTournamentTypeModel>();

export const initialTournamentTypeState: TournamentTypeState = adapter.getInitialState({ loading: false });

export function TournamentTypeReducer(state = initialTournamentTypeState, action: TournamentTypeActions): TournamentTypeState {
  switch (action.type) {

    case TournamentTypeActionTypes.TournamentTypeRequested: {
      return { ...state, loading: true };
    }
    case TournamentTypeActionTypes.TournamentTypeLoaded: {
      return adapter.addMany(action.payload.TournamentTypes, { ...state, loading: false });
    }
    case TournamentTypeActionTypes.TournamentTypeCancelled: {
      return { ...state, loading: false };
    }
    default: {
      return state;
    }
  }
}

export const {
  selectAll,
  selectEntities,
  selectIds,
  selectTotal
} = adapter.getSelectors();
