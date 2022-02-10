import TicTacToeGame from 'TicTacToe/components/TicTacToeGame';
import Vs from 'TicTacToe/components/Vs';
import VsComputer from 'TicTacToe/components/VsComputer';
import VsHuman from 'TicTacToe/components/VsHuman';
import 'TicTacToe/tictactoe-style.css';

export default function Tictactoe() {
    return (
        <div id='tictactoe' className='container-fluid'>
           <div id='title' className='row mb-5 border-bottom'>
                <h1>Tic Tac Toe</h1>
            </div>
            <div className='row'>
                <Vs />
            </div>
            <div className='row'>
                <TicTacToeGame />
            </div>
            <div className='row'>
                <VsComputer />
            </div>
            <div className='row'>
                <VsHuman />
            </div>
        </div>
    );
}

