import { Board } from './board.model';
import { Difficulty } from './difficulty.enum';

export interface SolveResponse {
  difficulty: Difficulty;
  solution: number[][];
  status: 'solved' | 'broken' | 'unsolvable';
}
