import { Component } from '@angular/core';
import { SudokuService } from '../../services/sudoku.service';
import { CommonModule } from '@angular/common';
import { Difficulty } from '../../models/difficulty.enum';

@Component({
  selector: 'app-board',
  imports: [CommonModule],
  templateUrl: './board.component.html',
  styleUrl: './board.component.scss'
})
export class BoardComponent {
  board: number[][] = [];

  constructor(private sudokuService: SudokuService) { }

  ngOnInit() {
    this.sudokuService.getBoard(Difficulty.Easy).subscribe((response) => {
      this.board = response.board;
    });
  }

  isPreFilled(rowIndex: number, colIndex: number): boolean {
    return this.board[rowIndex][colIndex] !== 0;
  }

  onCellInput(event: Event, row: number, col: number): void {
  const input = (event.target as HTMLInputElement);
  const value=input.valueAsNumber
  if (value >= 1 && value <= 9) {
    input.readOnly = true;
  } 
}
}