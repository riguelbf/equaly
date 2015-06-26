-- carga setor
INSERT INTO dbo.Setor VALUES('Administração do sistema','ADM001')
SELECT * from dbo.Setor

-- carga de nivel acesso
INSERT INTO dbo.NiveisAcesso VALUES('A',1)
SELECT * FROM dbo.NiveisAcesso

-- carga de usuario admin
INSERT INTO dbo.Usuario VALUES('Riguel Figueiro','riguel','280683','123456','riguel@dkosoftware.com.br',1,1);
SELECT * from usuario

--carga inicial dos menus
INSERT INTO Menu VALUES('Dashboard','icon-home',1,'Index','Dashboard')
INSERT INTO Menu VALUES('Não conformidades','icon-cogs',2,'Index','NaoConformidadeController')
INSERT INTO Menu VALUES('Documentos','icon-file-text',3,'Index','DocumentoController')
INSERT INTO Menu VALUES('Indicadores','icon-bar-chart',4,'Index','IndicadoresController')
SELECT * FROM dbo.Menu

-- carga inicial para submenus
INSERT INTO MenuItem VALUES('Ação Corretiva','Index','AcaoCorretivaController','','',1)
INSERT INTO MenuItem VALUES('Ação Preventiva','Index','AcaoPreventivaController','','icon-briefcase',2)
INSERT INTO MenuItem VALUES('Gerenciar documentos','GerenciarDocumentos','DocumentoController','','',1)
INSERT INTO MenuItem VALUES('Gerenciar Indicadores','GerenciarIndicadores','IndicadoresController','','',1)
SELECT * FROM dbo.MenuItem

-- carga para niveisAcessoMenu
INSERT INTO dbo.NiveisAcessoMenu VALUES(1,1)
INSERT INTO dbo.NiveisAcessoMenu VALUES(1,2)
INSERT INTO dbo.NiveisAcessoMenu VALUES(1,3)
INSERT INTO dbo.NiveisAcessoMenu VALUES(1,4)
SELECT * FROM dbo.NiveisAcessoMenu

-- carga permissao
INSERT INTO dbo.Permissaos VALUES(1,1,1,1)
SELECT * FROM dbo.Permissaos

-- carga menuPermissao
INSERT INTO dbo.menuPermissaos VALUES(1,1)
INSERT INTO dbo.menuPermissaos VALUES(2,1)
INSERT INTO dbo.menuPermissaos VALUES(3,1)
INSERT INTO dbo.menuPermissaos VALUES(4,1)
SELECT * FROM dbo.menuPermissaos

-- carga menuItemPermissaos
INSERT INTO dbo.MenuItemPermissaos VALUES(1,1)
INSERT INTO dbo.MenuItemPermissaos VALUES(2,1)
INSERT INTO dbo.MenuItemPermissaos VALUES(3,1)
INSERT INTO dbo.MenuItemPermissaos VALUES(4,1)
SELECT * FROM dbo.MenuItemPermissaos

/* RESTAR IDENTITY TABLES
BEGIN transaction
delete from MenuItemPermissaos
DBCC CHECKIDENT ('NiveisAcessoMenu', RESEED, 0)
commit
*/

/*
 Carga inicial para setores
*/
INSERT into dbo.Setor VALUES('Logistica','LOG002')
INSERT into dbo.Setor VALUES('Comercial','COM003')
INSERT into dbo.Setor VALUES('Controle Qualidade','QUA004')
INSERT into dbo.Setor VALUES('Gestão Qualidade','GEQ005')
INSERT into dbo.Setor VALUES('Administrativo','ADM006')
INSERT into dbo.Setor VALUES('Manutenção','MAT007')