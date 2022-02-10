import 'TicTacToe/tictactoe-style.css';

export default function VsComputer() {
    return (
        <div id='tictactoe' className='container-fluid flex-center'>
            <div id='register'>
                <div id='input-div'>
                    <label id='input-label'>Email</label>
                    <input type="email" className='input-box-with' placeholder='exemple@email.com' />
                </div>
                <div id='input-div'>
                    <label id='input-label'>Player Name</label>
                    <input type="text" className='input-box-with' />
                </div>
                <div>
                    <input type="button" className='difficult-btn' value="Easy" />
                </div>
                <div>
                    <input type="button" className='difficult-btn' value="Intermediate" />
                </div>
                <div>
                    <input type="button" className='difficult-btn' value="Hard" />
                </div>
            </div>
        </div>
    )
}

