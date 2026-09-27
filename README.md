Principais Detalhes da Implementação
====================================

1 - Data: Formata o retorno do método ToString() para garantir a saída em duas casas para dia/mês e quatro para o ano (dd/mm/aaaa).

2 - Contato:

- GetIdade(): Calcula dinamicamente a idade baseada no ano e ajusta caso o aniversário do ano corrente ainda não tenha ocorrido.

- Equals(): Sobrescrito para comparar contatos pelo Email (usado como chave de busca/identificador único na lista).

- GetTelefonePrincipal(): Procura o telefone assinalado com Principal = true.

3 - Contatos: A propriedade Agenda encapsula a lista agenda (readonly). Adiciona validações para evitar cadastro em duplicidade e garante alteração/remoção seguras.
