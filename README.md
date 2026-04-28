 <h1>GameStore</h1>
</div>

<br/>

## Integrantes


- Gabriel Mediotti Marques - **RM 552632**
- Gustavo Bezerra Assumção - **RM 553076**
- Jó Sales - **RM 552679**
- Miguel Garcez de Carvalho - **RM 553768**
- Vinicius Souza e Silva - **RM 552781**


## Sobre o Projeto

O GameStore é um projeto criado com a intenção do gerenciamento de catalogo de jogos online. Com funcionalidades de criação de usuários, autenticação e controle de um acervo de jogos. Utilizado o padrão de arquitetura MVC (Model-View-Controller).

## Funcionalidades

- **Gestão de Usuários:** Sistema de cadastro seguro e login.
- **Catálogo de Games:** Visualização e gerenciamento de títulos da loja.
- **Repositórios:** Uso do padrão Repository (`GameRepositorio`, `UsuarioRepositorio`) para abstração de acesso aos dados.
- **Arquitetura MVC:** Separação clara entre dados (Models), interface (Views) e rotas/regras de negócios (Controllers).

## Estrutura do Projeto

GameStore/
````text
├── Controllers/       # Controladores da aplicação (ex: GameController)
├── Models/            # Modelos de dados e ViewModels
├── Views/             # Interface do usuário (Páginas Web Razor)
├── Repositorio/       # Regras de persistência e acesso a dados
├── Interfaces/        # Contratos para os repositórios
└── wwwroot/           # Arquivos estáticos (CSS, JS, Imagens)
````

##  Como Executar o Projeto

1. **Clone o repositório (se aplicável):**
   ```bash
   git clone <url-do-repositorio>
   ```

2. **Abra o projeto:**
   Abra o arquivo de solução (`GameStoreMVC.sln`) no **Visual Studio** ou abra a pasta do projeto no **Visual Studio Code**.

3. **Execute a aplicação:**
   * No **Visual Studio**: Pressione `F5` ou clique em "Iniciar".
   * No **Terminal/CLI**: Navegue até a pasta `GameStoreMVC` e execute os comandos:
     ```bash
     dotnet restore
     dotnet run
     ```

4. **Acesse no navegador:**
   O console exibirá as URLs (geralmente `http://localhost:5xxx` ou `https://localhost:7xxx`). Clique no link para abrir a aplicação.

---

<div align="center">
  <p>Desenvolvido com dedicação.</p>
</div>
