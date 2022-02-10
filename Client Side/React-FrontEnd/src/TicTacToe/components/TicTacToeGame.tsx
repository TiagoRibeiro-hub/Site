import 'TicTacToe/tictactoe-style.css';
import TicTacToeBoard from '../../TicTacToe/components/TicTacToeBoard';

export default function TicTacToeGame() {
  return (
    <div id='tictactoe' className='container-fluid'> 
            <div id='title' className='row mb-5 border-bottom'>
                <h1>Tic Tac Toe</h1>
            </div>
            <div id='title' className='row mb-5'>
                <h1>Info Game(who playes and winner)</h1>
            </div>
            <div id="tictactoe-content-board" className='row '>
                    <TicTacToeBoard />
            </div>
        </div>
  )
}

