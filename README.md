# Modulo03_Projeto01_DEVinHouse
Projeto desenvolvido para o curso DEVinHouse - Turma NDD 🚀

## DEVinCar
Projeto avaliativo DEVinHouse, desenvolvido com ASP.NET 6 com EntityFramework Core 6, em C#, conectando em base SQL Server, respeitando padrões Rest(métodos HTTP, cache, middleware, content negotiation), com implementação do SOLID e divisão em camadas.

### Sobre
O projeto desenvolve uma API para vendas de carros. Separados em 3 módulos:
<ul>
    <li>Módulo de Cadastro: Responsável por manter e gerir o cadastro de usuários e produtos;</li>
    <li>Módulo de Vendas: Responsável por gerir as vendas de carros e as entregas;</li>
    <li>Módulo de Geo-Posicionamento: Responsável por gerir o cadastro de cidades, estados e endereços.</li>
</ul>

### Como executar
Baixe o projeto para sua máquina com <code>git clone https://github.com/DEVin-NDD/M2P2-DEVinCar</code> então conecte a sua máquina com um SQL Server local e atualize-o rodando no diretório do projeto o comando <code>dotnet ef database update</code>. Aí você terá o SQL Server atualizado e o projeto está pronto para ser executado com <code>dotnet run</code>. Por padrão a rota será: <code>https://localhost:7019/</code> e para acessar o swaggerUI <code>https://localhost:7019/swagger/index.html</code>.
