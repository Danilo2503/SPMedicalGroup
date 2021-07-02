import { Component } from 'react';
import Header from '../../Components/header/header';
import axios from 'axios';
import {parseJwt} from '../../services/auth';
import Espaco from '../../assets/images/Espaco.png'

import '../../App.css'

class Login extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : '',
            erroMensagem : '',
            isLoading : false
        }
    }

    atualizarCampos = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value})
    }

    logar = (event) => {

        event.preventDefault()

        this.setState({erroMensagem : '', isLoading : true})

        axios.post("http://localhost:5000/api/Login", {
            email : this.state.email,
            senha : this.state.senha
        })

        .then(resposta => {
            if(resposta.status === 200)
            {
                localStorage.setItem("Usuario-login" , resposta.data.token);

                console.log('Meu token é: ' + resposta.data.token);

                this.setState({isLoading : false});

                console.log(parseJwt().role)

                switch (parseJwt().role) {
                    case '1':
                        this.props.history.push('/Administrador')
                        break;
                
                    case '2':
                        this.props.history.push('/Medico')
                        break;

                    case '3':
                        this.props.history.push('/Paciente')
                    break;

                    default:
                        this.props.history.push('/')
                    break;
                }
            }
        })
        .catch( () => {
            this.setState({erroMensagem : 'Email ou senha incorretos! Tente novamente', isLoading : false})
        })
    }

    render(){
        return(
            <div>
                <Header />
                <section className="Section-login">
                    <div className="Form-login">
                        <h2>Efetue o login para acessar o sistema</h2>
                        
                        <form onSubmit={this.logar}>

                        <input name="Email" onChange={this.atualizarCampos} value={this.state.email} type="email" placeholder="Digite seu email" required></input>

                        <input name="Senha" onChange={this.atualizarCampos}  value={this.state.senha} type="password" placeholder="Digite sua senha" required></input>

                        <p className="Erro">{this.state.erroMensagem}</p>

                        <button type="Submit">Conectar</button>
                        </form>
                    </div>
                </section>
            </div>
        )
    }
} 

export default Login;