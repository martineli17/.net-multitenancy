# Multitancy

##### O cenário de uma aplicação ser multitenancy é a necessidade de atender vários clientes ao mesmo tempo.
##### Existem algumas abordagens para que uma aplicação consiga atender a este requisito, como: 
- criar banco de dados específico para cada cliente: essa abordagem tem alguns pontos negativos, como o de aumentar a complexibilidade de alterações no schema das tabelas.
- criar um deploy para cada cliente: essa abordagem tem alguns pontos negativos, como o de aumentar a complexibilidade de deploys e monitoramento.
- criar uma coluna nas tabelas que referencia a qual cliente aquele registro pertence: <b>ESSE É O CENÁRIO APRESENTADO NESTE PROJETO.</b>

## Exemplo de como implementar
1. Pode ser criada uma entidade base, que terá essa propriedade e, todas as demais entidades herdarão dessa. Assim, quando essa entidade for mapeada para o banco, a coluna referente ao cliente estará presente. Neste exemplo, não foi criada uma entidade base, sendo assim, a propriedade ficou diretamente na própria entidade.
   - [Entidade](https://github.com/martineli17/.net-multitenancy/blob/master/Domain/Entities/Contract.cs)

2. É necessário criar uma entidade que fará referência a sua tabela de clientes e, além disso, registrar os mesmos no banco de dados.
   - [Endpoint de criação de um cliente](https://github.com/martineli17/.net-multitenancy/blob/master/Multitenancy/Controllers/TenancyController.cs)
   
3. Quando algum usuário realizar login na sua aplicação, será necessário identificar de qual cliente ele pertence e buscar o ID deste cliente. Com o ID recuperado, pode-se adicionar essa informação na geração do token JWT e, assim, sempre que uma requisição for realizada, essa informação estará disponível para ser acessada.
   - [Login:  Neste exemplo, o login foi feito de maneira simplificada apenas para demonstrar o processo](https://github.com/martineli17/.net-multitenancy/blob/master/Multitenancy/Controllers/LoginController.cs)
   - [Criação do Token JWT](https://github.com/martineli17/.net-multitenancy/blob/master/Multitenancy/Configuration/TokenService.cs)
   - [Obtendo a informação do Tenancy Id do request](https://github.com/martineli17/.net-multitenancy/blob/master/Multitenancy/Configuration/UserService.cs)
  
4. Quando algum usuário realizar um novo request na aplicação, a sua aplicação terá acesso ao TenancyId da requisição através do JWT e, assim, deve filtrar apenas os registros daquele cliente e adicionar registros informando o cliente.
   - [Service](https://github.com/martineli17/.net-multitenancy/blob/master/Service/ContractService.cs)

## Conclusão
##### A abordagem de apenas adicionar mais uma propriedade que faz referência a qual cliente aquele registro pertence é mais simples e menos complexo.
##### Assim, quando algum registro for adicionado ou retornado, basta informar o TenancyId e assim o usuário terá acesso a registros somente do cliente ao qual ele pertence.
