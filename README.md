# README

## Requisitos
* Visual Studio 2022 [Instalar ambiente de ASP.NET]
* .NET 6.0

## Instalação
* Utilizando o Visual Studio 2022, basta abrir a solução para ser capaz de executar esta aplicação. A IDE deve se encarregar de baixar todas dependências automaticamente.

## Utilização
* Ao executar a aplicação pelo Visual Studio, uma aba se abrirá no navegador com a rota padrão inicial da aplicação (https://localhost:7186/api/robo/reset), que irá redirecionar automaticamente para o Swagger.
* Como a requisição foi de uma interface gráfica Web simples, utilizou-se o próprio Swagger para "controlar" o ROBO. O Swagger é responsável por listar todas os endpoints disponíveis na API, bem como permitir testá-los e mostrar a resposta em JSON (que apresenta o estado atual do ROBO e seus componentes).

## Decisões de Arquitetura
* Como o ROBO é uma entidade individual, não foi necessário um banco de dados para esta aplicação. Para fins de praticidade, o estado do ROBO foi gerenciado com um arquivo de texto, serializando o objeto que representa o ROBO em JSON e des-serializando sempre que necessário.
* Os múltiplos estados dos braços e cabeça foram controlados por meio do Design Pattern State, adequado para este fim.

## Endpoints
* `GET https://localhost:7186/api/robo`
    * Retorna o objeto que representa o ROBO, mostrando todo seu estado de uma só vez
* `GET https://localhost:7186/api/robo/reset`
    * Reseta o estado do ROBO para o inicial. Este endpoint será executado sempre que a aplicação inicia, redirecionando logo em seguida para o Swagger. Sendo assim, o ROBO sempre inicia no estado padrão
* `GET https://localhost:7186/api/robo/head`
    * Controla as ações da cabeça do ROBO, através da query string `command`, que pode assumir 4 valores:
        1. `raise`: "levanta" a cabeça do robô, transicionando para estágios superiores ou lançando uma exceção caso já esteja maximizado
        2. `lower`: análogo ao raise, porém "abaixando" a cabeça
        3. `left`: gira a cabeça do ROBO para a esquerda
        4. `right`: gira a cabeça do ROBO para a direita
* `GET https://localhost:7186/api/robo/arm`
    * Endpoint para controlar os braços do ROBO
    * A requisição possui duas queries strings **obrigatórias**: `arm` e `command`
    * `arm` pode assumir apenas 2 valores: `left` ou `right`, indicando qual braço do robô deverá responder ao `command`
    * `command`: pode assumir 4 valores:
        1. `contract`: contrai o braço do robô, transicionando em direção aos estados de maior contração
        2. `relax`: relaxa o braço do robô, análogo ao contract
        3. `clockwise`: rotaciona o pulso do robô no sentido horário (apenas se o pulso estiver fortemente contraído, do contrário lança um erro)
        4. `counterclockwise`: análogo ao clockwise
* `https://localhost:7186/swagger/index.html`
    * Playground gráfico para fazer as requisições à API, controlando o ROBO e conferindo seus estados atuais
