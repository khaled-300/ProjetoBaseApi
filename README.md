# ProjetoBaseApi
Projeto base de um API em .net 5 usando serilog como logger.

Startar a aplicação app no seu local host só altera a porta no config  
troca connection string e coloca sua pode ser localDb 
cria a tabela que abixo e roda o app
no meu caso estou usando SQL Server

aqui script para rodar 

CREATE TABLE Usuario (

Id int identity(1,1) CONSTRAINT PK_Usuario_Id PRIMARY KEY
, Nome VARCHAR(200) 
, Email VARCHAR(255)
, Senha  VARCHAR(300)
, Perfis smallInt
, Ativo bit not null 
, DataCadastro DATETIME NULL CONSTRAINT DF_Usuario_DataCadastro DEFAULT GETDATE()

)
