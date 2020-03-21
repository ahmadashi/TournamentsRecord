import { DataSource } from "@angular/cdk/collections";
import { BehaviorSubject, of, Observable } from "rxjs";
import { Store, select } from "@ngrx/store";
import { tap, catchError } from "rxjs/operators";
import * as _ from "lodash";
import { selectAllTournamentTypes } from "./tournament-type.selectors";
import { TournamentTypeRequested } from "./tournament-type.actions";
import { TrTournamentTypeModel } from "../../../models/tr-Tournament-type-model";
import { AppState } from "../../../reducers";


export class TournamentTypeDataSource implements DataSource<TrTournamentTypeModel> {

  private TournamentTypeSubject = new BehaviorSubject<TrTournamentTypeModel[]>([]);

  constructor(private store: Store<AppState>) { }

  loadTournamentTypes(): void {
    this.store
      .pipe(
      select(selectAllTournamentTypes),
      tap(TournamentTypes => {
          if (TournamentTypes.length > 0) {
            this.TournamentTypeSubject.next(TournamentTypes);
          }
          else {
            this.store.dispatch(new TournamentTypeRequested());
          }
        }),
        catchError(() => of([]))
      )
      .subscribe();

  }

  connect(): Observable<TrTournamentTypeModel[]> {
    return this.TournamentTypeSubject.asObservable();
  }

  disconnect(): void {
    this.TournamentTypeSubject.complete();
  }

}
