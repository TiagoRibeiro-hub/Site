import 'TicTacToe/tictactoe.css';
import Square from './Square';
import { useState, useEffect } from 'react';
import { Game } from '../types/Types';
import { PossibleMoves } from '../funcs/funcs'

type Props = {
    game: Game,
}

const defaultSquares = () => new Array(9).fill(null)
const inLine = [
    [0, 1, 2], [3, 4, 5], [6, 4, 7],
    [0, 3, 6], [1, 4, 6], [2, 5, 8],
    [0, 4, 8], [2, 4, 6]
]

export default function TicTacToeBoard({ game }: Props) {
    const [squares, setSquares] = useState(defaultSquares);
    const [shift, setShift] = useState(game.shift.symbol)
    game.computer.active = false;

    useEffect(() => {
        if (game.computer.active) {

            const possibleMoves = PossibleMoves(squares);

            const computerMove = (index: number) => {
                let newSquare = squares;
                newSquare[index] = game.shift.symbol;
                setSquares([...newSquare])
            }
            const randomIndex = possibleMoves[Math.ceil(Math.random() * possibleMoves.length)];
            if (randomIndex !== null) {
                computerMove(randomIndex);
            }
        }
    }, [squares, game.computer.active, game.shift.symbol])

    const handleSquareClick = (index: number) => {

        let newSquare = squares;
        if (shift === game.shift.symbol) {
            newSquare[index] = game.shift;
            setShift(game.shift.symbol);
        }
        if (shift === game.shift.symbol) {
            newSquare[index] = game.shift;
            setShift(game.shift.symbol);
        }
        setSquares([...newSquare]);
    }

    return (
        <div id='tictactoe-board'>
            {squares.map((square, index) =>
                <Square key={index}
                    X={square === game.shift.symbol ? true : false}
                    O={square === game.shift.symbol ? true : false}
                    index={index}
                    squareClick={handleSquareClick} />
            )}
        </div>
    );
}

