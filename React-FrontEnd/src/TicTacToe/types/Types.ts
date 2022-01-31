export type Game = {
    player: Player,
    computer: Computer,
    shift: Shift,
    board: Board,
    winner: string
}

export type Player = {
    player1: string,
    player2: string,
}

export type Computer = {
    name: string,
    active: boolean,
    easy: boolean,
    intermediate: boolean,
    hard: boolean
}

export type Shift = {
    symbol: string,
}

export type Board = {
    board: []
}