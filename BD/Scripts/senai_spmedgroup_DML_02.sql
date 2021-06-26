USE SP_Medical_Group;
GO

INSERT INTO TiposUsuarios (NomeTipoUsuario)
VALUES		('Administrador')
			,('Paciente')
			,('Médico')
GO

INSERT INTO Usuarios (IdTipoUsuario, NomeUsuario, EmailUsuario, SenhaUsuario)
VALUES		(1, 'Ricardo Lemos', 'adm@spmedical.com', 'admin')
			,(3, 'Ligia', 'ligia.senai@spmedical.com', 'ver234')
			,(2, 'Roberto Possarle', 'rpossarle@smedical.com', 'ric128')
			,(3, 'Roberto Silva', 'robertosilva@spmedial.com', 'asf987')
			,(3, 'Marcelo', 'marcelo@spmedical.com', 'msc698')
			,(3, 'Otávio', 'otavio.augusto@spmedical.com', 'psr991')
			,(3, 'Nayara', 'nayara@spmedical.com', 'cra997')
			,(2, 'Esther', 'esther@spmedical.com', 'fer430')
			,(2, 'Leonardo', 'leonardo1503@spmedical.com', 'enz050')
GO

INSERT INTO Pacientes (IdUsuario, CPF, RG, DataNascimento, Telefone, Endereco, Nome)
VALUES		(3, '43923256914', '520689972', '15/07/1983', '11929824476', 'Rua Homero Sales,14', 'Ligia')
			,(8, '97356387518', '491204599', '28/02/2000', '11958903321', 'Av. Mutinga,89', 'Roberto Silva')
			,(9, '27934912924', '389294523', '02/12/1990', '11992569408', 'Rua José Rufino Freire,349', 'Marcelo')
			,(2, '12098335769', '221346795', '17/07/1976', '11976543782', 'Rua Argemiro Couto,49', 'Otávio')
			,(6, '33076242078', '982334788', '04/08/1993', '11976536179', 'Rua William Roberto Bank,19', 'Nayara')
			,(7, '57889327899', '785125547', '31/05/1967', '11965674187', 'Rua Francisco de Assis,1278', 'Roberto Possarle')
			,(5, '87267022410', '837241234', '25/03/1980', '11971396483', 'Av. Paulista,2000', 'Leonardo')
GO

INSERT INTO Clinicas (Nome, CNPJ, Endereco, RazaoSocial)
VALUES		('Clínica Silva', '52122609002254', 'Av. Barão Limeira,532', 'SP Medical Group')
GO

INSERT INTO Especialidades (NomeEspecialidade)
VALUES ('Acunpuntura')
	   ,('Anestesiologia')
	   ,('Angiologia')
	   ,('Cardiologia')
	   ,('Cirurgia Cardiovascular')
	   ,('Cirurgia da Mão')
	   ,('Cirurgia do Aparelho Disgestivo')
	   ,('Cirurgia Geral')
	   ,('Cirurgia Pediátrica')
	   ,('Cirurgia Plástica')
	   ,('Cirurgia Torácica')
	   ,('Cirurgia Vascular')
	   ,('Dermatologia')
	   ,('Radioterapia')
	   ,('Urologia')
	   ,('Pediatria')
	   ,('Psiquiatria')
GO

INSERT INTO Medicos (IdUsuario, IdClinica, IdEspecialidade, CRM)
VALUES (4, 1, 5, '32982'),
	   (9, 1, 14, '79534'),
	   (2, 1, 3, '33790');
GO

INSERT INTO Situacoes (NomeSituacao)
VALUES ('Agendada'),
	   ('Finalizada'),
	   ('Cancelada');
GO

INSERT INTO Consultas (IdPaciente, IdMedico, DataConsulta)
VALUES (10, 5, '20/01/2020  15:00'),
	   (4, 3, '06/01/2020  10:00'),
	   (6, 3, '07/02/2020  11:00'),
	   (4, 3, '06/02/2018  10:00'),
	   (7, 1, '07/02/2019  11:00'),
	   (10, 5, '08/03/2020  15:00'),
	   (7, 1, '09/03/2020  11:00');
GO