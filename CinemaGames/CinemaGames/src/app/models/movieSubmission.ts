import { Match } from "./match";
import { Player } from "../models/player"

export interface MovieSubmission
{
  id?: number,
  playerId?: number,
  matchId?: number,
  title: string,
  trailer?: string,
  created?: Date,
  reasonToChoose?: string,
  synopsis?: string

  player?: Player,
  match?: Match
}
