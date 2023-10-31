# API PARA CADASTRO DE CLIENTES

Este projeto é uma API de cadastro de clientes e logradouros, desenvolvida para fins de teste pela empresa ThomasGreg. A aplicação segue os princípios do Domain-Driven Design (DDD) e as melhores práticas de arquitetura web, incluindo o padrão MVC (Model-View-Controller).

## Recursos Principais

- **Cadastro e Gerenciamento de Clientes**: Permite o cadastro de novos clientes e seus logradouros, bem como a recuperação, atualização e exclusão de informações de clientes existentes.

- **Autenticação via JWT Token e Armazenamento de Informações de Login**: A autenticação é realizada de forma segura usando JSON Web Tokens (JWT), garantindo que apenas usuários autorizados tenham acesso aos recursos protegidos. As informações de login, como tokens JWT emitidos e outros dados relevantes, são armazenadas com segurança no serviço de armazenamento em cache distribuído fornecido pelo `IDistributedCache`. Isso melhora o desempenho e a escalabilidade da autenticação, garantindo que as informações de login sejam acessíveis e compartilhadas entre os servidores da aplicação.

- **Persistência de Dados com Entity Framework 6**: Os dados dos clientes são armazenados de forma eficiente no banco de dados SQL Server, com o auxílio do Entity Framework 6. Para garantir o desempenho e a eficiência, consultas são otimizadas usando o Entity Framework 6 para leitura de dados, enquanto procedimentos armazenados são criados para ações como inclusão, atualização e exclusão de registros.

## Estrutura do Projeto

A API de Cadastro de Clientes segue uma estrutura organizada, dividida em camadas claras que promovem a separação de responsabilidades e facilitam a manutenção e evolução do sistema:

- **Camada de Domínio**: Contém as entidades, objetos de valor e regras de negócios relacionados ao domínio de clientes. Essa camada é o núcleo da aplicação e reflete com precisão o modelo de negócios.

- **Camada de Aplicação**: Coordena as operações entre a camada de domínio e a camada de infraestrutura. Ela lida com a lógica de aplicação e garante a integridade das transações.

- **Camada de Infraestrutura**: Responsável por interagir com recursos externos, como o banco de dados SQL Server. Aqui, o Entity Framework 6 é utilizado para persistir dados. Também é onde a autenticação JWT é implementada.

- **Camada de API (Model-View-Controller)**: Esta camada expõe os endpoints da API para interações externas. Ela é responsável por receber as solicitações, validar as entradas e coordenar as ações apropriadas na camada de aplicação.

## Tecnologias Implementadas

- Asp.NET CORE 6 
- Entity Framework 6
- Banco de Dados SQL Server
- AutoMapper
- Swagger
- Migrations
- JWT Token

## Como Rodar a Aplicação

1. Clone o Projeto:
   ```shell
   git clone https://github.com/arthurmoraes1/ThomasGreag.git
	
2. **Configure a Conexão com o Banco de Dados:**

* Abra o arquivo appsettings.json.
* Atualize a string de conexão para refletir as configurações do seu próprio banco de dados.

3. **Configuração de Inicialização do Projeto:**

* No Visual Studio, clique com o botão direito na Solution e selecione "Propriedades".
* Na barra lateral, vá para "Common Properties".
* Em "Startup Project", selecione "Multiple startup projects".
* Configure os projetos "Api" e "Ui" para iniciar.
* Execute a aplicação. O Entity Framework executará as migrações, criando tabelas e procedimentos no banco de dados.

4. **Login de Teste:**

* Para acessar a aplicação, utilize as credenciais de teste: usuário "Administrador" e senha "password".
* Após o login, você terá acesso ao CRUD de cadastro de clientes e logradouros.

Para dúvidas ou suporte, entre em contato pelo e-mail [arthurmmoraes@hotmail.com].
