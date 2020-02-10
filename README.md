## WebApiForPeople
### Api CRUD para manipulação de Funcionarios.

**Ao fazer clone da aplicação o projeto deve ser executado no Visual Studio:**
![img1](https://i.imgur.com/uz3bnxI.png)

**Logo apos a abertura do projeto no Visual Studio deve se iniciar o Build da Aplicação:**
![img2](http://i.imgur.com/Ut9MayE.png)

**Com o build completo e a aplicação ja rodando no navegador Adicione logo apos a porta da aplicação "/swagger" para iniciar os testes de rotas pelo FrameWork "Swagger":**
![img3](https://i.imgur.com/IVJ07Ms.png)

**Ou utilize algum programa para teste REST como o "postman" ou "insomnia".**

**As rotas implementadas e suas funçoes são:**

* (POST) funcionarios/create => Cria um novo resgisto de um funcionario a partir do corpo da requisição, Exemplo de corpo de requisição:
  ```json
  {
	"id": 1,
	"nome": "Christian",
	"cpf": "000.000.000-00",
	"idade": 16,
	"endereco": ["endereço1", "endereço2"]
  }
  ```
* (POST) funcionarios/update => Atualiza os dados de um resgisto do funcionario, utilizando a id para pesquisa, o exemplo de requisição é o mesmo da requisição acima.

* (POST) funcionarios/destroy => Excluí o registro do funcionario referente ao id passado a partir do corpo da requisição, exemplo de corpo de requisição:
```json
1
```

* (GET) funcionarios/show/id => Retorna um Json com os dados do funcionario referente a id passada na url:
```url
localhost:porta/funcionarios/show/1
```

* (GET) funcionarios/list => Retorna todos os registro de funcionarios ja cadastrados:
```url
localhost:porta/funcionarios/list
```

Toda o formato de requisição e resposta da API é feita por Json.
