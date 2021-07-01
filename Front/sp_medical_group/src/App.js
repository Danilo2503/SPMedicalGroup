import Header from './Components/header/header'
import Banner from '../src/assets/images/Banner.png'

import './App.css';

function App(){
  return(
    <div>
      <Header>
        <main>
          <div className="Banner">
            <img src={Banner} alt="caricatura de médica com diversas siringas ao seu redor"></img>
            <div className="Historia">
              <h2>Junte-se a nós</h2>
            </div>
            <div id="Sobre-nos" className="Sobre">
              <h1>Sobre</h1>
              <div className="Paragrafo1">
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam urna dui, fringilla id lectus vestibulum, fermentum pulvinar ex. Vivamus vel pulvinar mi. Vivamus tristique, nibh quis condimentum porttitor, risus ex ornare erat, at maximus tellus risus ac est. Morbi semper, mauris nec lacinia consectetur, ipsum enim iaculis purus, at fringilla justo neque id augue. Vestibulum faucibus tellus id leo accumsan egestas. In tempor lacus in feugiat mattis. Pellentesque vestibulum augue lacus, ac iaculis ante blandit ut. Ut neque mauris, porttitor eget tincidunt quis, porttitor efficitur ante. Vivamus id libero quis velit ultricies mollis.</p>
              </div>
            </div>
            <div className="Barra"></div>
            <div className="Sobre2">
              <div className="Paragrafo2">
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam urna dui, fringilla id lectus vestibulum, fermentum pulvinar ex. Vivamus vel pulvinar mi. Vivamus tristique, nibh quis condimentum porttitor, risus ex ornare erat, at maximus tellus risus ac est. Morbi semper, mauris nec lacinia consectetur, ipsum enim iaculis purus, at fringilla justo neque id augue. Vestibulum faucibus tellus id leo accumsan egestas. In tempor lacus in feugiat mattis. Pellentesque vestibulum augue lacus, ac iaculis ante blandit ut. Ut neque mauris, porttitor eget tincidunt quis, porttitor efficitur ante. Vivamus id libero quis velit ultricies mollis.</p>
              </div>
            </div>
          </div>
        </main>
      </Header>
    </div>
  )
}

export default App;
