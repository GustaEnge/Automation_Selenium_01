Feature: Busca termos
	Buscar por termos no motor de busca do Google e acessar o primeiro resultado


@SearchAppStepDefinitions
Scenario: Acessar uma instância de uma página do google e pesquisar termos
	Given Estou na página principal do Google
	And Digito o termo de pesquisa: <termos>
	And Resultados da busca para <termos> deve aparecer e acessar o primeiro resultado
	Then Compare o <titulo> e feche

Examples:
| termos  | titulo																						   |
| BDD     | BDD (Desenvolvimento orientado por comportamento)											   |
| Abacaxi | Abacaxi melhora a digestão e aumenta a imunidade; veja 9 benefícios - 01/12/2018 - UOL VivaBem |
| PrimeUp | PrimeUp																						   |
#	CucumberStudio | #1 BDD Collaboration Tool -> tratar esse titulo que vem com o mesmo caracter que separa