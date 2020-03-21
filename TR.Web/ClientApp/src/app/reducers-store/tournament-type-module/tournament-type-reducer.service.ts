import { Injectable, Inject } from '@angular/core';
import { Observable, of } from 'rxjs';
import * as _ from 'lodash';
import { TrTournamentTypeModel } from './../../models/tr-Tournament-type-model';
import { map, catchError } from 'rxjs/operators';
import { GenericService } from '../../services/generic.service';


@Injectable()
export class TournamentTypeReducerService {

  constructor(private genericService: GenericService, ) { }


  //public getSchoolTypes(): Observable<TrTournamentTypeModel[]> {
  //  //const accessToken = this.localStorage.getItem(this.constant.storageKey.accessToken);
  //  //const api = this.constant.schools.schoolTypes.api;
  //  //const option = this.util.getConfigOption(accessToken);
  //  return this.genericService.get("ddd", "dsd")
  //    .pipe(map((result: TrTournamentTypeModel[]) => {
  //      const TournamentType = _.map(result,
  //        function (element) {
  //          return _.extend({}, element, {
  //            id: element.TournamentTypeId
  //          });
  //        });
  //      return TournamentType;
  //    }));
  //}


  public getTournamentsType(): Observable<TrTournamentTypeModel[]> {


    return this.genericService.get('api/tournamenttype', '').pipe(
      map((res: any) => {
        const tournamentType = _.map(res,
        function (element) {
          return _.extend({}, element, {
            id: element.tournamentTypeId
          });
        });
      return (tournamentType as TrTournamentTypeModel[]);
      }));  

  }


}
