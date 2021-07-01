import { Link } from 'react-router-dom'

export function toggleMenu(event){
    const nav = document.getElementById('nav')
    nav.classList.toggle('active')
}

export function header(){
    return(
        <header className="Header-app">
            <div className="Logo-app"><h1>SP Medical Group</h1></div>
            <div className="Menu">
                <nav id="Nav" className="Btn-menu">
                    <button id="Btn-mobile" onClick={() => toggleMenu}>
                        <span id="Hamburguer"></span>
                        <ul class="Menu">
                            <Link className="a" to="/">Home</Link>
                            <a href="#Sobre">Sobre nós</a>
                            <a href="#Contato">Contato</a>
                            <Link className="a" to="/Login">Login</Link>
                        </ul>
                    </button>
                </nav>
            </div>
        </header>
    )
}