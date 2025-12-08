# **C# Advanced Topics**

## 1. **Events**

* Used for **notification-based communication**.
* Built on **delegates**.
* Follows **Publisher–Subscriber pattern**.
* Uses `event` keyword.
* Custom events often use **EventArgs**.
* Used in:

  * UI updates
  * Temperature monitoring
  * Order systems
* Key Concept: **Loose coupling**

---

## 2. **Delegates**

* A **type-safe method pointer**.
* Can reference:

  * One method (single-cast)
  * Multiple methods (multicast)
* Used in:

  * Events
  * Callbacks
  * LINQ
* Built-in delegates:

  * `Func<T>` → returns value
  * `Action<T>` → no return value
  * `Predicate<T>` → returns bool

---

## 3. **Lambda Expressions**

* Short form of anonymous functions.
* Syntax:

  ```csharp
  x => x * 2
  ```
* Used heavily with:

  * LINQ
  * Delegates
  * Tasks
* Faster to write, readable, but sometimes harder to debug.

---

## 4. **using Statement**

### Uses:

1. Import namespaces
2. Create aliases
3. Use static members
4. **Automatic resource disposal**

```csharp
using (var file = new FileStream(...)) { }
```

* Prevents memory leaks.

---

## 5. **Nullable Data Types**

* Allows value types to be `null`

```csharp
int? x = null;
```

* Useful with:

  * Databases
  * Optional values
* Operators:

  * `??` (null coalescing)

---

## 6. **Serialization & Deserialization**

* Converts object ↔ data format.
* Types:

  * XML
  * JSON
  * Binary
* Used in:

  * APIs
  * File storage
  * Data transfer

---

## 7. **Attributes**

* Add **metadata** to code.
* Affect:

  * Compilation
  * Runtime behavior
* Built-in:

  * `[Obsolete]`
  * `[Serializable]`
  * `[Conditional]`
* Custom attributes used for:

  * Validation
  * Logging
  * Mapping

---

## 8. **Reflection**

* Inspect and execute code **at runtime**.
* Uses `Type` class.
* Can:

  * Discover methods & properties
  * Create objects dynamically
  * Invoke methods
* Used in:

  * ORMs
  * Dependency Injection
* **Disadvantage:** Slow performance

---

## 9. **Special XML Comments**

* Used for documentation.
* Enhances IntelliSense.

```csharp
/// <summary>
```

---

## 10. **Mutable vs Immutable**

* **Immutable:** Cannot change after creation
  Example: `string`
* **Mutable:** Can be modified
  Example: `StringBuilder`
* Immutable = safer
* Mutable = faster in loops

---

## 11. **Generics**

* Write code once for multiple data types.
* Improves:

  * Type safety
  * Performance
* Examples:

  * `List<T>`
  * Generic methods
* Avoids boxing/unboxing.

---

## 12. **App.config**

* XML configuration file.
* Stores:

  * Connection strings
  * App settings
* Separates configuration from code.

---

## 13. **StringBuilder**

* Used for **heavy string modification**.
* Faster than `string` in loops.
* Avoids memory overhead.

---

## 14. **Cryptography**

### Hashing:

* One-way encryption.
* Used for passwords.
* Example algorithms:

  * SHA256

### Symmetric Encryption:

* Same key for encrypt & decrypt.
* Example: AES
* Fast & efficient.

### Asymmetric Encryption:

* Public + Private key.
* Used for secure key exchange.

---

## 15. **Operator Overloading**

* Custom behavior for operators.
* Example:

  * `+`, `-`, `==`, `!=`
* Rules:

  * `==` and `!=` must be overloaded together.
  * Not all operators are allowed.
* Improves code readability.

---

## 16. **Multithreading**

* Multiple threads inside one process.
* Improves CPU usage.
* Risks:

  * Race conditions
  * Deadlocks
* Uses:

  * `Thread` class
* Requires:

  * Synchronization (`lock`)

---

## 17. **Asynchronous Programming**

* Non-blocking execution.
* Uses:

  * `Task`
  * `async / await`
* Efficient for:

  * I/O operations
  * APIs
* Parallel tools:

  * `Parallel.For`
  * `Parallel.ForEach`
  * `Parallel.Invoke`
* Lower memory usage than threading.

---
