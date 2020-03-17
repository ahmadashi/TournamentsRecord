import { Action } from '@ngrx/store';
import { TrSportTypeModel } from '../../models/tr-sport-type-model';


export enum SportTypeActionTypes {
  SportTypeRequested = '[SportType] Sport Type requested',
  SportTypeLoaded = '[SportType] Sport Type loaded',
  SportTypeCancelled = '[SportType] Sport Type cancelled'
}

export class SportTypeRequested implements Action {
  readonly type = SportTypeActionTypes.SportTypeRequested;
}

export class SportTypeLoaded implements Action {
  readonly type = SportTypeActionTypes.SportTypeLoaded;
  constructor(public payload: { SportType: TrSportTypeModel[] }) { }
}

export class SportTypeCancelled implements Action {
  readonly type = SportTypeActionTypes.SportTypeCancelled;
}

export type SportTypeActions =
  SportTypeRequested
  | SportTypeLoaded
  | SportTypeCancelled;
