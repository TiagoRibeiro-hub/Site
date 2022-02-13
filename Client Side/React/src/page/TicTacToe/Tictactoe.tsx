import TicTacToeGame from 'Games/TicTacToe/components/TicTacToeGame';
import VsHuman from 'Games/components/VsHuman';
import Vs from 'Games/components/Vs';
import VsComputer from 'Games/components/VsComputer';

export default function Tictactoe() {
    return (
        <div id='tictactoe' className='container-fluid'>
           <div id='title' className='row mb-5 border-bottom'>
                <h1>Tic Tac Toe</h1>
            </div>
            <div className='row'>
                <Vs />
            </div>
            <div className='row display-none'>
                <VsComputer />
            </div>
            <div className='row display-none'>
                <VsHuman />
            </div>
            <div className='row display-none'>
                <TicTacToeGame />
            </div>
        </div>
    );
}

