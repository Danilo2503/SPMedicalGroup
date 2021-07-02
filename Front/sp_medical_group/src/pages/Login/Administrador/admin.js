import { Link } from 'react-router-dom';
import Header from '../../Components/header/header'
import React, { useState, useEffect } from 'react';
import axios from 'axios';

import '../../App.css';

export default function Administrador() {


    const [idPaciente, setIdPaciente] = useState(0)
    console.log(idPaciente)

    const [idMedico, setIdMedico] = useState(0)
    console.log(idMedico)

    const [idStatusConsulta, setIdStatusConsulta] = useState(0)
    console.log(idStatusConsulta)

    const [dataConsulta, setDataConsulta] = useState("")
    console.log(dataConsulta)

    const [hroConsulta, setHroConsulta] = useState("")
    console.log(hroConsulta)


    const [descricaoConsulta, setDescricaoConsulta] = useState("")
    console.log(descricaoConsulta)

    const [isLoading, setIsLoading] = useState(false)
    console.log(isLoading)

    const [listaConsultas, setListaConsultas] = useState([])
    const [listaMedicos, setListaMedicos] = useState([])
    const [listaPacientes, setListaPacientes] = useState([])

    const [idTipoUsuario, setIdTipoUsuario] = useState(0)
    const [nome, setNome] = useState('')
    const [email, setEmail] = useState('')
    const [senha, setSenha] = useState('')

    const [listaUsuarios, setListaUsuarios] = useState([])
    const [listaTiposUsuarios, setTiposUsuarios] = useState([])

    function getConsultas() {
        axios.get('http://localhost:5000/api/Consulta')
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaConsultas(resposta.data)
                }
            })
            .catch(erro => console.log(erro))
    }

    function getUsers() {
        axios.get('http://localhost:5000/api/Usuario', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('Usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaUsuarios(resposta.data)
                    console.log('Listando usuários')
                }
            })
    }

    function getMedicos() {
        axios.get('http://localhost:5000/api/Medico', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('Usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaMedicos(resposta.data)
                }
            })
            .catch(erro => console.log(erro))
    }

    function getPacientes() {
        axios.get('http://localhost:5000/api/Paciente', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('Usuario-login')
            }
        })

            .then(resposta => {
                if (resposta.status === 200) {
                    setListaPacientes(resposta.data)
                }
            })
            .catch(erro => console.log(erro))
    }

    function getTypeUser() {
        axios.get('http://localhost:5000/api/Tiposusuario', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('Usuario-login')
            }
        })

            .then(resposta => {
                if (resposta.status === 200) {
                    setTiposUsuarios(resposta.data)
                }
            })
            .catch(erro => console.log(erro))
    }

    function postConsultas(event) {

        event.preventDefault()

        setIsLoading(true)

        axios.post('http://localhost:5000/api/Consulta', {

            idPaciente: idPaciente,
            idMedico: idMedico,
            dataConsulta: dataConsulta,
            hroConsulta: hroConsulta,
            idStatusConsulta: idStatusConsulta,
            descricaoConsulta: descricaoConsulta

        }, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('Usuario-login')
            }
        })

            .then(resposta => {

                if (resposta.status === 202) {
                    console.log('Consulta cadastrada')
                    setIsLoading(false)
                }
            })
            .catch(erro => {
                console.log(erro)
                setIsLoading(false)
            })

    };

    useEffect(getConsultas, [])
    useEffect(getUsers, [])
    useEffect(getMedicos, [])
    useEffect(getPacientes, [])
    useEffect(getTypeUser, [])

    function createUsers(event) {
        event.preventDefault()

        axios.post('http://localhost:5000/api/Usuario', {
            idTipoUsuario: idTipoUsuario,
            nome: nome,
            email: email,
            senha: senha

        }, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('Usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 201) {
                    console.log('Usuário cadastrado')
                }
            })
            .catch((erro) => console.log(erro))
    }

    return (
        <div>
            <Header />
            <Link to="/"><h3 className="Logout">Sair</h3></Link>
            <section className="Section-cadastrar-consulta cadastrar">
                <h1>Cadastrar consultas</h1>
                <div className="Cadastrar-consulta">
                    <form className="CadastrarConsulta" onSubmit={postConsultas}>

                        <h2>Nome do paciente:</h2>
                        <select name="idPaciente"
                            value={idPaciente}
                            onChange={(event) => setIdPaciente(event.target.value)}
                        >
                            <option value="0">Pacientes</option>
                            {
                                listaPacientes.map(pacientes => {
                                    return (
                                        <option key={pacientes.idPaciente} value={pacientes.idPaciente}>
                                            {pacientes.nomePaciente}
                                        </option>
                                    )
                                })
                            }
                        </select>

                        <h2>Nome do médico</h2>
                        <select name="idMedico"
                            value={idMedico}
                            onChange={(event) => setIdMedico(event.target.value)}
                        >
                            <option value="0">Médico</option>
                            {
                                listaMedicos.map(medico => {
                                    return (
                                        <option key={medico.idMedico} value={medico.idMedico}>
                                            {medico.nomeMedico}
                                        </option>
                                    )
                                })
                            }
                        </select>

                        <h2>Data da consulta</h2>
                        <input
                            type="date"
                            placeholder="Data da consulta"
                            required
                            name="dataConsulta"
                            value={dataConsulta}
                            onChange={(event => setDataConsulta(event.target.value))}
                        />

                        <h2>Horário da consulta</h2>
                        <input
                            type="time"
                            placeholder="Horário da consulta"
                            required
                            name="hroConsulta"
                            value={hroConsulta}
                            onChange={(event) => setHroConsulta(event.target.value)}
                        />

                        <h2>Status da Consulta</h2>
                        <select name="idStatusConsulta" value={idStatusConsulta} onChange={(event) => setIdStatusConsulta(event.target.value)}>
                            <option disabled value="0">X----Selecione um Status----X</option>
                            <option value="1">Agendada</option>
                            <option value="2">Realizada</option>
                            <option value="3">Cancelada</option>
                        </select>

                        <h2>Descrição da consulta</h2>
                        <input
                            type="text"
                            placeholder="Descrição da consulta"
                            required
                            name="descricaoConsulta"
                            value={descricaoConsulta}
                            onChange={(event) => setDescricaoConsulta(event.target.value)}
                        />

                        <button type="submit">Cadastrar</button>
                    </form>
                </div>
            </section>
            <section className="Section-consultas">
                <h1>Consultas</h1>
                <table>
                    <thead>
                        <tr>
                            <th>Médico</th>
                            <th>Pacientes</th>
                            <th>Especialidade</th>
                            <th>Data</th>
                            <th>Horário</th>
                            <th>Status</th>
                            <th>Descrição</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            listaConsultas.map((consultas) => {
                                return (
                                    <tr key={consultas.idConsulta}>
                                        <td>{consultas.idMedicoNavigation.nomeMedico}</td>
                                        <td>{consultas.idPacienteNavigation.nomePaciente}</td>
                                        <td>{consultas.idMedicoNavigation.idEspecialidadeNavigation.descricaoEspec}</td>
                                        <td>{consultas.dataConsulta}</td>
                                        <td>{consultas.idConsulta.hroConsulta}</td>
                                        <td>{consultas.idStatusConsultaNavigation.statusConsulta}</td>
                                        <td>{consultas.descricaoConsulta}</td>
                                    </tr>
                                )
                            }
                            )
                        }
                    </tbody>
                </table>
            </section>

            <section className="Section-cadastrar-consulta">
                <h1>Cadastrar usuários</h1>
                <div className="Cadastrar-consulta">
                    <form className="CadastrarConsulta" onSubmit={createUsers}>
                        <h2>Tipo de usuário</h2>
                        <select name="idTipoUsuario"
                            value={idTipoUsuario}
                            onChange={(event) => setIdTipoUsuario(event.target.value)}>

                            <option Disabled >----Selecione o tipo de usuario----</option>
                            {
                                listaTiposUsuarios.map(usuarios => {
                                    return (
                                        <option key={usuarios.idTipoUsuario} value={usuarios.idTipoUsuario}>
                                            {usuarios.nome}
                                        </option>
                                    )
                                })
                            }

                        </select>

                        <h2>Nome</h2>
                        <input type="text"
                            value={nome}
                            onChange={(event) => setNome(event.target.value)}
                            required
                            placeholder="Digite o nome de usuário:"
                            name="name"
                        />

                        <h2>Email</h2>
                        <input type="email"
                            value={email}
                            onChange={(event) => setEmail(event.target.value)}
                            required
                            placeholder="Digite seu email:"
                            name="email"
                        />

                        <h2>Senha</h2>
                        <input type="password"
                            minlength="5"
                            value={senha}
                            onChange={(event) => setSenha(event.target.value)}
                            required
                            placeholder="Digite sua senha:"
                            name="senha"
                        />
                        <button type="submit">Cadastrar</button>
                    </form>
                </div>
            </section>
            <section className="Section-consultas">
                <h1>Usuários</h1>
                <table>
                    <thead>
                        <tr>
                            <th>Tipo de usuário</th>
                            <th>Id</th>
                            <th>Nome</th>
                            <th>Email</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            listaUsuarios.map((usuarios) => {
                                return (
                                    <tr key={usuarios.idUsuario}>

                                        <td>{usuarios.idTipoUsuario}</td>
                                        <td>{usuarios.idUsuario}</td>
                                        <td>{usuarios.nome}</td>
                                        <td>{usuarios.email}</td>
                                    </tr>
                                )
                            }
                            )
                        }
                    </tbody>
                </table>
            </section>
        </div>
    )
}
