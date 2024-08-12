# LINQ 
> Language Integrated Query

- É um conjunto de tecnologias baseadas na integração de funcionalidades de consulta diretamente na linguagem C#
	- Operações chamadas diretamente a partir das coleções
	- Consultas são objetos de primeira classe
	- Suporte do compilador e IntelliSense da IDE
- `Namespace: System.Linq`
- Possui diversas operações de consulta, cujos parâmetros tipicamente são expressões lambda ou expressões de sintaxe similar à SQL
- Referência
	- https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/index

## Três passos

1. Criar um data source (coleção, array, recurso de E/S, etc.)
2. Definir a query
3. Executar a query (foreach ou alguma operação terminal)

![](attachments/Pasted%20image%2020240812145230.png)

### Demo
```csharp
Demo
// Specify the data source.
int[] numbers = new int[] { 2, 3, 4, 5 };

// Define the query expression.
IEnumerable<int> result = numbers
	.Where(x => x % 2 == 0)
	.Select(x => 10 * x);
	
// Execute the query.
foreach (int x in result)
{
    Console.WriteLine(x);
}
```

## Operações do LINQ / Referências

- Filtering: 
		- `Where`
		- `OfType`
- Sorting:
	- `OrderBy`
	- `OrderByDescending`
	- `ThenBy`
	- `ThenByDescending`
	- `Reverse`
- Set
	- `Distinct`
	- `Except`
	- `Intersect`
	- `Union`
- Quantification
	- `All`
	- `Any`
	- `Contains`
- Projection
	- `Select`
	- `SelectMany`
- Partition
	- `Skip`
	- `Take`
- Join
	- `Join` 
	- `GroupJoin`
- Grouping
	- `GroupBy`
- Generational
	- `Empty`
- Equality
	- `SequenceEquals`
- Element
	- `ElementAt`
	- `First`
	- `FirstOrDefault`
	- `Last`
	- `LastOrDefault`
	- `Single`
	- `SingleOrDefault`
- Conversions
	- `AsEnumerable` 
	- `AsQueryable`
- Concatenation
	- `Concat`
- Aggregation
	- `Aggregate`
	- `Average`
	- `Count`
	- `LongCount,` 
	- `Max`
	- `Min`
	- `Sum`
### Referências
- https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b/view/SamplePack/1?sortBy=Popularity
- https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b/view/SamplePack/2?sortBy=Popularity
- https://odetocode.com/articles/739.aspx

## Demo: LINQ com Lambda

![](attachments/Pasted%20image%2020240812150331.png)
- Resolução 
	- https://github.com/acenelio/linq-demo1
## Conclusões

• Where (operação "filter" / "restrição")
• Select (operação "map" / "projeção")
• OrderBy, OrderByDescending, ThenBy, ThenByDescending
• Skip, Take
• First, FirstOrDefault Last, LastOrDefault, Single, SingleOrDefault
• Max, Min, Count, Sum, Average, Aggregate (operação "reduce")
• GroupBy


[Algebra relacional e SQL](Algebra%20relacional%20e%20SQL.md)