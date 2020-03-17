import { createEntityAdapter, EntityAdapter, EntityState } from '@ngrx/entity';
import { TrSportTypeModel } from '../../models/tr-sport-type-model';
import { SportTypeActions, SportTypeActionTypes } from './sport-type.actions';


export interface SportTypeState extends EntityState<TrSportTypeModel> {
  loading: boolean;
  ecsLoading: boolean;
}

export const adapter: EntityAdapter<TrSportTypeModel> = createEntityAdapter<TrSportTypeModel>();

export const initialSportTypeState: SportTypeState = adapter.getInitialState({ loading: false, ecsLoading: false });

export function SportTypeReducer(state = initialSportTypeState, action: SportTypeActions): SportTypeState {
  switch (action.type) {

    case SportTypeActionTypes.SportTypeRequested: {
      return { ...state, loading: true };
    }
    case SportTypeActionTypes.SportTypeLoaded: {
      return adapter.addMany(action.payload.SportType, { ...state, loading: false });
    }
    case SportTypeActionTypes.SportTypeCancelled: {
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
