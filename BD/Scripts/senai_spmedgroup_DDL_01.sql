CREATE DATABASE SP_Medical_Group;
GO

USE SP_Medical_Group;
GO

CREATE TABLE TiposUsuarios
(
	IdTipoUsuario			INT PRIMARY KEY IDENTITY
	,NomeTipoUsuario		VARCHAR(200) NOT NULL
);
GO

CREATE TABLE Usuarios
(
	IdUsuario				INT PRIMARY KEY IDENTITY
	,IdTipoUsuario			INT FOREIGN KEY REFERENCES TiposUsuarios (IdTipoUsuario)
	,NomeUsuario			VARCHAR(140) NOT NULL
	,EmailUsuario			VARCHAR(120) NOT NULL
	,SenhaUsuario			VARCHAR(120) NOT NULL
);
GO

CREATE TABLE Pacientes
(
	IdPaciente				INT PRIMARY KEY IDENTITY
	,IdUsuario				INT FOREIGN KEY REFERENCES Usuarios (IdUsuario)
	,CPF					CHAR(11) NOT NULL
	,RG						CHAR(9) NOT NULL
	,DataNascimento			DATE NOT NULL
	,Telefone				VARCHAR(15) NOT NULL
	,Endereco				VARCHAR(350) NOT NULL
	,Nome					VARCHAR(200) NOT NULL
);
GO

CREATE TABLE Clinicas
(
	IdClinica				INT PRIMARY KEY IDENTITY
	,Nome					VARCHAR(200) NOT NULL
	,CNPJ					CHAR(14) NOT NULL
	,RazaoSocial			VARCHAR(350) NOT NULL
	,Endereco				VARCHAR(300) NOT NULL
);
GO

CREATE TABLE Especialidades
(
	IdEspecialidade			INT PRIMARY KEY IDENTITY
	,NomeEspecialidade		VARCHAR(300) NOT NULL
);
GO

CREATE TABLE Medicos
(
	IdMedico				INT PRIMARY KEY IDENTITY
	,IdUsuario				INT FOREIGN KEY REFERENCES Usuarios (IdUsuario) NOT NULL
	,IdClinica				INT FOREIGN KEY REFERENCES Clinicas (IdClinica) NOT NULL
	,IdEspecialidade		INT FOREIGN KEY REFERENCES Especialidades (IdEspecialidade) NOT NULL
	,CRM					CHAR(5) NOT NULL
);
GO

CREATE TABLE Situacoes
(
	IdSituacao				INT PRIMARY KEY IDENTITY
	,NomeSituacao			VARCHAR(300)
);
GO

CREATE TABLE Consultas
(
	IdConsulta				INT PRIMARY KEY IDENTITY
	,IdPaciente				INT FOREIGN KEY REFERENCES Pacientes (IdPaciente)
	,IdMedico				INT FOREIGN KEY REFERENCES Medicos (IdMedico)
	,DataConsulta		    DATETIME NOT NULL
	,IdSituacao				INT FOREIGN KEY REFERENCES Situacoes (IdSituacao) DEFAULT 1
);
GO