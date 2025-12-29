# Data Structures Level 2 in C#

## Boxing and Unboxing in C#

### 1. Background: Value Types vs Reference Types (Important Context)

Before understanding boxing and unboxing, you **must** understand this distinction:

#### Value Types

* Stored **directly** in memory (usually stack).
* Hold the **actual data**.
* Examples:

  * `int`, `double`, `float`, `bool`, `char`
  * `struct`
  * `enum`

#### Reference Types

* Store a **reference (address)** to data in the heap.
* The actual data lives in the **heap**.
* Examples:

  * `object`
  * `string`
  * `class`
  * `interface`
  * `array`

📌 **Key rule**:
All types in C# ultimately derive from `System.Object`, **but value types are NOT objects by default**.

---

### 2. What is Boxing?

#### Definition

**Boxing** is the process of:

> Converting a **value type** into a **reference type** by wrapping it inside an object.

* The value is:

  * Copied
  * Wrapped inside an object
  * Stored in the **heap**

#### What Actually Happens in Memory?

1. Value type exists (usually on the stack).
2. CLR creates a new object on the heap.
3. The value is **copied** into that object.
4. A reference to that object is returned.

📌 This means:

* Boxing creates **new memory allocation**
* Boxing involves **copying data**

---

### 3. Why Boxing Exists (Why Do We Need It?)

#### 1️⃣ Compatibility with `object`

* Many APIs work with `object`
* Example:

  * Collections (old ones like `ArrayList`)
  * Logging methods
  * Reflection
  * General-purpose methods

```csharp
void Print(object value)
{
    Console.WriteLine(value);
}
```

You can now pass **any value type** because of boxing.

---

#### 2️⃣ Polymorphism & Interfaces

Value types can implement interfaces.

```csharp
int x = 10;
IComparable c = x; // Boxing
```

The value must be boxed to be treated as an interface.

---

#### 3️⃣ Legacy Collections

Before generics, collections stored `object`.

```csharp
ArrayList list = new ArrayList();
list.Add(10);   // Boxing
list.Add(20);   // Boxing
```

---

### 4. Boxing in C# – Example

#### Simple Boxing Example

```csharp
using System;

class Program
{
    static void Main()
    {
        int valType = 10;
        object objType = valType; // Boxing

        Console.WriteLine("Value Type: " + valType);
        Console.WriteLine("Object Type: " + objType);
    }
}
```

#### Output

```
Value Type: 10
Object Type: 10
```

#### Explanation

* `valType` → stored as an `int`
* `objType` → reference to an object in the heap
* Same value, **different memory locations**

---

### 5. Performance Impact of Boxing ⚠️ (Very Important)

#### Boxing Is Expensive Because:

* Allocates memory on the heap
* Requires garbage collection later
* Involves copying data

---

### 6. What is Unboxing?

#### Definition

**Unboxing** is the reverse of boxing:

> Extracting the **value type** from a boxed object.

#### What Happens Internally?

1. CLR checks the object’s actual type.
2. Value is copied from heap back to stack.
3. Reference is removed.

📌 Unboxing requires:

* Explicit cast
* **Exact type match**

---

### 7. Unboxing in C# – Correct Example

```csharp
using System;

class Program
{
    static void Main()
    {
        int valType = 10;
        object objType = valType; // Boxing

        int unboxedValType = (int)objType; // Unboxing

        Console.WriteLine("Unboxed Value: " + unboxedValType);
    }
}
```

#### Output

```
Unboxed Value: 10
```

---

### 8. Invalid Unboxing (Common Mistake ❌)

```csharp
object obj = 10;
long x = (long)obj; // ❌ Runtime error
```

#### Why This Fails?

* The object contains an **int**
* You are trying to unbox it as a **long**
* Even though conversion is possible, **unboxing requires exact type**

#### Exception Thrown

```
InvalidCastException
```

---

### 9. Safe Unboxing Techniques ✅

#### 1️⃣ Using `is`

```csharp
if (obj is int value)
{
    Console.WriteLine(value);
}
```

---

#### 2️⃣ Using `as` (Works only with reference types)

❌ Not usable for value types directly

```csharp
object obj = 10;
int? value = obj as int?; // Nullable workaround
```

---

### 10. Boxing & Unboxing with Collections

#### Old Way (Bad – Causes Boxing)

```csharp
ArrayList list = new ArrayList();
list.Add(1);
list.Add(2);

int x = (int)list[0]; // Unboxing
```

#### Modern Way (Best Practice ✅)

```csharp
List<int> list = new List<int>();
list.Add(1);
list.Add(2);
```

✔ No boxing
✔ Better performance
✔ Type safety

---

### 11. Boxing with Structs

```csharp
struct Point
{
    public int X;
    public int Y;
}

Point p = new Point { X = 1, Y = 2 };
object obj = p; // Boxing
```

* Entire struct is copied
* Larger structs = more expensive boxing

---

### 12. Key Rules to Remember (Exam & Interview Gold ⭐)

* ✔ Boxing converts **value → reference**
* ✔ Unboxing converts **reference → value**
* ❌ Unboxing requires **exact type**
* ❌ Boxing/unboxing affects performance
* ✔ Prefer **generics** to avoid boxing
* ✔ Avoid boxing inside loops

---

### 13. Summary

* Boxing allows value types to behave like objects
* Unboxing retrieves the original value type
* Both involve **copying data**
* Both can impact performance
* Modern C# minimizes boxing using **generics**

---

## Introduction to Collections (Data Structures) in C#

### 1. What Are Collections?

#### Definition

**Collections** are data structures used to:

* Store
* Organize
* Manage
  groups of related data in memory.

In C#, collections provide **advanced alternatives to arrays** with more power, flexibility, and built-in functionality.

---

#### Key Characteristics of Collections

* Can store **multiple elements**
* Support **dynamic sizing** (grow/shrink at runtime)
* Provide **built-in methods** for:

  * Searching
  * Sorting
  * Adding
  * Removing
  * Iterating

📌 Unlike arrays, collections do **not** require a fixed size at creation.

---

### 2. Collections vs Arrays

| Feature             | Array     | Collection |
| ------------------- | --------- | ---------- |
| Size                | Fixed     | Dynamic    |
| Flexibility         | Limited   | High       |
| Built-in operations | Minimal   | Rich       |
| Performance tuning  | Manual    | Built-in   |
| Real-world usage    | Low-level | High-level |

📌 **Rule of thumb**:
Arrays are low-level and rigid.
Collections are high-level and flexible.

---

### 3. Why Use Collections?

#### 1️⃣ Managing Large Amounts of Data

Collections are designed to efficiently store and manage **large or changing datasets**.

---

#### 2️⃣ Built-in Functionality

Collections provide ready-to-use operations such as:

* Add
* Remove
* Insert
* Find
* Sort
* Filter

This:

* Reduces boilerplate code
* Improves readability
* Reduces bugs

---

#### 3️⃣ Better Abstraction

Collections hide complex internal logic (memory management, resizing, indexing), allowing you to:

* Focus on **problem-solving**
* Not low-level memory details

---

#### 4️⃣ Safer and More Expressive Code

Especially with **generic collections**, C# ensures:

* Type safety
* Compile-time checks
* Better performance

---

### 4. Common Operations on Collections

Almost all collections support some or all of the following operations:

* **Add** elements
* **Remove** elements
* **Update / Modify** elements
* **Search** for elements
* **Access** elements
* **Iterate** over elements
* **Sort** or **order** data

📌 The performance of these operations depends on the **type of collection** used.

---

### 5. Namespaces That Contain Collections

C# collections are mainly found in two namespaces:

#### 1️⃣ `System.Collections`

* Contains **non-generic collections**
* Stores data as `object`
* Older and mostly legacy

---

#### 2️⃣ `System.Collections.Generic`

* Contains **generic collections**
* Strongly typed
* Preferred in modern C#

---

### 6. High-Level Classification of Collections

Collections in C# can be broadly divided into:

#### 🔹 Generic Collections

* Type-safe
* Better performance
* No boxing/unboxing
* Preferred choice

#### 🔹 Non-Generic Collections

* Store data as `object`
* Require casting
* Cause boxing/unboxing
* Mostly legacy support

---

### 7. Generic Collections (System.Collections.Generic)

#### What Are Generic Collections?

Generic collections use **type parameters** (`<T>`) to specify:

* What type of elements the collection can store

Example:

```csharp
List<int>
Dictionary<string, int>
```

---

#### Advantages of Generic Collections

###### ✔ Type Safety

* Prevents storing wrong data types
* Errors caught at **compile time**

---

###### ✔ Better Performance

* No boxing/unboxing for value types
* Direct storage of values

---

###### ✔ Reduced Memory Overhead

* Value types are not wrapped inside `object`

---

###### ✔ Code Reusability

* Same collection logic works for multiple types

---

#### Key Generic Collections (Overview Only)

* `List<T>` – Dynamic indexed list
* `Dictionary<TKey, TValue>` – Key-value storage
* `Queue<T>` – FIFO structure
* `Stack<T>` – LIFO structure
* `HashSet<T>` – Unique elements
* `LinkedList<T>` – Doubly linked list
* `SortedSet<T>` – Automatically sorted set
* `SortedDictionary<TKey, TValue>` – Sorted keys
* `SortedList<TKey, TValue>` – Sorted key-value with index access
* `ConcurrentDictionary<TKey, TValue>` – Thread-safe dictionary
* `BlockingCollection<T>` – Thread-safe with blocking
* `ConcurrentQueue<T>` – Thread-safe FIFO
* `ConcurrentStack<T>` – Thread-safe LIFO
* `ConcurrentBag<T>` – Unordered thread-safe collection

---

### 8. Non-Generic Collections (System.Collections)

#### What Are Non-Generic Collections?

* Store elements as `object`
* Can hold **any data type**
* Introduced before generics existed

---

#### Disadvantages Compared to Generic Collections

##### ❌ Type Unsafe

* Allows mixing unrelated data types
* Errors appear at runtime

---

##### ❌ Performance Overhead

* Value types require boxing/unboxing

---

##### ❌ Higher Memory Usage

* Value types are wrapped as objects

---

#### Key Non-Generic Collections (Overview)

* `ArrayList`
* `Hashtable`
* `Queue`
* `Stack`
* `SortedList`
* `BitArray`
* `HybridDictionary`
* `ListDictionary`
* `NameValueCollection`
* `OrderedDictionary`
* `StringCollection`
* `StringDictionary`

📌 These are mainly used in:

* Legacy code
* Backward compatibility
* Special framework scenarios

---

### 9. When Should You Use Which?

#### Use Generic Collections When:

* You know the data type
* Performance matters
* You want clean, safe code
  ➡ **99% of modern C# applications**

---

#### Use Non-Generic Collections When:

* Working with old APIs
* Dealing with mixed data intentionally
* Maintaining legacy systems

---

### 10. Relation to Boxing & Unboxing (Important Link)

* **Generic collections**:

  * ❌ No boxing/unboxing
  * ✔ Better performance

* **Non-generic collections**:

  * ✔ Store everything as `object`
  * ❌ Cause boxing/unboxing

📌 This directly connects to the **previous topic**.

---

### 11. Big Picture: Collections as Data Structures

Collections are **concrete implementations** of data structures such as:

* Lists
* Sets
* Queues
* Stacks
* Dictionaries
* Trees (sorted collections)

Understanding:

* **Which collection to use**
* **Why it exists**
* **How it behaves**

---

### 12. Summary

* Collections store and manage groups of data efficiently
* They are more powerful than arrays
* C# provides many collection types for different use cases
* Collections are divided into:

  * Generic (preferred)
  * Non-generic (legacy)
* Choosing the right collection affects:

  * Performance
  * Memory
  * Code quality

---

## Lists in C# (`List<T>`)

### 1. What Is `List<T>`?

#### Definition

`List<T>` is a **generic collection class** provided by the .NET Framework (in `System.Collections.Generic`) used to store a **sequence of elements of the same type**.

```csharp
List<int>
List<string>
List<Person>
```

Here, **`T`** is a *type parameter* that represents the type of elements stored in the list.

---

#### Key Idea

> A `List<T>` is essentially a **dynamic array** with many built-in features.

Unlike arrays:

* It **resizes automatically**
* It provides **rich APIs** for searching, sorting, filtering, and modifying data

---

### 2. Core Characteristics of `List<T>`

#### 1️⃣ Generic Collection

* Strongly typed
* Prevents runtime type errors
* Eliminates boxing/unboxing

Example:

```csharp
List<int> numbers;      // only int allowed
List<string> names;    // only string allowed
```

Trying to add a wrong type causes a **compile-time error**, not a runtime error.

---

#### 2️⃣ Dynamic Sizing

* No fixed size at creation
* Grows and shrinks automatically
* Internally uses an array that resizes when needed

📌 Resizing is handled internally, but **frequent resizing has a cost**, which leads us to:

---

#### 3️⃣ Capacity vs Count (Very Important)

| Property   | Meaning                                  |
| ---------- | ---------------------------------------- |
| `Count`    | Number of elements currently in the list |
| `Capacity` | Size of the internal array               |

* `Count ≤ Capacity`
* When `Count` exceeds `Capacity`, the list **allocates a larger array** and copies elements

📌 This is why knowing expected size can improve performance.

---

#### 4️⃣ Zero-Based Index

* First element index = `0`
* Last element index = `Count - 1`

Just like arrays:

```csharp
numbers[0]
numbers[1]
```

---

#### 5️⃣ Strongly Typed

* `List<string>` cannot accept `int`
* `List<Person>` cannot accept `string`

This ensures **data integrity** and **cleaner code**.

---

### 3. Thread Safety

* `List<T>` is **NOT thread-safe**
* Multiple threads modifying the same list can cause:

  * Data corruption
  * Exceptions

#### Alternatives for Multi-threading:

* `ConcurrentBag<T>`
* `ConcurrentQueue<T>`
* `ConcurrentStack<T>`
* `ConcurrentDictionary<TKey, TValue>`

📌 For single-threaded logic (most business logic), `List<T>` is perfectly fine.

---

### 4. Creating and Initializing Lists

#### Empty List

```csharp
List<int> numbers = new List<int>();
```

#### Initialized List

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
```

---

### 5. Adding Elements

#### Add (End of List)

```csharp
numbers.Add(10);
```

#### Insert (Specific Index)

```csharp
numbers.Insert(0, 99); // shifts elements to the right
```

#### Insert Multiple Elements

```csharp
numbers.InsertRange(3, new List<int> { 100, 200 });
```

📌 Inserting at the beginning or middle is **more expensive** than adding at the end because elements must be shifted.

---

### 6. Accessing & Modifying Elements

#### Access by Index

```csharp
int value = numbers[2];
```

#### Modify by Index

```csharp
numbers[1] = 500;
```

📌 Direct index access is **O(1)** (very fast).

---

### 7. Removing Elements

#### Remove by Value

```csharp
numbers.Remove(5); // removes first occurrence only
```

#### Remove by Index

```csharp
numbers.RemoveAt(0);
```

#### Remove by Condition

```csharp
numbers.RemoveAll(n => n % 2 == 0);
```

#### Clear Entire List

```csharp
numbers.Clear();
```

📌 Removing elements shifts remaining items → **O(n)** cost.

---

### 8. Looping Through a List

#### `for` Loop

* Use when index is needed

```csharp
for (int i = 0; i < numbers.Count; i++)
{
    Console.WriteLine(numbers[i]);
}
```

---

#### `foreach` Loop

* Cleaner and safer
* Cannot modify the list structure

```csharp
foreach (int n in numbers)
{
    Console.WriteLine(n);
}
```

---

#### `List.ForEach`

* Executes an action on each element
* Functional style

```csharp
numbers.ForEach(n => Console.WriteLine(n));
```

📌 Avoid modifying the list inside `ForEach`.

---

### 9. LINQ with `List<T>`

LINQ works on any collection that implements `IEnumerable<T>` — `List<T>` does.

---

#### Aggregation Operations

```csharp
numbers.Sum();
numbers.Average();
numbers.Min();
numbers.Max();
numbers.Count();
```

📌 These **do not modify** the list — they return values.

---

#### Filtering (LINQ `Where`)

```csharp
numbers.Where(n => n > 5);
numbers.Where(n => n % 2 == 0);
numbers.Where((n, index) => index % 2 == 1);
```

📌 LINQ uses **deferred execution** — evaluation happens when enumerated.

---

### 10. Sorting Lists

#### Default Sorting (Ascending)

```csharp
numbers.Sort();
```

#### Descending Order

```csharp
numbers.Sort();
numbers.Reverse();
```

---

#### LINQ Sorting

```csharp
numbers.OrderBy(n => n);
numbers.OrderByDescending(n => n);
```

📌 LINQ sorting **does not change** the original list.

---

#### Custom Sorting

```csharp
numbers.Sort((a, b) => Math.Abs(a).CompareTo(Math.Abs(b)));
```

---

### 11. Searching & Querying Methods

#### `Contains`

* Checks for exact value

```csharp
numbers.Contains(9);
```

---

#### `Exists`

* List-specific
* Uses predicate

```csharp
numbers.Exists(n => n < 0);
```

---

#### `Find`

* Returns **first matching element**
* Returns default value if not found

```csharp
numbers.Find(n => n < 0);
```

---

#### `FindAll`

* Returns **new list**

```csharp
numbers.FindAll(n => n < 0);
```

---

#### `Any` (LINQ)

* Works on all `IEnumerable<T>`

```csharp
numbers.Any(n => n > 100);
```

---

### 12. Exists vs Any (Clear Comparison)

| Feature     | Exists                   | Any                 |
| ----------- | ------------------------ | ------------------- |
| Belongs to  | `List<T>`                | LINQ                |
| Works on    | Only List                | Any IEnumerable     |
| Performance | Slightly faster for List | Small LINQ overhead |
| Flexibility | Limited                  | Very flexible       |

📌 Use:

* `Exists` → when working **only with List**
* `Any` → when writing **LINQ-based logic**

---

### 13. Lists with Custom Objects

* Lists store **references** to objects
* Modifying an object affects it everywhere

```csharp
Person p = people.Find(x => x.Name == "Alice");
p.Age = 31; // updates inside the list
```

📌 This is **reference behavior**, not list behavior.

---

### 14. Converting Between List and Array

#### List → Array

```csharp
int[] arr = numbers.ToArray();
```

---

#### Array → List

```csharp
List<int> list = new List<int>(array);
```

📌 Conversion creates a **new collection**, not a shared reference.

---

### 15. Performance Summary (Important for Data Structures)

| Operation       | Complexity     |
| --------------- | -------------- |
| Index access    | O(1)           |
| Add (end)       | O(1) amortized |
| Insert / Remove | O(n)           |
| Search          | O(n)           |
| Sort            | O(n log n)     |

---

### 16. When Should You Use `List<T>`?

Use `List<T>` when:

* Order matters
* You need indexing
* Size changes dynamically
* You need rich manipulation APIs

Avoid `List<T>` when:

* You need constant-time lookup by key → use `Dictionary`
* You need uniqueness → use `HashSet`
* You need strict FIFO/LIFO → use `Queue` / `Stack`

---

### 17. Final Summary

* `List<T>` is the **most commonly used collection** in C#
* It is dynamic, type-safe, and feature-rich
* Supports:

  * Indexing
  * Searching
  * Sorting
  * LINQ

---
