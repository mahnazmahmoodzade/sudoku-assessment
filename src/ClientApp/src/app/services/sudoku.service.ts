import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Difficulty } from '../models/difficulty.enum';

@Injectable({
  providedIn: 'root'
})
export class SudokuService {

  private baseUrl = 'https://localhost:5001/api/boards';
  constructor(private http: HttpClient) { }

  getBoard(difficulty: Difficulty):Observable<{board:number[][]}> {
    return this.http.get<{board: number[][]}>(`${this.baseUrl}?difficulty=${difficulty}`);
  }

}
