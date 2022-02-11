
type Props = {
    X: boolean,
    O: boolean,
    index: number,
    squareClick: Function;
}

export default function Square({X, O, index, squareClick} : Props) {

    return (
        <div id='square' 
            onClick={() => squareClick(index)}
        >{X ? 'X' : (O ? 'O' : '')}</div>
    );
}

