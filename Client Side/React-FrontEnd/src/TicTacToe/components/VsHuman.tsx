import 'TicTacToe/tictactoe-style.css';

export default function VsHuman() {
  return (
    <div id='tictactoe' className='container-fluid flex-center'>
      <div className='row'>
        <div className='col-6'>
          <div id="title">
            <h1>First Player</h1>
          </div>
          <div id='input-div' className='flex-center'>
            <label id='input-label'>Email</label>
            <input type="email" className='input-box-with' placeholder='exemple@email.com' />
          </div>
          <div id='input-div' className='flex-center'>
            <label id='input-label'>Player Name</label>
            <input type="text" className='input-box-with' />
          </div>
        </div>
        <div className='col-6'>
          <div id="title">
            <h1>Second Player</h1>
          </div>
          <div id='input-div' className='flex-center'>
            <label id='input-label'>Email</label>
            <input type="email" className='input-box-with' placeholder='exemple@email.com' />
          </div>
          <div id='input-div' className='flex-center'>
            <label id='input-label'>Player Name</label>
            <input type="text" className='input-box-with' />
          </div>
        </div>
        <div className='row'>
          <div className='flex-center mt-5'>
            <input type="button" className='difficult-btn' value="Start The Game" />
          </div>
        </div>
      </div>
    </div>
  )
}

