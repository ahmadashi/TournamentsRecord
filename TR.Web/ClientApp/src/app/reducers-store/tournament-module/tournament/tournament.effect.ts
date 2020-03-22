import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { map, mergeMap, catchError } from "rxjs/operators";
import { Store } from '@ngrx/store';
import { of } from 'rxjs';
import { TournamentCancelled, TournamentActionsType, TournamentRequested, TournamentLoaded, TournamentsLoaded, TournamentsRequested, TournamentAddRequested, TournamentAddLoaded, TournamentUpdateRequested, TournamentUpdateLoaded } from './tournament.actions';
import { TournamentReducerService } from '../tournament-reducer.service';
import { TrTournamentModel } from '../../../models/tr-Tournament-model';
import { AppState } from '../../../reducers';


@Injectable()
export class TournamentEffects {
  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private TournamentService: TournamentReducerService) { }

  @Effect()
  loadTournamentsByUserId$ = this.actions$
    .pipe(
      ofType<TournamentsRequested>(TournamentActionsType.TournamentsRequested),
      mergeMap(action => this.TournamentService.getTournaments(action.payload.userId)
        .pipe(
          catchError(error => {
            this.store.dispatch(new TournamentCancelled({ error }));
          let Tournaments: TrTournamentModel[] = [];
          return of(Tournaments);
          })
        )),
      map((Tournaments: TrTournamentModel[]) => {
        return new TournamentsLoaded({ tournaments: Tournaments });
      }));


  @Effect()
  loadTournament$ = this.actions$
    .pipe(
      ofType<TournamentRequested>(TournamentActionsType.TournamentRequested),
      mergeMap(action => this.TournamentService.getTournaments(action.payload.tournamentId)
        .pipe(
          catchError(error => {
            this.store.dispatch(new TournamentCancelled({ error }));
            let Tournament: TrTournamentModel;
            return of(Tournament);
          })
        )),
      map((Tournament: TrTournamentModel) => {
        return new TournamentLoaded({ tournament: Tournament });
      }));



  @Effect()
  loadAddTournament$ = this.actions$
    .pipe(
      ofType<TournamentAddRequested>(TournamentActionsType.TournamentAddRequested),
      mergeMap(action => this.TournamentService.addTournament(action.payload.tournament/*, action.payload.isPublic*/)
        .pipe(
          catchError(error => {
            this.store.dispatch(new TournamentCancelled({ error }));
            let tour = new TrTournamentModel();
            tour.id = 0;
            return of(tour);
          })
        )),
      map((tournamentModel: TrTournamentModel) =>
        new TournamentAddLoaded({ tournament: tournamentModel }))
  );


  @Effect()
  loadUpdateTournament$ = this.actions$
    .pipe(
      ofType<TournamentUpdateRequested>(TournamentActionsType.TournamentUpdateRequested),
      mergeMap(action => this.TournamentService.updateTournament(action.payload.tournament)
        .pipe(
          catchError(error => {
            this.store.dispatch(new TournamentCancelled({ error }));
            return of(new TrTournamentModel());
          })
        )),
      map((tournamentModel: TrTournamentModel) =>
        new TournamentUpdateLoaded({ tournament: tournamentModel }))
    );


  
 

}
