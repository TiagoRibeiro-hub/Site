import { useState } from "react";


export default function VsComputer() {

    const [playerName, SetPlayerName] = useState()

        return (
        <div> 
            <div id='register' className='container-fluid'>
                <div id='input-div'>
                    <label id='input-label'>Email</label>
                    <input type="email" className='input-box-with' placeholder='example@email.com' />
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

