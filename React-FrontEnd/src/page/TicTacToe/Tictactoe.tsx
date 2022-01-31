import { useState } from 'react';
import { Game, Player, Computer, Shift, Board } from 'TicTacToe/types/Types';
import TicTacToeBoard from '../../TicTacToe/components/TicTacToeBoard';

export default function Tictactoe() {
    const [player, SetPlayer] = useState<Player>({
        player1: "",
        player2: ""
    });
    const [computer, SetComputer] = useState<Computer>({
        name: "",
        active: false,
        easy: false,
        intermediate: false,
        hard: false
    });

    const [shift, SetShift] = useState<Shift>({
        symbol: ''
    });

    const [board, SetBoard] = useState<Board>({
        board: []
    });

    const [game, SetGame] = useState<Game>({
        player: player,
        computer: computer,
        shift: shift,
        board: board,
        winner: ""
    });

    return (
        <div id='tictactoe'>
            <div id='title'>
                <h1>Tic Tac Toe</h1>
            </div>
            <div id="tictactoe-content" className='row '>
                <div className='col-2 player-name player-1'>
                    <h6>Player1</h6>
                </div>
                <div id="tictactoe-content-board" className='col-8'>
                    <TicTacToeBoard game={game} />
                </div>
                <div className='col-2 player-name player-2'>
                    <h6>Player2</h6>
                </div>
            </div>

        </div>
    );
}

