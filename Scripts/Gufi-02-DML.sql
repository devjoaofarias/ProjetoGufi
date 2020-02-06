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
VALUES ('11111111111111', 'Escola SENAI de informática','Alameda Barão de Limeira, 538');

INSERT INTO Usuario(IdTipoUsuario, NomeUsuario, Email, Senha, Genero, DataNascimento)
VALUES (1, 'Administrador', 'adm@adm.com', 'adm123', 'Não informado', '06/02/2020');

INSERT INTO Usuario(IdTipoUsuario, NomeUsuario, Email, Senha, Genero, DataNascimento)
VALUES (2, 'Carol', 'carol@email.com', 'carol123', 'Feminino', '06/02/2020'),(2, 'Saulo', 'saulo@email.com', 'saulo123', 'Masculino', '06/02/2020');

-- FALTA ADICIONAR DADOS EM evento E presenca