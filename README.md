# Avaliação Dev ManagerBS

## Premissas da implementação
- Arquitetura do projeto
  - A escolha do framework foi o .Net 3.1, devido ao suporte LTS que a Microsoft está dando.
  - Optei por organizar o código em projetos separados, sendo o projeto Core contém as principais funcionalidades da solução, com os modelos e comandos.A WebApi trata apenas a parte das chamadas HTTP REST as chamadas REST e o projeto Tests são os testes de integração e unidade da aplicação.
  <br>Utilizei uma nomenclatura **NomeDaEmpresa.NomeDoProjeto.Funcionalidade** na criação dos projetos, para que haja padrão e organização na solução.

- Implementação das funcionalidade
  - Na aplicação, o input de dado precisa ser codificado na base64, visto que é mais comum de se trabalhar através da API REST pois transforma o dado binário em string, facilitando e agilizando a transferencia do dado.
  - A persistencia dos dados foi feita através de escrita em arquivo, com o objetivo de testar o conceito mais rapidamente sem a dependencia de uma lógica de persistencia de dados mais elaborada.
  - Separei o código em módulos para que seja fácil aplicar mudanças e manutenções, que são comuns em uma prova de conceito.
  
- Testes
  - Escolhi a biblioteca xUnit para testes de unidade, pois a propria microsoft a utiliza no desenvolvimento dos frameworks.
  
## Compilação
Há duas formas de compilar e executar o código:

1 - clonar ou baixar o código desse repositorio e executar o comando abaixo com o terminal aberto na pasta do projeto.
    
    dotnet run --project src/ManagerBS.AvaliacaoDev.WebApi/ManagerBS.AvaliacaoDev.WebApi.csproj

2 - Abrir a solução e executar via IIS Express pelo Visual Studio 2019.

**Obs**: É preciso ter o runtime do .netcore 3.1<br>
Link para download<br>
    
    https://dotnet.microsoft.com/download/dotnet-core/3.1

## Testes
Para executar os testes, abra uma janela de comando na pasta da solução e execute o seguinte comando:

    dotnet test
    
Ou abra pelo Visual Studio 2019 e execute pela janela do Test Explorer.