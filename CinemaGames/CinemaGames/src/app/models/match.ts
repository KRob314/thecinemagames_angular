import { Genre } from '../models/genre';
import { Season } from "./season";
import { Status } from "./status";

export interface Match
{
  id: number,
  seasonId?: number,
  genreId?: number,
  statusId?: number,
  name: string,
  startDate: Date,
  endDate: Date,
  isCurrent: boolean,
  fullName?: string,
  //season?: string,
  //genre?: string,
  //status?: string
  season?: Season,
  genre?: Genre,
  status?: Status
}

//export class Match
//{
//  constructor(
//    public productId?: number

//  )
//}

export interface MatchEdit
{
  id: number,
  seasonId?: number,
  genreId?: number,
  statusId?: number,
  name: string,
  startDate: string,
  endDate: string,
  isCurrent: boolean,
}
