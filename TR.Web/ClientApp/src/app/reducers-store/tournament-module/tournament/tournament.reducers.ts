import { createEntityAdapter, EntityAdapter, EntityState } from '@ngrx/entity';
import {  TournamentActionsType, TournamentActions } from './tournament.actions';
import { TrTournamentModel } from '../../../models/tr-tournament-model';


export interface TournamentState extends EntityState<TrTournamentModel> {
  loading: boolean;
  error: any; 
}

export const adapter: EntityAdapter<TrTournamentModel> = createEntityAdapter<TrTournamentModel>();

export const initialTournamentState: TournamentState = adapter.getInitialState({ loading: false, error: undefined });

export function TournamentReducer(state = initialTournamentState, action: TournamentActions): TournamentState {
  switch (action.type) {

    case TournamentActionsType.TournamentRequested: {
      return { ...state, loading: true };
    }

    case TournamentActionsType.TournamentLoaded: {
      return adapter.addOne(action.payload.tournament, { ...state, loading: false, error: undefined});
    }

    case TournamentActionsType.TournamentsRequested: {
      return { ...state, loading: true };
    }
    case TournamentActionsType.TournamentsLoaded: {
      return adapter.addMany(action.payload.tournaments, { ...state, loading: false, error: undefined});
    }


    case TournamentActionsType.TournamentAddRequested:
      return { ...state, loading: true };

    case TournamentActionsType.TournamentAddLoaded: {
      return adapter.addOne(action.payload.tournament, { ...state, loading: false, error: undefined });
    }


    case TournamentActionsType.TournamentUpdateRequested:
      return { ...state, loading: true };

    case TournamentActionsType.TournamentUpdateLoaded: {
      return adapter.addOne(action.payload.tournament, { ...state, loading: false, error: undefined });
    }

    case TournamentActionsType.TournamentCancelled: {
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
