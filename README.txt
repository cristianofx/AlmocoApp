O aplicativo criado destina-se a escolha automatizada (aleatória) entre restaurantes para almoçar.
É possível fazer a escolha por dois parâmetros, categoria do restaurante ou faixa de preço, (ou os dois).

O que vale destacar no código implementado: Apesar de não pedir implementação do banco de dados nas instruções,
acabei for utilizá-lo, uma vez que implementei o código utilizando o Entity Framework pelo método Code First.

O que poderia ser feito para melhorar o sistema: Dentro do escopo do projeto, poderia ser implementado uma maneira
para que o último restaurante escolhido ficasse de fora da próxima vez que o aplicativo fosse utilizado. Para isso,
eu escolheria gravar o resultado no banco de dados, sendo que quando for chamado novamente, o programa procure no banco
o último escolhido e tire-o do pool de escolhas, substituindo após pelo novo resultado.

Outras considerações: No curso Students to Business aprendemos a utilizar C#/.NET com Webforms. Após o curso, por mim,
já estou estudando o framework MVC5, porém estou no início do programa, portanto tiveram alguns métodos de apresentação
do Razor que tive de pesquisar enquanto ia fazendo o código, é possível que haja maneiras melhores de resolver os
problemas deste projeto, porém o código está funcional e acredito que o objetivo do escopo do projeto foi alcançado.