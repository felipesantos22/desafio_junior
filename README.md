# Desafio Backend C# com xUnit

## O que vou desenvolver?

Irei desenvolver uma API e um banco de dados para um sistema hospitalar! Para isso irei usar C#, MySql, xUnit, Docker e AspNet

Neste projeto irei:

- Desenvolver endpoints que estarão conectados ao banco de dados seguindo os princípios do REST;
- Trabalhar a relação de pacientes, médicos e consultas

## Missão essencial

- Desenvolver API até 12/12 com as melhores praticas possível.

## O que preciso saber para fazer o projeto?

-  Entender o conceito de Migrations
-  Entender o conceito de Camadas
-  Entender relacionamentos 1:N entre pacientes e consultas
-  Entender relacionamentos 1:N entre médicos e consultas
-  Autenticação JWT

## Requisitos obrigatórios do projeto

 1. Criar migrations para pacientes, médicos, consultas, especialidades e médicos_especialidades
 2. Endpoints de CRUD (Create, Read, Update e Delete) de pacientes com os campos (Nome, idade e Cpf)
 3. Endpoints de CRUD (Create, Read, Update e Delete) de médicos com os campos (Nome e Crm)
 4. Endpoints de CRUD (Create, Read, Update e Delete) de Consultas com os campos (Data, Paciente_Id e Médico_Id)
 5. Endpoints de CRUD (Create, Read, Update e Delete) de Login com os campos (NomeUsuário e Senha)
 6. Controle de acesso aos endpoints utilizando JWT - Os endpoints para cadastrar médicos e pacientes necessitam de autenticação
 7. Validações da informações enviadas - Foram feitas diversas validações, como agendamento com diferença de 30 min de um para o outro
 8. Testes de unidade e TDD - Foram testados as validações de cpf, crm e login
 9. Consultas com dapper - Implementado consulta por nome na classe DoctorRepository usando dapper

<img width="600" img src="https://github.com/felipesantos22/desafio_junior/assets/81933510/c13120ce-ea7f-45fb-8736-c764702d097e" >
<img width="600" img src="https://github.com/felipesantos22/desafio_junior/assets/81933510/75d5c0da-0c2b-459a-9e04-10e64b4ec533" >
<img width="600" img src="https://github.com/felipesantos22/desafio_junior/assets/81933510/b08ff7b1-7f9f-4f9c-8ee4-f58fc26c0392" >
<img align="center" alt="felipe-CSS" height="30" width="40" img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" >  
