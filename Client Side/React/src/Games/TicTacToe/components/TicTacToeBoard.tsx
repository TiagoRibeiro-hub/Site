import 'Games/TicTacToe/tictactoe-style.css';
import Square from './Square';
import { useState, useEffect } from 'react';


const defaultSquares = () => new Array(9).fill(null)

export default function TicTacToeBoard() {
    const [squares, setSquares] = useState(defaultSquares);
    const [shift, setShift] = useState("X")
    // game.computer.active = false;

    // useEffect(() => {
    //     if (game.computer.active) {
    //         const computerMove = (index: number) => {
    //             let newSquare = squares;
    //             newSquare[index] = game.shift.symbol;
    //             setSquares([...newSquare])
    //         }

    //     }
    // }, [squares, game.computer.active, game.shift.symbol])

    const handleSquareClick = (index: number) => {

        let newSquare = squares;
        if (shift === "X") {
            newSquare[index] = "X";
            setShift("O");
        }
        if (shift === "O") {
            newSquare[index] = "O";
            setShift("X");
        }
        setSquares([...newSquare]);
    }

    return (
        <div id='tictactoe-board'>
            {squares.map((square, index) =>
                <Square key={index}
                    X={square === "X" ? true : false}
                    O={square === "O" ? true : false}
                    index={index}
                    squareClick={handleSquareClick} />
            )}
        </div>
    );
}

{/* <div id='tictactoe-board'>
            {squares.map((square, index) =>
                <Square key={index}
                    X={square === game.shift.symbol ? true : false}
                    O={square === game.shift.symbol ? true : false}
                    index={index}
                    squareClick={handleSquareClick} />
            )}
        </div> */}