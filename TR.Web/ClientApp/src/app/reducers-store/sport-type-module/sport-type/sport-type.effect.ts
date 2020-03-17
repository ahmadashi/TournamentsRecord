import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { map, mergeMap, catchError } from "rxjs/operators";
import { Store } from '@ngrx/store';
import { of } from 'rxjs';
import { SportTypeCancelled, SportTypeActionTypes, SportTypeRequested, SportTypeLoaded } from './sport-type.actions';
import { SportTypeReducerService } from '../sport-type-reducer.service';
import { TrSportTypeModel } from '../../../models/tr-sport-type-model';
import { AppState } from '../../../reducers';


@Injectable()
export class SportTypeEffects {
  constructor(
    private actions$: Actions,
    private store: Store<AppState>,
    private sportTypeService: SportTypeReducerService) { }

  @Effect()
  loadData$ = this.actions$
    .pipe(
      ofType<SportTypeRequested>(SportTypeActionTypes.SportTypeRequested),
      mergeMap(() => this.sportTypeService.getSportsType()
        .pipe(
          catchError(err => {
          this.store.dispatch(new SportTypeCancelled());
          let SportTypes: TrSportTypeModel[] = [];
          return of(SportTypes);
          })
        )),
      map((SportTypes: TrSportTypeModel[]) => {
        return new SportTypeLoaded({ SportTypes: SportTypes });
    }));

}
