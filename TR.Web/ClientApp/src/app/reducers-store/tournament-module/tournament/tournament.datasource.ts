import { DataSource } from "@angular/cdk/collections";
import { BehaviorSubject, of, Observable } from "rxjs";
import { Store, select } from "@ngrx/store";
import { tap, catchError } from "rxjs/operators";
import * as _ from "lodash";
import { selectAllTournaments, selectTournamentsByUserId, selectTournamentById } from "./tournament.selectors";
import { TournamentRequested, TournamentsRequested } from "./tournament.actions";
import { TrTournamentModel } from "../../../models/tr-Tournament-model";
import { AppState } from "../../../reducers";
import {  filter, first } from "rxjs/operators";


export class TournamentDataSource implements DataSource<TrTournamentModel> {

  private TournamentSubject = new BehaviorSubject<TrTournamentModel[]>([]);
  private componentActive: boolean = true;

  constructor(private store: Store<AppState>) { }

  getTournament(tournamentId: number): Observable<TrTournamentModel> {

    return this.store.pipe(
      select(selectTournamentById(tournamentId)),
      tap(user => {
        if (user !== undefined) {
          return user;
        }
        else {
          this.store.dispatch(new TournamentRequested({ tournamentId: tournamentId }));
        }
      }),
      filter(tour => !!tour),
      first()
    );
  }


  //setUserToInactive(vprcUser: TrTournamentModel) {
  //  vprcUser.Status = false;
  //  this.store.dispatch(new UserPostRequested({ vprcUser }));
  //}



  

  getTournaments(userId: number) {
    this.store
      .pipe(
        select(selectTournamentsByUserId(userId)),
        tap(users => {

          if (users !== undefined) {
            if (users.length > 0) {
              this.TournamentSubject.next(users);
            } else {
              this.store.dispatch(new TournamentsRequested({ userId: userId }));
            }
            this.TournamentSubject.next(users);
          }
        }),
        catchError(() => of([]))
      )
      .subscribe();
  }

  connect(): Observable<TrTournamentModel[]> {
    return this.TournamentSubject.asObservable();
  }

  disconnect(): void {
    this.TournamentSubject.complete();
    this.componentActive = false;
  }


  

}
