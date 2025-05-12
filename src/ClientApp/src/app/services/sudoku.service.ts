import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Difficulty } from '../models/difficulty.enum';
import { SolveResponse } from '../models/solve-response.model';
import { ValidateResponse } from '../models/validate-response.model';
import { BoardResponse } from '../models/board-response.model';
import { Board } from '../models/board.model';

@Injectable({
  providedIn: 'root'
})
export class SudokuService {
  private baseUrl = 'https://localhost:5001/api/boards';
  constructor(private http: HttpClient) { }

  getBoard(difficulty: Difficulty):Observable<BoardResponse> {
    return this.http.get<BoardResponse>(`${this.baseUrl}?difficulty=${difficulty}`);
  }

  validate(board: Board): Observable<ValidateResponse> {
    return this.http.post<ValidateResponse>(`${this.baseUrl}/validate`, { board });
  }
  solve(board: Board): Observable<SolveResponse> {
    return this.http.post<SolveResponse>(`${this.baseUrl}/solve`, { board });
  } 

}
