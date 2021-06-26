USE SP_Medical_Group;
GO

SELECT * FROM TiposUsuarios;
SELECT * FROM Usuarios;
SELECT * FROM Pacientes;
SELECT * FROM Clinicas;
SELECT * FROM Especialidades;
SELECT * FROM Medicos;
SELECT * FROM Situacoes;
SELECT * FROM Consultas;

SELECT IdUsuario, TU.NomeTipoUsuario AS Tipo, EmailUsuario FROM Usuarios U
INNER JOIN TiposUsuarios TU
ON U.IdTipoUsuario = TU.IdTipoUsuario;

SELECT 
	IdClinica
	,Nome
	,CNPJ
	,RazaoSocial
	,Endereco
FROM Clinicas;

SELECT 
	IdMedico
	,U.EmailUsuario
	,CRM
	,E.NomeEspecialidade AS Especialidade
	,C.Nome AS [Clínica]
FROM Medicos M
INNER JOIN Usuarios U
ON M.IdUsuario = U.IdUsuario
INNER JOIN Clinicas C
ON M.IdClinica = C.IdClinica
INNER JOIN Especialidades E
ON M.IdEspecialidade = E.IdEspecialidade;

SELECT
	IdConsulta
	,P.Nome AS Paciente
	,S.NomeSituacao AS [Situação]
	,FORMAT(DataConsulta, 'd', 'pt-bt') AS [Data da Consulta]
FROM Consultas C
INNER JOIN Pacientes P
ON C.IdPaciente = P.IdPaciente
INNER JOIN Medicos M
ON C.IdMedico = M.IdMedico
INNER JOIN Situacoes S
ON C.IdSituacao = S.IdSituacao;



