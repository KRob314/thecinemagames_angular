import { MovieSubmission } from "./movieSubmission";
import { Player } from "./player";

export interface MovieRating
{
  id?: number,
  playerId?: number,
  movieSubmissionId?: number,
  rating?: number,
  created?: string,
  reasonForVote?: string,
  pickEm?: string,

  player?: Player,
  movieSubmission?: MovieSubmission
}
