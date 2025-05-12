import { Component } from '@angular/core';
import { SudokuService } from '../../services/sudoku.service';
import { CommonModule } from '@angular/common';
import { Difficulty } from '../../models/difficulty.enum';

@Component({
  selector: 'app-board',
  imports: [CommonModule],
  templateUrl: './board.component.html',
  styleUrl: './board.component.scss',
})
export class BoardComponent {
  board: number[][] = [];
  difficulties = Object.values(Difficulty).filter(value => typeof value === 'number');
  selectedDifficulty: Difficulty = Difficulty.Easy;
  Difficulty = Difficulty;

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
  const value = Number(select.value); // safely convert string to number
  if (!isNaN(value)) {
    this.selectedDifficulty = value as Difficulty;
    this.generateBoard(this.selectedDifficulty);
  }
  }

  // Add this method to generate board based on difficulty
  generateBoard(difficulty: Difficulty): void {
    this.sudokuService.getBoard(difficulty).subscribe((response) => {
      this.board = response.board;
    });
  }
}
