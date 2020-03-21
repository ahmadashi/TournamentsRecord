import { Action } from '@ngrx/store';
import { TrTournamentTypeModel } from '../../../models/tr-Tournament-type-model';


export enum TournamentTypeActionTypes {
  TournamentTypeRequested = '[TournamentType] Tournament Type requested',
  TournamentTypeLoaded = '[TournamentType] Tournament Type loaded',
  TournamentTypeCancelled = '[TournamentType] Tournament Type cancelled'
}

export class TournamentTypeRequested implements Action {
  readonly type = TournamentTypeActionTypes.TournamentTypeRequested;
}

export class TournamentTypeLoaded implements Action {
  readonly type = TournamentTypeActionTypes.TournamentTypeLoaded;
  constructor(public payload: { TournamentTypes: TrTournamentTypeModel[] }) { }
}

export class TournamentTypeCancelled implements Action {
  readonly type = TournamentTypeActionTypes.TournamentTypeCancelled;
}

export type TournamentTypeActions =
  TournamentTypeRequested
  | TournamentTypeLoaded
  | TournamentTypeCancelled;
