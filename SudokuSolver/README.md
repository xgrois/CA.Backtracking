## Sudoku solver problem

__Problem statement__

Given a sudoku initial state, solve it.

__Difficulty in literature__

This problem is considered Medium in literature.

__Runtime Complexity__

Backtracking needs to explore all possible combinations so it is a brute force algorithm and the complexity grows exponentially
with the matrix size.

A Sudoku can be constructed to work against backtracking. 
Assuming the solver works from top to bottom (as in the animation), a puzzle with few clues (17), 
no clues in the top row, and has a solution "987654321" for the first row, would work in opposition to the algorithm. 
Thus the program would spend significant time "counting" upward before it arrives at the grid which satisfies the puzzle.

This is one example:

<img src="/SudokuSolver/bad_sudoku.png" alt="drawing" width="200"/>

Anyway, this can be easily overcomed by adding some initial logic that "guess" where to start (top-down or down-top), e.g., start down-top if first row has less initial values than the last row.

__Space Complexity__

The original matrix 9x9

__References__

[[1]](https://es.wikipedia.org/wiki/Sudoku) Sudoku, Wikipedia.

[[2]](https://www.sudoku-online.org/) Sudoku game online.

## Output

![Alt text](/SudokuSolver/output.JPG?raw=true "Output")

