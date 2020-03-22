import { Action } from '@ngrx/store';
import { TrTournamentModel } from '../../../models/tr-Tournament-model';


export enum TournamentActionsType {
  TournamentRequested = '[Tournament] Tournament  requested',
  TournamentLoaded = '[Tournament] Tournament  loaded',
  TournamentsRequested = '[Tournament] Tournaments  requested',
  TournamentsLoaded = '[Tournament] Tournaments  loaded',
  TournamentCancelled = '[Tournament] Tournament  cancelled',
  TournamentAddRequested = '[Tournament] Tournament add requested',
  TournamentAddLoaded = '[Tournament] Tournament add loaded',
  TournamentUpdateRequested = '[Tournament] Tournament update requested',
  TournamentUpdateLoaded = '[Tournament] Tournament update loaded'
}

export class TournamentRequested implements Action {
  readonly type = TournamentActionsType.TournamentRequested;
  constructor(public payload: { tournamentId: number }) { }
}

export class TournamentLoaded implements Action {
  readonly type = TournamentActionsType.TournamentLoaded;
  constructor(public payload: { tournament: TrTournamentModel }) { }}


export class TournamentsRequested implements Action {
  readonly type = TournamentActionsType.TournamentsRequested;
  constructor(public payload: { userId: number }) { }
}

export class TournamentsLoaded implements Action {
  readonly type = TournamentActionsType.TournamentsLoaded;
  constructor(public payload: { tournaments: TrTournamentModel[] }) { }
}


export class TournamentAddRequested implements Action {
  readonly type = TournamentActionsType.TournamentAddRequested;
  constructor(public payload: { tournament: TrTournamentModel }) { }
}

export class TournamentAddLoaded implements Action {
  readonly type = TournamentActionsType.TournamentAddLoaded;
  constructor(public payload: { tournament: TrTournamentModel }) { }
}


export class TournamentUpdateRequested implements Action {
  readonly type = TournamentActionsType.TournamentUpdateRequested;
  constructor(public payload: { tournament: TrTournamentModel }) { }
}

export class TournamentUpdateLoaded implements Action {
  readonly type = TournamentActionsType.TournamentUpdateLoaded;
  constructor(public payload: { tournament: TrTournamentModel }) { }
}



export class TournamentCancelled implements Action {
  readonly type = TournamentActionsType.TournamentCancelled;
  constructor(public payload: { error: any }) { }
}

export type  TournamentActions =
  TournamentRequested
  | TournamentLoaded
  | TournamentsRequested
  | TournamentsLoaded
  | TournamentCancelled
  | TournamentAddRequested
  | TournamentAddLoaded 
  | TournamentUpdateRequested
  | TournamentUpdateLoaded 
