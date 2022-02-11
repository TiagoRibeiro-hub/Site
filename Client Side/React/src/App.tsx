import {
  BrowserRouter,
  Routes,
  Route
} from "react-router-dom";
import Home from 'page/Home/Home';
import TicTacToe from 'page/TicTacToe/Tictactoe';
import Chess from 'page/Chess/Chess';
import TicTacToeGame from "Games/TicTacToe/components/TicTacToeGame";

function App() {
  return (
    <BrowserRouter>
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/TicTacToe" element={<TicTacToe />} />
      <Route path="/TicTacToeGame" element={<TicTacToeGame />} />
      <Route path="/Chess" element={<Chess />} />
    </Routes>
  </BrowserRouter>
  );
}

export default App;
