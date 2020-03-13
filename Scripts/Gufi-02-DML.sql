-- ESCOLHER BANCO DE DADOS A SER USADO
USE Gufi_Tarde;

SELECT * FROM TipoEvento
SELECT * FROM TipoUsuario
SELECT * FROM Usuario
SELECT * FROM Instituicao
SELECT * FROM Presenca
SELECT * FROM Evento

INSERT INTO TipoUsuario(TituloTipoUsuario)
VALUES ('Administrador'), ('Comum');

INSERT INTO TipoEvento(TituloTipoEvento)
VALUES ('C#'), ('React'), ('SQL');

INSERT INTO Instituicao(Cnpj, NomeFantasia, Endereco)
VALUES ('11111111111111', 'Escola SENAI de inform�tica','Alameda Bar�o de Limeira, 538');

INSERT INTO Usuario(IdTipoUsuario, NomeUsuario, Email, Senha, Genero, DataNascimento)
VALUES (1, 'Administrador', 'adm@adm.com', 'adm123', 'N�o informado', '06/02/2020');

INSERT INTO Usuario(IdTipoUsuario, NomeUsuario, Email, Senha, Genero, DataNascimento)
VALUES (2, 'Carol', 'carol@email.com', 'carol123', 'Feminino', '06/02/2020'),(2, 'Saulo', 'saulo@email.com', 'saulo123', 'Masculino', '06/02/2020');

INSERT INTO Evento(IdInstituicao, IdTipoEvento, NomeEvento, Descricao, DataEvento, AcessoLivro)
VALUES (1, 1, 'Introdu��o ao C#', 'Conceitos sobre os pilares da programa��o orientada a objetos', '07/02/2020', 1)

INSERT INTO Evento(IdInstituicao, IdTipoEvento, NomeEvento, Descricao, DataEvento, AcessoLivro)
VALUES (1, 3, 'Optimiza��o de banco de dados', 'Aplica��o de indices clusterizados e n�o clusterizados', '07/02/2020', 0), (1, 2, 'Ciclo de vida', 'Como utilizar o ciclo de vida com ReactJs', '07/02/2020', 1);

INSERT INTO Presenca(IdUsuario, IdEvento)
VALUES (2, 2), (2, 3), (3, 1);


