O aplicativo criado destina-se a escolha automatizada (aleat�ria) entre restaurantes para almo�ar.
� poss�vel fazer a escolha por dois par�metros, categoria do restaurante ou faixa de pre�o, (ou os dois).

O que vale destacar no c�digo implementado: Apesar de n�o pedir implementa��o do banco de dados nas instru��es,
acabei for utiliz�-lo, uma vez que implementei o c�digo utilizando o Entity Framework pelo m�todo Code First.

O que poderia ser feito para melhorar o sistema: Dentro do escopo do projeto, poderia ser implementado uma maneira
para que o �ltimo restaurante escolhido ficasse de fora da pr�xima vez que o aplicativo fosse utilizado. Para isso,
eu escolheria gravar o resultado no banco de dados, sendo que quando for chamado novamente, o programa procure no banco
o �ltimo escolhido e tire-o do pool de escolhas, substituindo ap�s pelo novo resultado.

Outras considera��es: No curso Students to Business aprendemos a utilizar C#/.NET com Webforms. Ap�s o curso, por mim,
j� estou estudando o framework MVC5, por�m estou no in�cio do programa, portanto tiveram alguns m�todos de apresenta��o
do Razor que tive de pesquisar enquanto ia fazendo o c�digo, � poss�vel que haja maneiras melhores de resolver os
problemas deste projeto, por�m o c�digo est� funcional e acredito que o objetivo do escopo do projeto foi alcan�ado.