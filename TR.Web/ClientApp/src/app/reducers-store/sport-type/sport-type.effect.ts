import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { map, mergeMap, catchError } from "rxjs/operators";
import { Store } from '@ngrx/store';
//import { AppState } from 'app/reducers';
import { of } from 'rxjs';

//import { SchoolReducerService } from 'app/reducers-store/school-module/school-reducer-service';
import { SportTypeCancelled, SportTypeActionTypes, SportTypeRequested, SportTypeLoaded } from './sport-type.actions';
import { TrSportTypeModel } from '../../models/tr-sport-type-model';
import { TournamentService } from '../../main-componants/tournament.service';
import { AppState } from '../../reducers';

@Injectable()
export class SportTypeEffects {
  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private tournamentService: TournamentService) { }

  @Effect()
  loadData$ = this.actions$
    .pipe(
      ofType<SportTypeRequested>(SportTypeActionTypes.SportTypeRequested),
      mergeMap(() => this.tournamentService.getSportsType()
        .pipe(
          catchError(err => {
          this.store.dispatch(new SportTypeCancelled());
          let SportType: TrSportTypeModel[] = [];
          return of(SportType);
          })
        )),
      map((SportType: TrSportTypeModel[]) => {
        return new SportTypeLoaded({ SportType: SportType });
    }));

}
