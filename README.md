# To-Do App

Um aplicativo de tarefas multiplataforma desenvolvido com .NET MAUI.

## Funcionalidades

- Adicionar, editar e excluir tarefas
- Marcar tarefas como conclu�das
- Sincronizar tarefas com uma API RESTful
- Interface responsiva para dispositivos m�veis e desktop

## Tecnologias

- [.NET 9](https://dotnet.microsoft.com/)
- .NET MAUI
- Arquitetura MVVM
- Integra��o com API REST

## Primeiros Passos

### Pr�-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 (com o workload do MAUI)

### Executando o Aplicativo

1. Clone o reposit�rio:
   ```sh
   git clone https://github.com/rafaelVictor05/To-Do-APP.git
   cd ApiAgenda
   ```

2. Restaure as depend�ncias e execute:
   ```sh
   dotnet build dotnet maui run
   ```

### API

O aplicativo se conecta a:  
`https://agenda-api-9zhi.onrender.com/api/tasks`

## Estrutura do Projeto

- `Models/` � Modelos de dados
- `ViewModels/` � ViewModels (MVVM)
- `Views/` � P�ginas da interface
- `Services/` � Integra��o com servi�os/API

## Licen�a

Este projeto est� licenciado sob a licen�a MIT.