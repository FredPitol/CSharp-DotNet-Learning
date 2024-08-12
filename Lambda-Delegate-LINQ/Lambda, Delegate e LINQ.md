# Tipo `Comparison<T>`

## Problema
> Vamos explorar diferentes abordagens para sua resolução

- Suponha uma classe Product com os atributos name e price.
- Suponha que precisamos ordenar uma lista de objetos Product.
- Podemos implementar a comparação de produtos por meio da implementação da interface `IComparable<Product>`
- Entretanto, desta forma nossa classe Product não fica fechada para alteração: se o critério de comparação mudar, precisaremos alterar a classe Product.
	- Caso queira ordenar por outro critério de comporação se torna necessário trocar o comportamento da classe
- Podemos então usar outra sobrecarga do método "Sort" da classe List:



```csharp
public void Sort(Comparison<T> comparison)
```

## `Comparison<T> (System)`

```csharp
public delegate int Comparison<in T>(T x, T y);
```
- `Comparison
	- Tipo genérico 
- `<in T>`
	- Do tipo T
- `(T x, T y)`
	- Que recebe dois objetos 
- `int`
	- E retorna um inteiro

### Declarando antes 

```csharp
Comparison<Product> comp = CompareProducts;

list.Sort(comp);
```

- `Comparison<Product> comp = CompareProducts;`
	- Var que recebe referência para função
- `list.Sort(comp);`
	- Passando referência para função sort

### Expressão lambda atribuída a uma variável tipo delegate

- Não necessita da declaração da função na classe

```csharp
Comparison<Product> comp = (p1,p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
```

- `Comparison<Product> comp = (p1,p2)`
	- Compara dois objetos 
- `p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());`
	- Retorno

### Função lambda dentro do argumento da função sort
>Expressão lambda inline

```csharp
list.Sort((p1,p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper()));
```

## Conclusão
```csharp
public void Sort(Comparison<T> comparison)
```

## Implementações
### Referência simples de método como parâmetro
#### Product
```csharp
using System;
using System.Globalization;

namespace Course.Entities {
    class Product : IComparable<Product> {

        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price) {
            Name = name;
            Price = price;
        }

        public override string ToString() {
            return Name + ", " + Price.ToString("F2", CultureInfo.InvariantCulture);
        }

        public int CompareTo(Product other) {
            return Name.ToUpper().CompareTo(other.Name.ToUpper());
        }
    }
}
```

#### Main

```csharp
using System;
using System.Collections.Generic;
using Course.Entities;

namespace Course {
    class Program {
        static void Main(string[] args) {

            List<Product> list = new List<Product>();

            list.Add(new Product("TV", 900.00));
            list.Add(new Product("Notebook", 1200.00));
            list.Add(new Product("Tablet", 450.00));

            list.Sort();

            foreach (Product p in list) {
                Console.WriteLine(p);
            }
        }
    }
}
```


### Referência de método atribuído a uma variável tipo delegate
#### main
```csharp
﻿using System;
using System.Collections.Generic;
using Course.Entities;

namespace Course {
    class Program {
        static void Main(string[] args) {

            List<Product> list = new List<Product>();

            list.Add(new Product("TV", 900.00));
            list.Add(new Product("Notebook", 1200.00));
            list.Add(new Product("Tablet", 450.00));

            list.Sort(CompareProducts);

            foreach (Product p in list) {
                Console.WriteLine(p);
            }
        }

        static int CompareProducts(Product p1, Product p2) {
            return p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
        }
    }
}
```

#### Product
```csharp
﻿using System.Globalization;

namespace Course.Entities {
    class Product {

        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price) {
            Name = name;
            Price = price;
        }

        public override string ToString() {
            return Name + ", " + Price.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
```

### Expressão lambda atribuída a uma variável tipo delegate

#### Main
```csharp
﻿using System;
using System.Collections.Generic;
using Course.Entities;

namespace Course {
    class Program {
        static void Main(string[] args) {

            List<Product> list = new List<Product>();

            list.Add(new Product("TV", 900.00));
            list.Add(new Product("Notebook", 1200.00));
            list.Add(new Product("Tablet", 450.00));

            Comparison<Product> comp = (p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());

            list.Sort(comp);

            foreach (Product p in list) {
                Console.WriteLine(p);
            }
        }
    }
}
```

#### Product

```csharp
﻿using System.Globalization;

namespace Course.Entities {
    class Product {

        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price) {
            Name = name;
            Price = price;
        }

        public override string ToString() {
            return Name + ", " + Price.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
```

### Expressão lambda inline
> Solução menos verbosa 
#### Classe 
```csharp
﻿using System.Globalization;

namespace Course.Entities {
    class Product {

        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price) {
            Name = name;
            Price = price;
        }

        public override string ToString() {
            return Name + ", " + Price.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
```

#### Main
```csharp
﻿using System;
using System.Collections.Generic;
using Course.Entities;

namespace Course {
    class Program {
        static void Main(string[] args) {

            List<Product> list = new List<Product>();

            list.Add(new Product("TV", 900.00));
            list.Add(new Product("Notebook", 1200.00));
            list.Add(new Product("Tablet", 450.00));

            list.Sort((p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper()));

            foreach (Product p in list) {
                Console.WriteLine(p);
            }
        }
    }
}
```

# Programação funcional e cálculo lambda
## Paradigmas de programação

- Imperativo (C, Pascal, Fortran, Cobol)
- Orientado a objetos (C++, Object Pascal, Java (< 8), C# (< 3))
- Funcional (Haskell, Closure, Clean, Erlang)
- Lógico (Prolog)
- Multiparadigma (JavaScript, Java (8+), C# (3+), Ruby, Python, Go)

> C# aplica funcional e orientando a objetos se tornando multiparadigma
## Paradigma funcional de programação
> Baseado no formalismo matemático Cálculo Lambda (Church 1930)

![](attachments/Pasted%20image%2020240812141142.png)
- Funcional
	- Descreve o que vai ser computado por meio de expressões, sendo declarativa
- Imperativa
	- Define comandos a serem executados

### Transparência referencial
> A função depende apenas de argumento que estão presentes nela mesma 

- Uma função possui transparência referencial se seu resultado for sempre o mesmo para os mesmos dados de entrada. 
- Benefícios: 
	- Simplicidade  
	- Previsibilidade
	- Torna mais fácil de entender a função

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
> Exemplo de função que não é referencialmente transparente

- Algoritmo 
	- Recebe um vetor 
	- Se o elemento do vetor na posição i for impar 
	- Atribuo a ele o que ele tinha dentro dele += valor global
		- Estamos operando com um valor fora da função o que a torna referencialmente não transparente
			- Essa característica é mais forte na programação funcional


### Funções são objetos de primeira ordem (ou primeira classe)
> Isso significa que funções podem, por exemplo, serem passadas como parâmetros de métodos, bem como retornadas como resultado de métodos

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

### Inferência de tipos
> Não é necessário a declaração do tipo da variável


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
- `list.Sort((p1, p2) `
	- Compilador infere o tipo da variável 

### Expressividade / "como" vs. "o quê"

```csharp
int sum = 0;
foreach (int x in list) 
	{
	sum += x;
	}

```

 VS

```csharp
int sum = list.Aggregate(0, (x, y) => x + y);
```

### O que são expressões lambda ? 
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

### Conclusões 

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
		- Posso passar uma função como parâmetro de outra função
			- Esse parâmetro sera do tipo delegate 

## Delegates pré-definidos

- **Action**
- **Func**
- **Predicate**

### Implentação

#### Classe Calculadora
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

- `Max`
	- Retorna maior
- `Sum`
	- Retorna soma
- `square`
	- Retorna numero ao quadrado

#### Main
```csharp
using System;
using Course.Services;

namespace Course
{
    delegate double BinaryNumericOperation(double n1, double n2); // Declara delegate
    class Program
    {
        static void Main(string[] args)
        {
	        
            double a = 10;
            double b = 12;
            BinaryNumericOperation op = CalculationService.Sum;
            // BinaryNumericOperation op = new BinaryNumericOperation(CalculationService.Sum); 
            // double result = op(a, b);
            double result = op.Invoke(a, b);
            Console.WriteLine(result);
        }
    }
}
```

- `delegate double BinaryNumericOperation(double n1, double n2);`
	- Referência para função que recebe dois doubles
	- TypeSafety 
		- A função fica restrita a receber dois doubles e retornar um double
			- A função square por exemplo é incompatível, pois só tem um argumento
- **Sintaxes**
	- Estanciando
		- `BinaryNumericOperation op = new BinaryNumericOperation(CalculationService.Sum);`
			- Verbosa 
		- `BinaryNumericOperation op = CalculationService.Sum;`
			- Simples
	- Chamando função
		- `double result = op(a, b);`
			- Simples
		- `double result = op.Invoke(a, b);`
			- Verbosa
## Multicast delegates

- Delegates que guardam a referência para mais de um método
- Para adicionar uma referência, pode-se usar o operador +=
- A chamada Invoke (ou sintaxe reduzida) executa todos os métodos na ordem em que foram adicionados
	- O que faz seu uso fazer sentido para métodos void

### Implementação
> Adaptando implementação anterior para multicast

- **Commit da implementação**
	- https://github.com/FredPitol/CSharp-DotNet-Learning/tree/d117025c786b0bc131127de5485f9abcceb1e075/Lambda-Delegate-LINQ


#### Classe Calculadora
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


#### Main 
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
            
	        //double result = op.Invoke(a, b);
            op += CalculationService.ShowMax;
            op(a, b);
        }
    }
}
```

- `delegate void BinaryNumericOperation(double n1, double n2);`
	- Transformamos a função em void
- `BinaryNumericOperation op = CalculationService.ShowSum;`
	- Guarda referência para duas funções 
- `double result = op.Invoke(a, b);`
## Delegate Predicate (exemplo com RemoveAll)

### Predicate (System)
> Representa um método que recebe um objeto do tipo T e retorna um valor booleano

https://msdn.microsoft.com/en-us/library/bfcke1bz%28v=vs.110%29.aspx

#### Exemplo

```csharp
public delegate bool Predicate<in T>(T obj)
```
- 

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
- **Commit da implementação**
	- https://github.com/FredPitol/CSharp-DotNet-Learning/tree/d117025c786b0bc131127de5485f9abcceb1e075/Lambda-Delegate-LINQ
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

# Próximo tema

[Introdução ao LINQ](Introdução%20ao%20LINQ.md)
