import { Component } from '@angular/core';
import { SudokuService } from '../../services/sudoku.service';
import { CommonModule } from '@angular/common';
import { Difficulty } from '../../models/difficulty.enum';
import { Board } from '../../models/board.model';

@Component({
  selector: 'app-board',
  imports: [CommonModule],
  templateUrl: './board.component.html',
  styleUrl: './board.component.scss',
})
export class BoardComponent {
  board: Board=[];
  difficulties = Object.values(Difficulty).filter(value => typeof value === 'number');
  selectedDifficulty: Difficulty = Difficulty.Easy;
  Difficulty = Difficulty;
  message: string = '';
  constructor(private sudokuService: SudokuService) {}

  ngOnInit() {
    this.generateBoard(this.selectedDifficulty);
  }

  isPreFilled(rowIndex: number, colIndex: number): boolean {
    return this.board[rowIndex][colIndex] !== 0;
  }

  onCellInput(event: Event, row: number, col: number): void {
    const input = event.target as HTMLInputElement;
    const value = input.valueAsNumber;
    if (value >= 1 && value <= 9) {
      input.readOnly = true;
    }
  }

  onDifficultyChange(event: Event): void {
    const select = event.target as HTMLSelectElement;
  const value = Number(select.value); 
  if (!isNaN(value)) {
    this.selectedDifficulty = value as Difficulty;
    this.generateBoard(this.selectedDifficulty);
  }
  }

  generateBoard(difficulty: Difficulty): void {
    this.sudokuService.getBoard(difficulty).subscribe((response) => {
      this.board = response.board;
    });
  }

  validate(){
    this.sudokuService.validate(this.board).subscribe((response) => {
      if (response.status === 'solved') {
        this.message = 'Sudoku is valid';
      } else {
        this.message = 'Sudoku is invalid';
      }
    });
  }

  solve(){
    this.sudokuService.solve(this.board).subscribe((response) => {
      if (response.status === 'solved') {
        this.board = response.solution;
        this.message = 'Sudoku is solved';
      } else {
        this.message = 'Sudoku is not solved';
      }
    });
  }
}
