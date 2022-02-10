export type GameRequest = {
    isComputer: boolean
    idGame: number,
    playerName: string,
    moveTo: string,
    difficulty: string,
    possibleMoves: []
}

export type GameComputerRequest = {
    idGame: number,
    difficulty: string,
    possibleMoves: []
}

export type RegisterPlayersRequest = {
    isComputer: boolean,
    listPlayers:[],
    easy: boolean
    intermediate: boolean
    hard: boolean
}

export type Player = {
    name: string,
    email: string,
    startFirst: boolean
}

export type GameResponse = {
    idGame: number,
    haveWinner: boolean,
    winnerName: string,
    gameFinished: boolean,
    state: string,
    difficulty: string,
    possibleMoves: []
}