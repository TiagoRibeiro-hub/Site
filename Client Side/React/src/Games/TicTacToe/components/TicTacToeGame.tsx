import 'Games/TicTacToe/tictactoe-style.css';
import TicTacToeBoard from './TicTacToeBoard';

export default function TicTacToeGame() {
  return (
    <div>
      <div id='title' className='row mb-5'>
        <h1>Info Game(who playes and winner)</h1>
      </div>
      <div id="tictactoe-content-board" className='row '>
        <TicTacToeBoard />
      </div>
    </div>
  )
}

