import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { map, mergeMap, catchError } from "rxjs/operators";
import { Store } from '@ngrx/store';
import { of } from 'rxjs';
import { TournamentTypeCancelled, TournamentTypeActionTypes, TournamentTypeRequested, TournamentTypeLoaded } from './tournament-type.actions';
import { TournamentTypeReducerService } from '../tournament-type-reducer.service';
import { TrTournamentTypeModel } from '../../../models/tr-Tournament-type-model';
import { AppState } from '../../../reducers';


@Injectable()
export class TournamentTypeEffects {
  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private TournamentTypeService: TournamentTypeReducerService) { }

  @Effect()
  loadData$ = this.actions$
    .pipe(
      ofType<TournamentTypeRequested>(TournamentTypeActionTypes.TournamentTypeRequested),
      mergeMap(() => this.TournamentTypeService.getTournamentsType()
        .pipe(
          catchError(err => {
          this.store.dispatch(new TournamentTypeCancelled());
          let TournamentTypes: TrTournamentTypeModel[] = [];
          return of(TournamentTypes);
          })
        )),
      map((TournamentTypes: TrTournamentTypeModel[]) => {
        return new TournamentTypeLoaded({ TournamentTypes: TournamentTypes });
    }));

}
