# To-Do App

Um aplicativo de tarefas multiplataforma desenvolvido com .NET MAUI.

## Funcionalidades

- Adicionar, editar e excluir tarefas
- Marcar tarefas como concluídas
- Sincronizar tarefas com uma API RESTful
- Interface responsiva para dispositivos móveis e desktop

## Tecnologias

- [.NET 9](https://dotnet.microsoft.com/)
- .NET MAUI
- Arquitetura MVVM
- Integração com API REST

## Primeiros Passos

### Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 (com o workload do MAUI)

### Executando o Aplicativo

1. Clone o repositório:
   ```sh
   git clone https://github.com/rafaelVictor05/To-Do-APP.git
   cd ApiAgenda
   ```

2. Restaure as dependências e execute:
   ```sh
   dotnet build dotnet maui run
   ```

### API

O aplicativo se conecta a:  
`https://agenda-api-9zhi.onrender.com/api/tasks`

## Estrutura do Projeto

- `Models/` – Modelos de dados
- `ViewModels/` – ViewModels (MVVM)
- `Views/` – Páginas da interface
- `Services/` – Integração com serviços/API

## Licença

Este projeto está licenciado sob a licença MIT.