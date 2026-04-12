# 🏦 GlobalBankApi - Lista de Exercícios XI

Bem-vindo ao projeto **GlobalBankApi**. 

Este é um exercício prático destinado ao aprendizado de sistemas distribuídos, desenvolvimento de APIs com .NET e persistência de dados em memória.

## 📝 Orientações Gerais

* **Modalidade:** Individual ou em equipes de até 05 alunos.
* **Linguagem:** C# (.NET).
* **Entrega:** Via URL do repositório no GitHub (conforme orientações em aula).
* **Requisito:** O código deve estar devidamente indentado e versionado.

---

## 🎯 Objetivo do Projeto

Desenvolver o núcleo de um sistema bancário internacional para gerenciamento de contas e transações monetárias, utilizando o padrão **Web API** com Controllers.

---

## 🚀 1. Setup do Projeto

Abra o seu terminal (PowerShell ou Bash) e utilize os comandos do **.NET CLI** para estruturar o ambiente:

```bash
# Criar o projeto Web API
dotnet new webapi -n GlobalBankApi --use-controllers

# Entrar na pasta
cd GlobalBankApi

# Adicionar pacotes necessários
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Swashbuckle.AspNetCore
```

---

## 🏗️ 2. Arquitetura de Dados (Models)

Crie as seguintes entidades dentro da pasta `Models`:

### **A. ContaBancaria**
* `Id` (int)
* `Titular` (string)
* `NumeroConta` (string) - *Ex: "12345-X"*
* `Saldo` (decimal)
* `TipoConta` (string) - *Ex: "Corrente", "Poupança" ou "Investimento"*

### **B. Transacao**
* `Id` (int)
* `ContaId` (int) - *Chave estrangeira*
* `Tipo` (string) - *Ex: "Deposito" ou "Saque"*
* `Valor` (decimal)
* `DataTransacao` (DateTime)

---

## ⚙️ 3. Configuração de Contexto

* Configure o `AppDbContext` para gerenciar as entidades.
* No `Program.cs`, registre o **Banco de Dados em Memória (InMemory)** e certifique-se de que o **Swagger** está ativo para testes.

---

## 🛠️ 4. Regras de Implementação (Controllers)

### **ContasController**
* **[POST] Abertura de Conta:** O saldo inicial não pode ser negativo. Se for, retornar `BadRequest` com a mensagem: *"O saldo inicial não pode ser negativo para contas internacionais."*
* **[GET] Listagem de Contas:** Retornar todas as contas cadastradas com saldo e titular.

### **TransacoesController**
* **[POST] Registrar Transação:** 1. Se for **Saque** e o valor exceder o saldo, retornar `Conflict` ("Saldo Insuficiente").
    2. Se aprovada, atualizar o saldo da `ContaBancaria`.
    3. **Desafio:** Se o valor for **> $10.000,00**, exibir no console do servidor: `"🚩 ALERTA DE SEGURANÇA: Transação de alto valor detectada para a conta [Número da Conta]!"`.
* **[GET] Extrato:** Rota `api/transacoes/extrato/{contaId}` para listar transações de uma conta específica.

---

## 🌐 5. Desafio de Sistemas Distribuídos

No `ContasController` (ou um controller de sistema), crie a rota:
* **[GET] `api/banco/dashboard`**: Deve retornar um objeto contendo o **Patrimônio Total** (soma de todos os saldos) e a **Quantidade Total** de transações do sistema.

---

## ✅ Checkpoint de Entrega

Para validar sua atividade, siga estes passos:

1.  **Execução:** Inicie o projeto (`dotnet watch` ou `dotnet run`).
2.  **Massa de Dados:**
    * Cadastre 2 contas.
    * Realize 1 depósito.
    * Realize 1 saque aprovado e 1 tentativa de saque negada (por saldo).
3.  **Documentação:** Tire prints das rotas funcionando no **Swagger** e adicione ao seu repositório.
4.  **Resposta Teórica:** No final deste README (ou em um arquivo separado), responda à seguinte questão:

> **Pergunta:** Sendo este um sistema distribuído, quais seriam os riscos de manter o saldo em memória (InMemory) caso tivéssemos múltiplas instâncias desta API rodando simultaneamente?
 
> **Resposta:** Usar InMemory em sistemas distribuídos compromete a consistência, confiabilidade e escalabilidade. Pode haver perda de dados em caso de falhas ou reinicializações, e operações simultâneas podem gerar condições de corrida, resultando em cálculos incorretos e saldos inconsistentes para o mesmo usuário.
---

## 📁 Instruções para o Aluno
1. Faça um **Fork** deste repositório.
2. O nome do seu repositório deve ser: `una-sdm-lista-11`.
3. Suba o código completo e as evidências (prints).

---
*Boa sorte, devs!*
