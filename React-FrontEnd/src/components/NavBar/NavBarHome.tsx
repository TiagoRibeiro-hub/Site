import { ReactComponent as GithubIcon } from "assets/img/github.svg";
import { Link } from "react-router-dom";
import 'components/NavBar/navbarStyle.css';

export default function NavBar() {
    return (
        <header>
            <nav className="container">
                <div className="row home-nav-content">
                    <a className='col-3' href="https://github.com/TiagoRibeiro-hub" target="_blank" rel="noreferrer">
                        <div className="home-contact-container">
                            <p className="home-contact-link">Tiago Ribeiro/</p>
                            <GithubIcon id="githubIcon" />
                        </div>
                    </a>
                    <div className="col-9 d-flex align-items-center justify-content-end">
                        <a className="meu-links" href="https://sr-movie.netlify.app/" target="_blank" rel="noreferrer">
                            <h6>Review Movie</h6>
                        </a>
                        <Link className="meu-links" to={'/tictactoe'} target="_blank" rel="noreferrer">
                            <h6>TicTacToe</h6>
                        </Link>
                        <Link className="meu-links" to={'/chess'} target="_blank" rel="noreferrer">
                            <h6>Chess</h6>
                        </Link>
                    </div>
                </div>
            </nav>
        </header>
    );
}

