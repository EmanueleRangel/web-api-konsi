# Aplicação de Consulta de Benefícios

## Descrição
Esta aplicação tem como objetivo consultar os benefícios associados a um CPF de cliente. Antes de realizar consultas, é necessário gerar um token utilizando as credenciais fornecidas. A seguir estão as etapas necessárias para utilizar a aplicação:

## Geração de Token
Endpoint: POST /api/v1/token

Para gerar o token, utilize o seguinte corpo de requisição:

{
  "username": "seu_usuario",
  "password": "sua_senha"
}
### Observação: As credenciais e a URL base serão fornecidas no privado. Caso não tenha recebido, favor solicitar.

## Consulta de Benefícios
Endpoint: GET /api/v1/inss/consulta-beneficios?cpf={cpf}

Realize a consulta de benefícios utilizando o CPF do cliente como parâmetro na URL.

## Dados a serem Coletados
A consulta retornará uma lista de números de matrículas (número do benefício) com o respectivo código do tipo de benefício.

## Etapas Obrigatórias
A lista de CPFs deve ser inicialmente colocada em uma fila do RabbitMQ.
Na fila do RabbitMQ, podem existir CPFs repetidos.
Ao consumir da fila do RabbitMQ um CPF, o sistema deve verificar previamente no cache do Redis se existe um JSON com os dados referentes ao CPF.
Após realizar a consulta, os dados de matrículas de um CPF devem ser indexados utilizando o Elasticsearch.

## Executando a Aplicação

Clone este repositório.
Instale as dependências necessárias.
Inicie a aplicação.
Exemplo de Uso:

Copy code
git clone https://github.com/seu-usuario/nome-do-repositorio.git
cd nome-do-repositorio
npm install
npm start

Nota: Certifique-se de ter as credenciais corretas antes de utilizar a aplicação.
