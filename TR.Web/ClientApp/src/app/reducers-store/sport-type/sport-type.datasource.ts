import { DataSource } from "@angular/cdk/collections";

import { BehaviorSubject, of, Observable } from "rxjs";
import { Store, select } from "@ngrx/store";
import { tap, catchError } from "rxjs/operators";
//import { AppState } from "app/reducers";
import * as _ from "lodash";
import { TrSportTypeModel } from "../../models/tr-sport-type-model";
import { selectAllSportTypes } from "./sport-type.selectors";
import { SportTypeRequested } from "./sport-type.actions";
import { AppState } from "../../reducers";

export class SportTypeDataSource implements DataSource<TrSportTypeModel> {

  private SportTypeSubject = new BehaviorSubject<TrSportTypeModel[]>([]);

  constructor(private store: Store<AppState>) { }

  loadSportTypes(): void {
    this.store
      .pipe(
      select(selectAllSportTypes),
      tap(SportType => {
          if (SportType.length > 0) {
            this.SportTypeSubject.next(SportType);
          }
          else {
            this.store.dispatch(new SportTypeRequested());
          }
        }),
        catchError(() => of([]))
      )
      .subscribe();

  }

  connect(): Observable<TrSportTypeModel[]> {
    return this.SportTypeSubject.asObservable();
  }

  disconnect(): void {
    this.SportTypeSubject.complete();
  }

}
