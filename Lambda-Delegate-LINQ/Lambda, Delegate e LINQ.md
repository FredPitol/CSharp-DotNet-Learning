# `Comparison<T>`

## Problema


- Suponha uma classe Product com os atributos name e price.
- Suponha que precisamos ordenar uma lista de objetos Product.
- Podemos implementar a comparação de produtos por meio da implementação da interface `IComparable<Product>`
- Entretanto, desta forma nossa classe Product não fica fechada para alteração: se o critério de comparação mudar, precisaremos alterar a classe Product.
- Podemos então usar outra sobrecarga do método "Sort" da classe List:

```csharp
public void Sort(Comparison<T> comparison)
```

## `Comparison<T> (System)`

```csharp
public delegate int Comparison<in T>(T x, T y);
```

## Conclusão
```csharp
public void Sort(Comparison<T> comparison)
```

- Referência simples de método como parâmetro
- Referência de método atribuído a uma variável tipo delegate
- Expressão lambda atribuída a uma variável tipo delegate
- Expressão lambda inline

# Programação funcional e cálculo lambda

## Paradigmas de programação

- Imperativo (C, Pascal, Fortran, Cobol)
- Orientado a objetos (C++, Object Pascal, Java (< 8), C# (< 3))
- Funcional (Haskell, Closure, Clean, Erlang)
- Lógico (Prolog)
- Multiparadigma (JavaScript, Java (8+), C# (3+), Ruby, Python, Go)

## Paradigma funcional de programação
> Baseado no formalismo matemático Cálculo Lambda (Church 1930)

![](attachments/Pasted%20image%2020240812141142.png)

## Transparência referencial
>Uma função possui transparência referencial se seu resultado for sempre o mesmo para os mesmos dados de entrada. 

Benefícios: simplicidade e previsibilidade

```csharp
using System;
namespace Course
{
    class Program
    {
        public static int globalValue = 3;
        static void Main(string[] args)
        {
            int[] vect = new int[] { 3, 4, 5 };
            ChangeOddValues(vect);
            Console.WriteLine(string.Join(" ", vect));
        }
        public static void ChangeOddValues(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    numbers[i] += globalValue;
                }
            }
        }
    }
}
```
> Exemplo de função que não é referencialmente transparent

## Funções são objetos de primeira ordem (ou primeira classe

sso significa que funções podem, por exemplo, serem passadas como parâmetros de
métodos, bem como retornadas como resultado de métodos

```csharp
class Program
{
    static int CompareProducts(Product p1, Product p2)
    {
        return p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
    }
    static void Main(string[] args)
    {
        List<Product> list = new List<Product>();
        list.Add(new Product("TV", 900.00));
        list.Add(new Product("Notebook", 1200.00));
        list.Add(new Product("Tablet", 450.00));
        list.Sort(CompareProducts);
        (...)
            }
}
```

## Inferência de tipos

```csharp
list.Add(new Product("TV", 900.00));
list.Add(new Product("Notebook", 1200.00));
list.Add(new Product("Tablet", 450.00));
list.Sort((p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper()));
foreach (Product p in list)
    {
	Console.WriteLine(p);
    }
```

## Expressividade / "como" vs. "o quê"

```csharp
int sum = 0;
foreach (int x in list) 
	{
	sum += x;
	}

```

### VS

```csharp
int sum = list.Aggregate(0, (x, y) => x + y);
```

## O que são expressões lambda ? 
> Em programação funcional, expressão lambda corresponde a uma função anônima de primeira classe.

```csharp
class Program
{
    static int CompareProducts(Product p1, Product p2)
    {
        return p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
    }
    static void Main(string[] args)
    {
        (...)
		list.Sort(CompareProducts);
		list.Sort((p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper()));
        (...)
(...)
```

## Conclusões 

![](attachments/Pasted%20image%2020240812142315.png)

- **Cálculo Lambda** = formalismo matemático base da programação funciona
- **Expressão lambda** = função anônima de primeira classe


# Delegates\
- Docs
	- https://docs.microsoft.com/en-us/dotnet/standard/delegates-lambdas
- É uma referência (com type safety) para um ou mais métodos
	- É um tipo referência
- Usos comuns:
	- Comunicação entre objetos de forma flexível e extensível (eventos / callbacks)
	- Parametrização de operações por métodos (programação funcional)

## Delegates pré-definidos

- Action
- Func
- Predicate

### Demo1 
```csharp
namespace Course.Services
{
    class CalculationService
    {
        public static double Max(double x, double y)
        {
            return (x > y) ? x : y;
        }
        public static double Sum(double x, double y)
        {
            return x + y;
        }
        public static double Square(double x)
        {
            return x * x;
        }
    }
}
```

### Demo
```csharp
using System;
using Course.Services;

namespace Course
{
    delegate double BinaryNumericOperation(double n1, double n2);
    class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;
            // BinaryNumericOperation op = CalculationService.Sum;
            BinaryNumericOperation op = new BinaryNumericOperation(CalculationService.Sum);
            // double result = op(a, b);
            double result = op.Invoke(a, b);
            Console.WriteLine(result);
        }
    }
}
```

## Multicast delegates

• Delegates que guardam a referência para mais de um método
• Para adicionar uma referência, pode-se usar o operador +=
• A chamada Invoke (ou sintaxe reduzida) executa todos os métodos na ordem em que foram adicionados
• Seu uso faz sentido para métodos void

### Demo

```csharp
using System;
namespace Course.Services
{
    class CalculationService
    {
        public static void ShowMax(double x, double y)
        {
            double max = (x > y) ? x : y;
            Console.WriteLine(max);
        }
        public static void ShowSum(double x, double y)
        {
            double sum = x + y;
            Console.WriteLine(sum);
        }
    }
	
}
```

```csharp
using System;
using Course.Services;
namespace Course
{
    delegate void BinaryNumericOperation(double n1, double n2);
    class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;
            BinaryNumericOperation op = CalculationService.ShowSum;
            op += CalculationService.ShowMax;
            op(a, b);
        }
    }
}
```

## Predicate (exemplo com RemoveAll)

### Predicate (System)
> Representa um método que recebe um objeto do tipo T e retorna um valor booleano

https://msdn.microsoft.com/en-us/library/bfcke1bz%28v=vs.110%29.aspx

```csharp
public delegate bool Predicate<in T>(T obj)
```

#### Problemas Exemplo

Fazer um programa que, a partir de uma lista de produtos, remova da lista somente aqueles cujo preço mínimo seja 100.

```csharp
List<Product> list = new List<Product>();
list.Add(new Product("Tv", 900.00));
list.Add(new Product("Mouse", 50.00));
list.Add(new Product("Tablet", 350.50));
list.Add(new Product("HD Case", 80.90))
```

- Resolução 
	- https://github.com/acenelio/lambda2-csharp

## Action (exemplo com ForEach)

### Action (System)
> Representa um método void que recebe zero ou mais argumentos

https://msdn.microsoft.com/en-us/library/system.action%28v=vs.110%29.aspx

```csharp
public delegate void Action();
public delegate void Action<in T>(T obj);
public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
public delegate void Action<in T1, in T2, in T3>(T1 arg1, T2 arg2, T3 arg3);
(..)
```
> 16 sobrecargas

### Problemas exemplo

Fazer um programa que, a partir de uma lista de produtos, aumente o preço dos produtos em 10%

```csharp
List<Product> list = new List<Product>();
list.Add(new Product("Tv", 900.00));
list.Add(new Product("Mouse", 50.00));
list.Add(new Product("Tablet", 350.50));
```

- Resolução 
	- https://github.com/acenelio/lambda3-csharp

## Func (exemplo com Select)


### Func (System)
> Representa um método que recebe zero ou mais argumentos, e retorna um valor

- https://msdn.microsoft.com/en-us/library/bb534960%28v=vs.110%29.aspx

```csharp
public delegate TResult Func<out TResult>();
public delegate TResult Func<in T, out TResult>(T obj);
public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
public delegate TResult Func<in T1, in T2, in T3, out TResult>(T1 arg1, T2
arg2, T3 arg3)
```
> (16 sobrecargas)

### Problema exemplo

Fazer um programa que, a partir de uma lista de produtos, gere uma
nova lista contendo os nomes dos produtos em caixa alta

```csharp
List<Product> list = new List<Product>();
list.Add(new Product("Tv", 900.00));
list.Add(new Product("Mouse", 50.00));
list.Add(new Product("Tablet", 350.50));
list.Add(new Product("HD Case", 80.90));
```
- Resolução
	- https://github.com/acenelio/lambda4-csharp

### Nota sobre a função Select

A função "Select" (pertencente ao LINQ) é uma função que aplica uma função a todos elementos de uma coleção, gerando assim uma nova coleção (do tipo IEnumerable).

```csharp
List<int> numbers = new List<int> { 2, 3, 4 };
IEnumerable<int> newList = numbers.Select(x => 2 * x);
Console.WriteLine(string.Join(" ", newList))
```

- 4 6 8
## Criando funções que recebem funções como argumento

- removeAll(Predicate)
- ForEach(Action)
- Select(Func)

### Problema exemplo

Fazer um programa que, a partir de uma lista de produtos, calcule a
soma dos preços somente dos produtos cujo nome começa com "T".

```csharp
List<Product> list = new List<Product>();
list.Add(new Product("Tv", 900.00));
list.Add(new Product("Mouse", 50.00));
list.Add(new Product("Tablet", 350.50));
list.Add(new Product("HD Case", 80.90))
```

- Retorno?
	- 1250.0
- Resolução
	- https://github.com/acenelio/lambda5-csharp

```csharp

```

```csharp

```

```csharp

```

```csharp

```

```csharp

```

```csharp

```

```csharp

```



