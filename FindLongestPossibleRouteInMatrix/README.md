## Find longest path and route in a 1-0 matrix problem

__Problem statement__

Given a rectangular path in the form of a binary matrix:

Problem 1. Find the length of the longest possible path from a given cell
Problem 2. Find the length of the longest possible route between two given cells.

No cycles allowed.
Allowed moves: left, up, right, down.

__Difficulty in literature__

This problem is considered Medium in literature.

__Runtime Complexity__

Backtracking needs to explore all possible combinations so it is a brute force algorithm and the complexity grows exponentially
with the matrix size.

__Space Complexity__

Just two equal sized matrices.

__References__

[[1]](https://www.techiedelight.com/find-longest-possible-route-matrix/) Find Longest Possible Route in a Matrix, Techiedelight.

## Examples

![Alt text](/FindLongestPossibleRouteInMatrix/longest_path_example.JPG?raw=true "Example01")

![Alt text](/FindLongestPossibleRouteInMatrix/longest_route_example.JPG?raw=true "Example02")

![Alt text](/FindLongestPossibleRouteInMatrix/output.JPG?raw=true "Output")

