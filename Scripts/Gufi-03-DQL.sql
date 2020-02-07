-- ESCOLHER BANCO DE DADOS A SER USADO


SELECT * FROM TipoEvento
SELECT * FROM TipoUsuario
SELECT * FROM Usuario
SELECT * FROM Instituicao
SELECT * FROM Presenca
SELECT * FROM Evento

-- LISTAR TODOS OS USUÁRIOS
SELECT NomeUsuario, Email, IdTipoUsuario, Genero, DataNascimento FROM Usuario 

-- LISTAR TODOS OS USUÁRIOS SEM MOSTRAR DEMAIS ID
SELECT Usuario.NomeUsuario, Usuario.Email, Usuario.DataNascimento, Usuario.Genero, TipoUsuario.TituloTipoUsuario
FROM Usuario
INNER JOIN TipoUsuario on Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario
WHERE Usuario.IdTipoUsuario > 0

-- LISTAR AS INSTITUIÇÕES
SELECT Cnpj, NomeFantasia, Endereco FROM Instituicao

-- LISTAR OS TIPOS DE EVENTOS
SELECT TituloTipoEvento FROM TipoEvento

-- LISTAR TODOS OS EVENTOS SEM MOSTRAR DEMAIS ID 
SELECT NomeEvento, TipoEvento.TituloTipoEvento, Evento.Descricao, AcessoLivro, Instituicao.NomeFantasia, Instituicao.Endereco FROM Evento
INNER JOIN TipoEvento on Evento.IdTipoEvento = TipoEvento.IdTipoEvento
INNER JOIN Instituicao on Instituicao.IdInstituicao = Evento.IdInstituicao

-- LISTAR TODOS EVENTOS PUBLICOS SEM MOSTRAR DEMAIS ID
SELECT NomeEvento, TipoEvento.TituloTipoEvento, Evento.Descricao, AcessoLivro, Instituicao.NomeFantasia, Instituicao.Endereco FROM Evento
INNER JOIN TipoEvento on Evento.IdTipoEvento = TipoEvento.IdTipoEvento
INNER JOIN Instituicao on Instituicao.IdInstituicao = Evento.IdInstituicao
WHERE AcessoLivro = 1

-- LISTAR EVENTOS QUE UM DETERMINADO USUARIO PARTICIPA 
SELECT Evento.NomeEvento, TipoEvento.TituloTipoEvento, Evento.DataEvento, Evento.AcessoLivro, Evento.Descricao, Instituicao.NomeFantasia, Instituicao.Endereco, Usuario.NomeUsuario, Usuario.DataNascimento, Usuario.Genero  FROM Presenca
INNER JOIN Evento on Presenca.IdEvento = Evento.IdEvento
INNER JOIN Usuario on Usuario.IdUsuario = Presenca.IdUsuario 
INNER JOIN TipoEvento on TipoEvento.IdTipoEvento = Evento.IdTipoEvento
INNER JOIN Instituicao on Instituicao.IdInstituicao = Evento.IdInstituicao
WHERE Presenca.IdUsuario = 2

-- LISTAR EVENTOS TROCANDO 1/0 POR PÚBLICO E PRIVADO
SELECT NomeEvento, TipoEvento.TituloTipoEvento, Evento.Descricao, CASE WHEN AcessoLivro = 1 THEN 'Publico' ELSE 'Privado' END, Instituicao.NomeFantasia, Instituicao.Endereco FROM Evento
INNER JOIN TipoEvento on Evento.IdTipoEvento = TipoEvento.IdTipoEvento
INNER JOIN Instituicao on Instituicao.IdInstituicao = Evento.IdInstituicao

-- CADASTRAR 3 PESSOAS E AO LISTAR OS USUÁRIOS, MOSTRAR A IDADE
INSERT INTO Usuario(IdTipoUsuario, NomeUsuario, Email, Senha, Genero, DataNascimento)
VALUES (2, 'Joao', 'joao.santos.farias.2003@gmail.com', 'joao321', 'Masculino', '10/03/2003'), (2, 'Lucas', 'lucas.2003@gmail.com', 'lulu321', 'feminino', '07/02/2003'), (2, 'Gustavo', 'gustavo@gmail.com', 'gus321', 'Masculino', '10/08/2005')

SELECT Usuario.NomeUsuario, Usuario.Email, DATEDIFF(YEAR, Usuario.DataNascimento, GETDATE()) AS Idade, Usuario.Genero, TipoUsuario.TituloTipoUsuario
FROM Usuario
INNER JOIN TipoUsuario on Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario
WHERE Usuario.IdTipoUsuario > 0














