
/*
EQUIPE: PETTWARE
ALUNOS: Caian Henrique / Milena Lucas / Julia Cardoso / Alinne Tonetti / Pedro Henrique / Amanda Teodoro

REQUISITOS FUNCIONAIS:
2.1 Fazer Login                                                                                                      
2.2 Acessar Menu                                                                                                  
2.3 Cadastrar Produtos	
2.4 Cadastrar Endereço                                                                                        
2.5 Cadastrar Cliente
2.6 Cadastrar Funcionário	
2.7 Fazer Venda	
2.8 Gerar Recebimento                                                                                         
2.9 Cadastrar Serviços	
2.10 Cadastrar Fornecedores	
2.11 Cadastrar Compra                                                                                         
2.12 Cadastrar despesas	
2.13 Gerar Caixa                                                                                                   
2.14 Consultar Caixa	
2.15 Consultar Produto	
2.16 Consultar Cliente	
2.17 Consultar Funcionário	
2.18 Cadastrar Usuário	
2.19 Gerar Relatório de Despesas	
2.20 Gerar Relatório de Vendas	
_____________________________________*/

#BANCO DE DADOS:
CREATE database BD_Pettware;
use BD_Pettware;

create table Endereco (
cod_end integer not null primary key auto_increment,
logradouro_end varchar (300),
numero_end integer,
bairro_end varchar (100),
cidade_end varchar (100)
); 

create table Cliente (
cod_cli integer not null primary key auto_increment,
nome_cli varchar (200) not null,
cpf_cli varchar (20) not null,
rg_cli varchar (30),
datanasc_cli date,
telefone_cli varchar (50),
email_cli varchar (50),
naturalidade_cli varchar (50),
nacionalidade_cli varchar (50),
cod_end int not null,
foreign key (cod_end) references Endereco (cod_end)
);

create table Fornecedor (
cod_forn integer not null primary key auto_increment,
cnpj_forn varchar (200),
nome_forn varchar (100),
telefone_forn varchar (20),
email varchar (50),
representante_forn varchar (100)
);

create table Fornecedor_Endereco (
cod_fe integer not null primary key auto_increment,
cod_forn int not null,
cod_end  int not null,
foreign key (cod_end) references Endereco (cod_end),
foreign key (cod_forn) references Fornecedor (cod_forn)
);

create table Funcionario (
cod_func integer not null primary key auto_increment,
nome_func varchar (200) not null,
cpf_func varchar (20) not null,
rg_func varchar (30),
datanasc_func date,
telefone_func varchar (50),
email_cli varchar (50),
naturalidade_func varchar (50),
nacionalidade_func varchar (50),
cod_end int not null,
foreign key (cod_end) references Endereco (cod_end)
);

create table Usuario (
cod_usu integer not null primary key auto_increment,
senha_usu varchar (30),
nome_usu varchar (30),
cod_func int not null,
foreign key (cod_func) references Funcionario (cod_func)
);

create table Caixa(
cod_caixa integer not null primary key auto_increment,
receitatotal_caixa double,
despesatotal_caixa double,
lucro_caixa double,
debito_caixa double
);

create table Venda (
cod_vend integer not null primary key auto_increment,
cod_cli int not null,
cod_func int not null,
data_vend date,
valortotal_vend double,
precocomdesconto_vend double,
formapagamento_vend varchar(50),
foreign key (cod_func) references Funcionario (cod_func),
foreign key (cod_cli) references Cliente (cod_cli)
);

create table Recebimento(
cod_receb integer not null primary key auto_increment,
cod_caixa int not null,
cod_vend int not null,
valor_receb double,
data_receb date,
foreign key (cod_caixa) references Caixa (cod_caixa),
foreign key (cod_vend) references Venda (cod_vend)
);

create table Servico(
cod_serv  integer not null primary key auto_increment,
nome_serv varchar (100) not null,
preconormal_serv double,
precocomdesconto_serv double
);

create table Produto (
cod_prod int primary key not null auto_increment,
descrição_prod varchar (50) not null,
quant_prod int,
preconormal_prod double,
precocomdesconto_serv double
);

create table Venda_Servico (
cod_vs integer not null primary key auto_increment,
cod_vend int not null,
cod_serv  int not null,
foreign key (cod_vend) references Venda (cod_vend),
foreign key (cod_serv) references Servico (cod_serv)
);

create table Venda_Produto (
cod_vp integer not null primary key auto_increment,
cod_vend int not null,
cod_prod  int not null,
foreign key (cod_vend) references Venda (cod_vend),
foreign key (cod_prod) references Produto (cod_prod)
);

create table Compra(
cod_compr integer not null primary key auto_increment,
cod_func int not null,
cod_forn int not null,
valor_compr double,
data_compr date,
foreign key (cod_func) references Funcionario (cod_func),
foreign key (cod_forn) references Fornecedor (cod_forn)
);

create table Despesa(
cod_desp integer not null primary key auto_increment,
tipo_desp varchar(50),
nome_desp varchar(100),
cod_caixa int not null,
valor_desp double,
foreign key (cod_caixa) references Caixa (cod_caixa)
);


create table Compra_Produto (
cod_cp integer not null primary key auto_increment,
cod_compr int not null,
cod_prod  int not null,
foreign key (cod_compr) references Compra (cod_compr),
foreign key (cod_prod) references Produto (cod_prod)
);

insert into Caixa values(null, 5000, 2000, 0, 0);

#PROCEDIMENTOS_________________________________________________________________________________
delimiter $$
create procedure inserirEndereco (logradouro varchar(300), numero integer, bairro varchar(100), cidade varchar(100))
begin
	IF (logradouro <> "")THEN
		IF (numero > 0) THEN
			IF (bairro <> "") THEN
				IF (cidade <> "") THEN
					insert into Endereco values (null, logradouro, numero,bairro, cidade );
                    select 'Endereço inserido com sucesso!!' as Confirmação;
				ELSE
					select 'O Campo cidade está vazio' as Erro;
				END IF;
			ELSE
				select 'O Campo bairro está vazio' as Erro;
			END IF;
        ELSE
			select 'Digite um numero maior que 0'as Erro;
        END IF;
    ELSE
		select 'O Campo logradouro está vazio'as Erro;
    END IF;
end;
$$ delimiter ; 

call InserirEndereco ('Rua Abilio Santana', 45 , 'Caipó', 'Vilhena');

delimiter $$
create procedure inserirCliente (nome varchar(200), cpf varchar(20), rg varchar(30),
 datanascimento date ,telefone varchar(50), email varchar(50), naturalidade varchar(50),
 nacionalidade varchar(50), codendereco int)
begin
declare end_aux int;
set end_aux = (select cod_end from Endereco WHERE cod_end = codendereco);

	IF (codendereco = end_aux)THEN
		IF(cpf <> '')THEN
			insert into Cliente values (null, nome, cpf,rg, datanascimento, telefone, email, naturalidade, nacionalidade,codendereco );
			select 'Cliente cadastrado com sucesso!!'as Confirmação;
		ELSE
			select 'CPF está vazio'as Confirmação;
        END IF;
	ELSE
		select 'Coleque um código de endereço válido'as Erro;
	END IF;
end;
$$ delimiter ;

call inserirCliente ('mario', '03966936283', '1527306', '2000-12-02','324555', 'joao@gmail.com', 'ji-paraná', 'Brasileiro', 1);


delimiter $$
create procedure inserirFuncionario (nome varchar(200), cpf varchar(20), rg varchar(30),
 datanascimento date ,telefone varchar(50), email varchar(50), naturalidade varchar(50),
 nacionalidade varchar(50), codendereco int)
begin
declare end_aux int;
set end_aux = (select cod_end from Endereco WHERE cod_end = codendereco);

	IF (codendereco = end_aux)THEN
		IF(rg <> '')THEN
			insert into Funcionario values (null, nome, cpf,rg, datanascimento, telefone, email, naturalidade, nacionalidade,codendereco );
			select 'Funcionário cadastrado com sucesso!!'as Confirmação;
		ELSE
			select 'RG está vazio'as Erro;
        END IF;
	ELSE
		select 'Coleque um código de endereço válido'as Erro;
	END IF;
end;
$$ delimiter ;

call inserirFuncionario ('Pedro', '4156844544', '296053', '1994-05-02','324555', 'pedrinhomatadordeporco@gmail.com', 'ji-paraná', 'Brasileiro', 1);

delimiter $$
create procedure inserirFornecedor (cnpj varchar(200), nome varchar(100), telefone varchar(20), email varchar(50), representante varchar(100))
begin
	IF (cnpj <> '')THEN
		IF (nome <> '')THEN
			IF (telefone <> '')THEN
				IF (email <> '')THEN
					IF (representante <> '')THEN
						insert into Fornecedor values (null, cnpj, nome, telefone, email, representante );
						select 'Fornecedor cadastrado com sucesso!!'as Confirmação;
					ELSE
						select 'O Campo representante está vazio'as Erro;
					END IF;
				ELSE
					select 'O Campo email está vazio'as Erro;
				END IF;
			ELSE
				select 'O Campo telefone está vazio'as Erro;
			END IF;
		ELSE
			select 'O Campo nome está vazio'as Erro;
		END IF;
    ELSE
		select 'O Campo cnpj está vazio'as Erro;
    END IF;
end;
$$ delimiter ; 

call inserirFornecedor ('22522-48', 'Wiskas sache', '2522-5784', 'Wiskasat@gmail.com', 'Lucas');

delimiter $$
create procedure inserirFornecedorEndereco (fornecedor int, endereco int)
begin
declare end_aux int;
declare forn_aux int;
set end_aux = (select cod_end from Endereco WHERE cod_end = endereco);
set forn_aux = (select cod_forn from Fornecedor WHERE cod_forn = fornecedor);
	IF (endereco = end_aux)THEN
		IF(fornecedor = forn_aux)THEN
			insert into Fornecedor_Endereco values (null, fornecedor, endereco);
            select 'Cadastro realizado com Sucesso!'as Confirmação;
		ELSE
			select 'coloque um código de fornecedor válido'as Erro;
        END IF;
	ELSE
		select 'Coleque um código de endereço válido'as Erro;
	END IF;
end;
$$ delimiter ;

call inserirFornecedorEndereco(1,1);

delimiter $$
create procedure inserirUsuario (senha varchar(30), nome varchar(30), codfunc int)
begin
declare func_aux int;
set func_aux = (select cod_func from Funcionario WHERE cod_func = codfunc);
	IF (senha <> '')THEN
		IF (nome <> '')THEN
			IF (codfunc = func_aux)THEN
			 insert into Usuario values (null, senha, nome, codfunc);
             select 'Usuario cadastrado com Sucesso!!' as Confirmação;
			ELSE
				select 'digite um código de funcionario válido'as Erro;
			END IF;
		ELSE
			select 'O Campo nome está vazio'as Erro;
		END IF;
	ELSE
	select 'O Campo senha está vazio'as Erro;
	END IF;
end;
$$ delimiter ;

call inserirUsuario('batatadoce', 'Mateus', 1);




delimiter $$
create procedure inserirVenda (codcli int, codfunc int, datavenda date, valortotal double, valorcomdesconto double, formapagamento varchar(50))
begin
declare func_aux int;
declare cli_aux int;
set func_aux = (select cod_func from Funcionario WHERE cod_func = codfunc);
set cli_aux = (select cod_cli from Cliente WHERE cod_cli = codcli);

	IF (codfunc = func_aux)THEN
		IF (codcli = cli_aux)THEN
		 Insert into Venda values(null, codcli, codfunc, datavenda, valortotal,valorcomdesconto, formapagamento);
         select 'Venda cadastrada com sucesso!!' as Confirmação;
		ELSE
			select 'digite um código de Cliente válido'as Erro;
		END IF;
	ELSE
		select 'digite um código de funcionario válido'as Erro;
	END IF;

end;
$$ delimiter ;

call inserirVenda (1,1,'2021-08-30',210,200,'Cartão Débito');

delimiter $$
create trigger atualizarCaixa after insert on Recebimento for each row
begin
update Caixa SET receitatotal_caixa = receitatotal_caixa + NEW.valor_receb WHERE cod_caixa = NEW.cod_caixa;
update Caixa SET debito_caixa = debito_caixa + despesatotal_caixa WHERE cod_caixa = NEW.cod_caixa;
update Caixa SET lucro_caixa = receitatotal_caixa - debito_caixa  WHERE cod_caixa = NEW.cod_caixa;
end;
$$ delimiter ;

delimiter $$
create procedure inserirRecebimento (codcaixa int, codvenda int, valor double, datareceb date)
begin

declare cai_aux int;
declare vend_aux int;
set cai_aux = (select cod_caixa from Caixa WHERE cod_caixa = codcaixa);
set vend_aux = (select cod_vend from Venda WHERE cod_vend = codvenda);
	IF (codcaixa = cai_aux)THEN
		IF (codvenda = vend_aux)THEN
			IF (valor > 0)THEN
				Insert into Recebimento values(null, codcaixa,codvenda,valor,datareceb);
				select 'Recebimento cadastrada com sucesso!!' as Confirmação;
			ELSE
				select 'digite um valor maior que 0'as Erro;
			END IF;
		ELSE
			select 'digite um código de Venda válido'as Erro;
		END IF;
	ELSE
		select 'digite um código de Caixa válido'as Erro;
	END IF;
end;
$$ delimiter ;

call inserirRecebimento (1,1,200,'2021-08-30');

delimiter $$
create procedure inserirServico (nome varchar(100), preco double, precocomdesconto double)
begin
	IF (nome <> '')THEN
		IF (preco > 0)THEN
			IF (precocomdesconto <= preco)THEN
				Insert into Servico values(null, nome,preco,precocomdesconto);
                select 'Serviço cadastrado com sucesso!!' as Confirmação;
			ELSE
				select 'O preco com desdonto é maior que o preço normal'as Erro;
			END IF;
		ELSE
			select 'Digite um preço maior que 0'as Erro;
		END IF;
    ELSE
			select 'O Campo nome está vazio'as Erro;
	END IF;
end;
$$ delimiter ;

call inserirServico('Banho', 50, 50);

delimiter $$
create procedure inserirProduto (descricao varchar(50), qnt int,preco double ,precocomdesconto double)
begin
	IF (descricao <> '')THEN
		IF (preco > 0)THEN
			IF (precocomdesconto <= preco)THEN
				IF (qnt > 0)THEN
					Insert into Produto values(null, descricao,qnt,preco,precocomdesconto);
					select 'Produto cadastrado com sucesso!!' as Confirmação;
				ELSE
					select 'A quantidade é menor que 1'as Erro;
				END IF;
			ELSE
				select 'O preco com desdonto é maior que o preço normal'as Erro;
			END IF;
		ELSE
			select 'Digite um preço maior que 0'as Erro;
		END IF;
    ELSE
			select 'O Campo descrição está vazio'as Erro;
	END IF;
end;
$$ delimiter ;

call inserirProduto('Ração 12kg', 7, 90, 90);

delimiter $$
create procedure inserirVendaServico (venda int, servico int)
begin
declare venda_aux int;
declare serv_aux int;
set venda_aux = (select cod_vend from Venda WHERE cod_vend = venda);
set serv_aux = (select cod_serv from Servico WHERE cod_serv = servico);
	IF (venda = venda_aux)THEN
		IF(servico = serv_aux)THEN
			insert into Venda_Servico values (null, venda,servico);
            select 'Cadastro realizado com Sucesso!'as Confirmação;
		ELSE
			select 'coloque um código de serviço válido'as Erro;
        END IF;
	ELSE
		select 'Coleque um código de venda válido'as Erro;
	END IF;
end;
$$ delimiter ;

call inserirVendaServico(1,1);

delimiter $$
create procedure inserirVendaProduto (venda int, prod int)
begin
declare venda_aux int;
declare prod_aux int;
set venda_aux = (select cod_vend from Venda WHERE cod_vend = venda);
set prod_aux = (select cod_prod from Produto WHERE cod_prod = prod);
	IF (venda = venda_aux)THEN
		IF(prod = prod_aux)THEN
			insert into Venda_Produto values (null, venda,prod);
            select 'Cadastro realizado com Sucesso!'as Confirmação;
		ELSE
			select 'coloque um código de produto válido'as Erro;
        END IF;
	ELSE
		select 'Coleque um código de venda válido'as Erro;
	END IF;
end;
$$ delimiter ;

call inserirVendaProduto(1,1);

delimiter $$
create procedure inserirCompra (codfunc int, codforn int, valor double, datacompra date)
begin
declare func_aux int;
declare forn_aux int;
set func_aux = (select cod_func from Funcionario WHERE cod_func = codfunc);
set forn_aux = (select cod_forn from Fornecedor WHERE cod_forn = codforn);

	IF(valor > 0)THEN
		IF (codfunc= func_aux)THEN
			IF(codforn = forn_aux)THEN
				insert into Compra values (null, codfunc,codforn,valor,datacompra);
				select 'Compra cadastrada com Sucesso!'as Confirmação;
			ELSE
				select 'coloque um código de fornecedor válido'as Erro;
			END IF;
		ELSE
			select 'Coleque um código de funcionario válido'as Erro;
		END IF;
    ELSE
		select 'Digite um Valor maior que 0'as Erro;
    END IF;
end;
$$ delimiter ;

call inserirCompra(1,1, 1000, '2021-03-15');

delimiter $$
create trigger atualizarCaixaDespesa after insert on Despesa for each row
begin
update Caixa SET despesatotal_caixa = despesatotal_caixa + NEW.valor_desp WHERE cod_caixa = NEW.cod_caixa;
update Caixa SET debito_caixa = debito_caixa + NEW.valor_desp WHERE cod_caixa = NEW.cod_caixa;
update Caixa SET lucro_caixa = receitatotal_caixa - debito_caixa  WHERE cod_caixa = NEW.cod_caixa;
end;
$$ delimiter ;
#drop trigger atualizarCaixaDespesa;
delimiter $$
create procedure inserirDespesa (tipo varchar(50), nome varchar(50), codcaixa int, valor double)
begin
declare cai_aux int;
set cai_aux = (select cod_caixa from Caixa WHERE cod_caixa = codcaixa);

 IF(tipo <> '')THEN
	IF(nome <> '')THEN
		IF(codcaixa = cai_aux)THEN
			IF(valor > 0)THEN
				insert into Despesa values (null, tipo, nome, codcaixa, valor);
                select 'Despesa cadastrada com Sucesso!'as Confirmação;
			ELSE
				select 'Valor é menor que 1'as Erro;
			END IF;
		ELSE
			select 'coloque um código de caixa válido'as Erro;
		END IF;
	ELSE
		select 'O campo nome está vazio'as Erro;
	END IF;
 ELSE
	select 'O campo tipo está vazio'as Erro;
 END IF;
end;
$$ delimiter ;

call inserirDespesa('Contas', 'Luz', 1, 300);

select * from Caixa;

delimiter $$
create procedure inserirCompraProduto (compra int, prod int)
begin
declare compra_aux int;
declare prod_aux int;
set compra_aux = (select cod_compr from Compra WHERE cod_compr = compra);
set prod_aux = (select cod_prod from Produto WHERE cod_prod = prod);
	IF (compra = compra_aux)THEN
		IF(prod = prod_aux)THEN
			insert into Compra_Produto values (null, compra,prod);
            select 'Cadastro realizado com Sucesso!'as Confirmação;
		ELSE
			select 'coloque um código de produto válido'as Erro;
        END IF;
	ELSE
		select 'Coleque um código de compra válido'as Erro;
	END IF;
end;
$$ delimiter ;

call inserirCompraProduto(1,1);