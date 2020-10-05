DROP SCHEMA IF EXISTS Calopsite;
CREATE SCHEMA Calopsite;

USE Calopsite;

CREATE TABLE Login(
ID_Usuario INT NOT NULL AUTO_INCREMENT,
Usuario VARCHAR(64) NOT NULL,
Senha  VARCHAR(255) NOT NULL,
VenAssinatura date NOT NULL,
PRIMARY KEY(ID_Usuario));

CREATE TABLE Passaro(
ID_Passaro INT AUTO_INCREMENT NOT NULL,
Proprietario INT NOT NULL,
Sexo Varchar(20) NOT NULL,
Mutacao varchar(255) NOT NULL,
Descricao VARCHAR(255),
Ocupado BOOLEAN,
FOREIGN KEY (Proprietario) REFERENCES Login(ID_Usuario),
PRIMARY KEY(ID_Passaro));


CREATE TABLE Gaiola (
ID_Gaiola INT AUTO_INCREMENT NOT NULL,
Filhotes INT,
Descricao VARCHAR(255) NOT NULL,
PRIMARY KEY(ID_Gaiola)); 

CREATE TABLE Passaro_Gaiola(
ID_Passaro_Gaiola INT NOT NULL AUTO_INCREMENT,
ID_Passaro INT NOT NULL,
ID_Gaiola INT NOT NULL,
FOREIGN KEY (ID_Gaiola) REFERENCES Gaiola(ID_Gaiola),
FOREIGN KEY (ID_Passaro) REFERENCES Passaro(ID_Passaro),
PRIMARY KEY(ID_Passaro_Gaiola));

CREATE TABLE INSUMO(
ID_Insumo INT NOT NULL AUTO_INCREMENT,
Nome VARCHAR(64) NOT NULL,
Quantidade INT,
Peso FLOAT,
Preco FLOAT NOT NULL,
PRIMARY KEY(ID_Insumo));

CREATE TABLE Hist_Alimentacao(
ID_Alimentacao INT AUTO_INCREMENT NOT NULL,
ID_Racao INT NOT NULL,
Peso FLOAT NOT NULL,
ID_Gaiola INT NOT NULL,
FOREIGN KEY (ID_Gaiola) REFERENCES Gaiola(ID_Gaiola),
FOREIGN KEY (ID_Racao) REFERENCES INSUMO(ID_Insumo),
PRIMARY KEY(ID_Alimentacao));

CREATE TABLE Hist_Medicacao(
ID_Medicacao INT AUTO_INCREMENT NOT NULL,
ID_Remedio INT NOT NULL,
Quantidade INT NOT NULL,
ID_Gaiola INT NOT NULL,
FOREIGN KEY (ID_Gaiola) REFERENCES Gaiola(ID_Gaiola),
FOREIGN KEY (ID_Remedio) REFERENCES INSUMO(ID_Insumo),
PRIMARY KEY(ID_Medicacao));

#INSERT INTO Login (Usuario, Senha) VALUES ("igor", MD5("dd97813dd40be87559aaefed642c3fbb"));

#SELECT * from login where usuario = "igor" and Senha = MD5("dd97813dd40be87559aaefed642c3fbb");
#SELECT * from login;
#select MAX(ID_Passaro) from passaro;
#select * from gaiola;
#select * from Hist_Alimentacao;

#SELECT ID_Insumo, Nome FROM Insumo WHERE Peso IS NULL;

#SELECT DISTINCT Gaiola.Descricao, Gaiola.ID_Gaiola FROM Gaiola, Passaro, Passaro_Gaiola WHERE Passaro.Proprietario = 1 AND Passaro.ID_Passaro = Passaro_Gaiola.ID_Passaro AND Passaro_Gaiola.ID_Gaiola = Gaiola.ID_Gaiola;

#select ID_Insumo, Nome from Insumo where Quantidade is null;

#SELECT DISTINCT Gaiola.Descricao, Gaiola.ID_Gaiola FROM Gaiola, Passaro, Passaro_Gaiola WHERE Passaro.Proprietario = 1 AND Passaro.ID_Passaro = Passaro_Gaiola.ID_Passaro AND Passaro_Gaiola.ID_Gaiola = Gaiola.ID_Gaiola;
#SELECT DISTINCT Gaiola.Descricao, Gaiola.ID_Gaiola FROM Gaiola, Passaro, Passaro_Gaiola WHERE Passaro.Proprietario = 1 AND Passaro.ID_Passaro = Passaro_Gaiola.ID_Passaro AND Passaro_Gaiola.ID_Gaiola = Gaiola.ID_Gaiola;

#SELECT DISTINCT Insumo.Preco, Hist_Alimentacao.Peso,Insumo.Peso as inPeso FROM Gaiola, Passaro, Passaro_Gaiola,Hist_Alimentacao,Insumo WHERE Passaro.Proprietario = 1 AND Passaro.ID_Passaro = Passaro_Gaiola.ID_Passaro AND Passaro_Gaiola.ID_Gaiola = Gaiola.ID_Gaiola AND 
#Gaiola.ID_Gaiola = Hist_Alimentacao.ID_Gaiola AND Hist_Alimentacao.ID_Racao = Insumo.ID_Insumo;
