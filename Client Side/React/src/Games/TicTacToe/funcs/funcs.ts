export function PossibleMoves(squares: number[]){ 
    return squares.map((square, index) => square === null ? index : null).filter(value => value !== null);
}
