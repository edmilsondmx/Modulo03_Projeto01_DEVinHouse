# Modulo03_Projeto01_DEVinHouse
Projeto desenvolvido para o curso DEVinHouse - Turma NDD 🚀

<h1 align="center">
   <p>DEVinCar - API RESTful de Vendas</p>
</h1>

Projeto avaliativo DEVinHouse, desenvolvido com ASP.NET 6 com EntityFramework Core 6, em C#, conectando em base SQL Server, respeitando padrões Rest(métodos HTTP, cache, middleware, content negotiation), com implementação do SOLID e divisão em camadas.

### 💻 Sobre
O projeto desenvolve uma API para vendas de carros. Separados em 3 módulos:
<ul>
    <li>Módulo de Cadastro: Responsável por manter e gerir o cadastro de usuários e produtos;</li>
    <li>Módulo de Vendas: Responsável por gerir as vendas de carros e as entregas;</li>
    <li>Módulo de Geo-Posicionamento: Responsável por gerir o cadastro de cidades, estados e endereços.</li>
</ul>

### ⚙️ Funcionalidades

Crud Completo:

- User
- Car
- Address
- Sales
- Delivery
- State
- City
- Autenticação JWT
- Autorização


### 🚀 Como executar

Baixe o projeto para sua máquina com <code>git clone https://github.com/edmilsondmx/Modulo03_Projeto01_DEVinHouse</code> então conecte a sua máquina com um SQL Server local e atualize-o rodando no diretório do projeto o comando <code>dotnet ef database update</code>. Aí você terá o SQL Server atualizado e o projeto está pronto para ser executado com <code>dotnet run</code>. Por padrão a rota será: <code>https://localhost:7019/</code> e para acessar o swaggerUI <code>https://localhost:7019/swagger/index.html</code>.


### Pré-requisitos

Para rodar o projeto em sua máquina, você vai precisar ter instalado as seguintes ferramentas:
[Git](https://git-scm.com) e [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
Além disto é importante ter um editor para trabalhar com o código, como [VisualStudio](https://visualstudio.microsoft.com/) e um sistema gerenciador de Banco de dados relacional, como o [SQLServer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads).

#### 🎲 Rodando a Aplicação

<ol start="1">
    <li>No repositório do GitHub, clone o projeto 👇</li>

    ```bash
    # Clone este repositório
    $ git clone https://github.com/edmilsondmx/Modulo03_Projeto01_DEVinHouse
    ```

    <li>Abra o projeto no VisualStudio, clicando 2x no arquivo <b style="color:#7b9eeb">DevInCar.sln</b></li>
<br>
    <li>Vá para o arquivo <b style="color:#7b9eeb">appsettings.json</b> e adicione a ConnectionString, seguindo o modelo abaixo 👇<br>

        ```bash
        "ConnectionStrings": {
        "ServerConnection": "Server=localhost\\SQLEXPRESS;Database=BD_DEVINCAR;Trusted_Connection=True;"
        }
        ```
    </li>

    <li>Instale as seguintes dependências, via NuGet:</li>
<ul>
    <li>Microsoft.EntityFrameworkCore</li>
    <li>Microsoft.EntityFrameworkCore.Tools</li>
    <li>Microsoft.EntityFrameworkCore.Design</li>
    <li>Microsoft.EntityFrameworkCore.SqlServer</li>
    <li>Swashbuckle.AspNetCore</li>
</ul>
<br>

<li>Com os pacotes instalados, abra o terminal e digite o comando abaixo 👇</li>

```bash
dotnet ef migrations Add Initial
```

<li>Após o comando executado, você irá inserir as tabelas no Banco de Dados com o seguinte comando 👇</li>

```bash
dotnet ef Database Update
```

<li>Com esses passos executados, você já pode executar a aplicação inserindo o camendo no terminal:</li>

    ```bash
    dotnet watch run
```
</ol>
<br>


## Autor
Edmilson Gomes 😊
