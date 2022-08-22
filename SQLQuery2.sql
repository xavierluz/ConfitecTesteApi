BEGIN TRAN
INSERT INTO Escolaridades(Descricao, TipoEscolaridade)
VALUES('Infantil',1)

INSERT INTO Escolaridades(Descricao, TipoEscolaridade)
VALUES('Fundamental',2)

INSERT INTO Escolaridades(Descricao, TipoEscolaridade)
VALUES('Médio',3)

INSERT INTO Escolaridades(Descricao, TipoEscolaridade)
VALUES('Superior',4)
--ROLLBACK
--COMMIT