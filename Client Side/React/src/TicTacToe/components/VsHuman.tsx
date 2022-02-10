import 'TicTacToe/tictactoe-style.css';

export default function VsHuman() {
  return (
    <div  className='display-none'>
      <div className='input-div'>
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
      <div className='input-div'>
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
      <div className='input-div'>
        <div id='input-div' className='flex-center mt-4'>
          <h3 id='input-label'>Ready !!!</h3>
          <input type="button" className='difficult-btn' value="Start The Game" />
        </div>
      </div>
    </div>
  )
}

