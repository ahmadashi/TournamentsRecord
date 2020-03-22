import { Injectable, Inject } from '@angular/core';
import { Observable, of } from 'rxjs';
import * as _ from 'lodash';
import { TrTournamentModel } from './../../models/tr-Tournament-model';
import { map, catchError } from 'rxjs/operators';
import { GenericService } from '../../services/generic.service';


@Injectable()
export class TournamentReducerService {

  constructor(private genericService: GenericService, ) { }

  public addTournament(payload: TrTournamentModel/*, isPublic: boolean*/): Observable<TrTournamentModel> {
    //const accessToken = this.localStorage.getItem(this.constant.storageKey.accessToken);
    let api = 'api/tournament/add';   
    //const option = this.util.getConfigOption(accessToken);
    return this.genericService.add(payload, api, '')
      .pipe(map((res: any) => {
        const tour: TrTournamentModel = new TrTournamentModel();
        const tourModel = _.merge(res, tour);
        tourModel.id = res.userId;
        return tourModel;
      }));
  }


  public updateTournament(payload: TrTournamentModel): Observable<TrTournamentModel> {
    //const accessToken = this.localStorage.getItem(this.constant.storageKey.accessToken);
    const api = 'api/tournament/update';
    //const option = this.util.getConfigOption(accessToken);

    return this.genericService.add(payload, api, '')
      .pipe(map((res: any) => {        
         const tour: TrTournamentModel = new TrTournamentModel();
         const tourModel = _.merge(res, tour);
         tourModel.id = res.userId;
         return tourModel;
      }));
  }


  public getTournament(TournamentId: number): Observable<TrTournamentModel> {
    //const accessToken = this.localStorage.getItem(this.constant.storageKey.accessToken);
    const api = 'api/tournament/get/' + TournamentId.toString(); //this.constant.user.api + '/' + userId.toString();
    //const option = this.util.getConfigOption(accessToken);
    return this.genericService.get(api, '')
      .pipe(map((res: any) => {
        const tour: TrTournamentModel = res;
        tour.id = res.TournamentId;
        return tour;
      }));
  }

  public getTournaments(userId: number): Observable<TrTournamentModel[]> {
    //const accessToken = this.localStorage.getItem(this.constant.storageKey.accessToken);
    const api = 'api/tournament/GetByUserId/' + userId.toString(); //this.constant.user.listApi + '/' + schoolId.toString();
    //const option = this.util.getConfigOption(accessToken);
    return this.genericService.get(api, '')
      .pipe(map((result: any) => {
        let tournaments = _.map(result,
          function (element) {
            return _.extend({}, element, {
              id: element.tournamentId,
              //fullName: element.givenName + ' ' + element.familyName
            });
          });

        return tournaments;
      }));
  }


}
