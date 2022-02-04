# Authorizer
- Descrição:
O Authorizer se resume em uma aplicação que aborda dois tipos de operação: criação de conta, autorizador de transação (simulando um cartão de débito).
A aplicação recebe via entrada padrão args do console (stdin) o caminho de um arquivo json com determinadas operações.

A parte de criação de conta é simplificada quando a aplicação recebe uma operação de "account" dentro do Json.
Já a transação é representada dentro do json por uma operação "transaction".

A aplicação conta com regras para autorizar as transações, que podem ser melhor exploradas nos testes automatizados da aplicação.
Os diversos modelos de JSONs de entrada também podem ser vistos nos testes automatizados.

### Decisões técnicas e arquiteturais:
- Separada estrutura da solução baseada em camadas Apresentação/Aplicação/Domínio/Infra/Testes para facilitar organização do código e das regras de negócio.
- Utilizada injeção de dependência através destas camadas
- Utilizado armazenamento em memória com uma interface Storage na expectativa de facilitar a implementação de uma nova forma de armazenamento, reutilizando a interface e criando uma nova implementação para banco por exemplo.
- Criados testes automatizados testando todos os cenários propostos no desafio.
- Criados alguns testes unitários em cima do domínio validando as principais regras de negócio e violations.
- Criação de projeto chamado JsonLib (que utiliza Newtonsoft.Json.Schema) com um método genérico para realizar a validação de schema e identificação dos tipos de operação esperados pela aplicação.
- Criação de projeto chamado ResultLib. Serve para aplicar o Result Pattern, padrão onde o objetivo é retornar um objeto Result com tipos customizáveis atrelados a ele, e indicadores revelando sucesso ou falha de determinado método. Tentei utilizar frameworks prontos mas não possuiam o que eu precisava, assim implementei o meu próprio para atender a solução.

### Referências externas utilizadas (escolhidas por afinidade com as mesmas):
- Json.NET - Newtonsoft: utilizado para trabalhar com serialização e deserialização do Json.
- Json.NET - Newtonsoft Schema: utilizado para validação do schema Json.
- MicrosoftDependencyInjection: utilizado para fazer a injeção de dependência através de toda aplicação.

### Instruções para compilar e executar o projeto:
- Descompactar o Authorizer.zip
- Abrir a janela de comando
- Navegar para a pasta onde se encontra a solução (.sln) (..\src\Solution\Authorizer Solution)
- Rodar o comando de build com o nome da solução
	- dotnet build "Authorizer Solution.sln"
- Navegar para a pasta onde se encontra a aplicação (..\src\1_Presentation\authorizer\bin\Debug\net5.0)
- Rodar o comando de execução com o nome da .dll (authorizer.dll) e o caminho do arquivo operations como único parâmetro
	- dotnet authorizer.dll operations
- O resultado aparecerá na sequência no console.